using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AsteriodsARGame
{
    public class Player : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private UnityEvent OnShoot;
        [SerializeField] private float _fireRate = 0.5f;
        private bool _canShoot = true;
        private bool _shoot;
        #endregion

        #region Private Methods
        private void Update()
        {
            _shoot = Input.GetMouseButtonDown(0);

            if (_shoot && _canShoot)
            {
                OnShoot?.Invoke();
                _canShoot = false;
                StartCoroutine(EnableShooting());
            }
        }
        
        IEnumerator EnableShooting()
        {
            yield return new WaitForSeconds(_fireRate);
            _canShoot = true;
        }
        #endregion
    }
}
