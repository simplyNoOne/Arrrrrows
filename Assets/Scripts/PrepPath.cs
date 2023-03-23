using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepPath : MonoBehaviour
{
    public Transform[] controlPoints;
   
    private Vector3[] calculatedPositions;
    
    public LineController line;
   
    private Vector2 gizmosPosition;

    public float step;

    

    private void Start()
    {

        int multipl = (int)(1 / step);
       
        calculatedPositions = new Vector3[multipl + 1];

        int i = 0;
        for (float t = 0; t <= 1; t += step)
        {           
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position
                + 3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position
                + 3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position
                + Mathf.Pow(t, 3) * controlPoints[3].position;
            calculatedPositions[i] = gizmosPosition;
            
            i++;
        }

       
        line.SetUpLine(calculatedPositions);
    }


}
