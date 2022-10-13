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
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, -0.05f));
    }

    public void GenerateLevel(int difficulty){
        Instantiate(boosterPrefab, new Vector3(Random.Range(0, 5) * 2 - 4, 0, /*currentRow*/ 10), Quaternion.identity, gameObject.transform);
    }
}
