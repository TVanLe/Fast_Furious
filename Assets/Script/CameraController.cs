using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    Vector3 veclocity = Vector3.zero;

    [Range(0, 1)]
    public float smoothTime;
    public Vector3 positionOffset;

    public Vector2 xLimit;
    public Vector2 yLimit;

    private void Awake() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {
        Vector3 targetPosition = target.position + positionOffset;
        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), targetPosition.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref veclocity, smoothTime);
    }
}
