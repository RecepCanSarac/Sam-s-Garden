using UnityEngine;

public abstract class SOAugment : ScriptableObject
{
    public abstract string AugmentName { get; set; }
    public abstract string AugmentDec { get; set; }
    public abstract Sprite AugmentImage { get; set; }
    public abstract string AugmentLevel { get; set; }
    public abstract void Augment();
}
