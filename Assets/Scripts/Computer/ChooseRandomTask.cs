using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseRandomTask : MonoBehaviour
{
    public TypingGame typingGame;
    private int taskDecider;

    void Start()
    {
        // Whatever number the int is assigned determines which task will play
        taskDecider = Random.Range(0,1);
        ChooseTask();
    }
    private void ChooseTask()
    {
        if (taskDecider == 0)
        {
            SceneManager.LoadScene("Typing Game");
        }
        if (taskDecider == 1)
        {
            SceneManager.LoadScene("Drawing Game");
        }
        if (taskDecider == 2)
        {
            SceneManager.LoadScene("Maze Game");
        }
    }

}
