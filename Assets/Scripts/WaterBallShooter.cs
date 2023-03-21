using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallShooter : MonoBehaviour
{

    [SerializeField] private float throwForce = 40f;
    [SerializeField] private GameObject waterBallPrefab;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ShootBall();
        }
    }

    private void ShootBall()
    {
        GameObject waterBall = Instantiate(waterBallPrefab, transform.position, transform.rotation);
        Rigidbody rb = waterBall.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * throwForce;
    }
}
