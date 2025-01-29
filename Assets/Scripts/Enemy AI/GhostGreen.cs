using Player;
using UnityEngine;

namespace Enemy_AI
{
    public class GhostGreen : GhostBase
    {
        [SerializeField] private Transform SendPlayerBackToOffice;
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("TriggerEvent")) GreenGhostAttack();
        }
        private void GreenGhostAttack()
        {
            //TODO implement sending the player back to their desk. Somehow.
            
            BasePlayer.Instance.PlayerRespawn();
            
            // SendPlayerBackToOffice.position = Player.transform.position;
            
            GhostTouch(this);
        }
    }
}