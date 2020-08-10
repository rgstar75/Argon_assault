using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class loadingnextlevel : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Invoke("nextscene", 2f);
	}
	void nextscene()
	{
		SceneManager.LoadScene(1);
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
