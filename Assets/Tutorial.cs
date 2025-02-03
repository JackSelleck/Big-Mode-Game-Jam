using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public LimitPapersHeld PapersHeld;
    private bool paperTutorial = true;
    private TextMeshProUGUI text;
    private bool DeskTutorial = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void OnDisable()
    {
        DeskTutorial = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PapersHeld.papersHeld == 0 && paperTutorial == true)
        {
            text.text = ("Grab a paper!");
        }
        if (PapersHeld.papersHeld >= 1)
        {
            paperTutorial = false;
        }
        if (paperTutorial == false && DeskTutorial == true)
        {
            text.text = ("Now, bring the paper to your desk and press E");
        }
        if (DeskTutorial == false)
        {
            text.text = ("Good job! Now just make sure you dont run out of coffee...");
            StartCoroutine(RemoveGoodJobText());
        }

    }
    private IEnumerator RemoveGoodJobText()
    {
        yield return new WaitForSeconds(5);
        this.gameObject.SetActive(false);
    }
}
