using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public SOPlayer player;
    public float currentXP;
    public int currentLevel = 1;
    public int xpToNextLevel = 100;
    public float currentHealth { get; private set; }
    public ExperianceBar exp;
    private void OnEnable()
    {
        Experiance.experiance += XPAdded;
        EnemyManager.damage += TakeDamage;
    }
    private void OnDisable()
    {
        Experiance.experiance -= XPAdded;
        EnemyManager.damage -= TakeDamage;
    }

    void Start()
    {
        currentHealth = player.Health;
    }
    #region TakeDamage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            Debug.Log("Oyunu Kaybettin!");
            Destroy(this.gameObject);
        }
    }
    #endregion


    public void XPAdded(float amount)
    {
        currentXP += amount;
        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
        exp.UpdateSlider();
    }
    void LevelUp()
    {
        currentXP -= xpToNextLevel;
        currentLevel++;
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.1f);
        exp.levelSlider.maxValue = xpToNextLevel;
    }
}
