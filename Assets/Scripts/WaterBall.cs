using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates the force and splash effect for the waterball
/// </summary>
public class WaterBall : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 200f;
    public GameObject splashEffect;

    private float countdown;
    private bool hasSplashed = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;   
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        //Waterball either splashes on a surface or splashes anywhere once the countdown ends
        if (countdown <= 0f && !hasSplashed)
        {
            Splash();
            hasSplashed = true;
        }
    }

    /// <summary>
    /// Adds force and splash effect on the waterball
    /// </summary>
    private void Splash()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //Adds explosive force to the waterball
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        //Checks if the splash effect is not null and instantiates it
        //Note the splash effect has not been implemented yet
        if (splashEffect != null)
        {
            Instantiate(splashEffect, transform.position, transform.rotation);
        }

        //Destroys the game object once it is done
        Destroy(gameObject);

    }
}
