using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySimulation : MonoBehaviour
{
    [SerializeField] private float planetGravity;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Assign a realistic mass (e.g., 1 kg) to the Rigidbody.
        rb.mass = 1f;
    }

    void FixedUpdate()
    {
        // Apply gravitational force.
        Vector3 gravity = new Vector3(0f, planetGravity, 0f); // Gravity on the planet
        rb.AddForce(gravity * rb.mass);
    }
}
