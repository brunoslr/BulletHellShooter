using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	public Text gameOverText,gameOverTextBack;
	public GameObject creditsPanel;
	// Use this for initialization

	void OnCollisionEnter(Collision col)
	{
		creditsPanel.SetActive (true);
		gameOverText.text = "Congratulations, you found the artifacts and won the game";
		gameOverTextBack.text = gameOverText.text;
		StartCoroutine("Victory", 5f);
	}
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator Victory(float time)
	{
			
		gameOverText.text = "Congratulations, you found the artifacts and won the game" ;
		gameOverTextBack.text = gameOverText.text;

		yield return new WaitForSeconds (time);
		if (Application.loadedLevel == 1)
			Application.LoadLevel ("level2");
		if (Application.loadedLevel == 2)
			Application.LoadLevel ("mainMenu");
		
	}

}
