using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    // горизонтальный размер поля - 5 клеток по 2 unity
    private int panelSize = 5 * 2;
    public float playerSpeed = 0.002f;

    public bool playerMove;
    void Start()
    {
        playerMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove) transform.Translate(new Vector3(0, 0, playerSpeed));
    }

    public void PlayerMoveX(float deltaX)
    {
        Vector3 newPosition = new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z);

        if (Mathf.Abs(newPosition.x) > panelSize / 2 - 0.5f)
            newPosition.x = (panelSize / 2.0f - 0.5f) * Mathf.Sign(deltaX);



        Collider[] colliders = Physics.OverlapBox(new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z - 0.1f), transform.localScale / 2);
        foreach (Collider c in colliders)
            if (c.CompareTag("Box"))
                return;

        transform.position = newPosition;
    }
}

