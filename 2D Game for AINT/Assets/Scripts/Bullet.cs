using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifeTime;
    public GameObject thisBullet;
    GameObject targetHit;
    public int damage;

	public void Made()
    {
        Destroy(thisBullet, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        targetHit = collision.gameObject;
        Debug.Log("HIT");
        Destroy(gameObject);
        if (targetHit.tag == "Enemy")
        {
            targetHit.GetComponent<Enemy>().health -= damage;
        }
    }
}
