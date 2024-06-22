using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AsteriodsARGame
{
    public class MakeDamage : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private int _damagePower = 10;
        [SerializeField] private string _tagToCompare = "Player";
        [SerializeField] private UnityEvent OnTrigger;
        #endregion

        #region Private Methods
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_tagToCompare))
            {
                if (other.TryGetComponent(out Health health))
                {
                    if (health.enabled)
                    {
                        health.ReceiveDamage(_damagePower);
                        OnTrigger?.Invoke();
                    }
                }
            }
        }
        #endregion
    }
}
