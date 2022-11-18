using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] _patients;
    //Vector2 _createPoint;
    int _totalScore;

    public int TotalScore { get => _totalScore; }

    void Start()
    {

    }

    void Update()
    {
        if (FindObjectsOfType<Enemy>().Length == 0)
        {
            int r = Random.Range(0, _patients.Length);
            Instantiate(_patients[r], transform.position, transform.rotation);
        }
    }

    public void AddScore(int score)
    {
        _totalScore += score;
    }
}
