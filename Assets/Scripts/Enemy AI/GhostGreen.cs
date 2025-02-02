using Player;
using UnityEngine;

namespace Enemy_AI
{
    public class GhostGreen : GhostBase
    {
        public AudioSource ghostHit;
        [SerializeField] private Transform SendPlayerBackToOffice;

        [SerializeField] private BasePlayer PlayerRef;
        
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("TriggerEvent")) GreenGhostAttack();
        }
        private void GreenGhostAttack()
        {
            if (ghostHit != null && ghostHit.clip != null)
            {
                ghostHit.PlayOneShot(ghostHit.clip);
            }

            PlayerRef.PlayerRespawn();
            
            GhostTouch(this);
        }
    }
}