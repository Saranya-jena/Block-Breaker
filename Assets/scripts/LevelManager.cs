using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		
		//Application.LoadLevel (name);
		SceneManager.LoadScene (name);
		Brick.breakableCount = 0;
	}
	public void QuitRequest(){
		Debug.Log ("i want to quit");
		Application.Quit ();
	}

	public void LoadNextLevel()
	{
		//Application.LoadLevel (Application.loadedLevel + 1);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+ 1);
		Brick.breakableCount = 0;
	}
public void BrickDestroyed()
{
if(Brick.breakableCount<=0)
{
			LoadNextLevel ();
}
}

}
