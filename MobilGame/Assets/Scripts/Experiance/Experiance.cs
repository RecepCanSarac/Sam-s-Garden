using TreeEditor;
using UnityEngine;

public class Experiance : MonoBehaviour
{
    public delegate void addXP(float xp);
    public static event addXP experiance;



    [Header("Attributes")]
    public float radius;
    public LayerMask mask;
    private ItemObjPool pool;
    public float exp;
    private void Start()
    {
        pool = GameObject.Find("ItemPool").GetComponent<ItemObjPool>();
    }
    private void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, mask);

        if (hit != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, hit.transform.position, 1f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (experiance != null)
            {
                experiance?.Invoke(exp);
                pool.ReturnItemPool(this.gameObject);
            }
        }
    }
}
