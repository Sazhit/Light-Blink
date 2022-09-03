using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] easy;
    [SerializeField] private GameObject[] medium;
    [SerializeField] private float timeStep;

    private int _randX;
    
    public static float speed = 1f;
    public float chengeSpeed;


    public float x;
    public float y;

    private Vector2 whereToSpawn;
    
    
    private void Start()
    {
        Repeat();
    }

    private void Update()
    {
        speed += Time.deltaTime * chengeSpeed;
    }
    
    public void Repeat()
    {
        if (ScoreController.Instance.scoreTraveled < 200)
        {
            _randX = Random.Range(0, easy.Length);
            whereToSpawn = new Vector2(x, y);
            Instantiate(easy[_randX], whereToSpawn, Quaternion.identity);
        }

        if (ScoreController.Instance.scoreTraveled > 200)
        {
            _randX = Random.Range(0, medium.Length);
            whereToSpawn = new Vector2(x, y);
            Instantiate(medium[_randX], whereToSpawn, Quaternion.identity);
        }
    }

   
}
