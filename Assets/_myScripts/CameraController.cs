using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//New Camera
public class CameraController : MonoBehaviour
{
    private Transform view; //this is a new field
    public Vector3 initialOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 3.5f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

    private void Start()
    {
        view = GameObject.FindGameObjectWithTag("Player").transform;
        initialOffset = transform.position - view.position;
    }

    private void Update()
    {
        moveVector = view.position + initialOffset;
        moveVector.x = 0;
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

        if (transition > 1.0f)
        {
            transform.position = view.position + initialOffset;
        }
        else
        {
            //Animation at start of the game. This will last for two seconds
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(view.position + Vector3.up);

        }



    }
}



//Walk Like Larry Camera
//Target is the Larry transform
//Offest 0, -0.5, 1
//public class CameraController : MonoBehaviour
//{

//    public Transform target;

//    public Vector3 offset;
//    public float zoomSpeed = 4f;
//    public float minZoom = 5f;
//    public float maxZoom = 15f;

//    public float pitch = 2f;

//    //TODO: rotating camera is not suiting me right now, decide at other levels if this functionality is helpful
//    //public float yawSpeed = 100f;

//    //public float currentYaw = 0f;

//    private float currentZoom = 10f;

//    void Update()
//    {
//        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
//        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

//        //currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
//    }

//    void LateUpdate()
//    {
//        transform.position = target.position - offset * currentZoom;
//        transform.LookAt(target.position + Vector3.up * pitch);

//        //transform.RotateAround(target.position, Vector3.up, currentYaw);
//    }
//}




//Attempt at updating Larry Camera
//Target is the Larry transform
//Offest 0, -0.5, 1
//public class CameraController : MonoBehaviour
//{
//    private float transition = 0.0f;
//    private float animationDuration = 2.0f;
//    private Vector3 animationOffset = new Vector3(0, 5, 5);
//    public Transform target;

//    public Vector3 offset;
//    public float zoomSpeed = 4f;
//    public float minZoom = 5f;
//    public float maxZoom = 15f;

//    public float pitch = 2f;

//    private Vector3 moveVector;

//    //TODO: rotating camera is not suiting me right now, decide at other levels if this functionality is helpful
//    //public float yawSpeed = 100f;

//    //public float currentYaw = 0f;

//    private float currentZoom = 10f;

//    void Update()
//    {
//        moveVector = target.position + offset;

//        moveVector.x = 0;
//        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

//        if (transition > 1.0f) 
//        {
//            currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
//            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

//            //currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
//        } 
//        else 
//        {
//            //enter this animation at the start of the game and last for only 2 seconds
//            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
//            transition += Time.deltaTime * 1 / animationDuration; //it will take 2 seconds for the transion to equal 1; the camera will move closer to the player

//        }

//    }

//    void LateUpdate()
//    {
//        transform.position = target.position - offset * currentZoom;
//        transform.LookAt(target.position + Vector3.up * pitch);

//        //transform.RotateAround(target.position, Vector3.up, currentYaw);
//    }
//}