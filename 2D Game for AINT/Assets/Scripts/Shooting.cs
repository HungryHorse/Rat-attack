using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    float rechamberRate = 5f;
    int GunChoice;
    Weapons currentWeapon;
    public GameObject SpawnPoint;
    public string FireSide;

    void Start()
    {
        GameObject Gun = GameObject.Find("Guns");
        Guns gunScript = Gun.GetComponent<Guns>();
        GunChoice = 2;
        currentWeapon = new Weapons(gunScript.WeaponTypes[GunChoice]);
    }


	// Update is called once per frame
	void Update () {

        if (Input.GetButton(FireSide))
        {
            Fire();
        }
		
        if(currentWeapon.rechamberTimer > 0)
        {
            currentWeapon.rechamberTimer -= rechamberRate * Time.deltaTime;
        }
	}

    void Fire()
    {

        if (currentWeapon.type == 0 && currentWeapon.rechamberTimer <= 0)
        {
            GameObject newBullet = Instantiate(currentWeapon.bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            Bullet newBulletScript = newBullet.GetComponent<Bullet>();
            newBulletScript.lifeTime = currentWeapon.bulletLifeTime;
            newBulletScript.thisBullet = newBullet;
            newBulletScript.Made();
            newBulletScript.damage = currentWeapon.damage;
            Rigidbody2D rigid = newBullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(SpawnPoint.transform.up * currentWeapon.fireSpeed);
            currentWeapon.rechamberTimer = currentWeapon.fireRate;
        }

    }
}
