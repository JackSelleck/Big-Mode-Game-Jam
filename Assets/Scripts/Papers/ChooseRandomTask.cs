using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseRandomTask : MonoBehaviour
{
    private int taskDecider;
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
            taskDecider = Random.Range(0, 3);
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
