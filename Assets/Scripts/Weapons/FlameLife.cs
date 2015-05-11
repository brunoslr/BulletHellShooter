using UnityEngine;
using System.Collections;

public class FlameLife : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("delete", 1.0f);
	}
	
	// Update is called once per frame
	//void Update () {
	//}

	void delete()
	{
		Destroy (this.gameObject);
	}
}
