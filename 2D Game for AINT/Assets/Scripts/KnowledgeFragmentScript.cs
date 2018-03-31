using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeFragmentScript : MonoBehaviour {

    GameObject targetHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        targetHit = collision.gameObject;
        if (targetHit.tag == "Player")
        {
            targetHit.GetComponent<PlayerStats>().Knowledge += 1;
            Destroy(gameObject);
        }
    }
}
