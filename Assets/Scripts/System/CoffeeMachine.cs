using UnityEngine;

namespace DefaultNamespace
{
    public class CoffeeMachine : MonoBehaviour
    {
        [SerializeField] private CoffeeManager coffeeManager;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Refill coffee");
            if (other.gameObject.CompareTag("TriggerEvent")) coffeeManager.RefillCoffee();
        }
    }
}