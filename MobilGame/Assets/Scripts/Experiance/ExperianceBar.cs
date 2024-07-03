using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ExperianceBar : MonoBehaviour
{
    public Slider levelSlider;
    private PlayerManager playerManager;
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        UpdateSlider();
    }

    private void Update()
    {

    }
    public void UpdateSlider()
    {
        levelSlider.maxValue = playerManager.xpToNextLevel;
        levelSlider.value = playerManager.currentXP;
    }
}
