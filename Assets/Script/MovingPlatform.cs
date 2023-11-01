using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    Vector3 targetPos;

    public GameObject ways;
    public Transform[] wayPoints;
    int pointIndex = 1;
    int pointCount;
    int direction = 1;

    MovementController movementController;
    Rigidbody2D rb;
    Vector3 moveDirection;
    
    public float waitDuration;


    private void Awake()
    {
        movementController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
        rb = GetComponent<Rigidbody2D>();

        pointCount = ways.transform.childCount;
        wayPoints = new Transform[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i);
        }

    }

    private void Start()
    {
        pointIndex = 1;
        targetPos = wayPoints[1].transform.position;
        DirectionCalculate();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }


    void DirectionCalculate()
    {
        moveDirection = (targetPos - transform.position).normalized;
    }


    private void Update()
    {

        if (Vector2.Distance(transform.position, targetPos) < 0.1f)
        {
            NextPoint();
        }

    }

    void NextPoint()
    {
        transform.position = targetPos;
        moveDirection = Vector2.zero;
        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }
        else if (pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        targetPos = wayPoints[pointIndex].position;
        StartCoroutine(WaiteNextPoint());
    }

    IEnumerator WaiteNextPoint()
    {
        yield return new WaitForSeconds(waitDuration);
        DirectionCalculate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            movementController.isOnPlatform = true;
            movementController.platformRb = rb;
            movementController.rb.gravityScale = 15;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            movementController.isOnPlatform = false;
            movementController.rb.gravityScale = 1;
            movementController.platformRb.velocity = Vector2.zero;
        }
    }
}
