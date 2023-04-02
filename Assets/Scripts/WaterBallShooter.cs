using UnityEngine;

/// <summary>
/// Shooter class that generates waterballs with a throwforce
/// Needs to be attached to a first person camera
/// </summary>
public class WaterBallShooter : MonoBehaviour
{

    [SerializeField] private float throwForce = 40f;
    [SerializeField] private GameObject waterBallPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ShootBall();
        }
    }

    /// <summary>
    /// Instantiates the waterball from the prefab and adds a throwforce
    /// </summary>
    private void ShootBall()
    {
        GameObject waterBall = Instantiate(waterBallPrefab, transform.position, transform.rotation);
        Rigidbody rb = waterBall.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * throwForce;
    }
}