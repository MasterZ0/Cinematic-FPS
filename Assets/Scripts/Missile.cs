using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float moveSpeed = 10f;
    public GameObject explosionEffect;
    public Rigidbody rigidbod;
    private float countdown;
    void Start()
    {
        rigidbod.AddForce(transform.forward * moveSpeed, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other) {

        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);

    }
}
