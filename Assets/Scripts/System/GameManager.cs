using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace System
{
    public class GameManager : MonoBehaviour
    {
        public GameObject GameOverUI;
        [SerializeField] private BasePlayer PlayerRef;
        
        private void Start()
        {
            PlayerRef.OnPlayerDeath += GameOver;
        }

        public void RestartGame()
        {
            Time.timeScale = 1;
            GameOverUI.SetActive(false);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void MainMenu()
        {
            SceneManager.LoadScene(0);
        }
        private void GameOver()
        {
            Time.timeScale = 0;
            
            GameOverUI.SetActive(true);
        }
    }
}