using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI ScoreOne;
    public TextMeshProUGUI ScoreTwo;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScores(int one, int two)
    {
        ScoreOne.text = "PLAYER 1: " + one;
        ScoreTwo.text = "PLAYER 2: " + two;
    }
}
