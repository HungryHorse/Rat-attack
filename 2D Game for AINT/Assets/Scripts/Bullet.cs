using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifeTime;
    public GameObject thisBullet;

	public void Made()
    {
        Destroy(thisBullet, lifeTime);
    }
}
