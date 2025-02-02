using System;
using UnityEngine;

namespace Enemy_AI
{
    public class GhostRed : GhostBase
    {
        public AudioSource ghostHit;
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("TriggerEvent")) RedGhostAttack();
        }
        private void RedGhostAttack()
        {
            if (ghostHit != null && ghostHit.clip != null)
            {
                ghostHit.PlayOneShot(ghostHit.clip);
            }
            //TODO damage the player work. Somehow.
            GhostTouch(this);
        }
    }
}