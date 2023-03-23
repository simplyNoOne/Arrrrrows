using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public LayerMask m_LayerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        checkHit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkHit()
    {
        // Use the OverlapBox to detect if there are any other colliders within this box area.
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            //Output all of the collider names
            print("WAS HIT");
            //Increase the number of Colliders in the array
            i++;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            print("MATHAFUCKA");
            other.GetComponent<ProjectileBehaviour>().destroy();
            GetComponentInParent<Targets>().TargetHit(gameObject);
            Destroy(gameObject);
        }
       
    }
}


    

