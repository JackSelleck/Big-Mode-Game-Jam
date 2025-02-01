using System;
using Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace System
{
    public class CoffeeManager : MonoBehaviour
    {
        [SerializeField] private Slider coffeeSlider;
        [SerializeField] private float depletionRate = 0.6f;

        [SerializeField] private BasePlayer PlayerRef;

        [SerializeField] private GameObject CoffeeBarUI;
        
        
        public UnityAction OnCoffeeRefill;
        public UnityAction OnCoffeeDeplete;
        public static UnityAction<bool> OnCoffeDrain;

        public float currentCoffeeValue;
        private bool coffeeDrain = true;
        public static CoffeeManager Instance { get; private set; }
        private void Start()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
            
            coffeeSlider.value = coffeeSlider.maxValue;
            currentCoffeeValue = coffeeSlider.value;
        }

        private void OnEnable()
        {
            OnCoffeDrain += CoffeeDraining;
        }

        private void Update()
        {
            if (!coffeeDrain) return;
            if (!(currentCoffeeValue >= 0f)) return;
            
            currentCoffeeValue -= Time.deltaTime * depletionRate;
            coffeeSlider.value = currentCoffeeValue;

            Debug.Log("Coffee Value: " + currentCoffeeValue);

            if (!(coffeeSlider.value <= 0)) return;
            
            Debug.Log("Game Over");
            PlayerRef.OnPlayerDeath?.Invoke();
        }
        
        public void RefillCoffee()
        {
            currentCoffeeValue = coffeeSlider.maxValue;
            coffeeSlider.value = currentCoffeeValue;
            
            OnCoffeeRefill?.Invoke();
        }

        public void CoffeDrain(float energyDrain)
        {
            currentCoffeeValue = currentCoffeeValue * energyDrain;
            coffeeSlider.value = currentCoffeeValue;
            
            OnCoffeeDeplete?.Invoke();
        }

        private void CoffeeDraining(bool coffeeDraining)
        {
            // ChooseRandomTask.isInsideGame = !coffeeDraining;
            coffeeDrain = coffeeDraining;
            CoffeeBarUI.SetActive(coffeeDraining);
        }
    }
}