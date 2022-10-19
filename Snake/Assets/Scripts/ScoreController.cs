using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int maxScore = 10;
    private int _score;
    public int score {
        get { return _score; }
        set
        {
            _score = value;
            textField.text = _score.ToString();
        }
    }
    public TextMeshProUGUI textField;
}

