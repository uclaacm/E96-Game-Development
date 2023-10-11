using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
        if (Input.GetKeyDown(KeyCode.LeftControl)) Stomp();
        if (Input.GetKey(KeyCode.F)) Jetpack();
    }

    void Jump()
    {
        // Jumping is an instantaneous application of force usually, so we use Impulse
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }

    void Stomp()
    {
        // Like jumping, stomping would also be an instantaneous burst of force. Let's use Impulse
        rb.AddForce(Vector3.down * 10f, ForceMode.Impulse);
    }

    void Jetpack()
    {
        // A jetpack needs to have its force applied continuously.
        // Both Force and Acceleration work here, the difference lies in their effect.
        // Force will be less noticeable with higher mass, while Acceleration will stay constant.
        rb.AddForce(Vector3.up * 5f, ForceMode.Force); 
    }
}
