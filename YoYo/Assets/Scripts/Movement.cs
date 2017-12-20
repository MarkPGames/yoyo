using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum YoyoState
{
    IDLE,
    EXPANDING,
    SHRINKING,
}

public class Movement : MonoBehaviour
{
    // Determines if 'yoyo' is in the expand or the shrink state
    private YoyoState mYoyoState;

    //The red circle's position
    [SerializeField]
    private Vector2 anchorPos = Vector2.zero;
    [SerializeField]
    private float minDistance = 1.0f;
    [SerializeField]
    private float maxDistance = 2.5f;
    LineRenderer line;

    Transform _transform;
    // Use this for initialization
    void Start()
    {
        _transform = this.transform;
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // current distance from anchor
        float currDist = Vector2.Distance(anchorPos, _transform.position);

        if (Input.GetMouseButton(0))
        {
            mYoyoState = YoyoState.EXPANDING;
        }
        else
        {
            mYoyoState = YoyoState.SHRINKING;
        }
        //simple finite state machine
        switch (mYoyoState)
        {
            case YoyoState.IDLE:
                {
                    break;
                }
            case YoyoState.EXPANDING:
                {
                    if (currDist <= maxDistance)
                    {
                        _transform.position = Vector2.MoveTowards(_transform.position, (_transform.position * (maxDistance / currDist)), 0.8f * Time.deltaTime);
                    }
                    break;
                }
            case YoyoState.SHRINKING:
                {
                    if (currDist >= minDistance)
                    {
                        _transform.position = Vector2.MoveTowards(_transform.position, (_transform.position * (-maxDistance / currDist)), 0.8f * Time.deltaTime);
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }

        line.SetPosition(1, transform.position);
    }
}
