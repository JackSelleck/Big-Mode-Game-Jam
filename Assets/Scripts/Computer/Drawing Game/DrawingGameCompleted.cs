using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawingGameCompleted : MonoBehaviour
{
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
        SceneManager.LoadScene("Office");
    }
}
