using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ProjectilePickup : MonoBehaviour, Ipickupable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           pickedUp();
        }
    }

    public void pickedUp()
    {
        ProjectileManager.increaseAmmoCount();
        Debug.Log("picked up");
        Destroy(gameObject);
    }


}
