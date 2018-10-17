using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    bool gameHasEnded = false;

    public GameObject completeLevelUI;

    public void CompleteLevel (){

        Debug.Log("LEVEL WON!");
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Restart();
        }
    
    }


    void Restart () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
