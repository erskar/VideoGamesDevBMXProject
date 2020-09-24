using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    
    public float zSpawn = 0;
    public float tileLength;
    public int numberOfTiles = 2;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {

        //When starting, checks if there are any tiles spawned. If none it will spawn the default tile (Tile0)
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(1, tilePrefabs.Length)); //works but need to fix Tile0 prefab so currently Tile0 isn't in the list of tilePrefabs
        }
    }

    // Update is called once per frame
    void Update()
    {
        //spawns new tiles
        if (playerTransform.position.z - 30 > zSpawn - (numberOfTiles * tileLength))
        {
            for (int i = 0; i < numberOfTiles; i++)
            {
                if (i == 3)
                    SpawnTile(0);
          

                else

                SpawnTile(Random.Range(1, tilePrefabs.Length));
            }
            DeleteTile();
        }
    }

    //spawn tile method
    public void SpawnTile(int tileIndex)
    {

        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }


    //delete tile method
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
