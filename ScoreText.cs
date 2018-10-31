using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    public Text scoreofcar;	
	// Update is called once per frame
	void Update () {

 
            scoreofcar.text = "Score: " + (TruckMovement.score).ToString("F0");

    }   
}
