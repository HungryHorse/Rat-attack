using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifeTime;
    public GameObject thisBullet;
    GameObject targetHit;
    public float damage;

	public void Made()
    {
        Destroy(thisBullet, lifeTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        targetHit = collision.gameObject;
        if (targetHit.tag != "Bullet")
        {
            Destroy(gameObject);
        }
        if (targetHit.tag == "Enemy")
        {
            targetHit.GetComponent<Enemy>().health -= damage;
        }
    }
}
