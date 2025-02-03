using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace System
{
    public class GameManager : MonoBehaviour
    {
        public GameObject GameOverUI;
        
        [SerializeField] private GameObject ResumeButton;
        [SerializeField] private GameObject RestartButton;
        [SerializeField] private GameObject CoffeeEnergyBar;
        
        [SerializeField] private BasePlayer PlayerRef;
        
        private InputSystem_Actions playerControls;
        private InputAction esc;

        private bool gameOver;
        
        public static GameManager instance;
        
        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);
            
            playerControls = new InputSystem_Actions();
        }
        private void OnEnable()
        {
            PlayerRef.OnPlayerDeath += GameOver;
            esc = playerControls.Player.ESCAPE;
            esc.Enable();
            
            CoffeeManager.OnCoffeeEnergyBarActive += ChangeCoffeeBarVisibility;
        }
        private void OnDisable()
        {
            PlayerRef.OnPlayerDeath -= GameOver;
            esc.Disable();
            
            CoffeeManager.OnCoffeeEnergyBarActive -= ChangeCoffeeBarVisibility;
        }
        private void Update()
        {
            if (gameOver) return;
            
            // PlayerInputHandler.MoveInput = esc.ReadValue<Vector2>();
            //
            // if (PlayerInputHandler.MoveInput != Vector2.zero)
            // {
            //     PauseButton();;
            // }
            if (Input.GetKeyDown(KeyCode.Escape)) PauseButton();
        }
        public void MainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
        public void RestartGame()
        {
            Time.timeScale = 1;
            GameOverUI.SetActive(false);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameOver = false;
        }
        public void ResumeGame()
        {
            Time.timeScale = 1;
            GameOverUI.SetActive(false);
        }
        private void PauseButton()
        {
            ResumeButton.SetActive(true);
            RestartButton.SetActive(false);
            Time.timeScale = 0;
            GameOverUI.SetActive(true);
        }
        private void GameOver()
        {
            RestartButton.SetActive(true);
            ResumeButton.SetActive(false);
            Time.timeScale = 0;
            GameOverUI.SetActive(true);

            gameOver = true;
        }
        
        private void ChangeCoffeeBarVisibility(bool isActive)
        {
            CoffeeEnergyBar.SetActive(isActive);
        }
    }
}