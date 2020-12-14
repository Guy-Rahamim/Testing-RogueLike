using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float lifeTime;
    [SerializeField] public static int maxAmmoCount=5;
    [SerializeField] private static int currentAmmoCount=maxAmmoCount;
    private static TextMeshProUGUI ammoText;

    [SerializeField] ProjectilePickup pickup;

    void Start()
    {
        ammoText = GetComponentInChildren<TextMeshProUGUI>();    
        currentAmmoCount = 5;
    }

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

    public static bool decreaseAmmoCount()
    {
        if (currentAmmoCount-1< 0)
        {
            Debug.Log("No ammo left!");
            currentAmmoCount = 0;
            updateStats();
            return false;
        }

        currentAmmoCount--;
        updateStats();
        Debug.Log("decreased successfully: " + currentAmmoCount + "left.");
        return true;

    }
    public static void increaseAmmoCount()
    {
        currentAmmoCount++;

        if (currentAmmoCount>maxAmmoCount)
        {
            Debug.Log("Ammo full.");
            currentAmmoCount = maxAmmoCount;
        }
        else { Debug.Log("increased successfully: " + currentAmmoCount + "left."); }

        updateStats();
    }
    public static void updateStats()
    {
        ammoText.text = "Ammo Left: " + currentAmmoCount;
    }
}
