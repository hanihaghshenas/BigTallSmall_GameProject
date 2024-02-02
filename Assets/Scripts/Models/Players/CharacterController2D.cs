using Photon.Pun;
﻿using Models;
using Models.Players;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : AbstractPlayer, IPunObservable
{
	private PhotonView m_view;
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	// [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
	// [SerializeField] private Collider2D m_CrouchDisableCollider;				// A collider that will be disabled when crouching

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	//
	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }
	

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
		m_view = GetComponent<PhotonView>();
		AddObservable();
		
	}
	private void AddObservable()
	{
		if (!m_view.ObservedComponents.Contains(this))
		{
			m_view.ObservedComponents.Add(this);
		}
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}

			// if (colliders[i].gameObject.CompareTag(ItemTagsEnum.Box.ToString()))
			// {
				// Debug.Log(colliders[i].gameObject);
				// m_Grounded = true;
				// if (!wasGrounded)
					// OnLandEvent.Invoke();
			// }
		}
	}


	public void Move(float move, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag(TagsEnum.Key.ToString()))
		{
			keys += 1;
			other.gameObject.SetActive(false);
		}
		
		if (other.gameObject.CompareTag(TagsEnum.LockedDoor.ToString()))
		{
			if (keys > 0)
			{
				keys--;
				other.gameObject.SetActive(false);
			}
		}

		if (
			this.gameObject.CompareTag(TagsEnum.Big.ToString()) && 
			other.gameObject.CompareTag(TagsEnum.PrivateDoorBig.ToString()))
		{
			other.gameObject.SetActive(false);
		}
		
		if (
			this.gameObject.CompareTag(TagsEnum.Tall.ToString()) && 
			other.gameObject.CompareTag(TagsEnum.PrivateDoorTall.ToString()))
		{
			other.gameObject.SetActive(false);
		}
		
		if (
			this.gameObject.CompareTag(TagsEnum.Small.ToString()) && 
			other.gameObject.CompareTag(TagsEnum.PrivateDoorSmall.ToString()))
		{
			other.gameObject.SetActive(false);
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			stream.SendNext(transform.localScale);
		}
		else
		{
			transform.localScale = (Vector3) stream.ReceiveNext();
		}
	}
	
	public override void PlayJumpSound()
	{
	}

	public override void PlayTerminationSound()
	{
	}

	public override void Jump()
	{
	}

	public override void Move()
	{
	}
}
