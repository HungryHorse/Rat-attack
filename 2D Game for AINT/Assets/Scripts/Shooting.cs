using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    float rechamberRate = 5f;
    public int isTutorial;
    public int GunChoice;
    Weapons currentWeapon;
    public GameObject SpawnPoint;
    public string FireSide;
    Vector3[] rots = new Vector3[3];

    void Start()
    {
        GameObject Gun = GameObject.Find("Guns");
        Guns gunScript = Gun.GetComponent<Guns>();

        isTutorial = PlayerPrefs.GetInt("Tutorial");
        
        currentWeapon = new Weapons(gunScript.WeaponTypes[GunChoice]);
        
        rots[0] = new Vector3(0, 0, 0);
        rots[1] = new Vector3(0, 0, 8);
        rots[2] = new Vector3(0, 0, -8);

        if (isTutorial == 1)
        {
            GunChoice = 0;
            this.enabled = false;
        }
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
        if (currentWeapon.type == 1 && currentWeapon.rechamberTimer <= 0)
        {
            GameObject[] newBullets = new GameObject[3];
            for(int i = 0; i <= newBullets.Length - 1; i++)
            {
                newBullets[i] = Instantiate(currentWeapon.bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation * Quaternion.Euler(rots[i]));
                Bullet newBulletScript = newBullets[i].GetComponent<Bullet>();
                newBulletScript.lifeTime = currentWeapon.bulletLifeTime;
                newBulletScript.thisBullet = newBullets[i];
                newBulletScript.Made();
                newBulletScript.damage = currentWeapon.damage;
                Rigidbody2D rigid = newBullets[i].GetComponent<Rigidbody2D>();
                rigid.AddForce(newBullets[i].transform.up * currentWeapon.fireSpeed);
            }            
            currentWeapon.rechamberTimer = currentWeapon.fireRate;
        }

    }
}
