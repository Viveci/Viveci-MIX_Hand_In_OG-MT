using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public int level;
    public int points;
    public float timeLeft;

    public Text Display_Points;
    public Text Display_Level;
    public Text Display_Timer;

    public bool game;

    void Start () {
        game = true;
        points = 0;
        level = 1;
        timeLeft = 60f;
        Display_Level.text = ""+level;
	}
	
	void Update () {
        timeLeft -= Time.deltaTime;
        Display_Timer.text = " "+ (int)timeLeft;
        if (timeLeft <= 0) {
            game = false;
            Display_Timer.text = ""+0;
        }
    }

    public void inc(int n) {
        if (game)
        {
            points += n;
            Display_Points.text = "" + points;
            Debug.Log(Time.time + "; Game Controler: Increment called, end result is: " + points);
        }
    }
}
