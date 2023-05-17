using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour
{
	[Header("Prefabs")]
	[SerializeField] GameObject atkOnePrefab;
	[SerializeField] GameObject atkTwoPrefab;
	[SerializeField] GameObject atkThreePrefab;
	[SerializeField] GameObject atkFourPrefab;
	GameObject currentHitbox;
	
	PlayerController pC;
	
	void Start() 
	{
		pC = GetComponent<PlayerController>();
	}
	
   public void ActivateHitBoxOne()
	{
		GameObject atk = Instantiate(atkOnePrefab);
		if(pC.IsFacingRight())
		{
			atk.transform.position = new Vector2(this.transform.position.x + 1.1f, 
				this.transform.position.y);
		}else
		{
			atk.transform.position = new Vector2(this.transform.position.x - 1.16f, 
				this.transform.position.y);
		}

		
		if(currentHitbox != null)
		{
			DestroyCurrentHitBox();
		}
		
		currentHitbox = atk;
	}
	
	public void ActivateHitBoxTwo()
	{
		GameObject atk = Instantiate(atkTwoPrefab);
		if(pC.IsFacingRight())
		{
			atk.transform.position = new Vector2(this.transform.position.x + 1.19f, 
				this.transform.position.y);
		}else
		{
			atk.transform.position = new Vector2(this.transform.position.x - 1.18f, 
				this.transform.position.y);
		}

		
		if(currentHitbox != null)
		{
			DestroyCurrentHitBox();
		}
		
		currentHitbox = atk;
	}
	
	public void ActivateHitBoxThree()
	{
		GameObject atk = Instantiate(atkThreePrefab);
		if(pC.IsFacingRight())
		{
			atk.transform.position = new Vector2(this.transform.position.x + 1.1f, 
				this.transform.position.y);
		}else
		{
			atk.transform.position = new Vector2(this.transform.position.x - 1.16f, 
				this.transform.position.y);
		}

		
		if(currentHitbox != null)
		{
			DestroyCurrentHitBox();
		}
		
		currentHitbox = atk;
	}
	
	public void ActivateHitBoxFour()
	{
		GameObject atk = Instantiate(atkFourPrefab);
		if(pC.IsFacingRight())
		{
			atk.transform.position = new Vector2(this.transform.position.x + 1.1f, 
				this.transform.position.y);
		}else
		{
			atk.transform.position = new Vector2(this.transform.position.x - 1.16f, 
				this.transform.position.y);
		}

		
		if(currentHitbox != null)
		{
			DestroyCurrentHitBox();
		}
		
		currentHitbox = atk;
	}
	
	public void DestroyCurrentHitBox()
	{
		Destroy(currentHitbox.gameObject);
	}
}
