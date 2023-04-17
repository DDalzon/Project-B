using UnityEngine;

public class Movement : MonoBehaviour
{
	public float speed = 5f;
	[SerializeField] float reducedDrag = 0.5f; //value of the reduced linear drag
	[SerializeField] float bufferTime = 0.1f; // time in seconds to buffer the input
	
	float horizontalInput ;
	private Rigidbody2D rb;
	float lastHorizontalInput;
	float timeSinceLastInput;



	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		Move();
	}
	
	void Update()
	{
		horizontalInput  = Input.GetAxisRaw("Horizontal");
	}
	
	void Move()
	{
		// if the player is moving in the opposite direction of the last input, apply reduced drag
        if (horizontalInput == 0f && Mathf.Sign(lastHorizontalInput) != 0f && timeSinceLastInput <= bufferTime)
        {
            rb.drag = reducedDrag;
        }
        else
        {
            rb.drag = 0f;
        }
		
		// create a direction vector with the desired speed and the horizontal input direction
		Vector2 direction = new Vector2(horizontalInput  * speed, rb.velocity.y);

		// apply a force to the player in the specified direction and magnitude
		rb.AddForce(direction - rb.velocity, ForceMode2D.Force);
		
		// store the last horizontal input and update the time since the last input
		lastHorizontalInput = horizontalInput;
		timeSinceLastInput += Time.deltaTime;
		if (horizontalInput != 0f)
		{
			timeSinceLastInput = 0f;
		}
	}
}