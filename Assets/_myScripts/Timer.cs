using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    private float score = 0.0f;

    public Text timerText;
    public LossMenu lossMenu;

    private float startTime;

    private bool hasLost = false;

    // allow game to have increasing difficulty as time passes
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;

    void Start () {
        startTime = Time.time;
	}
	
	
	void Update () {

        if(hasLost)
        {
            return;
        }

        score = (Time.time - startTime) * difficultyLevel;


        if (score >= scoreToNextLevel)
        {
            LevelUp();
        }

        score += Time.deltaTime;
        timerText.text = ((int)score).ToString();


        //Former Score <-- TODO:decide between the design prior to deployment
        //float score = Time.time - startTime;
        //string minutes = ((int) score / 60).ToString();
        //string seconds = (score % 60).ToString("f2");

        //timerText.text = minutes + ":" + seconds;
    }

    private void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
        {
            return;
        }

        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);
        Debug.Log("Here is the difficulty level in Timer component:" + difficultyLevel);
    }

    public void OnLoss()
    {
        hasLost = true;
        if(PlayerPrefs.GetFloat("Highscore") < score)
        {
            PlayerPrefs.SetFloat("Highscore", score);//saves high school to devices registry
        }
           
        lossMenu.ToggleLossMenu(score);
    }
}
