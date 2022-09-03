using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;

    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI Highscore;
    [HideInInspector] public float scoreTraveled;
    [HideInInspector] public bool isTraveling;

    public const string prefScore = "prefScore";

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Highscore.text += PlayerPrefs.GetInt(prefScore);
    }

    private void Update()
    {
        Score();
    }

    public void StartScript()
    {
        isTraveling = true;
    }

    public void Score()
    {
        if (!isTraveling)
            return;

        scoreTraveled += Time.deltaTime * 5;
        scoreText.text = (int)scoreTraveled + "";
    }

    public void CheckNewHigscore()
    {
        if ((int)scoreTraveled > PlayerPrefs.GetInt(prefScore))
        {
            //new Highscore
            PlayerPrefs.SetInt(prefScore, (int)scoreTraveled);

            Debug.Log("new Highscore: " + (int)scoreTraveled);
        }
        else
        {
            //no new Highscore
            Debug.Log("NO new Hoghscore");
        }
    }
}
