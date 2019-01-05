using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private float animationDuration = 3.5f;

    private float startTime;

    private bool lostGame = false;

    public AudioSource soundtrack;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        if (lostGame)
            return;


        if(Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return; //the player movement will not be run if it is past 6 seconds and we'll do normal movements
        }

        moveVector = Vector3.zero;

        //Check to see if Larry character is on the floor or not
        if(controller.isGrounded) 
        {
            //soundtrack.Play();
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

       
        //Moves character Left and Right on Laptop
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        if(Input.GetMouseButton(0))
        {
            //Checks to see if screens are touched on the right side of the screen
            if(Input.mousePosition.x > Screen.width/2) 
            {
                moveVector.x = speed;
            }
            else 
            {
                moveVector.x = -speed;
            }
        }

        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
	}

    public void SetSpeed(int speedometer)
    {
        speed = 5.0f + speedometer;
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Distraction")
            Lose();
    }

    private void Lose() 
    {
        lostGame = true;
        soundtrack.Stop();
        Debug.Log("Loser");
        GetComponent<Timer>().OnLoss();
    }

   
}
