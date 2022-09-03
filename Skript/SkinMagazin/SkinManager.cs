
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance;
    
    public static Sprite equippedSkin { get; private set; }
    public static ParticleSystem particleSystem { get; private set; }

    [SerializeField] private SSkininfo[] allSkins;
    private const string skinPref = "skinPref";

    [SerializeField] private Transform skinInShopPanelsParent;
    [SerializeField] private List<SkinShop> skinInShopPanels = new List<SkinShop>();

    private Button currentlyEguippedSkinButton;

    private void Awake()
    {
        Instance = this;
        
        foreach (Transform s in skinInShopPanelsParent)
        {
            if (s.TryGetComponent(out SkinShop skinShop))
                skinInShopPanels.Add(skinShop);
        }
        
        EquipPrevioussSkin();
        
        SkinShop skinEquippedPanel = Array.Find(skinInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinSprite == equippedSkin);
        currentlyEguippedSkinButton = skinEquippedPanel.GetComponentInChildren<Button>();
        currentlyEguippedSkinButton.interactable = false;
    }

    private void EquipPrevioussSkin()
    {
        string lastSkinUsed = PlayerPrefs.GetString(skinPref, SSkininfo.SkinIDs.White.ToString());
        SkinShop skinEquippedPanel = Array.Find(skinInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinID.ToString() == lastSkinUsed);
        EquipSkin(skinEquippedPanel);
    }

    public void EquipSkin(SkinShop skinInfoShop)
    {
        equippedSkin = skinInfoShop._skinInfo._skinSprite;
        particleSystem = skinInfoShop._skinInfo._particleSystem;
        PlayerPrefs.SetString(skinPref, skinInfoShop._skinInfo._skinID.ToString());
        
        if (currentlyEguippedSkinButton != null)
            currentlyEguippedSkinButton.interactable = true;
       
        currentlyEguippedSkinButton = skinInfoShop.GetComponentInChildren<Button>();
        currentlyEguippedSkinButton.interactable = false;
    }
}
