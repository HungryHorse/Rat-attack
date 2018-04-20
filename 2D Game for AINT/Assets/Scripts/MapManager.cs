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
    public GameObject Portal;

    void Start()
    {
        currentIndex = 0;
        UpdateMap();
    }

    // Update is called once per frame
    void Update () {        
        if (Player == null && EnemyArray != null)
        {
            EnemyArray.SetActive(false);
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
        if (currentIndex > Maps.Length - 1)
        {
            Player.GetComponent<PlayerStats>().won = true;
            Player.GetComponent<PlayerStats>().health = 0;
        }

        newMap = Instantiate(Maps[currentIndex], gameObject.transform.position, gameObject.transform.rotation);

        EnemyArray = newMap.transform.GetChild(3).gameObject;

        AstarPath.active.Scan();

        Player.transform.position = Spawn.position;
        Player.transform.rotation = Quaternion.identity;

        currentIndex++;
    }
}
