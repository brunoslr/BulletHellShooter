using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameIdentifiers : MonoBehaviour {

	public float time;
	private Text timeText;
	//private CycleManager cycleManager;
	public GameObject health;
	//public Health1 health1;
	//private Health _health1;

	
	void Start()
	{
		timeText = this.GetComponent<Text>();
	//	cycleManager = CycleManager.Instance;
	
		health = GameObject.Find("health");

	
	}
	
	void Update () 
	{

//		time = CycleManager.Instance.<0>;
		//cycleManager.FirstDigit = 5;
		//Player.GetComponent<he
		//int test = Player;
		//_health1 = Player.GetComponent<Health>();
		timeText.text =" First: " + (health.transform.position.x).ToString() + "Second: " + cycleManager.SecondDigit + "Third: " + cycleManager.ThirdDigit + "Fourth: " + cycleManager.FourthDigit;
		//if (Input.GetKeyDown ("space"))
		//	cycleManager.AdjustTimeLeft (10f);

	}
}