using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this public array allows me to craete new weapons in the editor and store them, the shooting script then grabs the selected weapons from this array
public class Guns : MonoBehaviour {
    public Weapons[] WeaponTypes;
}
