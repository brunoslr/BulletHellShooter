using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour 
{

	public GUIText winLoseText;
	// Use this for initialization
	void Start () 
	{
		winLoseText.text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "boulder") 
		{
						winLoseText.text = "YOU WIN!";
						ResetLevel();
		}
	}

	public void ResetLevel()
	{
				Application.LoadLevel (0);
	}
}
