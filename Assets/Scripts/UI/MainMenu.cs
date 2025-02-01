using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;
    
    private bool isCreditsActive;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreditsButton()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
        // creditsPanel.SetActive(active);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
