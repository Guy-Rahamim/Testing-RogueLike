using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private static EnemySpawner enemy;
    public static int enemyMax = 1;
   public static int enemyCount = enemyMax;


    public static EnemySpawner instance
    {
        get
        {
            if (!enemy)
            {
                enemy = GameObject.FindObjectOfType<EnemySpawner>();
            }
            return enemy;
        }
    }

    private void Awake()
    {
      //  DontDestroyOnLoad(gameObject);
    }


    public static void decreaseEnemyCount()
    {
        enemyCount--;
        if (enemyCount<=0)
        {
            enemyCount = 0;
           spawnEnemy();
        }
    }

    public static void spawnEnemy()
    {
       // EnemyMovement enemy = Instantiate(General.enemy, new Vector3(0,0,0), Quaternion.identity);
    }
}
