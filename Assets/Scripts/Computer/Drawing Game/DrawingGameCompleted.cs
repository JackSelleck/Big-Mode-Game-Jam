using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawingGameCompleted : MonoBehaviour
{
    public LimitPapersHeld LimitPapersHeld;
    public TasksCompleted tasksCompleted;
    public GameObject taskParent;
    public GameObject officeParent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        tasksCompleted.tasksCompleted++;
        LimitPapersHeld.papersHeld--;
        taskParent.SetActive(false);
        officeParent.SetActive(true);
        
        CoffeeManager.OnCoffeeEnergyBarActive?.Invoke(true);

        //SceneManager.LoadScene("Office");
    }
}
