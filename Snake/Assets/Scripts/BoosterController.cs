using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoosterController : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI textField;

    public float distance = .2f;
    public float speef = 280;
    
    private void Start()
    {
        textField.text = score.ToString();
    }

   

}

