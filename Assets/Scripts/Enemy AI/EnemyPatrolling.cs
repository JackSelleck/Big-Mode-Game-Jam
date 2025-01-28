using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy_AI
{
    public class EnemyPatrolling : MonoBehaviour
    {
        [SerializeField] private Transform[] waypoints;
        
        private int waypointIndex = 0;
        
        
        public void GetRandomWayPoint(NavMeshAgent agent)
        {
            if (!(agent.remainingDistance < 0.5f)) return;
            
            int index = IterateWaypoint();
            agent.SetDestination(waypoints[index].position);
            Debug.DrawRay(transform.position, waypoints[index].position - transform.position, Color.magenta, 1.5f);
        }
        
        private int IterateWaypoint()
        {
            waypointIndex++;

            if (waypointIndex >= waypoints.Length) waypointIndex = 0;

            return waypointIndex;
        }
    }
}