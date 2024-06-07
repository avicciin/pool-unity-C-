using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{

    public float speed = 0;
    [SerializeField] Manager manager;
    [SerializeField] DragNShoot drag;



    // Start is called before the first frame update
    public void StartSpeed()
    {
        speed = 1;
        StartCoroutine(CalculateSpeed());


    }

    // Update is called once per frame
    void Update()
    {
        //BotIsReady();

    }

    IEnumerator CalculateSpeed()
    {
        while(speed > 0.5f )
        {

            Debug.Log("speed: " + speed);
            Vector3 lastPosition = transform.position;
            yield return new WaitForSeconds(1);
            speed = (lastPosition - transform.position).magnitude / Time.deltaTime;
            drag.Freez();

        }

        manager.CheckWhoPlaying();
        Debug.Log("CalculateSpeed work");

    }


}
