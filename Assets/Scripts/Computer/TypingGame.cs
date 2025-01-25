using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypingGame : MonoBehaviour
{
    private int decideText;
    public TextMeshProUGUI text;
    public TMP_InputField playersText;
    public void StartTask()
    {
        decideText = Random.Range(0, 20);
        DecideText();
    }
    private void DecideText()
    {
        if (decideText == 0) { text.text = "bigmode"; }
        if (decideText == 1) { text.text = "spagetti"; }
        if (decideText == 2) { text.text = "meatballs"; }
        if (decideText == 3) { text.text = "blueberry muffin"; }
        if (decideText == 4) { text.text = "well animal"; }
        if (decideText == 5) { text.text = "not even close baby!"; }
        if (decideText == 6) { text.text = "pizza butt"; }
        if (decideText == 7) { text.text = "ooh ooh ah ah"; }
        if (decideText == 8) { text.text = "muffin"; }
        if (decideText == 9) { text.text = "donkey kong december"; }
        if (decideText == 10){ text.text = "this game really makes you FEEL overworked"; }
        if (decideText == 11){ text.text = "huge drama"; }
        if (decideText == 12){ text.text = "goblins are real"; }
        if (decideText == 13){ text.text = "i want tacos"; }
        if (decideText == 14){ text.text = "Bigmode"; }
        if (decideText == 15){ text.text = "Bigmode"; }
        if (decideText == 16){ text.text = "Bigmode"; }
        if (decideText == 17){ text.text = "Bigmode"; }
        if (decideText == 18){ text.text = "Bigmode"; }
        if (decideText == 19){ text.text = "Bigmode"; }
        if (decideText == 20){ text.text = "Bigmode"; }
    }
    private void Update()
    {
        if (playersText.text == text.text)
        {
            SceneManager.LoadScene("Office");
            Debug.Log("Writing Task Complete");
        }
    }
}
