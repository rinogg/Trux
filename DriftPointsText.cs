using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriftPointsText : MonoBehaviour {

    public Text driftpoints;
    // Update is called once per frame
    void Update()
    {
   
            driftpoints.text = "Multiplier: x" + (PlayerMovement.driftPoints).ToString("F0");
    
    }
}

