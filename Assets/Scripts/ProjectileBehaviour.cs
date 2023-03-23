using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileBehaviour : MonoBehaviour
{
    private float speedMod;
    private float shootSpeed;

    private Transform[] routes;

    private PlayerInput playerInput;
    private Rigidbody2D body;

    private int activeRoute;
    private float tParam;
    private Vector2 spritePos;
    private bool followPath;
    private bool justCreated;
    
    //constructor
    public ProjectileBehaviour()
    {
        justCreated = true;
    }

    //setters
    public void SetLineAndShootSpeed(float speedMod, float shootSpeed)
    {
        this.speedMod = speedMod;
        this.shootSpeed = shootSpeed;
    }

    public void SetRoutes(Transform[] r)
    {
        routes = r;
    }


    //unity overrides
    void Start()
    {

        print("Projectile crated");
        print(transform.name);
        activeRoute = 0;
        tParam = 0f;
        followPath = true;
        GetComponent<SpriteRenderer>().enabled = false;
        body = GetComponent<Rigidbody2D>();



    }

    // Update is called once per frame
    void Update()
    {
        if (followPath)
            MoveOnPath();
        else
        {
            GoStraight();
        }
    }

    //custom logic
    private void GoStraight()
    {
        
        transform.position += (transform.up * Time.deltaTime * shootSpeed);
    }

    private void MoveOnPath()
    {
        Vector2 p0 = routes[activeRoute].GetChild(0).position;
        Vector2 p1 = routes[activeRoute].GetChild(1).position;
        Vector2 p2 = routes[activeRoute].GetChild(2).position;
        Vector2 p3 = routes[activeRoute].GetChild(3).position;


        tParam += Time.deltaTime * speedMod;

        spritePos = Mathf.Pow(1 - tParam, 3) * p0
            + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1
            + 3 * Mathf.Pow(tParam, 2) * (1 - tParam) * p2
            + Mathf.Pow(tParam, 3) * p3;

        if (tParam > 0.002f)
        {
            Turn(spritePos, new Vector2(transform.position.x, transform.position.y));
        }
        if(tParam > 0.05f)
        {
            if (justCreated)
                justCreated = false;
        }
        transform.position = spritePos;

        if (GetComponent<SpriteRenderer>().enabled == false)
            GetComponent<SpriteRenderer>().enabled = true;

        SetActiveRoute();
    }

    private void SetActiveRoute()
    {
        if (tParam >= 1.0f)
        {
            tParam = 0f;
            activeRoute += 1;
            if (activeRoute > routes.Length - 1)
            {
                activeRoute = 0;
            }
        }
    }

    private void Turn(Vector2 newPos, Vector2 currentPos)
    {
        
        Vector2 newDir = newPos - currentPos;
        newDir = newDir.normalized;
        Quaternion newRotation = Quaternion.LookRotation(Vector3.forward, newDir);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Time.deltaTime*500.0f);

    }


    public bool Shoot()
    {
        if (!justCreated)
        {
            followPath = false;
            return true;
        }
        else return false;
    }


    public void destroy()
    {
        Destroy(gameObject);
    }
}
