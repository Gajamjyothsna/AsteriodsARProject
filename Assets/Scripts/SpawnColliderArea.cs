using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteriodsARGame
{
    public class SpawnColliderArea : MonoBehaviour
    {
        //Code to control the area for spawning the asteroids randomly.

        #region Private Variables
        [SerializeField] private Collider spawnCollider;
        [SerializeField] private GameState gameState;
        [SerializeField] private float spawnDelay = 1;
        [SerializeField] private GameObject AsteroidPrefab;
        #endregion

        #region Private Methods
        private void Start()
        {
            StartCoroutine(SpawnAsteroids());
        }

        IEnumerator SpawnAsteroids()
        {
            while (!gameState.GameOver)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();

                GameObject AsteroidObject = Instantiate(AsteroidPrefab, spawnPosition, Quaternion.identity);

                AsteroidObject.name = "Asteroid " + AsteroidObject.GetInstanceID();

                yield return new WaitForSeconds(spawnDelay);
            }

        }

        private Vector3 GetRandomSpawnPosition()
        {
            //This method returns the random position inside the collider area.
            return new Vector3(Random.Range(spawnCollider.bounds.min.x, spawnCollider.bounds.max.x),
                Random.Range(spawnCollider.bounds.min.y, spawnCollider.bounds.max.y),
                Random.Range(spawnCollider.bounds.min.z, spawnCollider.bounds.max.z));
        }
        #endregion
    }
}
