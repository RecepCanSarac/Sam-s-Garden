using System.Collections.Generic;
using UnityEngine;

public class EnemyObjPool : MonoBehaviour
{
    public SOEnemy enemyObjPool;

    public int EnemyPool_Size;
    public Queue<GameObject> enemyPool;

    public MyEnum Type;
    private void Start()
    {
        enemyPool = new Queue<GameObject>();

        for (int i = 0; i < EnemyPool_Size; i++)
        {
            GameObject enemy = Instantiate(enemyObjPool.enemyPregab, transform);
            enemy.gameObject.SetActive(false);
            enemyPool.Enqueue(enemy);
        }
    }

    public GameObject GetFromEnemyObjPool()
    {
        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
            enemy.SetActive(true);
            return enemy;
        }
        return null;
    }

    public void ReturnPoolEnemy(GameObject enemy)
    {
        enemyPool.Enqueue(enemy);
        float health = enemy.GetComponent<EnemyManager>().enemy.MaxHealth;
        enemy.GetComponent<EnemyManager>().curretHealth = health;
        enemy.SetActive(false);
    }
}
