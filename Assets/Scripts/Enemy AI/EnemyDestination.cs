using System;
using UnityEngine;

namespace Enemy_AI
{
    public class EnemyDestination : GhostBase
    {
        [SerializeField] private float speed = 2.0f;
        
        [SerializeField] private GameObject PlayerRef;
        private bool lineOfSight = false;

        private void Update()
        {
            if (!lineOfSight) return;

            transform.position = Vector2.MoveTowards(transform.position, PlayerRef.transform.position, speed * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, PlayerRef.transform.position - transform.position);
            
            if (hit.collider == null) return;
            
            if (hit.collider.gameObject == PlayerRef)
            {
                Debug.DrawRay(transform.position, PlayerRef.transform.position - transform.position, Color.red);
                lineOfSight = true;
            }
            else
            {
                Debug.DrawRay(transform.position, PlayerRef.transform.position - transform.position, Color.green);
                lineOfSight = false;
            }
        }
    }
}