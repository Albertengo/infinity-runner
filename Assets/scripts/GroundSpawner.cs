using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    //[SerializeField] GameObject groundTile;
    public GameObject[] tilePrefabs;

    public float nextSpawnPoint;
    public float tileLength;
    public int numberOfTiles = 10;
    List<GameObject> ActiveTiles = new List<GameObject>();

    public Transform playerTransform;
    //Vector3 nextSpawnPoint;

    //public void SpawnTile (bool spawnItems)
    //{
    //    GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
    //    nextSpawnPoint = temp.transform.GetChild(1).transform.position;

    //}

    private void Start () 
    {
        //for (int i = 0; i < 15; i++) {
        //    if (i < 3)
        //    {
        //        SpawnTile(false);
        //    } 
        //    else 
        //    {
        //        SpawnTile(true);
        //    }
        //}
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile (0);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    private void Update ()
    {
        if (playerTransform.position.z - 20 > nextSpawnPoint - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int TileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[TileIndex], transform.forward * nextSpawnPoint, transform.rotation);
        ActiveTiles.Add(go);
        nextSpawnPoint += tileLength;
    }

    private void DeleteTile() 
    {
        Destroy(ActiveTiles[0]);
        ActiveTiles.RemoveAt(0);
    }
}

