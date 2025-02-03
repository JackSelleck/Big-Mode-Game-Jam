using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy_AI
{
    public class GhostBlue : GhostBase

    {
        public AudioSource ghostHit;
        [Range(0.1f, 0.5f)][SerializeField] private float EnergyDrain = 0.1f;
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("TriggerEvent")) BlueGhostAttack();
        }
        private void BlueGhostAttack()
        {
            if (ghostHit != null && ghostHit.clip != null)
            {
                ghostHit.PlayOneShot(ghostHit.clip);
            }

            CoffeeManager.Instance.CoffeDrain(EnergyDrain);
            
            GhostTouch(this);
        }
    }
}