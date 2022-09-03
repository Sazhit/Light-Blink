using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 2;
            Speed();
            Destroy(gameObject);
        }
    }

    private void Speed()
    {
        StartCoroutine(StartBoost());
        
        IEnumerator StartBoost()
        {
            yield return new WaitForSeconds(1);
            Time.timeScale = 1;
        }
    }
}
