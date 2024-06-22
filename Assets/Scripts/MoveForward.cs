using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteriodsARGame
{
    public class MoveForward : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        private Transform myTransform;

        private void Start()
        {
            myTransform = this.transform;
        }

        private void Update()
        {
            myTransform.position += myTransform.forward * (moveSpeed * Time.deltaTime);
        }
    }
}
