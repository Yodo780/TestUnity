using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerTail : MonoBehaviour
{
    private int playerScore = 0;
    private TextMeshProUGUI playerTextfield;

    public List<Transform> bodyParts = new List<Transform>();
    public int tailSize = 10;
    public float minDistance = 0.25f;

    public float speed;
    public float rotationSpeed = 59;

    public GameObject bodyPrefab;

    private float dis;
    private Transform curBodyPart;
    private Transform prevBodyPart;

    private const float maxTime = 0.5f;

    void Start()
    {
        playerTextfield = GetComponentInChildren<TextMeshProUGUI>();
        //scorePlayer = 0;
        playerTextfield.text = playerScore.ToString();

        for(int i = 0; i < 10; i++)
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
            Vector3 newpos = prevBodyPart.position;

            newpos.y = transform.position.y;

            float T = Time.deltaTime * dis / minDistance * speed;
            if (T > maxTime)
                T = maxTime;

            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newpos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);
        }

    }

    public void AddBodyPart(int score)
    {
        // суммируем очки со съеденного шарика
        playerScore += score;
        playerTextfield.text = playerScore.ToString();

        if (bodyParts.Count >= tailSize) return;

        Transform newPart = Instantiate(bodyPrefab, bodyParts[bodyParts.Count - 1].position, bodyParts[bodyParts.Count - 1].rotation).transform;
        bodyParts.Add(newPart);
    }
}
