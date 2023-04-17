using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] float jumpForce;
	float moveInput;
	
	Rigidbody2D rb;
	
	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update() 
	{
		moveInput = Input.GetAxisRaw("Horizontal");
	}
	
	void FixedUpdate() 
	{
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
	}
	
}
