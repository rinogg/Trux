using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float width = 16f;
    public float height = 9f;

    void Awake()
    {
        Camera.main.aspect = width / height;
    }
   
}
