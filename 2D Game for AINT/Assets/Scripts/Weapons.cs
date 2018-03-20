using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Weapons{

    public string name;
    public GameObject bullet;
    public int fireSpeed;
    public float bulletLifeTime;
    public float fireRate; //If using a beam will be how long inbetween damage ticks
    public int damage;
    public float rechamberTimer;
    public int type; // 0-Bullets, 1-Shotgun, 2-Laser (TODO: add more)


    //this way multiple things can use the same weapon but have their own instance
    public Weapons(Weapons ToCopy)
    {
        name = ToCopy.name;
        bullet = ToCopy.bullet;
        fireSpeed = ToCopy.fireSpeed * 100;
        bulletLifeTime = ToCopy.bulletLifeTime;
        fireRate = ToCopy.fireRate;
        damage = ToCopy.damage;
        rechamberTimer = ToCopy.rechamberTimer;
        type= ToCopy.type;
}
	
}
