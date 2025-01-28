using System;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy_AI
{
    public class GhostBase : MonoBehaviour
    {
        // public GameObject PlayerRef;
        protected UnityEvent OnGhostTouch;
        
        
        protected static void GhostTouch(GhostBase ghost)
        {
            ghost.OnGhostTouch?.Invoke();
        }
        

    }
}
