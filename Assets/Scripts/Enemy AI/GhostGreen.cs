using Player;
using UnityEngine;

namespace Enemy_AI
{
    public class GhostGreen : GhostBase
    {
        [SerializeField] private Transform SendPlayerBackToOffice;

        [SerializeField] private BasePlayer PlayerRef;
        
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("TriggerEvent")) GreenGhostAttack();
        }
        private void GreenGhostAttack()
        {
            PlayerRef.PlayerRespawn();
            
            GhostTouch(this);
        }
    }
}