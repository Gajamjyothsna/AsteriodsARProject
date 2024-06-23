using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace AsteriodsARGame
{
    public class UFO : MonoBehaviour
    {
       public enum UFOStates
       {
            Idle,
            Attack
       }

        #region Private Variables
        [SerializeField] private UFOStates _currentState;
        [SerializeField] private List<Vector3> _trajectoryVectors = new List<Vector3>(); //Stores Spawn Positions
        [SerializeField] private int _trajectoriesPerSpawn = 2; //how many positions for spawning
        [SerializeField] private float _spawnDistanceFromPlayer = 20; //It determines the distance you should have when creating your new spawn positions from the player
        [SerializeField] private float _xyOffset; //Offset for the spawn positon
        [SerializeField] private float _movementSpeed; //speed of the UFO.
        [SerializeField] private int _cooldownMinTime = 5; //When to stop move towards player
        [SerializeField] private int _cooldownMaxTime = 15; //when to start move towards player
        [SerializeField] private GameState _gameState;
        [SerializeField] private Transform _player;

        public UFOStates CurrentState 
        { 
            get => _currentState; 
            set 
            { 
                _currentState = value;
            } 
        }
        #endregion

        #region MonoBehaviour Methods
        private void Start()
        {
            //Find the player in the scene.
            GameObject playerObject = GameObject.Find("Player");

            // If the Player is found,then grab its transform object.
            if (playerObject)
            {
                _player = playerObject.transform;
            }
            // Players should start in this state.
            CurrentState = UFOStates.Idle;
        }
        #endregion
    }
}
