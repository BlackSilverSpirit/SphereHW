using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SphereGameRullers : MonoBehaviour
{
    [SerializeField] private SphereController _sphereController;
    [SerializeField] private CoinsManager _coinsManager;

    [SerializeField] private float _timeLoseGame;

    [SerializeField] private int _winCoins;

    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _FinishGameMessageText;
    [SerializeField] private TMP_Text _CoinsCountText;

    [SerializeField] private Vector3 _sphereStartPosition;

    private float _resetDefaultTimeLoseGame;

    private string _loseGameMessage = "Game Over";
    private string _winGameMessage = "You win";

    private int _coins;

    private bool _isPlayGame;

    private void Awake()
    {
        _resetDefaultTimeLoseGame = _timeLoseGame;

        StartGame();
    }

    private void Update()
    {
        HandleInput();

        if (_isPlayGame == false)
            return;

        GameLoop();
    }

    private void GameLoop()
    {
        if (CheckGameLooseQuantityCoin())
            LoseGame();
        if (CheckQuantityWinCoin())
            WinGame();
    }

    private bool CheckGameLooseQuantityCoin()
    {
        return _coins < _winCoins;
    }

    private bool CheckQuantityWinCoin()
    {
        return _coins >= _winCoins;
    }

    private void WinGame()
    {
        Debug.Log(_winGameMessage);

        _FinishGameMessageText.gameObject.SetActive(true);
        _FinishGameMessageText.color = Color.green;
        _FinishGameMessageText.text = _winGameMessage;

        _isPlayGame = false;
    }

    private void LoseGame()
    {
        _timeLoseGame -= Time.deltaTime;
        _timeText.text = _timeLoseGame.ToString("0.00");

        if (_timeLoseGame <= 0)
        {
            Debug.Log(_loseGameMessage);
            _timeLoseGame = 0;

            _FinishGameMessageText.gameObject.SetActive(true);
            _FinishGameMessageText.color = Color.red;
            _FinishGameMessageText.text = _loseGameMessage;

            _isPlayGame = false;
        }
    }

    public void AddCoins(int value)
    {
        _coins += value;
        Debug.Log($"Coin добавлен: {_coins}");
        _CoinsCountText.text = _coins.ToString();
    }

    private void StartGame()
    {
        _sphereController.ActiveObject(_sphereStartPosition);

        _coinsManager.RestoreCoinsPosition();

        _isPlayGame = true;

        _coins = 0;

        _timeLoseGame = _resetDefaultTimeLoseGame;

        _FinishGameMessageText.gameObject.SetActive(false);

        _CoinsCountText.text = _coins.ToString();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartGame();
        }
    }
}
