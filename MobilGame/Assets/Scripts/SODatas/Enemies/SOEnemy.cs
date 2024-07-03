using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Enemy")]
public class SOEnemy : ScriptableObject
{
    [Header("Enemy Attributes")]
    public float health;
    public float damage;
    public float speed;
    public float XP;
    [Header("Prefab")]
    public GameObject enemyPregab;
    public void TargetFallow(Transform thisTransform, Transform target)
    {
        Vector3 direction = thisTransform.position - target.position;

        thisTransform.position = Vector2.MoveTowards(thisTransform.position, target.position, speed * Time.deltaTime);
    }
}
