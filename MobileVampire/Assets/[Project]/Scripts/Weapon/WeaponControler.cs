using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//TODO WEAPON : Aoe de dmg
//TODO WEAPON : Tire dans la direction des mob
//TODO WEAPON : Attaque cac dans la direction de deplacement 
//TODO WEAPON : laisse une trainer aoe dmg 


public class WeaponControler : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weaponList;


    public void AddWeapon(Weapon toAdd)
    {
        Weapon w = Instantiate(toAdd, transform);
    }
}
