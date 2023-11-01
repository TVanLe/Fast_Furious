using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 checkpointPos;
    Quaternion rotationCheckPoint;
    float moveDirCheckPoint = 1f;
    Rigidbody2D rb;
    Collider2D collier;
    MovementController moveController;
    public ParticlesController particleController;
    Animation animDie;
    private void Start()
    {
        checkpointPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        collier = GetComponent<Collider2D>();
        moveController = GetComponent<MovementController>();
        animDie = GameObject.FindGameObjectWithTag("WhiteScreen").GetComponent<Animation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        StartCoroutine(ReSpawn(0.5f));
    }

    IEnumerator ReSpawn(float duration)
    {
        rb.velocity = Vector2.zero;
        collier.enabled = false;
        transform.localScale = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);
        rb.simulated = false;
        //animation
        particleController.PlayDieParticle(transform.position);
        animDie.Play("WhiteScreen");

        yield return new WaitForSeconds(duration);

        //Direction to Respawn

        transform.position = checkpointPos;

        moveController.moveDirection = moveDirCheckPoint;
        transform.rotation = rotationCheckPoint;

        collier.enabled = true;
        transform.localScale = new Vector3(1, 1, 1);
        rb.simulated = true;//Physis
        moveController.isOnPlatform = false;
        moveController.rb.gravityScale = 1;
    }

    public void UpdateCheckPointPos(Vector2 pos)
    {
        checkpointPos = pos;
    }

    public void UpdateCheckPointRotation(Quaternion rot)
    {
        rotationCheckPoint = rot;
    }

    public void UpdateCheckPointMoveDir(float movedir)
    {
        moveDirCheckPoint = movedir; 
    }
}
