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
    GameState _state = GameState.gameStart;
    //Vector2 _createPoint;
    int _totalScore;

    public int TotalScore { get => _totalScore; }
    public GameState State { get => _state; }

    private void Awake()
    {
        if(FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
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
            _timerbar.value -= Time.deltaTime;
            if (FindObjectsOfType<Enemy>().Length == 0)
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
}
