using UnityEngine;
using System.Collections;

public class ThrowPortal : MonoBehaviour {
	public GameObject leftPortal;
	public GameObject rightPortal;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Debug.Log("Left Click");
			throwPortal(leftPortal);
		
		}
		if(Input.GetMouseButtonDown(1))
		{
			Debug.Log("Right Click");
			throwPortal(rightPortal);
		}
	}
	
	void throwPortal(GameObject portal)
	{
		int x = Screen.width/2;
		int y = Screen.height/2;
		
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(x,y));
		RaycastHit hit;
		if(Physics.Raycast (ray,out hit ))
		{   Quaternion hitObjectRotation = Quaternion.LookRotation(hit.normal);
			portal.transform.position = hit.point;
			portal.transform.rotation = hitObjectRotation;
		}
	
	}
}
