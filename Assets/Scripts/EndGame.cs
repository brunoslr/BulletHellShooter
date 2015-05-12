using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {
	private Text gameText,gameTextBack;
	private Text gameOverText,gameOverTextBack;
	public GameObject creditsPanel;
	// Use this for initialization
	void Start () {
		
		gameText = GameObject.Find("FrontText").GetComponent<Text>();
		gameTextBack = GameObject.Find("BackText").GetComponent<Text>();
		gameOverText = GameObject.Find("GameOverFrontText").GetComponent<Text>();
		gameOverTextBack = GameObject.Find("GameOverBackText").GetComponent<Text>();
	}
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
		yield return new WaitForSeconds (time);
			Application.LoadLevel ("mainMenu");
		
	}

}
