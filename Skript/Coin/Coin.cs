
using UnityEngine;


public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;

    [SerializeField] public AuidoManager auidoManager;

    public void Start()
    {
        auidoManager = FindObjectOfType<AuidoManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(particleSystem, transform.position, Quaternion.identity);
            auidoManager.PlayClipByName(_clipName: "coin");
            PlayerMoney.Instance.AddMoney();
            PlayerMoney.Instance.SaveMoney();
            Destroy(gameObject);
        }
    }
}
