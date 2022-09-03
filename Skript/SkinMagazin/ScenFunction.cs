
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenFunction : MonoBehaviour
{
    public void ChangeScenByAddingIndex(int indexToAdd)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + indexToAdd);
    }

    public void Glav()
    {
        SceneManager.LoadScene(0);
    }
}
