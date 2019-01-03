using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LossMenu : MonoBehaviour {

    public Text timerText;
    public Image backgroundImage;

    public bool isShown = false;
    public float transition = 0.0f;

	void Start () {
        gameObject.SetActive(false);
	}
	
	
	void Update () {
        if (!isShown)
            return;

        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
	}

    public void ToggleLossMenu(float score) 
    {
        gameObject.SetActive(true);
        timerText.text = ((int)score).ToString();
        isShown = true;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
