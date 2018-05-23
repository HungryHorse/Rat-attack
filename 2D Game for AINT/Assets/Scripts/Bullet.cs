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
        // allows the bullet to pass through knowledge fragments themselves and the player
        if (targetHit.tag != "Bullet" || targetHit.tag != "Knowledge" || targetHit.tag != "Player")
        {
            Destroy(gameObject);
        }
        // does damage to an enemy if it hits one
        if (targetHit.tag == "Enemy")
        {
            targetHit.GetComponent<Enemy>().health -= damage;
        }
    }
}
