using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseRandomTask : MonoBehaviour
{
    public List<int> taskOptions = new List<int> { 0, 1, 2 };

    public GameObject officeMap;
    public GameObject writingTask;

    public int lastChosenTask; // Store last chosen task
    public int taskDecider;
    public TextMeshProUGUI text;

    private void OnTriggerEnter2D(Collider2D collision)
    {    
        if (collision.CompareTag("Papers"))
        {
            text.enabled = true;
            text.text = ("E to Start Task");
            Debug.Log("Desk Collision");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Papers") && Input.GetKey(KeyCode.E))
        {
            Debug.Log("Task Started");
            ChooseTask();
            collision.gameObject.SetActive(false);        
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Papers"))
        {
            text.enabled = false;
        }
    }

    private void ChooseTask()
    {
        // Remove the last chosen task from the list
        if (lastChosenTask == taskDecider)
        {
            taskOptions.Remove(lastChosenTask);
        }

        // Pick a random task from the remaining options
        taskDecider = taskOptions[Random.Range(0, taskOptions.Count)];

        lastChosenTask = taskDecider; // Store this as the last task

        Debug.Log($"Chosen task: {taskDecider}");

        // Load the corresponding scene
        switch (taskDecider)
        {
            case 0:
                SceneManager.LoadScene("Typing Game");
                //writingTask.SetActive(true);
                //officeMap.SetActive(false);
                break;
            case 1:
                SceneManager.LoadScene("Drawing Game");

                break;
            case 2:
                SceneManager.LoadScene("Maze Game");
                break;
        }

    }

}
