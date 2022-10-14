using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag) {
            case "Booster":
                print("Booster triggered");
                Destroy(other.gameObject.transform.parent.gameObject);
                break;
            default:
                print("Unknown collision");
                break;
        }
    }
}
