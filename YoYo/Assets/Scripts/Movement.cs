using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    // Determines if 'yoyo' is in the expand or the shrink state
    bool expand;
    bool shrink;
    // Determines if mouse or tap was pressed
    bool pressed;
    //The red circle's position
    Vector2 anchorPos;

    // Use this for initialization
    void Start ()
    {
        expand = false;
        shrink = true;
        pressed = false;
        anchorPos = new Vector3(0f,0f,0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        // current distance from anchor
        float currDist = Vector2.Distance(anchorPos, transform.position);
        
        if (Input.GetMouseButtonDown(0))
        {
            pressed = true;
        }

        if (pressed == true)
        {
            if (shrink == true && pressed == true)
            {
                if (currDist <= 2.5f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, (transform.position * (2.5f / currDist)), 0.8f * Time.deltaTime);
                }
                else
                {
                    pressed = false;
                    shrink = false;
                    expand = true;
                }
            }
           // if (expand == true && pressed == true)
           // {
           //     if (currDist >= 2.5f)
           //     {
           //         transform.position = Vector2.MoveTowards(transform.position, (transform.position / (2.5f / currDist)), 0.8f * Time.deltaTime);
           //     }
           //     else
           //     {
           //         pressed = false;
           //         shrink = true;
           //         expand = false;
           //     }
           // }
        }  //



    }
}
