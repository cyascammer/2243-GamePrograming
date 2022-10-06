using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    // Simple singleton script. This is the easiest way to create and understand a singleton script.
    [SerializeField] private PlayerHealthDisplay playerHealthDisplay;
    [SerializeField] private int life = 3;

    private void Awake()
    {
        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            playerHealthDisplay.HealthUpdate(life);
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        //SceneManager.LoadScene(GetCurrentBuildIndex());
        life--;
        playerHealthDisplay.HealthUpdate(life);
        if (life == 0)
        {
            MainMenu();
        }
        else
        {
            UpdateLevel(GetCurrentBuildIndex());
        }
    }

    public void UpdateLevel(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
        DOTween.KillAll();
    }

    public void MainMenu()
    {
        UpdateLevel(0);
        Destroy(gameObject);
    }
    public void LoadNextLevel()
    {
        var nextSceneIndex = GetCurrentBuildIndex() + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        UpdateLevel(nextSceneIndex);
        DOTween.KillAll();
    }

    private int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}