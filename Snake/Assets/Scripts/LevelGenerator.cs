using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Color = UnityEngine.Color;

public class LevelGenerator : MonoBehaviour
{
    public GameObject boosterPrefab;
    public GameObject boxPrefab;

    public int numberLines = 30;

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel(numberLines);
    }

    public void GenerateLevel(int line)
    {
        for (int i = 0; i < line; i++)
        {
            // создаем Food рандомно в одном из 5 полей, на растоянии от центра в 10 единиц, и вкладываем его в LevelConteiner
            if (Random.Range(0, 10) >= 2)
            {
                // новый бустер
                GameObject clone = Instantiate(boosterPrefab, new Vector3(Random.Range(0, 5) * 2 - 4, 0, 10 + i * 2), Quaternion.identity, gameObject.transform);
                clone.GetComponent<ScoreController>().score = Random.Range(1, clone.GetComponent<ScoreController>().maxScore + 1);
            }
            else
            {
                // новая коробка
                GameObject clone = Instantiate(boxPrefab, new Vector3(Random.Range(0, 5) * 2 - 4, 0, 10 + i * 2), Quaternion.identity, gameObject.transform);
                ScoreController boxScoreController = clone.GetComponent<ScoreController>();
                int score = Random.Range(1, clone.GetComponent<ScoreController>().maxScore + 1);
                boxScoreController.score = score;

                Renderer renderer = clone.transform.GetChild(0).GetComponent<Renderer>();
                renderer.material.color = Color.Lerp(Color.white, Color.black, (float)score / (float)boxScoreController.maxScore);
                //print("score/ maxScore: " + (float)score / (float)boxScoreController.maxScore + " maxScore: " + boxScoreController.maxScore + " score " + score);
            }
        }

    }
}
