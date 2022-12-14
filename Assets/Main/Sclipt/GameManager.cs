using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] _patients;
    [SerializeField] Slider _timerbar;
    [SerializeField] float _timer;
    [SerializeField] float _countDown;
    [SerializeField] Text _countDownText;
    [SerializeField] GameObject _result;
    GameState _state = GameState.gameStart;
    //Vector2 _createPoint;
    public static int _totalScore;
    public bool _timeStop;

    public GameState State { get => _state; set => _state = value; }

    private void Awake()
    {
        _totalScore = 0;
    }

    void Start()
    {
        _timerbar.maxValue = _timer;
        _timerbar.value = _timer;
    }

    void Update()
    {
        if (_state == GameState.isGame)
        {
            if (_timeStop)
            {
                _timerbar.value = _timer;
            }
            else
            {
                _timerbar.value -= Time.deltaTime;
            }
            if (FindObjectsOfType<PatientData>().Length == 0)
            {
                int r = Random.Range(0, _patients.Length);
                Instantiate(_patients[r], transform.position, transform.rotation);
            }
        }
        else
        {
            _countDown -= Time.deltaTime;
            _countDownText.text = $"{_countDown.ToString("f0")}";
            if(_countDown < 0)
            {
                _countDownText.gameObject.SetActive(false);
                _state = GameState.isGame;
            }
        }
        if(_timerbar.value <= 0)
        {
            _state = GameState.gameOver;
            _result.SetActive(true);
        }
    }

    public void AddScore()
    {
        _totalScore++;
    }
}
public enum GameState
{
    isGame,
    gameStart,
    gameOver,
    TimerReset,
    timeStop,
}
