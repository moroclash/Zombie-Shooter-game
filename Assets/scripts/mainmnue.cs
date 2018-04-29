using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmnue : MonoBehaviour {

	// Use this for initialization
	public void playGame() {
        SceneManager.LoadScene(1);
	}
	
	// Update is called once per frame
    public void quiteGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
	
}
