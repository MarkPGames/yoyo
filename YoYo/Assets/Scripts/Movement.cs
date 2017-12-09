using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    bool expand;
    bool shrink;
    bool pressed;
    Vector3 shrinkTargetPos;
    Vector3 expandTargetPos;
    // Use this for initialization
    void Start ()
    {
        expand = false;
        shrink = true;
        pressed = false;

    }
	
	// Update is called once per frame
	void Update ()
    {


    }
}
