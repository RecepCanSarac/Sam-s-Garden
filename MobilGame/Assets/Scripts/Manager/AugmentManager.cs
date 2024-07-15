using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentManager : MonoBehaviour
{

    public List<AugmentUI> UIList = new List<AugmentUI>();


    public List<Augments> Augments = new List<Augments>();

    private void Start()
    {
        AssignRandomAugmentsToUI();
    }

    public void AssignRandomAugmentsToUI()
    {
        System.Random random = new System.Random();
        List<Augments> availableAugments = new List<Augments>(Augments);
        Augments previousAugment = null;

        for (int i = 0; i < UIList.Count; i++)
        {
            if (availableAugments.Count > 0)
            {
                Augments randomAugment;
                do
                {
                    int randomIndex = random.Next(availableAugments.Count);
                    randomAugment = availableAugments[randomIndex];
                } while (randomAugment == previousAugment && availableAugments.Count > 1);

                UIList[i].Setup(randomAugment.augment.AugmentLevel, randomAugment.augment.name, randomAugment.augment.AugmentImage, randomAugment.augment.AugmentDec, randomAugment.augment);

                previousAugment = randomAugment;
                availableAugments.Remove(randomAugment);
            }
        }
    }

}

[Serializable]
public class Augments
{
    public SOAugment augment;
    public AugmentType type;
}

public enum AugmentType
{
    normalAbilty,
    newAbility,
    Abilty
}