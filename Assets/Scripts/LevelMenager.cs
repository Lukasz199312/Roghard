﻿using UnityEngine;
using System.Collections;

public class LevelMenager : MonoBehaviour {

	// Use this for initialization
	void Start () {

       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel(string name)
    {
        Application.LoadLevel(name);
    }



    public void QuiestGame()
    {
        Application.Quit();
    }
}
