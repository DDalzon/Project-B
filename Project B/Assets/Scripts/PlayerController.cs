using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("Values")]
	[SerializeField] float speed;
	[SerializeField] float airSpeed;
	[SerializeField] float jumpForce;
	float moveInput;

	[SerializeField] float coyoteTime = 0.065f;
	float coyoteTimeCounter;

	[SerializeField] float jumpBufferTime = 0.15f;
	float jumpBufferTimeCounter;

	bool facingRight = true;
	[SerializeField] Collider2D feetCollider;
	[SerializeField] LayerMask groundLayer;
	[SerializeField] bool isLocked;
	
	[Header("Prefabs")]
	[SerializeField] GameObject atkOnePrefab;
	[SerializeField] GameObject currentHitbox;
	
	[Header("HitBox Transforms")]
	[SerializeField] Transform atkOneTransform;


	Rigidbody2D rb;
	Animator animator;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		moveInput = Input.GetAxisRaw("Horizontal");
		animator.SetBool("attacked", Input.GetButtonDown("Fire1"));
		animator.SetBool("grounded", IsGrounded());

		Jump();
		SetCoyoteTime();
		JumpBuffer();
		AttackNormal();
	}

	void FixedUpdate()
	{
		if (!isLocked)
		{
			MoveAndFlip();
		}
	}

	void JumpBuffer()
	{
		if (Input.GetButtonDown("Jump"))
		{
			jumpBufferTimeCounter = jumpBufferTime;
		}
		else
		{
			jumpBufferTimeCounter -= Time.deltaTime;
		}
	}

	void MoveAndFlip()
	{
		if (IsGrounded())
		{
			rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
		}
		else 
		{ 
			MoveInAir(); 
		}

		if (!facingRight && moveInput > 0)
		{
			Flip();
		}
		else if (facingRight && moveInput < 0)
		{
			Flip();
		}
	}

	void MoveInAir()
	{
		if (facingRight && rb.velocity.x < 5.2f)
		{
			rb.AddForce(new Vector2(moveInput * airSpeed, 0f));
		}
		else if (!facingRight && rb.velocity.x > -5.2f)
		{
			rb.AddForce(new Vector2(moveInput * airSpeed, 0f));
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
		if (!isLocked)
		{
			if (coyoteTimeCounter > 0f && jumpBufferTimeCounter > 0f)
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
				jumpBufferTimeCounter = 0f;
			}

			if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
			{
				rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

				coyoteTimeCounter = 0f; // isso aqui é pro cara n pular 2x spamando o botao de jump
			}
		}
	}

	void SetCoyoteTime()
	{
		if (IsGrounded())
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
		if (Input.GetButtonDown("Fire1") && IsGrounded())
		{
			isLocked = true;
			rb.velocity = Vector2.zero;
		}
	}

	public void Unlock()
	{
		isLocked = false;
	}
	
	public void ActivateHitBoxOne()
	{
		float posYDif = -0.042f;
		
		GameObject atk = Instantiate(atkOnePrefab);
		if(facingRight)
		{
			atk.transform.position = new Vector2(this.transform.position.x + 0.622f, 
				this.transform.position.y + posYDif);
		}else
		{
			atk.transform.position = new Vector2(this.transform.position.x - 0.87f, 
				this.transform.position.y + posYDif);
		}

		
		if(currentHitbox != null)
		{
			Destroy(currentHitbox.gameObject);
		}
		
		currentHitbox = atk;
	}
	
	public void DestroyCurrentHitBox()
	{
		Destroy(currentHitbox.gameObject);
	}
	/* 
		O que fazer no código:
		
	
		Bugs conhecidos:
		- o pulo bufferado sempre vai com força total se o player soltar o botao de pulo rapido;
	*/
}
