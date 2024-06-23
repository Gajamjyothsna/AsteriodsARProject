using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AsteriodsARGame
{
    public class HealthItem : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private string _tagToCompare = "Player"; 
        [SerializeField] private int _healingPower = 10;
        [SerializeField] private UnityEvent OnHeal; //Event you can trigger so you know when the player collides with the Health Item.  
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(_tagToCompare))
            {
                if(other.TryGetComponent (out Health health))
                {
                    health.GainHealth(_healingPower);
                    OnHeal.Invoke ();
                }
            }
        }
    }
}
