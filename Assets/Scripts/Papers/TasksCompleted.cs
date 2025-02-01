using UnityEngine;

public class TasksCompleted : MonoBehaviour
{
    public int availableTasks;
    public int tasksCompleted;

    void Update()
    {
        if (tasksCompleted == availableTasks)
        {
            // Load Next Game
        }

    }

}
