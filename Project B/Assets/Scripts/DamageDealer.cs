using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
	[SerializeField] int damage;
	
	public int Damage()
	{
		return damage;
	}
	
	private void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log("Contact made:" + other.name);
		if(other.GetComponent<LifeManager>())
		{
			other.GetComponent<LifeManager>().CalculateDamage(this);
		}
	}
}
