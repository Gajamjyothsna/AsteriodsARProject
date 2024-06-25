using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
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
        [SerializeField] private UnityEvent OnStopAttacking;
        [SerializeField] private UnityEvent OnStartAttacking;
        [SerializeField] private UnityEvent OnDie;
        [SerializeField] private AudioSfx _ufoOnScene;
        public UFOStates CurrentState 
        { 
            get => _currentState; 
            set 
            { 
                _currentState = value;

                if (_currentState == UFOStates.Attack)
                {
                    OnStartAttacking?.Invoke();
                }
                else
                {
                    OnStopAttacking?.Invoke();
                }
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

        #region Private & Public Methods
        private IEnumerator IdleRoutine()
        {
            transform.position = new Vector3(1000, 1000, 1000);

            _trajectoryVectors.Clear();

            yield return new WaitForSeconds(Random.Range(_cooldownMinTime, _cooldownMaxTime));

            CurrentState = UFOStates.Attack;
        }

        public void StartCooldown()
        {
            _ufoOnScene.StopAudio();
            StartCoroutine(IdleRoutine());
        }

        private Vector3 GetNewPositionVector()
        {
            return new Vector3(Random.Range(-_xyOffset, _xyOffset), Random.Range(-_xyOffset, _xyOffset), _player.position.z + _spawnDistanceFromPlayer);
        }

        public void StartAttacking()
        {
            //You don’t want the UFO to attack if the player is dead.Your code needs to check if the player is dead or alive and,
            //if the player is dead, prevent the UFO from regenerating.

            // Check if the player is available
            if (_player == null) return;

            transform.position = GetNewPositionVector();

            // Define new random trajectory vectors
            for (int i = 0; i < _trajectoriesPerSpawn; i++)
            {
                _trajectoryVectors.Add(GetNewPositionVector());
            }
            _ufoOnScene.PlayAudio(gameObject);

            StartCoroutine(AttackMovement());
        }

        private IEnumerator AttackMovement() 
        {
            for (int i = 0; i < _trajectoryVectors.Count; i++)
            {
                float distance = Vector3.Distance(transform.position, _trajectoryVectors[i]);
                while(distance > 0.5f && !_gameState.GameOver)
                {
                    // wait a frame
                    yield return null;

                    transform.position = Vector3.MoveTowards(transform.position, _trajectoryVectors[i], Time.deltaTime * _movementSpeed);

                    distance = Vector3.Distance(transform.position, _trajectoryVectors[i]);
                }
            }
            CurrentState = UFOStates.Idle;
        }

        public void Die()
        {
            OnDie?.Invoke();
            OnStopAttacking?.Invoke();

            StopAllCoroutines();
            StartCooldown();
        }

        #endregion
    }
}
