﻿using UnityEngine;

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
            //Animation at start of the game. This will last for a set number of seconds
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(view.position + Vector3.up);

        }
    }
}

