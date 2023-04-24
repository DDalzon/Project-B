using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
	[SerializeField] int life;
	
	public void CalculateDamage(DamageDealer damageDealer)
	{
		life -= damageDealer.Damage();
		if(life <= 0)
		{
			Destroy(gameObject);
		}
	}
	
	
}
