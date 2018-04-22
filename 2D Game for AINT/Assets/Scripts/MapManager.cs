using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    public GameObject Player;
    public Transform Spawn;
    GameObject EnemyArray;
    GameObject MapToDestroy;
    public GameObject mapHolder;
    int currentIndex;
    public int numberOfLevels;
    GameObject newMap;
    public GenerateRandomLevel randLevelGen;
    public GameObject Portal;

    void Start()
    {
        currentIndex = 0;
        UpdateMap();
    }

    // Update is called once per frame
    void Update () {        
        if (Player == null)
        {
            Destroy(newMap);
        }
    }

    public void UpdateMap()
    {
        if (currentIndex != 0)
        {
            GameObject[] knowledge = GameObject.FindGameObjectsWithTag("Knowledge");
            foreach(GameObject element in knowledge)
            {
                Destroy(element);
            }
            Destroy(newMap);
        }
        if (currentIndex == numberOfLevels)
        {
            Player.GetComponent<PlayerStats>().won = true;
            Player.GetComponent<PlayerStats>().health = 0;
        }

        newMap = Instantiate(mapHolder, new Vector3(0,0,0), Quaternion.identity);

        randLevelGen.GenNewLevel(currentIndex, newMap);

        AstarPath.active.Scan();

        Player.transform.position = Spawn.position;
        Player.transform.rotation = Quaternion.identity;

        currentIndex++;
    }
}
