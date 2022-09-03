using System.Collections;
using Skript.ADS;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private Banner _banner;
    
    [SerializeField] bool PauseGame;
    [SerializeField] GameObject pauseGameMenu;
    

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }
    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0;
        PauseGame = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(Animka());

        IEnumerator Animka()
        {
            yield return new WaitForSeconds(0.1f);
            SceneManager.LoadScene(0);
        }
    }

    public void Shop()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        _banner.BannerDestroy();
    }

    public void PauseMenu()
    {
        StartCoroutine(Animka());

        IEnumerator Animka()
        {
            yield return new WaitForSeconds(0.2f);
            pauseGameMenu.SetActive(true);
            Time.timeScale = 0;
            PauseGame = true;
        }
    }

    public void Restart()
    {
        StartCoroutine(TimeRestrt());
        _banner.BannerDestroy();

        IEnumerator TimeRestrt()
        {
            Time.timeScale = 1;
            yield return new WaitForSeconds(0.1f);
            SceneManager.LoadScene(2);
        }
    }
}
