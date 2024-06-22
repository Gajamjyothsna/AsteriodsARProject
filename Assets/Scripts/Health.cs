using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AsteriodsARGame
{
    public class Health : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _currentHealth = 100;
        [SerializeField] private UnityEvent<int> OnReceiveDamage;
        [SerializeField] private UnityEvent OnZeroHealth;
        [SerializeField] private UnityEvent<int> OnReceiveHealth;
        #endregion

        #region Private Methods
        private void Start()
        {
            _currentHealth = _maxHealth;
        }
        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        public int MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        public void ReceiveDamage(int damageAmount)
        {
            CurrentHealth -= damageAmount;
            OnReceiveDamage?.Invoke(CurrentHealth);
            if (CurrentHealth <= 0)
            {
                OnZeroHealth?.Invoke();
            }
        }

        public void GainHealth(int gainAmount)
        {
            _currentHealth += gainAmount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            OnReceiveHealth?.Invoke(_currentHealth);
        }
        #endregion
    }
}
