using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player/Player")]
public class SOPlayer : ScriptableObject
{
    [Header("Sam Attributes")]
    public float Health;
    public float Speed;
    public float Experience;
    public float fireRate;
    public float Radius;

    public int SamsLevel = 1;
    [Header("Sam Number of Attack")]
    public int index;
}
