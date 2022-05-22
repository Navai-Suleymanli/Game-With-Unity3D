using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; // Creating Rigidbody type variable
    private Animator playerAnim;  // creating animator variable

    public ParticleSystem explosionParticle;  // creating particle system variable
    public ParticleSystem dirtParticle; // creating particle system variable
    public AudioClip jumpSound; // created audioclip variable
    public AudioClip crashSound; // created audioclip variable
    private AudioSource playerAudio;  // added audiosource type
    public float jumpForce = 30;  // how high it will jump
    public float gravityModifier;  // gravitation modifier
    public bool isOnGround = true;  // boolean variable
    public bool gameOver = false;  // created gameover boolean component
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // adding rigidbody component to our playerRb
        playerAnim = GetComponent<Animator>();  // adding animator to the variable
        playerAudio = GetComponent<AudioSource>(); // added audiosource to the variable
        // physics shows every physics element that is possible to add to our game
        Physics.gravity *= gravityModifier;  // physics increases gravitymodifier times
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)  // when space is pressed, and isGround is true, and gameover is flase, set isground to false
        {
            // AddForce adds force to our player
            //after , you can apply different force modes. .impulse immediately applies the force, that we wanted to apply
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // jump and add impulse force
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");  // sets trigger componenet for the jumping animation
            dirtParticle.Stop();  // it will stop the dirt particle because player will jumping
            playerAudio.PlayOneShot(jumpSound, 1.0f);  // using playOneShat function, added jumpsound and set it as 1
        }
    }

    // it will detect if it is on the ground. and if it is, isOnGroung will be true.
    public void OnCollisionEnter(Collision collision)   // created collison parameter
    {
        if (collision.gameObject.CompareTag("Ground"))   // if smt collides with ground tagged object
        {
            isOnGround = true;  // set isground to true
            dirtParticle.Play();  // it will play the dirt particle because player will be running
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;  // set gameover to true
            playerAnim.SetBool("Death_b", true);       // | setting variables for the death animation
            playerAnim.SetInteger("DeathType_int", 1); // |  
            explosionParticle.Play();  // it will play the explosion effect
            dirtParticle.Stop();  // it will stop the dirt partcile, because game will be ended
            playerAudio.PlayOneShot(crashSound, 1.0f);  // using playOneShat function, added jumpsound and set it as 1
        }
        
    }
}
