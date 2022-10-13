using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllMouse : MonoBehaviour
{
    public float sensitivity;
    void Start()
    {
        sensitivity = 0.05f;
    }

    // Update is called once per frame
    
    private Vector3 _previousMousePosition = Vector3.zero;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            transform.Translate(delta.x * sensitivity, 0, 0);
        }
        _previousMousePosition = Input.mousePosition;
    }
}
