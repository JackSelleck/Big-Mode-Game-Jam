using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy_AI
{
    public class EnemyDestination : GhostBase
    {
        [SerializeField] private float speed = 2.0f;

        [SerializeField] private GameObject PlayerRef;
        [SerializeField] private EnemyPatrolling Patrol;
        
        private bool lineOfSight = false;
        private void Update()
        {
            if (!agent.isOnNavMesh) return;

            //TODO Flip the sprite when the player is behind the enemy.
            // sr.flipX = PlayerRef.transform.position.x < transform.position.x;

            switch (lineOfSight)
            {
                case true:
                    agent.SetDestination(PlayerRef.transform.position);
                    break;
                case false when agent.remainingDistance < 0.5f:
                    Patrol.FollowWayPoints(agent);
                    break;
            }
            
            FlipSpriteOnDestination();
        }

        private void FixedUpdate()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, PlayerRef.transform.position - transform.position);
            
            if (hit.collider == null) return;
            
            lineOfSight = hit.collider.gameObject == PlayerRef;

            if (lineOfSight) sr.flipX = PlayerRef.transform.position.x < transform.position.x;
            
            Debug.DrawRay(transform.position, PlayerRef.transform.position - transform.position, lineOfSight ? Color.red: Color.clear);
        }
        
        private void FlipSpriteOnDestination()
        {
            if (lineOfSight) return; 

            Vector2 velocity = agent.velocity; 
            
            if (Mathf.Abs(velocity.x) > 0.01f) 
            {
                sr.flipX = velocity.x < 0;
            }
        }
    }
}