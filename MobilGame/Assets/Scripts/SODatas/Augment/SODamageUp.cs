using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Upgrade Augment", menuName = "Augmemts/Damage Upgrade Augment")]
public class SODamageUp : SOAugment
{
    [field: SerializeField] public override string AugmentName { get; set; }
    [field: SerializeField] public override string AugmentDec { get; set; }
    [field: SerializeField] public override Sprite AugmentImage { get; set; }
    [field: SerializeField] public override string AugmentLevel { get; set; }

    public override void Augment()
    {
        Debug.Log("Çalýþýyor");
    }
}
