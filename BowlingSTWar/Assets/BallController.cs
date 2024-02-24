using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //chỉnh mass thành 20, force là 400 sẽ giống thật nhất
    Rigidbody rb;
    public float force = 400f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
