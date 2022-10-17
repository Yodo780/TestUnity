using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControll : MonoBehaviour
{

    public float sensitivity;
    private PlayerController playerController;
    void Start()
    {
        if (sensitivity == 0) sensitivity = 0.01f;
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame

    private Vector3 _previousMousePosition = Vector3.zero;

    void Update()
    {
        Vector3 delta = Input.mousePosition - _previousMousePosition;
        if (Input.GetMouseButton(0) && delta.x != 0)
            playerController.PlayerMoveX(delta.x * sensitivity);
        _previousMousePosition = Input.mousePosition;
    }
}

