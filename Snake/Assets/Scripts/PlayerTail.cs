using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerTail : MonoBehaviour
{
    [SerializeField]
    private ScoreController playerScoreController;
    

    public List<Transform> bodyParts = new List<Transform>();
    public int tailSize = 10;
    public int tailMaxSize = 10;
    public float minDistance = 0.25f;

    public float speed;
    //public float rotationSpeed = 59;

    public GameObject bodyPrefab;

    public float dis;
    private Transform curBodyPart;
    private Transform prevBodyPart;

    private const float maxTime = 0.5f;

    


    void Start()
    {
        playerScoreController = GetComponentInChildren<ScoreController>();
    

        for (int i = 0; i < tailSize; i++)
        {
            AddBodyPart(1);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (bodyParts.Count > 0) Move();
    }

    public void Move()
    {
        // двигаем голову
        //transform.Translate(transform.forward * speed * Time.smoothDeltaTime, Space.World);

        // двигаем тело
        for (int i = 1; i < bodyParts.Count; i++)
        {
            curBodyPart = bodyParts[i];
            prevBodyPart = bodyParts[i - 1];

            dis = Vector3.Distance(prevBodyPart.position, curBodyPart.position);
            if (dis <= minDistance) continue;

            Vector3 newpos = prevBodyPart.position;

            newpos.y = transform.position.y;

            float T = Time.deltaTime * dis / minDistance * speed;
            if (T > maxTime)
                T = maxTime;


            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newpos, T);
            //curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);
        }

    }

    public void AddBodyPart(int score)
    {
        // суммируем очки со съеденного шарика
        playerScoreController.score += score;
        

        if (bodyParts.Count >= tailMaxSize) return;
        for (int i = 0; i < score; i++)
        {
            Transform newPart = Instantiate(bodyPrefab, bodyParts[bodyParts.Count - 1].position, bodyParts[bodyParts.Count - 1].rotation).transform;
            bodyParts.Add(newPart);
        }
    }

    internal void DelBodyPart()
    {
        if (playerScoreController.score <= 1)
        {
           
            transform.GetComponent<PlayerController>().Currentstate = PlayerController.State.Loss;
            return; // первая (1) голова - Loose (конец игры).
        }

        // суммируем очки со съеденного шарика
        playerScoreController.score -= 1;
        


        if (playerScoreController.score < tailMaxSize)
        {
            Destroy(bodyParts[bodyParts.Count - 1].transform.gameObject);
            bodyParts.RemoveAt(bodyParts.Count - 1);

        }
    }
}
