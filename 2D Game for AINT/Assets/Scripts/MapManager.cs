using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    public GameObject Player;
    public Transform Spawn;
    GameObject EnemyArray;
    GameObject MapToDestroy;
    int currentIndex;
    public GameObject[] Maps;
    GameObject newMap;

    void Start()
    {
        currentIndex = 0;
    }

    // Update is called once per frame
    void Update () {

        if(EnemyArray == null || EnemyArray.transform.childCount == 0)
        {
            UpdateMap();
            currentIndex += 1;
        }
    }

    void UpdateMap()
    {
        if (currentIndex != 0)
        {
            Destroy(newMap);
        }

        newMap = Instantiate(Maps[currentIndex], gameObject.transform.position, gameObject.transform.rotation);

        EnemyArray = newMap.transform.GetChild(3).gameObject;

        AstarPath.active.Scan();

        Player.transform.position = Spawn.position;
        Player.transform.rotation = Quaternion.identity;

    }
}
