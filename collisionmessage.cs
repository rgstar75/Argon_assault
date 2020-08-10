using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionmessage : MonoBehaviour 
{
	[Tooltip("seconds")][SerializeField] int levelloadspan=1;
	[Tooltip("FX prefab on player")] [SerializeField] GameObject deathVX;
	void OnTriggerEnter(Collider other)
	{
		startdeathsequence();
		deathVX.SetActive(true);
	}

	private void startdeathsequence()
	{
		gameObject.SendMessage("DEATHFUNCTION");
		Invoke("Reloadscene", levelloadspan);
	}
	private void Reloadscene()
	{
		SceneManager.LoadScene(1);
	}
}
