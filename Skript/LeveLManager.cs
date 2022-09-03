using UnityEngine;


public class LeveLManager : MonoBehaviour
{
    public static LeveLManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }
}
