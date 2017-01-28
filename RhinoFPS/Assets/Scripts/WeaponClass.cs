using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponClass : MonoBehaviour
{
    public int AmmoCapacity = 100;
    public int Ammo;
    public MeshRenderer AmmoCounter;

	void Start ()
    {
        Ammo = AmmoCapacity;	
	}
	
    void Update () {
		
	}

    public void OnShoot()
    {
        Ammo -= 1;
        AmmoCounter.material.color = new Color(0, 1, 0, (float)Ammo / (float)AmmoCapacity);
        //play shoot animation
    }

    public void Reload()
    {
        Ammo = AmmoCapacity;
        AmmoCounter.material.color = new Color(0, 1, 0, (float)Ammo / (float)AmmoCapacity);
        //play reload animation
    }
}
