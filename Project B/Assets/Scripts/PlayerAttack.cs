using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	[SerializeField] float duration = .2f;
	float durationCounter;
	
	
	void Update()
	{
		if(GetComponent<BoxCollider2D>().enabled)
		{
			durationCounter -= Time.deltaTime;
			if(durationCounter < 0)
			{
				DeactivateAttack();
			}
		}else
		{
			durationCounter = duration;
		}
	}
	
	public void ActivateAttack()
	{
		GetComponent<BoxCollider2D>().enabled = true;
		GetComponent<SpriteRenderer>().enabled = true;
	}
	
	void DeactivateAttack()
	{
		GetComponent<BoxCollider2D>().enabled = false;
		GetComponent<SpriteRenderer>().enabled = false;
	}
}
