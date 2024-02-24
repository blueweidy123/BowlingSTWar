using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

    void Awake()
    {
        _offset = transform.position - target.position;
    }

    void Update()
    {
        // Calculate the target position with fixed y
        Vector3 targetPosition = new Vector3(transform.position.x, target.position.y + _offset.y, target.position.z + _offset.z);

        // Smoothly move towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }
}


