using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer linerenderer;
    
    private Vector3[] points;

    private void Awake()
    {
        linerenderer = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Vector3[] points)
    {
        linerenderer.positionCount = points.Length;
        this.points = points;
    }

    public Vector3[] GetLine()
    {
        return points;
    }

    private void Update()
    {
        for(int i = 0; i< points.Length; i++)
        {
            linerenderer.SetPosition(i, points[i]);
        }
    }
}
