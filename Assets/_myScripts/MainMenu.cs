﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	
	void Start () {
		
	}
	

	void Update () {
		
	}

    public void ToGame() 
    {
        SceneManager.LoadScene("NewCity");
    }
}
