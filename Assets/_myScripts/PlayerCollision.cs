using UnityEngine;


public class PlayerCollision : MonoBehaviour {

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Hydrant"){
            Debug.Log("Larry ran into a hydrant");

            FindObjectOfType<GameManagement>().EndGame();
        }

    }

}
