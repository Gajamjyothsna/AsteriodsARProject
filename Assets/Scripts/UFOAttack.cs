using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AsteriodsARGame
{
    public class UFOAttack : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private float _fireCooldownTime = 0.3f; //It will determine the rate in which the UFO shoots
        [SerializeField] private UnityEvent OnShoot; //Every time the UFO shoots, you want to trigger the OnShoot event.  
        #endregion

        #region Private Methods
        private void OnEnable()
        {
            StartCoroutine(AttackRoutine());
        }

        IEnumerator AttackRoutine()
        {
            // continue loop while the UFOAttack component is enabled.
            while (enabled)
            {
                // trigger shooting event 
                OnShoot?.Invoke();

                // wait before looping again
                yield return new WaitForSeconds(_fireCooldownTime);
            }
        }
        #endregion
    }
}
