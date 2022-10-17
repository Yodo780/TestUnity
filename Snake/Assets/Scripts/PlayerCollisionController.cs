using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{

    private GameObject booster;
    private PlayerController playerController;
    private PlayerTail playerTail;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerTail = GetComponent<PlayerTail>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.tag)
        {
            case "Booster":
                booster = collider.gameObject.transform.parent.gameObject;

                //playerController.addTailSegment(booster.GetComponent<BoosterController>().score);
                playerTail.AddBodyPart(booster.GetComponent<BoosterController>().score);

                Destroy(booster);
                break;
            case "Box":
                print("Box collision");
                playerController.playerMove = false;
                break;
            default:
                print("Unknown collision: " + collider.ToString());
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("Triger exit");
        playerController.playerMove = true;

    }
}
