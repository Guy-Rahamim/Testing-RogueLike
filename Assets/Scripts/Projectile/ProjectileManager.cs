using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float lifeTime;
    [SerializeField] private int currentAmmoCount;
    [SerializeField] public int maxAmmoCount;

    [SerializeField] ProjectilePickup pickup;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmoCount = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float getSpeed()
    {
        return speed;
    }

    public float getLifeTime()
    {
        return lifeTime;
    }

    public void instantiateProjectilePickup(Vector3 position)
    {
       ProjectilePickup proj= Instantiate(pickup, position, Quaternion.identity);
    }

    public bool decreaseAmmoCount()
    {
        if (currentAmmoCount-1< 0)
        {
            currentAmmoCount = 0;
            return false;
        }

        currentAmmoCount--;
        return true;

    }

    public void increaseAmmoCount()
    {
        currentAmmoCount++;
        if (currentAmmoCount>maxAmmoCount)
        {
            currentAmmoCount = maxAmmoCount;
        }
    }
}
