using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponClass : MonoBehaviour
{
    public int AmmoCapacity = 100;
    public int Ammo;
    public int AmmoUsedPerShot = 10;
    public MeshRenderer AmmoCounter;

	void Start ()
    {
        Ammo = AmmoCapacity;	
	}
	
    void Update () {
		
	}

    public void OnShoot()
    {
        Ammo -= AmmoUsedPerShot;
        UpdateCounter();
        //play shoot animation
    }

    public void Reload()
    {
        if (Ammo < AmmoCapacity)
        {
            Ammo = AmmoCapacity;
            UpdateCounter();
            //play reload animation
        }
    }

    void UpdateCounter()
    {
        AmmoCounter.material.color = new Color(0, 1, 0) * ((float)Ammo / (float)AmmoCapacity);
    }
}
