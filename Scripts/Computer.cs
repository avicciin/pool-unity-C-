using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


public class Computer : MonoBehaviour
{
     public List<GameObject> BallsList = new List<GameObject>();
     public List<GameObject> HoleList = new List<GameObject>();
     public List<GameObject> ListBallHole = new List<GameObject>();
    public GameObject whiteBall;
 
     private Scene _ballSimulationScene;
    private PhysicsScene _ballPhysicsScene;
    [SerializeField] private Transform _gameTableObstacles;
    [SerializeField] private Transform _gameBalls;


    void Start()
    {   
        bestBallToShoot();
        foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("PlainBall"))
        {
            BallsList.Add(fooObj);
        }
        foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("SpotBall"))
        {
            BallsList.Add(fooObj);
        }
        
        foreach (GameObject obj in BallsList)
            {
                Debug.Log(obj.name);
            }


        foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("GameHole")) 
        {
            HoleList.Add(fooObj);
        }
            
        ListBallHole = ClosetBallToTheHole(BallsList,HoleList);
        Debug.Log(ListBallHole[0].name);
        }


    void Update()
    {
        
    }

    public void bestBallToShoot()
    {
         _ballSimulationScene = SceneManager.CreateScene("GameBallsSimulation", new CreateSceneParameters(LocalPhysicsMode.Physics2D));
        _ballPhysicsScene = _ballSimulationScene.GetPhysicsScene();

        //The Simulation Scene Creation
        foreach (Transform obj in _gameTableObstacles) {
            var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
            ghostObj.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(ghostObj, _ballSimulationScene);
        }
        foreach (Transform obj in _gameBalls) {
            var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
            ghostObj.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(ghostObj, _ballSimulationScene);
        }
        
    }

    public void distanceBalls()
    {
         Dictionary<float, GameObject> distanceToObject = new Dictionary<float, GameObject>();
        foreach (GameObject obj in BallsList)
        {
            float distance = Vector3.Distance(whiteBall.transform.position, obj.transform.position);
            distanceToObject.Add(distance, obj);
        }

        // Sort the list of objects by their distance to the target object
        List<GameObject> sortedObjects = new List<GameObject>();
        foreach (KeyValuePair<float, GameObject> entry in distanceToObject)
        {
            sortedObjects.Add(entry.Value);
        }

        sortedObjects.Sort((x, y) => Vector3.Distance(whiteBall.transform.position, x.transform.position).CompareTo(Vector3.Distance(whiteBall.transform.position, y.transform.position)));

        // Print the sorted list of objects
        Debug.Log("Sorted objects:");
        foreach (GameObject obj in sortedObjects)
        {
            Debug.Log(obj.name);

        }
    }

    public void DistanceComparator()
    {
         List<float> distances = new List<float>();
        foreach (GameObject obj1 in BallsList)
        {
            foreach (GameObject obj2 in HoleList)
            {
                float distance = Vector3.Distance(obj1.transform.position, obj2.transform.position);
                distances.Add(distance);
            }
        }

        // Sort the list of distances from the biggest to the smallest
        distances.Sort((x, y) => x.CompareTo(y));

        // Print the sorted list of distances
        Debug.Log("Sorted distances:");
        foreach (float distance in distances)
        {
            Debug.Log(distance);
        }
    }
    
    public List<GameObject> ClosetBallToTheHole(List<GameObject> list1, List<GameObject> list2)
    {
        List<GameObject> result = new List<GameObject>();
        Dictionary<GameObject, float> distances = new Dictionary<GameObject, float>();
        
        // Calculate distances between each GameObject in list1 and all GameObjects in list2
        foreach (GameObject obj1 in list1)
        {
            float minDistance = float.MaxValue;
            foreach (GameObject obj2 in list2)
            {
                float distance = Vector3.Distance(obj1.transform.position, obj2.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    distances[obj1] = distance;
                }
            }
        }
        
        // Sort list1 by the distances to objects in list2
        foreach (KeyValuePair<GameObject, float> pair in distances.OrderBy(pair => pair.Value))
        {
            result.Add(pair.Key);
        }
        
        return result;
    }
    
        public float PowerToShoot(GameObject whiteBall, GameObject targetBall, GameObject hole)
        {
            return 0;
        }

        public float AngelToShoot(GameObject whiteBall, GameObject targetBall, GameObject hole)
        {
            return 0;
        }
}
