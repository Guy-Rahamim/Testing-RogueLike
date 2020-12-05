using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float lifeTime;

    [SerializeField] ProjectilePickup pickup;

    // Start is called before the first frame update
    void Start()
    {

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
}
