using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AugmentUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI AugmentLevelText;
    [SerializeField] TextMeshProUGUI AugmentNameText;
    [SerializeField] Image AugmentImage;
    [SerializeField] TextMeshProUGUI AugmentDescText;

    public SOAugment augment;

    public void Setup(string _level, string _name, Sprite _image, string _desc, SOAugment _augmnet)
    {
        augment = _augmnet;
        AugmentLevelText.text = _level;
        AugmentNameText.text = _name;
        AugmentImage.sprite = _image;
        AugmentDescText.text = _desc;
        GetComponent<Button>().onClick.AddListener(delegate { Activeted(); });
    }

    public void Activeted()
    {
        augment.Augment();
    }
}
