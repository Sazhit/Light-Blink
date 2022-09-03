using UnityEngine;

public class Destroer : MonoBehaviour
{
    [SerializeField] private Spawn spawn;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Cub"))
        {
            spawn.Repeat();
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Cub_1"))
        {
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Cub"))
        {
            spawn.Repeat();
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Cub_1"))
        {
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
        
    }
}
