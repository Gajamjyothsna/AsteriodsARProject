using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace AsteriodsARGame
{
    public class GameManager : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private GameState _gameState;
        #endregion

        #region MonoBehaviour Methods
        private void Awake()
        {
            _gameState.GameOver = false;
            _gameState.Score = 0;
        }
        private void Update()
        {
            //timeScale property, which determines how fast the game runs. 
            Time.timeScale = _gameState.GameSpeed;
        }
        #endregion
    }
}
