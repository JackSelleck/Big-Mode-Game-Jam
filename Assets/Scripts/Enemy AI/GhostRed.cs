using System;
using UnityEngine;

namespace Enemy_AI
{
    public class GhostRed : GhostBase
    {
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("TriggerEvent")) RedGhostAttack();
        }
        private void RedGhostAttack()
        {
            //TODO damage the player work. Somehow.
            Debug.Log("Red ghost attack");
            GhostTouch(this);
        }
    }
}