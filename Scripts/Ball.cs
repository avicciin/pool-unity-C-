using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D ball;
    public Vector2 ballSpeed;
    public Vector2 ballPosition;
    public float ballVelocity = 0f;
    public bool ballType;
    public bool isAlive = true;

    void Start()
    {
        ballPosition = transform.position;
        float ballVelocity = ballPosition.magnitude;
        //if(collision.gameObject.CompareTag(object1Tag) && gameObject.CompareTag("GameHole"))
        {

        }
    }
    void Update()
    {
        
    }
}
