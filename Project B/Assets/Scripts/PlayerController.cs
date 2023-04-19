using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("Values")]
	[SerializeField] float speed;
	[SerializeField] float jumpForce;
	float moveInput;
	
	[SerializeField] float coyoteTime = 0.065f;
	float coyoteTimeCounter;
	
	[SerializeField] float jumpBufferTime = 0.15f;
	float jumpBufferTimeCounter;
	
	bool facingRight = true;
	[SerializeField] Collider2D feetCollider;
	[SerializeField] LayerMask groundLayer;
	
	[Header("Attacks")]
	[SerializeField] PlayerAttack[] attacks;
	
	Rigidbody2D rb;
	
	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update() 
	{
		moveInput = Input.GetAxisRaw("Horizontal");
		
		Jump();
		SetCoyoteTime();
		JumpBuffer();
		AttackNormal();
	}
	
	void FixedUpdate() 
	{
		MoveAndFlip();
	}
	
	void JumpBuffer()
	{
		if(Input.GetButtonDown("Jump"))
		{
			jumpBufferTimeCounter = jumpBufferTime;
		}else
		{
			jumpBufferTimeCounter -= Time.deltaTime;
		}
	}
	
	void MoveAndFlip()
	{
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
		
		if(!facingRight && moveInput > 0)
		{
			Flip();
		} else if (facingRight && moveInput < 0)
		{
			Flip();
		}
	}
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector2 scaler = transform.localScale;
		scaler.x *= -1;
		transform.localScale = scaler;
	}
	
	void Jump()
	{
		if(coyoteTimeCounter > 0f && jumpBufferTimeCounter > 0f)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			jumpBufferTimeCounter = 0f;
		}
		
		if(Input.GetButtonUp("Jump") && rb.velocity.y > 0)
		{
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*0.5f);
			
			coyoteTimeCounter = 0f; // isso aqui é pro cara n pular 2x spamando o botao de jump
		}
	}
	
	void SetCoyoteTime()
	{
		if(IsGrounded())
		{
			coyoteTimeCounter = coyoteTime;
		}
		else
		{
			coyoteTimeCounter -= Time.deltaTime;
		}
	}
	
	bool IsGrounded()
	{
		return feetCollider.IsTouchingLayers(groundLayer);
	}
	
	void AttackNormal()
	{
		if(Input.GetButtonDown("Fire1") && !attacks[0].GetComponent<BoxCollider2D>().enabled)
		{
			attacks[0].ActivateAttack();
		}
	}
	/* 
		O que fazer no código:
		-Fazer com q o movimento no ar seja por AddForce;
	
		Bugs conhecidos:
		- o pulo bufferado sempre vai com força total se o player soltar o botao de pulo rapido;
	*/
}
