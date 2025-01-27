using System;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy_AI
{
    public class GhostBase : MonoBehaviour
    {
        // public GameObject PlayerRef;
        public static UnityEvent OnGhostTouch;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        protected void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnGhostTouch.Invoke();
            }
        }
    }
}
