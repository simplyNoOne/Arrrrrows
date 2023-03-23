using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileLauncherScript : MonoBehaviour
{
    public Transform[] routes;
    public GameObject projectileTemp;
   
    public int noProjectiles;
    public float spawnGap;

    public float speedMod;
    public float shootSpeed;


    private List<GameObject> projectiles;
    private bool bSpawning;


    // unity overrides
    void Start()
    {
        projectiles = new List<GameObject>();
        bSpawning = false;
        StartCoroutine(LaunchProjectiles());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            print("Die");
            // projectiles[leadingProjectile].GetComponent<ProjectileBehaviour>().SetFirst();
            if (projectiles.Contains(other.gameObject))
                projectiles.Remove(other.gameObject);
            Destroy(other.gameObject);
            if (projectiles.Count == 0 && !bSpawning)
            {
                StartCoroutine(LaunchProjectiles());
            }

        }

    }

    //custom logic
    IEnumerator LaunchProjectiles()
    {
        bSpawning = true;
        yield return new WaitForSeconds(1);
        
        //projectiles.Clear();
        int n = 0;
        while (n < noProjectiles)
        {
            n++;
            GameObject temp = Instantiate(projectileTemp);
            temp.GetComponent<ProjectileBehaviour>().SetLineAndShootSpeed(speedMod, shootSpeed);
            temp.GetComponent<ProjectileBehaviour>().SetRoutes(routes);

            projectiles.Add(temp);
            yield return new WaitForSeconds(spawnGap);
        }
        bSpawning = false;
        StopCoroutine(LaunchProjectiles());
    }

    public void ChangeLeadingProjectile(InputAction.CallbackContext context)
    {
        if (context.performed && projectiles.Count != 0)
        {
            print("boom");
            if (projectiles[0].GetComponent<ProjectileBehaviour>().Shoot())
            {
                projectiles.RemoveAt(0);
                if (projectiles.Count == 0 && !bSpawning)
                {
                    StartCoroutine(LaunchProjectiles());
                }
            }
        }
    }

    
}
