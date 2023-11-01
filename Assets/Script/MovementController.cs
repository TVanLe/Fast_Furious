using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] int speed;
    float speedMultiplier;
    bool btnPressed;

    [Range(1,10)]
    [SerializeField] float acceleration;

    bool isWallTouch;
    public ParticlesController particlesController;
    public LayerMask walllayer;
    public Transform wallCheckPoint;    

    public float moveDirection = 1f;

    public bool isOnPlatform;
    public Rigidbody2D platformRb;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        UpdateSpeedMultiplier();
        float targetSpeed = speed * speedMultiplier * moveDirection;

        if(isOnPlatform)
        {
            rb.velocity = new Vector2(targetSpeed + platformRb.velocity.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(targetSpeed, rb.velocity.y);
        }

        isWallTouch = Physics2D.OverlapBox(wallCheckPoint.position, new Vector2(0.06f, 0.6f), 0, walllayer);
        if(isWallTouch)
        {
            Flip();
        }
    }
    
    public void Move(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            btnPressed = true;
        }
        else if(value.canceled)
        {
            btnPressed = false;
        }
    }


    void Flip()
    {
        particlesController.PlayTouchParticle(wallCheckPoint.position);
        transform.Rotate(0, 180, 0);
        UpdateRelativeTransform();
    }

    void UpdateRelativeTransform()
    {
        moveDirection = -moveDirection;
    }

    void UpdateSpeedMultiplier()
    {
        if(btnPressed && speedMultiplier < 1)
        {
            speedMultiplier += Time.deltaTime * acceleration;
        }
        else if(!btnPressed && speedMultiplier > 0)
        {
            speedMultiplier -= Time.deltaTime * acceleration;
        }
        else if(speedMultiplier < 0) 
            speedMultiplier = 0; 
    }

}
