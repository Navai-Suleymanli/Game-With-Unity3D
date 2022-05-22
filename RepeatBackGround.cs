using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;  // this sets all the possible values of transform to the startPos
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // get gameobject's size in x layer . 2
    }

    // Update is called once per frame
    void Update()
    {
        // if current position of the wall is less than startposx - repeatwidth, assign the value of startpos to the current position
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
