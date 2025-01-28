using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CoffeeManager : MonoBehaviour
    {
        [SerializeField] private Slider coffeeSlider;
        [SerializeField] private float depletionRate = 0.1f;

        public UnityAction OnCoffeeRefill;
        public UnityAction OnCoffeeDeplete;

        private float currentCoffeeValue;
        private void Start()
        {
            coffeeSlider.value = coffeeSlider.maxValue;
            currentCoffeeValue = coffeeSlider.value;
        }

        private void Update()
        {
            if (!(currentCoffeeValue > 0f)) return;
            
            currentCoffeeValue -= Time.deltaTime * depletionRate;
            coffeeSlider.value = currentCoffeeValue;
            
            if (coffeeSlider.value <= 0) Debug.Log("Game Over");
        }
        
        public void RefillCoffee()
        {
            currentCoffeeValue = coffeeSlider.maxValue;
            coffeeSlider.value = currentCoffeeValue;
            
            OnCoffeeRefill?.Invoke();
        }

        public void DepleteCoffee()
        {
            currentCoffeeValue = coffeeSlider.minValue;
            coffeeSlider.value = currentCoffeeValue;
            
            OnCoffeeDeplete?.Invoke();
        }
    }
}