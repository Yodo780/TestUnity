using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerTail playerTail;
    // горизонтальный размер поля - 5 клеток по 2 unity
    private int panelSize = 5 * 2;
    public float playerSpeed = 1f;

    public float playerBounce;

    public bool play = true;

    public GameObject WinScreen;
    public GameObject LooseScreen;

    public GameObject levelContainer;

    public enum State
    {
        Playing,
        Won,
        Loss,
        inputWaiting
    }
    public State Currentstate { get; set; }

    void Start()
    {
        Currentstate = State.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        switch (Currentstate)
        {
            case State.Playing:
                // двигаем игрока вперед
                transform.Translate(transform.forward * playerSpeed * Time.smoothDeltaTime, Space.World);
                int num = levelContainer.GetComponent<LevelGenerator>().numberLines;
                int levelStart = (int)levelContainer.transform.position.z;
                print("Z = " + transform.position.z + " level " + (num * 2 + levelStart / 2 + 2));
                if (transform.position.z > num * 2 + levelStart / 2 + 2)
                    Currentstate = State.Won;
                break;

            case State.Loss:
                // остановили игрока
                PlayerMoveY(0);
                LooseScreen.SetActive(true);
                // по нажатию перегружаем новый уровень
                if (Input.GetMouseButton(1))
                    ReloadLevel();
                break;

            case State.Won:
                PlayerMoveY(0);
                WinScreen.SetActive(true);
                // по нажатию перегружаем новый уровень
                if (Input.GetMouseButton(1))
                    ReloadLevel();
                break;

        }
    }

    // поглощение бустера
    public void ConsumeBooster(Collider booster)
    {
        playerTail.AddBodyPart(booster.GetComponent<ScoreController>().score);
        Destroy(booster.gameObject);
    }

    public void BoxHit(Collider box)
    {
        // удаляем конец хвоста
        playerTail.DelBodyPart();
        // уменьшаем очки коробки
        ScoreController boxScoreController = box.GetComponent<ScoreController>();
        boxScoreController.score -= 1;
        if (boxScoreController.score <= 0)
            Destroy(box.gameObject);

        Renderer renderer = box.transform.GetChild(0).GetComponent<Renderer>();
        renderer.material.color = Color.Lerp(Color.white, Color.black, (float)boxScoreController.score / (float)boxScoreController.maxScore);

        // отскок назад на playerBounce
        PlayerMoveY(playerBounce);
    }

    private void PlayerMoveY(float delta)
    {
        transform.Translate(transform.forward * delta);
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

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

