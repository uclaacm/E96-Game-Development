using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject cannonBall;
    [SerializeField] Transform referencePoint;
    [SerializeField] float fireDelay = 1f;
    [SerializeField] float raycastDistance = 5f;
    [SerializeField] float muzzleImpulse = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootRepeatedly());
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(referencePoint.position, referencePoint.position + referencePoint.forward * raycastDistance);
    }

#endif

    // Update is called once per frame
    void Update()
    {
    }
    

    IEnumerator ShootRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireDelay);
            ShootCannonball();
        }
    }

    void ShootCannonball()
    {
        // Raycast by default return a bool indicating if the ray hits something.
        // There are a number of overloads for this function.
        // Intellisense should show all the options. Unity's documentation also provides a brief list of all possible overloads
        // The current overload provides a position where the ray begins, a direction for the ray to follow,
        // the max distance the ray can travel, as well as a layer mask for all the layers the ray can collide with
        if (Physics.Raycast(referencePoint.position, referencePoint.forward, raycastDistance, 1 << LayerMask.NameToLayer("Player")))
        {
            GameObject projectile = Instantiate(cannonBall, referencePoint.position, referencePoint.rotation);
            Rigidbody prb = projectile.GetComponent<Rigidbody>();

            prb.AddForce(transform.forward * muzzleImpulse, ForceMode.Impulse);
            prb.AddTorque(Vector3.up * 2f, ForceMode.Impulse);  // Rotational force around the y axis
        }
    }
}
