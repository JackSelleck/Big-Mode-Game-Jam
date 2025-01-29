using UnityEngine;

namespace Player
{
    public class PlayerOfficeDesk : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("TriggerEvent")) Debug.Log("Player at office desk");
        }
    }
}