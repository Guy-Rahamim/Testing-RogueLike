using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] int nodeCounter;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        for (int i = 0; i < nodeCounter; i++)
        {
           
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
