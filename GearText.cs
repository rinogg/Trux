using UnityEngine;
using UnityEngine.UI;

public class GearText : MonoBehaviour {
    public Text gearofcar;

	
	// Update is called once per frame
	void Update () {
        gearofcar.text = "Gear: " + (ScrollingStreet.currentgear).ToString();
	}
}
