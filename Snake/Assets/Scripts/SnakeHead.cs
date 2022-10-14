using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public Food currentFood;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFood == null) return;

        currentFood.enabled = false;
    }

   
}

