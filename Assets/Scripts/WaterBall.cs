using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
        if (countdown <= 0f && !hasSplashed)
        {

            Splash();
            hasSplashed = true;
        }

    }

    private void Splash()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        if (splashEffect != null)
        {
            Instantiate(splashEffect, transform.position, transform.rotation);
        }

        Destroy(gameObject);

    }
}
