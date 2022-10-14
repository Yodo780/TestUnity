using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject boosterPrefab;
    public GameObject wallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel(1);
        GenerateLevel(2);
        GenerateLevel(3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, -0.01f));
    }

    public void GenerateLevel(int line)
    {
        // создаем Food рандомно в одном из 5 полей, на растоянии от центра в 10 единиц, и вкладываем его в LevelConteiner
        Instantiate(boosterPrefab, new Vector3(Random.Range(0, 5) * 2 - 4, 0, /*currentRow*/ 10 + line * 2), Quaternion.identity, gameObject.transform);
    }
}
