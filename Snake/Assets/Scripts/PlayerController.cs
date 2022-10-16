using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public int playerScore = 0;
    public TextMeshProUGUI playerTextfield;

    public List<Tail> tailList = new List<Tail>();

    public int tailCurrent = 0;
    public GameObject tailSegment;
    public float speedTail = .2f;
    private float countTime;



    public class Tail
    {
        public GameObject tail;
        public float oldX;
        public float newX;

        public Tail(GameObject tail)
        {
            this.tail = tail;
            oldX = newX = tail.transform.position.x;
        }
    }

    void Start()
    {
        //scorePlayer = 0;
        playerTextfield.text = playerScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if (countTime >= speedTail)
        {
            moveTail();
            countTime = 0;
        }

    }

    public void addTailSegment(int score)
    {
        playerScore += score;
        playerTextfield.text = playerScore.ToString();

        GameObject newSegment = Instantiate(tailSegment, new Vector3(transform.position.x, 0, -(tailList.Count + 1)), Quaternion.identity);
        tailList.Add(new Tail(newSegment));

        if (tailList.Count == 1)
            tailList[0].oldX = transform.position.x;
        else
            tailList[tailList.Count - 1].oldX = tailList[tailList.Count - 2].newX;
    }

    public void moveTail()
    {
        if (tailList.Count <= 0) return;

        for (int i = 0; i < tailList.Count; i++)
        {

            tailList[i].oldX = tailList[i].newX;
            tailList[i].newX = i == 0 ? transform.position.x : tailList[i - 1].oldX;
            tailList[i].tail.gameObject.transform.position = new Vector3(tailList[i].newX, tailList[i].tail.gameObject.transform.position.y, tailList[i].tail.gameObject.transform.position.z);

        }
    }
}

