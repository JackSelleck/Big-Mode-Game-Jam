using System;
using UnityEngine;

namespace Enemy_AI
{
    public class GhostBlue : GhostBase
    {
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("TriggerEvent")) BlueGhostAttack();
        }
        private void BlueGhostAttack()
        {
            //TODO implement drain energy. Somehow.
            
            CoffeeManager.Instance.DepleteCoffee();
            GhostTouch(this);
        }
    }
}