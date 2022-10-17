using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    public GameObject boosterPrefab;
    public GameObject boxPrefab;


    // Start is called before the first frame update
    void Start()
    {

        GenerateLevel(23, 30);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(new Vector3(0, 0, -0.05f));
    }

    public void GenerateLevel(int line, int maxScore)
    {
        for (int i = 0; i < line; i++)
        {
            // создаем Food рандомно в одном из 5 полей, на растоянии от центра в 10 единиц, и вкладываем его в LevelConteiner
            if (Random.Range(0, 2) > 0)
            {
                GameObject clone = Instantiate(boosterPrefab, new Vector3(Random.Range(0, 5) * 2 - 4, 0, /*currentRow*/ 10 + i * 2), Quaternion.identity, gameObject.transform);
                clone.GetComponent<BoosterController>().score = Random.Range(1, maxScore + 1);
            }
            else {
                GameObject clone = Instantiate(boxPrefab, new Vector3(Random.Range(0, 5) * 2 - 4, 0, /*currentRow*/ 10 + i * 2), Quaternion.identity, gameObject.transform);
                clone.GetComponent<BoosterController>().score = Random.Range(1, maxScore + 1);
            }
        }

    }
}
