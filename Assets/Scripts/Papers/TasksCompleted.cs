using UnityEngine;
using UnityEngine.SceneManagement;

public class TasksCompleted : MonoBehaviour
{
    public int availableTasks;
    public int tasksCompleted;

    void Update()
    {
        if (tasksCompleted == availableTasks)
        {
            SceneManager.LoadScene("Level2");
        }

    }

}
