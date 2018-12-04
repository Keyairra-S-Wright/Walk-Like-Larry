using System.Collections;
using System.Collections.Generic; //necessary to use the list types
using UnityEngine;

public class StreetSpawner : MonoBehaviour {

    public GameObject[] streetTilePrefabs; //This allows the Street Tile Prebas to be eventuall spawned

    private Transform playerTransform;
    private float spawnZ = -24.0f; //this will will cause a tile to spawn behind the player so that the user's view is not empty at first
    private float streetTileLength = 24.0f;
    private float safeZone = 15.0f;
    private int numTilesOnScreen = 7;//this may be adjusted based on camera view during testing

    private List<GameObject> activeTiles;

	void Start () {
        activeTiles = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
   

        for (int i = 0; i < numTilesOnScreen; i++)
        {
            SpawnTile();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
        if(playerTransform.position.z - safeZone > (spawnZ - numTilesOnScreen * streetTileLength)) 
        {
            SpawnTile();
            DeleteTile();
        }
	}

    private void SpawnTile(int prefabIndex = -1) //default index for tiles to spawn
    {
        GameObject go;
        go = Instantiate(streetTilePrefabs[0] as GameObject);
        go.transform.SetParent(transform);//grabs reference to our tile being created and specifies that the parent is now the StreetManager object in the hiearchy
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += streetTileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile(){
        Destroy (activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
