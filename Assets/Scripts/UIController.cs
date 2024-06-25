using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace AsteriodsARGame
{
    public class UIController : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private GameState _gameState;
        [SerializeField] private Slider _playerHealth;
        [SerializeField] private Slider _planetHealth;
        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private TMP_Text _finalScoreText;
        #endregion

        #region Private & Public Methods

        private void OnEnable()
        {
            _gameState.OnIncreaseScore.AddListener(UpdateScoreUI);
            _gameState.OnGameOver.AddListener(ShowGameOverScreen);
        }
        private void OnDisable()
        {
            _gameState.OnIncreaseScore.RemoveListener(UpdateScoreUI);
            _gameState.OnGameOver.RemoveListener(ShowGameOverScreen);
        }

        public void UpdateScoreUI(int newScore)
        {
            _scoreText.text = $"Score {newScore}";
        }

        public void UpdatePlayerHealthUI(int newHealth)
        {
            _playerHealth.value = newHealth;
        }

        public void UpdatePlanetHealthUI(int newHealth)
        {
            _planetHealth.value = newHealth;
        }

        public void ShowGameOverScreen()
        {
            _gameOverScreen.SetActive(true);
            _finalScoreText.text = $"Score: {_gameState.Score}";
        }

        public void PlayAgain()
        {
            SceneManager.LoadScene("AsteroidsScene");
            _gameState.GameOver = false;
        }
        #endregion
    }
}
