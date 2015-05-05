using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//public AudioClip start;
    //public AudioSource source;

	public void StartGame()
	{
     //   source.Play();	
        StartCoroutine("LoadMainLevel");
	}

	public void Level1()
	{
		//source.Play();	
		StartCoroutine("LoadLevel1");
	}

	public void Level2()
	{
		//source.Play();	
		StartCoroutine("LoadLevel2");
	}

	public void QuitGame()
	{
		Application.Quit ();
	}

    private IEnumerator LoadMainLevel() 
    {
        yield return new WaitForSeconds(0.5f);
        Application.LoadLevel ("level1");
    }

	private IEnumerator LoadLevel1() 
	{
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevel ("level1");
	}

	private IEnumerator LoadLevel2() 
	{
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevel ("jam9");
	}

}
