using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Enemy")]
public class SOEnemy : ScriptableObject
{
    [field: SerializeField] public float MaxHealth { get; private set; }
    [field: SerializeField] public float damage { get; private set; }
    [field: SerializeField] public float speed { get; private set; }
    [field: SerializeField] public float XP { get; private set; }

    [field: SerializeField] public GameObject enemyPregab;


    public void TargetFallow(Transform thisTransform, Transform target)
    {
        Vector3 direction = thisTransform.position - target.position;

        thisTransform.position = Vector2.MoveTowards(thisTransform.position, target.position, speed * Time.deltaTime);
    }
}
