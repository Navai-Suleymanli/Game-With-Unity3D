using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 5; // moving speed
    private PlayerController playerControllerScript;  // refference to PlayerController script
    private float leftBound = -15;  


    // Start is called before the first frame update
    void Start()
    {
        // this finds Player object, and adds PlayerController script to this
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)  // if gameOver is false
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))   // if goes beyond the border
        {
            Destroy(gameObject); // destroy gameobject
        };
        
    }
}
