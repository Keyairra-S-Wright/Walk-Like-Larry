using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class MainMenu : MonoBehaviour {

    public Text highScoreText; 

	void Start () {
        highScoreText.text = "High Score : " + (int)PlayerPrefs.GetFloat("Highscore");
    }


    public void ToGame() 
    {
        SceneManager.LoadScene("NewCity");
    }
}
