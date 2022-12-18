using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class RankingOpen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var __resultscore = GameManager._totalScore;
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(__resultscore);
    }
}
