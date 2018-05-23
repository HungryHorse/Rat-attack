using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    float rechamberRate = 5f;
    public int isTutorial;
    public int GunChoice;
    public bool canShoot = true;
    Weapons currentWeapon;
    public GameObject SpawnPoint;
    public string FireSide;
    Vector3[] rots = new Vector3[3];
    public GameObject audioManager;

    void Start()
    {
        // This is used to get the object that stores all the guns that are in the game
        GameObject Gun = GameObject.Find("Guns");
        Guns gunScript = Gun.GetComponent<Guns>();

        isTutorial = PlayerPrefs.GetInt("Tutorial");

        // if isTutorial = 1 then it is the tutorial so you can't shoot until you enter the room that tells you how to
        if (isTutorial == 1)
        {
            GunChoice = 0;
            canShoot = false;
        }
        else
        {
            // this uses the name Fire1 or Fire2 to get the gun choice from player prefs whilst still allowing this script be the same for both left and right gun
            GunChoice = PlayerPrefs.GetInt(FireSide);
        }

        currentWeapon = new Weapons(gunScript.WeaponTypes[GunChoice]);
        
        // sets up the spawn rotation for the shot gun shot type
        rots[0] = new Vector3(0, 0, 0);
        rots[1] = new Vector3(0, 0, 8);
        rots[2] = new Vector3(0, 0, -8);

    }


	// Update is called once per frame
	void Update () {

        if (Input.GetButton(FireSide) && canShoot)
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
        //This is used for all the basic shot types (pistol, machine gun)
        if (currentWeapon.type == 0 && currentWeapon.rechamberTimer <= 0)
        {
            audioManager.GetComponent<AudioController>().PlayShotSound();
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

        // this is used for the shotgun as it spawns 3 bullets rather than one
        if (currentWeapon.type == 1 && currentWeapon.rechamberTimer <= 0)
        {
            audioManager.GetComponent<AudioController>().PlayShotSound();
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
