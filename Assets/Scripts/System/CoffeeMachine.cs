using UnityEngine;

namespace System
{
    public class CoffeeMachine : MonoBehaviour
    {
        // [SerializeField] private CoffeeManager coffeeManager;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("TriggerEvent")) CoffeeManager.Instance.RefillCoffee();
        }
    }
}