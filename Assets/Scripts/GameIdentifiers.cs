using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameIdentifiers : MonoBehaviour {
	
	private GameObject commonGameObject;
	private GameObject player;
	private GameObject lightObject;
	private GameObject creditsPanel;
	private GameObject[] enemy;
	private Text gameText,gameTextBack;
	private Text gameOverText,gameOverTextBack;
	private float health;
	private float enemiesKilled;
	public bool allEnemiesKilled = false; 
	private bool outOfTime = false;
	
	void Start()
	{

		
		gameText = GameObject.Find("FrontText").GetComponent<Text>();
		gameTextBack = GameObject.Find("BackText").GetComponent<Text>();
		gameOverText = GameObject.Find("GameOverFrontText").GetComponent<Text>();
		gameOverTextBack = GameObject.Find("GameOverBackText").GetComponent<Text>();
		creditsPanel = GameObject.Find("Panel");
		commonGameObject = GameObject.Find("gameData");
		lightObject = GameObject.Find("Directional light");
		player = GameObject.Find("PlayerPrefab");
		enemy = GameObject.FindGameObjectsWithTag("Enemy");
		health = commonGameObject.transform.position.x;
		activateCreditsPanel (false);
		setPlayerSpeed(5);
		setFireSpeed(9);
		resolveLightEffects(9);
		removeRandomEnemies(9);

	}
	
	void Update () 
	{
		
		if (!allEnemiesKilled && !outOfTime) {
			
			if (commonGameObject.transform.position.y > enemiesKilled) {

				enemiesKilled = commonGameObject.transform.position.y;
			}
			
			health = commonGameObject.transform.position.x;
			
			gameText.text = " Player Health " + (commonGameObject.transform.position.x).ToString ("##.") + 
				"\n Enemies Killed: " + enemiesKilled;
			gameTextBack.text = gameText.text;
			
			if (countActiveEnemies () <= 10) //Kill all the enemies go to next lvl with full bonus
			{
				allEnemiesKilled = true;

				StartCoroutine("Victory", 5f); 
			}
			
		}
		
	}
	
	IEnumerator Victory(float time)
	{
		activateCreditsPanel (true);

		if (Application.loadedLevel == 1) {
			gameOverText.text = "Level 1 complete. Prepare for darkness." + enemiesKilled;
			gameOverTextBack.text = gameOverText.text;
				}
		if (Application.loadedLevel == 2) {
			gameOverText.text = "Congratulations, you found the artifacts and won the game" + enemiesKilled;
			gameOverTextBack.text = gameOverText.text;
				}
		yield return new WaitForSeconds (time);
		if (Application.loadedLevel == 1)
			Application.LoadLevel ("level2");
		if (Application.loadedLevel == 2)
			Application.LoadLevel ("mainMenu");

	}
	
	IEnumerator GameOver(float time)
	{
		activateCreditsPanel (true);
		yield return new WaitForSeconds (time);

	}
	

	
	void removeEnemy(int arrayPosition)
	{
		enemy[arrayPosition].SetActive (false);
	}
	
	void activateCreditsPanel(bool value)
	{
		creditsPanel.SetActive(value);
	}
	
	//REMOVE Random Enemies For each value received on the First Parameter
	void removeRandomEnemies(int enemiestoRemove)
	{
		for(int i=0; i< enemiestoRemove;i++)
		{
			removeEnemy((int)Random.Range(0,enemy.Length -1));
		}
	}
	

	
	//change start time according to the starting value
	void resolveStartingPosition(int value)
	{
		
		switch (value) {
		case 0:
			player.transform.position = new Vector3(99,1,47);
			break;
		case 1:
			player.transform.position = new Vector3(48,1,76);
			break;
		case 2:
			player.transform.position = new Vector3(150,1,66);
			break;
		case 3:
			player.transform.position = new Vector3(100,1,78);
			break;
		case 4:
			player.transform.position = new Vector3(101,1,101);
			break;
		case 5:
			player.transform.position = new Vector3(77,1,143);
			break;
		case 6:
			player.transform.position = new Vector3(92,1,114);
			break;
		case 7:
			player.transform.position = new Vector3(72,1,131);
			break;
		case 8:
			player.transform.position = new Vector3(100,1,143);
			break;
		case 9:
			player.transform.position = new Vector3(141,1,143);
			break;
		default:
			break;
			
		}
		
	}
	
	void resolveLightEffects(int value)
	{
		if(value<5)
			lightObject.SetActive(false);
	}
	
	int countActiveEnemies()
	{
	
		int activeEnemies = 0;
		for(int i=0; i < enemy.Length;i++)
		{
			if(enemy[i]!=null && enemy[i].activeSelf==true)
				activeEnemies++;
		}
		//Debug.Log ("Checking"+activeEnemies);
		return activeEnemies;
	}
	
	void setPlayerSpeed(int value)
	{
		float tempx = commonGameObject.transform.position.x;
		float tempy = commonGameObject.transform.position.y;
		float tempz = (float)value;
		commonGameObject.transform.position = new Vector3(tempx, tempy, tempz);
		
	}
	void setFireSpeed(int value)
	{
		float tempx = commonGameObject.transform.localScale.x;
		float tempy = commonGameObject.transform.localScale.y;
		float tempz = (float)value;
		commonGameObject.transform.localScale = new Vector3(tempx, tempy, tempz);
		
	}
}