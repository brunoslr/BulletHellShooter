using UnityEngine;
using System.Collections;

public class AIManager : MonoBehaviour 
{
    private static AIManager _instance;

    GameObject[] wayPointList = new GameObject[5];
    int[][] pathList = new int [][]
    {
        new []{ 0, 1, 2 }, 
        new []{ 0, 1, 4 }, 
        new []{ 1, 2, 3 }
    };

    int pathCounter = 0;

    public static AIManager instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<AIManager>();
            return _instance;
        }
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    int[] getMyPath()
    {
        int[] tempPath = new int[3];
        tempPath = pathList[pathCounter++];
        return tempPath;
    }
}
