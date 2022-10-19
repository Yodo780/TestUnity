using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{

    //private BoosterController booster;
    private GameObject box;
    private PlayerController player;
    private PlayerTail playerTail;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        playerTail = GetComponent<PlayerTail>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.tag)
        {
            case "Booster":
                player.ConsumeBooster(collider);
                break;

            case "Box":
                player.BoxHit(collider);
                break;

            default:
                print("Unknown collision: " + collider.ToString());
                break;
        }
    }
}
