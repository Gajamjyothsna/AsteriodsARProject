using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AsteriodsARGame
{
    public class DestroyObject : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private float delay;
        [SerializeField] private UnityEvent OnDestroy;
        #endregion

        #region Public Methods
        public void DestroyGameObjectWithDelay()
        {
            //Destroying the gameobject after delay
            OnDestroy?.Invoke();
            Destroy(this.gameObject, delay);
        }
        #endregion
    }
}
