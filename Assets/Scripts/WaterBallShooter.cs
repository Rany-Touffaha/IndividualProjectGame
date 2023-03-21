using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallShooter : MonoBehaviour
{

    public float throwForce = 40f;
    public GameObject waterBallPrefab;

    void Update()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            ShootBall();
        }

    }

    void ShootBall()
    {
        GameObject waterBall = Instantiate(waterBallPrefab, transform.position, transform.rotation);
        Rigidbody rb = waterBall.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
    
}
