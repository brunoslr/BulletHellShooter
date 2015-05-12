using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision col)
	{
		
		if(col.gameObject.name!="player")
		{
			Destroy(this.gameObject);
		}
		
	}
}
