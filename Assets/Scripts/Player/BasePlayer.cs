using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class BasePlayer : MonoBehaviour
    {
        public static BasePlayer Instance { get; private set; }

        [SerializeField] private Transform RespawnPoint;
        

        public UnityAction OnPlayerDeath;
        public UnityAction OnPlayerRespawn;
        
        private void Start()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        private void OnEnable() => OnPlayerDeath += PlayerDeath;
        
        private void OnDisable() => OnPlayerDeath -= PlayerDeath;
        

        private void PlayerDeath()
        {
            //TODO implement player death
            //TODO lose all progress. Somehow.

            
            gameObject.SetActive(false);
            Debug.Log("Player dead");
            
            PlayerRespawn();
            // StartCoroutine(PlayerRespawn());
            
        }
        
        private void PlayerRespawn()
        {
            transform.position = RespawnPoint.position;
            gameObject.SetActive(true);
            
            OnPlayerRespawn?.Invoke();
            // yield return new WaitForSeconds(2);
        }
        

        
    }
}