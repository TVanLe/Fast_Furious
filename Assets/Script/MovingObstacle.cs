using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{

    public float speed;
    Vector3 targetPos;


    public GameObject ways;
    public Transform[] wayPoints;
    int pointIndex = 1;
    int pointCount;
    int direction = 1;

    bool isMoving = true;
    public float waitDuration;

    private void Awake()
    {

        pointCount = ways.transform.childCount;
        wayPoints = new Transform[pointCount];

        for(int i = 0; i < pointCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i);
        }
    }

    private void Start()
    {
        pointIndex = 1;
        targetPos = wayPoints[1].transform.position;
    }

    private void Update()
    {
        if(isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPos) < 0.05f)
            {
                StartCoroutine(NextPoint());
            }
        }

    }


    IEnumerator NextPoint()
    {
        transform.position = targetPos;
        isMoving = false;
        yield return new WaitForSeconds(waitDuration);
        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }
        else if(pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        targetPos = wayPoints[pointIndex].position;
        isMoving = true;
    }
}
