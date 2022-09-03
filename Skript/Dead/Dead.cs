using System.Collections;
using UnityEngine;
using TMPro;
using Skript.ADS;


public class Dead : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject hol1;

    [SerializeField] private AudioSource _audioSource;




    [SerializeField]  Ads ads;
    private static int numberDead;
    

    private Menu menu;

    [SerializeField] private bool PauseGame;
    [SerializeField] private GameObject pauseGameMenu;

    [SerializeField] private TextMeshProUGUI textMesh;
    
    private void Start()
    {
        animator = GameObject.Find(nameof(hol1)).GetComponent<Animator>();
        anim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        anim.SetBool("Shake", false);
        Reqvest();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _audioSource.Play();
            Instantiate(SkinManager.particleSystem, transform.position, Quaternion.identity);
            animator.SetTrigger("Ded");
            anim.SetBool("Shake", true);
            Lose();
            PauseMenu();
        }
    }

    public void PauseMenu()
    {
        StartCoroutine(Animka());

        IEnumerator Animka()
        {
            yield return new WaitForSeconds(0.5f);
            pauseGameMenu.SetActive(true);
            Time.timeScale = 0;
            Spawn.speed = 1f;
            PauseGame = true;
            PlayerMoney.Instance.SaveMoney();
            PlayerMoney.Instance.SaveDiamond();
            ScoreController.Instance.CheckNewHigscore();
            textMesh.text = ScoreController.Instance.scoreText.text;
            Reqvest();
            Destroy(hol1);
        }
    }

    private void Lose()
    {
        numberDead++;
    }

    public void Reqvest()
    {
        if (numberDead == 0)
            return;
            
        
        ads.RequestInterstitial();

             if (numberDead % 3 == 0)
             {
                 if (ads.interstitial.IsLoaded())
                 {
                     ads.interstitial.Show();
                 }
             }
    }

}
