using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    
    [SerializeField] public AuidoManager _auidoManager;
    
    public void Start()
    {
        _auidoManager = FindObjectOfType<AuidoManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(particleSystem, transform.position, Quaternion.identity);
            _auidoManager.PlayClipByName(_clipName: "Diamond");
            PlayerMoney.Instance.moneyDiamond();
            PlayerMoney.Instance.SaveDiamond();
            Destroy(gameObject);
        }
    }
}
