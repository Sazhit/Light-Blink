using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
   public static PlayerMoney Instance;
   
   [SerializeField] private  int playerMoney;//SFD

   [SerializeField] public int diamondMoney;

   private const string prefMoney = "prefMoney";
   private const string dianondMoney = "dianondMoney";
   
   [SerializeField] public TextMeshProUGUI coinText;
   [SerializeField] public TextMeshProUGUI diamondText;

   private void Awake()
   {
      Instance = this;
      
      playerMoney = PlayerPrefs.GetInt(prefMoney);

      diamondMoney = PlayerPrefs.GetInt(dianondMoney);
   }

   private void Start()
   {
      coinText.text = "" +playerMoney;
      diamondText.text = "" + diamondMoney;
   }

   public bool TryRemoveMoney(int moneyToRemov)
   {
      if (playerMoney >= moneyToRemov)
      {
         playerMoney -= moneyToRemov;
         coinText.text = ""  + playerMoney;
         PlayerPrefs.SetInt(prefMoney, playerMoney);
         Debug.Log("Robotaetqqq");
         return true;
      }
      else
      {
         return false;
      }
   }

   public bool DiamondRemoveMoney(int domondToRemov)
   {
      if (diamondMoney >= domondToRemov)
      {
         diamondMoney -= domondToRemov;
         diamondText.text = "" + diamondMoney;
         PlayerPrefs.SetInt(dianondMoney, diamondMoney);
         return true;
      }
      else
      {
         return false;
      }
   }

   public void AddMoney()
   {
      playerMoney++;
      coinText.text = "" + playerMoney;
      PlayerPrefs.SetInt(prefMoney, playerMoney);
   }

   public void moneyDiamond()
   {
      diamondMoney++;
      diamondText.text = "" + diamondMoney;
      PlayerPrefs.SetInt(dianondMoney, diamondMoney);
   }

   public void SaveMoney()
   {
      PlayerPrefs.SetInt(prefMoney, playerMoney);
   }

   public void SaveDiamond()
   {
      PlayerPrefs.SetInt(dianondMoney, diamondMoney);
      Debug.Log("Robotaet");
   }
}
