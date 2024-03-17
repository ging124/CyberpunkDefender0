using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static public GameController instance;

    public float timeSurvival = 0;

    [SerializeField] protected Animator transition;

    [SerializeField] protected float transitionTime = 1f;

    void Awake()
    {
        GameController.instance = this;
        ContinueGame();
    }

    void Update()
    {
        timeSurvival += Time.deltaTime;
    }

    public void GameOver()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}