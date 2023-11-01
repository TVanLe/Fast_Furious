using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    AudioManager audioManager;
    MovementController movementController;
    GameController gameController;
    public Transform respawnPos;

    public Sprite passed;
    private SpriteRenderer thisSprite;
    Collider2D coll;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        movementController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
        thisSprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.checkpoint);
            gameController.UpdateCheckPointPos(respawnPos.position);
            gameController.UpdateCheckPointMoveDir(movementController.moveDirection);

            Quaternion curentRotation = movementController.transform.rotation;
            gameController.UpdateCheckPointRotation(curentRotation);
            thisSprite.sprite = passed;
            coll.enabled = false;
        }
    }
}
