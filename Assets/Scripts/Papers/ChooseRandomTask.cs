using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseRandomTask : MonoBehaviour
{
    public List<int> taskOptions = new List<int> {};

    public GameObject officeMap;

    public GameObject writingTask;

    public GameObject MazeTask1;
    public GameObject MazeTask2;
    public GameObject MazeTask3;
    public GameObject MazeTask4;
    public GameObject MazeTask5;

    public GameObject BallTask1;
    public GameObject BallTask2;
    public GameObject BallTask3;
    public GameObject BallTask4;
    public GameObject BallTask5;

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
            collision.gameObject.SetActive(false);
            Debug.Log("Task Started");
            ChooseTask();        
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
        if (taskOptions.Count == 0)
        {
            taskOptions.Add(15);
        }

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
                //SceneManager.LoadScene("Typing Game");
                writingTask.SetActive(true);
                officeMap.SetActive(false);
                break;
            case 1:
                //SceneManager.LoadScene("Drawing Game");
                writingTask.SetActive(true);
                officeMap.SetActive(false);
                break;
            case 2:
                writingTask.SetActive(true);
                officeMap.SetActive(false);
                //SceneManager.LoadScene("Maze Game");
                break;
            case 3:
                writingTask.SetActive(true);
                officeMap.SetActive(false);
                break;
            case 4:
                writingTask.SetActive(true);
                officeMap.SetActive(false);
                break;
            case 5:
                writingTask.SetActive(true);
                officeMap.SetActive(false);
                break;
            case 6:
                MazeTask1.SetActive(true);
                officeMap.SetActive(false);
                break;
            case 7:
                MazeTask2.SetActive(true);
                officeMap.SetActive(false);
                break;
            case 8:
                MazeTask3.SetActive(true);
                officeMap.SetActive(false);
                break;
            case 9:
                MazeTask4.SetActive(true);
                officeMap.SetActive(false);
                break;
            case 10:
                MazeTask5.SetActive(true);
                officeMap.SetActive(false);
                break;
            case 11:
                BallTask1.SetActive(true);
                officeMap.SetActive(false);
                break;
            case 12:
                BallTask2.SetActive(true);
                officeMap.SetActive(false);
                break;
            case 13:
                BallTask3.SetActive(true);
                officeMap.SetActive(false);
                break;
            case 14:
                BallTask4.SetActive(true);
                officeMap.SetActive(false);
                break;
            case 15:
                BallTask5.SetActive(true);
                officeMap.SetActive(false);
                break;




        }

    }

}
