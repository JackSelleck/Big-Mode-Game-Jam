using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Player
{
    public class BasePlayer : MonoBehaviour
    {
        public static BasePlayer Instance { get; private set; }
        
        public bool PlayerIsDead { get; private set; }

        [SerializeField] private Transform RespawnPoint;
        
        private Rigidbody2D rb;
        private SpriteRenderer sr;
        
        public UnityAction OnPlayerDeath;
        public UnityAction OnPlayerRespawn;
        
        private void Start()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);

            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
        }

        private void OnEnable() => OnPlayerDeath += PlayerDeath;
        private void OnDisable() => OnPlayerDeath -= PlayerDeath;
        private void PlayerDeath()
        {
            PlayerIsDead = true;
            //TODO lose all progress. Somehow.
            // gameObject.SetActive(false);
            // Debug.Log("Player dead");
            
            
            // //TODO experiment with this later.
            // // sr.enabled = false;
            // // rb.bodyType = RigidbodyType2D.Static;
            // //lerp the player color from yellow to clear
            //
            // // PlayerRespawn();
            // // StartCoroutine(PlayerRespawn());
            // // Invoke(nameof(PlayerRespawn), 2);
            //
            // //TODO instead of respawn. Just reload the scene.
            //
            // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            // SceneManager.LoadScene(currentSceneIndex);
        }
        public void PlayerRespawn()
        {
            transform.position = RespawnPoint.position;
            gameObject.SetActive(true);
            
            OnPlayerRespawn?.Invoke();
            // yield return new WaitForSeconds(2);
        }
    }
}