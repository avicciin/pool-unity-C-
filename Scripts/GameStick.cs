using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStick : MonoBehaviour
{
    public GameObject WhiteBall;
    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     public Transform pivotPoint;  // Pivot point of rotation
    public float rotationSpeed = 10f;  // Speed of rotation

    private Vector3 mousePosition;

    private void Update()
    {
        // Get the mouse position in world coordinates
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Calculate the direction from the pivot point to the mouse position
        Vector3 direction = mousePosition - pivotPoint.position;

        // Calculate the rotation angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the stick around the pivot point
        pivotPoint.rotation = Quaternion.Slerp(pivotPoint.rotation, Quaternion.Euler(0f, 0f, angle), rotationSpeed * Time.deltaTime);

    }

    
}

