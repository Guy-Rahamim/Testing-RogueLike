using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempSpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiateRoom2()
    {
        EnemyMovement enem1 = Instantiate(enemyPrefab, new Vector3(-3f, 22f, 0), Quaternion.identity);
        EnemyMovement enem2 = Instantiate(enemyPrefab, new Vector3(7f, 15f, 0), Quaternion.identity);
    }

   public  void instantiateRoom1()
    {
        EnemyMovement enem1 = Instantiate(enemyPrefab, new Vector3(6.39f, -8.28f, 0), Quaternion.identity);
    }
}
