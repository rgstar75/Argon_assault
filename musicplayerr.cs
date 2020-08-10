using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicplayerr : MonoBehaviour
{
    
    
    
    private void Awake()
    {
        int numberofmusicplayers = FindObjectsOfType<musicplayerr>().Length;
        if (numberofmusicplayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
