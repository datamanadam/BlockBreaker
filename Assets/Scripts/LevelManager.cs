using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {
 


    public void LoadLevel(string name){
		
        SceneManager.LoadScene(name);
       
	}

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <=0)
        {
            LoadNextLevel();
        }
    }



	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(Application.loadedLevel + 1);
    }

}
//SceneManager.sceneCount +1