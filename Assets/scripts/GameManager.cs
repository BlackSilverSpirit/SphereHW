using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private CoinsManager _coinsManager;
    [SerializeField] private Wallet _wallet;

    [SerializeField] private float _remainingTime;

    [SerializeField] private int _requiredCoinsForWin;

    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _finishGameMessageText;
    [SerializeField] private TMP_Text _CoinsCountText;

    [SerializeField] private Vector3 _heroStartPosition;

    private float _resetDefaultTimeLoseGame;

    private string _defeatMessage = "Game Over";
    private string _winGameMessage = "You win";

    private bool _isPlayGame;

    private void Awake()
    {
        _resetDefaultTimeLoseGame = _remainingTime;

        StartGame();
    }

    private void Update()
    {
        HandleInput();

        if (_isPlayGame == false)
            return;

        UpdateTimer();
        CheckGameConditions();
    }

    private void CheckGameConditions()
    {
        _CoinsCountText.text = _wallet.Coins.ToString();

        if (_wallet.Coins >= _requiredCoinsForWin)
            HandleVictory();
        else if (_remainingTime <= 0)
            HandleDefeat();      
    }

    private void HandleVictory()
    {
        Debug.Log(_winGameMessage);

        _finishGameMessageText.gameObject.SetActive(true);
        _finishGameMessageText.color = Color.green;
        _finishGameMessageText.text = _winGameMessage;

        _isPlayGame = false;
    }

    private void HandleDefeat()
    {
        if (_remainingTime <= 0)
        {
            Debug.Log(_defeatMessage);
            _remainingTime = 0;

            _finishGameMessageText.gameObject.SetActive(true);
            _finishGameMessageText.color = Color.red;
            _finishGameMessageText.text = _defeatMessage;

            _isPlayGame = false;
        }
    }

    private void StartGame()
    {
        _playerController.ActiveObject(_heroStartPosition);

        _coinsManager.RestoreCoinsPosition();

        _wallet.ResetCoins();

        _remainingTime = _resetDefaultTimeLoseGame;

        _finishGameMessageText.gameObject.SetActive(false);

        _isPlayGame = true;
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartGame();
        }
    }

    private void UpdateTimer()
    {
        _remainingTime -= Time.deltaTime;
        _timeText.text = $"Time: {_remainingTime:F1}s";
    }
}
