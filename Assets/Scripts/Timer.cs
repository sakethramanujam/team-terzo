﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text Score_text,GameOverText;
    public float score;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

        score += Time.deltaTime;
        Score_text.text = "Score: "+(int)score;
            }
}
