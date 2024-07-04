using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjPool : MonoBehaviour
{
    public const int bulletPoolObject_SIZE = 30;

    public GameObject bulletPrefab;
    private Queue<GameObject> bulletPool;
    void Start()
    {
        bulletPool = new Queue<GameObject>();
        for (int i = 0; i < bulletPoolObject_SIZE; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }
    public GameObject GetBulletFromPool()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        return null;
    }

    public void ReturnBulletPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

    public IEnumerator DisableBulletAfterDelay(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnBulletPool(bullet);
    }
}
