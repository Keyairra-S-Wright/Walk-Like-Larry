using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameManagement gameManager;

    private void OnTriggerEnter()
    {
        gameManager.CompleteLevel();
    }
}
