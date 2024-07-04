using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScripts : MonoBehaviour
{
    public SOBullet bullet;
    private BulletObjPool pool;

    private void Awake()
    {
        pool = GameObject.Find("BulletPool").GetComponent<BulletObjPool>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyManager enemy = collision.gameObject.GetComponent<EnemyManager>();
            enemy.TakeDamager(bullet.Damage);
            pool.ReturnBulletPool(this.gameObject);
        }
    }
}
