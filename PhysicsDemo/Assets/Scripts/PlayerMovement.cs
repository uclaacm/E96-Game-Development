using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speedCoefficient = 5f;
    [SerializeField] bool useForce = false;
    [SerializeField] ForceMode forceMode = ForceMode.Acceleration;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (useForce)
        {
            MovementByAddForce();
        } else
        {
            MovementBySetVelocity();
        }
    }

    void MovementBySetVelocity()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 dir = (transform.right * hori + transform.forward * vert).normalized;

        rb.velocity = new Vector3(dir.x * speedCoefficient, rb.velocity.y, dir.z * speedCoefficient);
    }

    void MovementByAddForce()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 dir = (transform.right * hori + transform.forward * vert).normalized;

        rb.AddForce(dir * speedCoefficient, forceMode);
    }
}
