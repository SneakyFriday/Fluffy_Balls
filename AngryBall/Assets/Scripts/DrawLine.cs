using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private float counter;
    private float dist;
    private bool isAiming;
    private float lineDrawSpeed = 6f;
    
    [SerializeField] private Transform origin;
    [SerializeField] private Transform destination;
    
    public bool IsAiming
    {
        get => isAiming;
        set => isAiming = value;
    }

    void Start()
    {
        
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.2f;
    }

    void LateUpdate()
    {
        if (isAiming)
        {
            dist = Vector3.Distance(origin.position, destination.position);

            counter += .1f / lineDrawSpeed;

            float x = Mathf.Lerp(0, dist, counter);

            Vector3 pointA = origin.position;
            Vector3 pointB = destination.position;

            Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;

            lineRenderer.SetPosition(1, pointAlongLine);
        }
        else
        {
            lineRenderer.SetPosition(1, origin.position);
            counter = 0f;
        }
    }
}