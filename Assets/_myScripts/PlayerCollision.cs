using UnityEngine;


public class PlayerCollision : MonoBehaviour {

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag != "Street"){
            Debug.Log("Larry ran into something");

            FindObjectOfType<GameManagement>().EndGame();
        }

    }

}
