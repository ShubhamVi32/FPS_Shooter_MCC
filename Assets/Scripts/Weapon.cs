using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Bullet;
    public float fireRate;
    public Transform FirePoint;
    public int currentAmmo, RefilAmount;

    public float fireCounter;
    public bool canAutoFire;


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = RefilAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if(fireCounter > 0)
        {
            fireCounter -= Time.deltaTime;
        }
    }

    public void ReloadAmmo()
    {
        currentAmmo = RefilAmount;
    }
}
