using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Skin", menuName = "Create New Skin")]
public class SSkininfo : ScriptableObject
{
   public enum SkinIDs {White, Blue, pink, red, green, Orange, }
   [SerializeField] private SkinIDs skinID;
   public SkinIDs _skinID {get { return skinID; } }

   [SerializeField] private Sprite skinSprite;
   public Sprite _skinSprite {get { return  skinSprite; } }
   
   public enum  Money{skinPrice, diamond}
   [SerializeField] private Money money;
   public Money _money {get { return  money; } }

   [SerializeField] private int skinPrice;
   public  int _skinPrice {get { return skinPrice; } }

   [SerializeField] private int diamond;
   public int _diamond {get { return diamond; } }

   [SerializeField] private ParticleSystem particleSystem;
   public ParticleSystem _particleSystem{get {return particleSystem; } }

}
