using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{

    private GameObject booster;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.tag)
        {
            case "Booster":
                booster = collider.gameObject.transform.parent.gameObject;

                playerController.addTailSegment(booster.GetComponent<BoosterController>().score);

                Destroy(booster);
                break;
            default:
                print("Unknown collision");
                break;
        }
    }
}
