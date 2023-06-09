using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorPath : MonoBehaviour
{

    public Transform[] controlPoints;


    private Vector2 gizmosPosition;

    private float step = 0.05f;



    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t +=step)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position
                + 3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position
                + 3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position
                + Mathf.Pow(t, 3) * controlPoints[3].position;


            Gizmos.DrawSphere(gizmosPosition, 0.22f);
        }

        Gizmos.DrawLine(controlPoints[0].position, controlPoints[1].position);
        Gizmos.DrawLine(controlPoints[2].position, controlPoints[3].position);

    }

}
