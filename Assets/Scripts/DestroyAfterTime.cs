using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    //The instantied GameObject, if not destroyed by other means, destroy itself within 60 seconds of it being spawned.
    #region Private Variables
    [SerializeField] private float _delayTime = 5;
    #endregion

    #region Public Methods
    private void Start()
    {
        Destroy(this.gameObject, _delayTime);   
    }
    #endregion
}
