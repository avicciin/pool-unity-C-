using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNShoot : MonoBehaviour
{
    [SerializeField] Speed speed;
    [SerializeField] Manager manager;
    [SerializeField] GameObject powerForPlayer;


    public float power = 20f;
    public Rigidbody2D rb;
    public GameObject stick;
    
    public Vector2 minPower;
    public Vector2 maxPower;
    public Vector2 ballPosition;
    TrajectoryLine tl;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    bool IsPowerCollision = false;

    private void Start()
    {
         cam = Camera.main;
         tl = GetComponent<TrajectoryLine>();
        powerForPlayer.SetActive(false);

    }

    public void Update() 
    {
        while(speed.speed >= 0)
        {
            
        }
        if (!manager.IsplayerTurn)
        {
            return;
        }

         Vector3 mousePose = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            GetLocal();

        }

        if (Input.GetMouseButton(0))
        {

            mousePose.z = 15;
            tl.RenderLine(startPoint, mousePose);
        }

        if (Input.GetMouseButtonUp(0))
        {
            
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;
            stick.SetActive(false);
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();
            speed.StartSpeed();
        }
    }
    public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps)
    {
        Vector2[] result = new Vector2[steps];
        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        float drag = 1f-timestep *rigidbody.drag;
        Vector2 movestep =- velocity*timestep;

        for (int i = 0; i < steps; i++)
        {
            movestep *=drag;
            pos += movestep;
            result[i] = pos ;   
        }

        return result;
    }

    private void PoolStick()
    {

    }

    private void BotTurn()
    {

    }

    public void GetLocal()
    {
        startPoint = transform.position;
        startPoint.z = 35;
    }
    public void GetLocalBot()
    {
      //  mousePose.z = 15;
       // tl.RenderLine(startPoint, mousePose);
    }
    public void GetLocalBotMove()
    {
        float Botpower = 30f;

    endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        endPoint.z = 30;
        //stick.SetActive(false);
        int min =  UnityEngine.Random.RandomRange(5, 10);
        int max = UnityEngine.Random.Range(5, 10);

        force = new Vector2(Mathf.Clamp(min - max, minPower.x, maxPower.x), Mathf.Clamp(min - max, minPower.y, maxPower.y));
        rb.AddForce(force * Botpower, ForceMode2D.Impulse);
        tl.EndLine();
        speed.StartSpeed();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OnCollisionEnter");

        if (other.gameObject.tag == ("Present"))
        {
             IsPowerCollision = true;
            Debug.Log("TOUCHED");
            Destroy(other.gameObject); //other.gameObject instead of just gameObject
        }
    }

    public void Freez()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("GetMouseButtonDown");

            //Cursor.visible = false;
           // Cursor.lockState = CursorLockMode.Locked;
           // UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("GetMouseButtonUp");

           // Cursor.visible = false;
           // Cursor.lockState = CursorLockMode.Locked;
            // UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            
            
        }

    }
}
