using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public delegate void TakeDamage(float damage);
    public static event TakeDamage damage;

    public SOEnemy enemy;
    public float curretHealth { get; set; }
    private float fireRate = 1.0f;
    private float nextTimeFireRate = 0.0f;

    private ItemObjPool poolItem;
    private EnemyObjPool enemyObjPool;
    private float xp;
    public MyEnum Type;
    private void Start()
    {
        poolItem = GameObject.Find("ItemPool").GetComponent<ItemObjPool>();

        curretHealth = enemy.MaxHealth;
        string type = Type.ToString();
        enemyObjPool = GameObject.Find(type).GetComponent<EnemyObjPool>();
        xp = enemy.XP;
    }
    public void TakeDamager(float damage)
    {
        curretHealth -= damage;

        if (curretHealth <= 0)
        {
            GameObject Item = poolItem.GetpoolFromItem();
            enemyObjPool.ReturnPoolEnemy(this.gameObject);
            if (Item != null)
            {
                Item.GetComponent<Experiance>().exp = xp;
                Item.transform.position = transform.position;
                Item.SetActive(true);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time > nextTimeFireRate)
            {
                nextTimeFireRate = Time.time + 1 / fireRate;
                damage?.Invoke(enemy.damage);
            }
        }
    }
}
public enum MyEnum
{
    BasicEnemyPool, NormalEnemyPool
}