using UnityEngine;

public class ChooseRandomTask : MonoBehaviour
{
    public TypingGame typingGame;

    private int taskDecider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Whatever number the int is assigned determines which task will play
        taskDecider = Random.Range(0,0);
        ChooseTask();
    }
    private void ChooseTask()
    {
        if (taskDecider == 0)
        {
            typingGame.StartTask();
        }
    }

}
