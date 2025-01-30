using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Enemy_AI
{
    public class GhostBase : MonoBehaviour
    {
        // public GameObject PlayerRef;
        
        protected NavMeshAgent agent;
        protected UnityEvent OnGhostTouch;
        protected SpriteRenderer sr;
        private void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
        protected void GhostTouch(GhostBase ghost)
        {
            ghost.OnGhostTouch?.Invoke();

            StartCoroutine(PauseEnemyMovement(ghost));
        }
        private static IEnumerator PauseEnemyMovement(GhostBase ghost)
        {
            ghost.agent.isStopped = true;
            yield return new WaitForSeconds(1.0f);
            ghost.agent.isStopped = false;
        }
    }
}
