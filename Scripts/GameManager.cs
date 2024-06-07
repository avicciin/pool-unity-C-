using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> BallsList;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BlackBallDie(Collision collision)
    {
        // Check if the collided object has tag1 and tag2
        if (collision.gameObject.CompareTag("BlackBall") && collision.gameObject.CompareTag("GameHole"))
        {
            // Check if the list is empty
            if (BallsList.Count != 0)
            {
                // Stop the game
                Time.timeScale = 0;
                Debug.Log("Game stopped!");
            }
    }
    }
}
