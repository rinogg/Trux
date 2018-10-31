using UnityEngine;
using UnityEngine.UI;

public class SpeedText : MonoBehaviour {
    public Text speedofcar;
	
	
	// Update is called once per frame
	void Update () {
        speedofcar.text = "Speed: " + (ScrollingStreet.speed).ToString("F0") + "mph";
    }
}
