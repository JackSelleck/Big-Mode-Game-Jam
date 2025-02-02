using UnityEngine;
using UnityEngine.SceneManagement;

public class TasksCompleted : MonoBehaviour
{
    public int availableTasks;
    public int tasksCompleted;
    public string NextSceneName;

    void Update()
    {
        if (tasksCompleted >= availableTasks)
        {
            SceneManager.LoadScene(NextSceneName);
        }

    }

}
