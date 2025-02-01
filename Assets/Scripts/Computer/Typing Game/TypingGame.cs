using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypingGame : MonoBehaviour
{
    public TasksCompleted tasksCompleted;
    private int decideText;
    public TextMeshProUGUI text;
    public TMP_InputField playersText;
    public GameObject typingGame;
    public GameObject Office;
    public void OnEnable()
    {
        decideText = Random.Range(0, 20);
        DecideText();
        playersText.Select();
    }
    private void OnDisable()
    {
        playersText.text = null;
    }
    private void DecideText()
    {
        if (decideText == 0) { text.text = "go bigmode"; }
        if (decideText == 1) { text.text = "spagetti"; }
        if (decideText == 2) { text.text = "meatballs"; }
        if (decideText == 3) { text.text = "blueberry muffin"; }
        if (decideText == 4) { text.text = "well animal"; }
        if (decideText == 5) { text.text = "not even close baby!"; }
        if (decideText == 6) { text.text = "pizza butt"; }
        if (decideText == 7) { text.text = "ooh ooh ah ah"; }
        if (decideText == 8) { text.text = "and i better get it too"; }
        if (decideText == 9) { text.text = "donkey kong december"; }
        if (decideText == 10){ text.text = "feel like batman"; }
        if (decideText == 11){ text.text = "huge drama"; }
        if (decideText == 12){ text.text = "goblins are real"; }
        if (decideText == 13){ text.text = "i want tacos"; }
        if (decideText == 14){ text.text = "mario bros 2"; }
        if (decideText == 15){ text.text = "frozen ape"; }
        if (decideText == 16){ text.text = "beeg yoshi"; }
        if (decideText == 17){ text.text = "ikon clan"; }
        if (decideText == 18){ text.text = "three beans please"; }
        if (decideText == 19){ text.text = "hogans castle"; }
        if (decideText == 20){ text.text = "bowsers big bean burrito"; }
    }
    private void Update()
    {
        if (playersText.text == text.text)
        {
            typingGame.SetActive(false);
            Office.SetActive(true);
            tasksCompleted.tasksCompleted++;
            //SceneManager.LoadScene("Office");
            Debug.Log("Writing Task Complete");
        }
    }
}
