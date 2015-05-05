using UnityEngine;
using System.Collections;

enum AISTATE
{
    patrolling = 0,
    tracking = 1,
}

public class AIPath : MonoBehaviour 
{
    public GameObject[] wayPoints = new GameObject[5];

    public bool[] isVisited = new bool[5];

    AISTATE myState;
    int[] myPath = new int[3];

	// Use this for initialization
	void Start () 
    {
	    for(int i = 0; i < 5; ++i)
        {
            isVisited[i] = false;
        }

        myState = AISTATE.patrolling;
      //  myPath = AIManagerInstance.getMyPath();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    void localPatrol()
    {
        
    }
}
