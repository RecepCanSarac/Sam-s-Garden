using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public delegate void TakeDamage(float damage);
    public static event TakeDamage damage;


    public SOEnemy enemy;
    public float curretHealth { get; private set; }
    private float fireRate = 1.0f;
    private float nextTimeFireRate = 0.0f;


    private ItemObjPool pool;
    private void Start()
    {
        pool = GameObject.Find("ItemPool").GetComponent<ItemObjPool>();
        curretHealth = enemy.health;
    }
    public void TakeDamager(float damage)
    {
        curretHealth -= damage;


        if (curretHealth <= 0)
        {
            GameObject Item = pool.GetpoolFromItem();

            if (Item != null)
            {
                Item.GetComponent<Experiance>().exp = enemy.XP;
                Item.transform.position = transform.position;
                Item.SetActive(true);
            }
            Destroy(this.gameObject);
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
