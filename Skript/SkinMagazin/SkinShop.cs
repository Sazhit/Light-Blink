using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkinShop : MonoBehaviour
{
    [SerializeField] private SSkininfo skinInfo;
    public  SSkininfo _skinInfo { get{ return skinInfo; } }
    
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Image skinImage;

    [SerializeField] private bool isSkinUnlocked;
    [SerializeField] private bool isFreeSkin;
    private void Awake()
    {
        skinImage.sprite = skinInfo._skinSprite;

        if (isFreeSkin)
        {
            PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
        }

        IsSkinUnlocked();
        IsSkinUnlocked_1();
    }

    private void IsSkinUnlocked()
    {
        if (PlayerPrefs.GetInt(skinInfo._skinID.ToString()) == 1)
        {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
        }
        else if (_skinInfo._money == SSkininfo.Money.skinPrice)
        {
            buttonText.text = "Buy" + ":"+ skinInfo._skinPrice;
        }
    }
    
    private void IsSkinUnlocked_1()
    {
        if (PlayerPrefs.GetInt(skinInfo._skinID.ToString()) == 1)
        {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
        }
        else if (_skinInfo._money == SSkininfo.Money.diamond)
        {
            buttonText.text = "Buy" + ":"+ skinInfo._diamond;
        }
    }
    
    public void OnButtonPress()
    {
        if (isSkinUnlocked)
        {
            //equip
            SkinManager.Instance.EquipSkin(this);
        }
        else
        {
            //buy
            if (PlayerMoney.Instance.TryRemoveMoney(skinInfo._skinPrice))
            {
                PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
                IsSkinUnlocked();
            }
            
        }
        
    }
    public void DiamondButton()
    {
        if (isSkinUnlocked)
        {
            //equip
            SkinManager.Instance.EquipSkin(this);
        }
        else
        {
            //buy
            if (PlayerMoney.Instance.DiamondRemoveMoney(skinInfo._diamond))
            {
                PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
                IsSkinUnlocked_1();
            }
            
        }
        
    }
}
