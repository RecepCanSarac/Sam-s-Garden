using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public enum LevelType
    {
        zero, one, two, three, four, five, six, seven, eight, nine, ten
    }

    public List<EnemyObjPool> enemyObjPools = new List<EnemyObjPool>();
    public static LevelType Type = LevelType.zero;
    private Transform target;

    private bool[] spawnerFlags;

    private void Start()
    {
        spawnerFlags = new bool[11];
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        CheckLevelAndSpawn();
    }

    private void CheckLevelAndSpawn()
    {
        if (!spawnerFlags[(int)Type])
        {
            StartCoroutine(Spawner((int)Type));
            spawnerFlags[(int)Type] = true;
        }
    }

    private IEnumerator Spawner(int index)
    {
        Debug.Log("Spawning enemies for level: " + index);
        for (int i = 0; i <= index; i++)
        {
            float x = Random.Range(target.position.x - 40, target.position.x + 40);
            float y = Random.Range(target.position.y - 40, target.position.y + 40);
            Vector2 randomPos = new Vector2(x, y);
            GameObject enemy = enemyObjPools[i].GetFromEnemyObjPool();
            if (enemy != null)
            {
                enemy.transform.position = randomPos;
                enemy.SetActive(true);
            }
        }
        yield return new WaitForSeconds(1.3f);
        StartCoroutine(Spawner(index));
    }
}
