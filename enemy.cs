using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
	[SerializeField] GameObject deathVX;
	[SerializeField] Transform garbage;
	scorecardcode scorecard;
	[SerializeField] int scoreperbullet;
	[SerializeField] int hits = 10;
	void Start()
	{
		nontriggerboxcollider();
		scorecard = FindObjectOfType<scorecardcode>();
	}
	void nontriggerboxcollider()
	{
		BoxCollider boxcollision = gameObject.AddComponent<BoxCollider>();
		boxcollision.isTrigger = false;
	}

	void OnParticleCollision(GameObject other)
	{
		hits = hits - 1;
		if (hits<=1)
		{
			scorecard.scorecall(scoreperbullet);
			GameObject VXinstantiation = Instantiate(deathVX, transform.position, Quaternion.identity);
			VXinstantiation.transform.parent = garbage;
			Destroy(gameObject);
		}

		
	}
}