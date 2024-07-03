using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Enemy")]
public class SOEnemy : ScriptableObject
{
    [Header("Enemy Attributes")]
    public float health;
    public float damage;
    public float speed;
    public float XP;

}
