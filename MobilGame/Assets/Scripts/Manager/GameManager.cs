using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI secondText;
    [SerializeField] private TextMeshProUGUI minuteText;

    public static int second;
    public static int minute;

    private float timeRate = 1;
    private float nextTimeTimeRate;

    private void Start()
    {
        nextTimeTimeRate = Time.time + 1 / timeRate;
    }

    private void Update()
    {
        if (Time.time >= nextTimeTimeRate)
        {
            Timer();
            secondText.text = second < 10 ? "0" + second.ToString() : second.ToString();
            minuteText.text = minute < 10 ? "0" + minute.ToString() + " : " : minute.ToString() + " : ";
            nextTimeTimeRate = Time.time + 1 / timeRate;

            if (minute >= 1 && minute <= 10)
            {
                SpawnManager.Type = (SpawnManager.LevelType)minute;
                Debug.Log("SpawnManager Type updated to: " + SpawnManager.Type);
            }
            else
            {
                SpawnManager.Type = SpawnManager.LevelType.zero;
            }
        }
    }

    public int Timer()
    {
        second++;
        if (second == 60)
        {
            second = 0;
            minute++;
        }
        return second;
    }
}
