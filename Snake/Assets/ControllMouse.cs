using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllMouse : MonoBehaviour
{
    public GameObject panel;
    public float sizePanel;
    public float sensitivity;
    void Start()
    {
        sensitivity = 0.05f;
        sizePanel = panel.GetComponent<Renderer>().bounds.size.x;
    }

    // Update is called once per frame

    private Vector3 _previousMousePosition = Vector3.zero;

    void Update()
    {
        Vector3 delta = Input.mousePosition - _previousMousePosition;
        if (Input.GetMouseButton(0) && delta.x != 0)
        {
            if (Mathf.Abs(transform.position.x + delta.x * sensitivity) < sizePanel / 2)
                transform.position = new Vector3(transform.position.x + delta.x * sensitivity, transform.position.y, transform.position.z);
            // transform.Translate(delta.x * sensitivity, 0, 0);
            else
                transform.position = new Vector3(sizePanel / 2f * Mathf.Sign(delta.x), transform.position.y, transform.position.z);
        }
        _previousMousePosition = Input.mousePosition;
    }
}
