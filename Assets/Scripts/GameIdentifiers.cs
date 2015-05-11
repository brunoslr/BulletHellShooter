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
	//private CycleManager cycleManager;
	private float health;
	private float enemiesKilled;
	private bool allEnemiesKilled = false; 
	private bool outOfTime = false;
	
	void Start()
	{
		
		//cycleManager = CycleManager.Instance;
		
		gameText = GameObject.Find("FrontText").GetComponent<Text>();
		
		gameTextBack = GameObject.Find("BackText").GetComponent<Text>();
		
//		gameOverText = GameObject.Find("GameOverFrontText").GetComponent<Text>();
		
//		gameOverTextBack = GameObject.Find("GameOverBackText").GetComponent<Text>();
		
		creditsPanel = GameObject.Find("Panel");
		
		commonGameObject = GameObject.Find("gameData");
		
		lightObject = GameObject.Find("Directional light");
		
		player = GameObject.Find("PlayerPrefab");
		
		enemy = GameObject.FindGameObjectsWithTag("Enemy");
		
		health = commonGameObject.transform.position.x;
		
		activateCreditsPanel (false);
		
		//Set the player speed according to the First Digit
		setPlayerSpeed(5);
		
		//Starting time = (secondDigit - 5) X2
		resolveStartingTime(9);
		
		setFireSpeed(9);
		
		//Start in one of the predetermined positions according the third Digit
		//resolveStartingPosition(9);
		
		//If greather than or equal 5, night time else, day time
		resolveLightEffects(9);
		
		//Dealing with the four PirateKart Digits
		//Remove a Random Enemies according to First Digit
		removeRandomEnemies(9);
		
		// player speed, rate of fire(possibly)
		
	}
	
	void Update () 
	{
		
		if (!allEnemiesKilled && !outOfTime) {
//			if (commonGameObject.transform.position.x < health) {
//				//cycleManager.AdjustTimeLeft (-5f);
//			}
			
			if (commonGameObject.transform.position.y > enemiesKilled) {
				//cycleManager.AdjustTimeLeft (2f);
				enemiesKilled = commonGameObject.transform.position.y;
			}
			
			health = commonGameObject.transform.position.x;
			
			gameText.text = " Player Health " + (commonGameObject.transform.position.x).ToString ("#.#") + 
				"\n Enemies Killed: " + enemiesKilled;
			gameTextBack.text = gameText.text;
			
			if (countActiveEnemies () == 0) //Kill all the enemies go to next lvl with full bonus
			{
				allEnemiesKilled = true;
				//cycleManager.AdjustTimeLeft (10f);
				StartCoroutine("Victory", 5f); 
			}
//			else if(cycleManager.TimeLeft <= 0.1) 	//If the game is about to end
//			{
//				outOfTime = true;
//				//cycleManager.AdjustTimeLeft (10f);
//				StartCoroutine("GameOver", 5f); 
//			}
			
		}
		
	}
	
	IEnumerator Victory(float time)
	{
		activateCreditsPanel (true);
		gameOverText.text = " You won! The next level will start with the indicators 9999 "+ 
			"Enemies Destroyed this round: " + enemiesKilled;
		gameOverTextBack.text = gameOverText.text;
		yield return new WaitForSeconds (time);
	//	setCycleManagerMax ();
	//	cycleManager.AdvanceToNext();
	}
	
	IEnumerator GameOver(float time)
	{
		activateCreditsPanel (true);
//	//	setCycleManagerEndGame ((int)enemiesKilled, countActiveEnemies(), (int)health,cycleManager.ThirdDigit + 5);
//		gameOverText.text = //"The next level will start with the indicators "+ cycleManager.FirstDigit + 
//			//cycleManager.SecondDigit + cycleManager.ThirdDigit + cycleManager.FourthDigit +
//				" Enemies Destroyed this round: " + enemiesKilled;
//		gameOverTextBack.text = gameOverText.text;
		yield return new WaitForSeconds (time);
		
		//cycleManager.AdvanceToNext();
	}
	
//	void setCycleManagerEndGame(int first, int second, int third, int fourth)
//	{
//		cycleManager.FirstDigit = first%10;  // Dependent on num enemies killed
//		cycleManager.SecondDigit = second%10; // Dependent on time left
//		cycleManager.ThirdDigit = third%10; // Dependent on health
//		cycleManager.FourthDigit = fourth%10; // 
//	}
//	
//	void setCycleManagerMax()
//	{
//		cycleManager.FirstDigit = 9;
//		cycleManager.SecondDigit = 9;
//		cycleManager.ThirdDigit = 9;
//		cycleManager.FourthDigit = 9;
//		
//	}
	
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
	void resolveStartingTime(int startingValue)
	{
		
		int timeAdjustment = (startingValue - 5) * 2;	
		
		//cycleManager.AdjustTimeLeft (timeAdjustment);
		
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