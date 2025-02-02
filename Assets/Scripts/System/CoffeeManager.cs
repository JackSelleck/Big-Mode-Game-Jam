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
        [SerializeField] private float depletionRate = 0.2f;

        [SerializeField] private BasePlayer PlayerRef;

        public UnityAction OnCoffeeRefill;
        public UnityAction OnCoffeeDeplete;

        public static UnityAction<bool> OnCoffeeEnergyBarActive;

        private float currentCoffeeValue;
        public static CoffeeManager Instance { get; private set; }
        private void Start()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
            
            coffeeSlider.value = coffeeSlider.maxValue;
            currentCoffeeValue = coffeeSlider.value;
        }

        private void Update()
        {
            if (!(currentCoffeeValue >= 0f)) return;
            
            currentCoffeeValue -= Time.deltaTime * depletionRate;
            coffeeSlider.value = currentCoffeeValue;

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
            currentCoffeeValue = currentCoffeeValue - energyDrain;
            coffeeSlider.value = currentCoffeeValue;
            
            OnCoffeeDeplete?.Invoke();
        }
    }
}