using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float speed, rotationSpeed;
    public GameObject gun;
    public delegate void BoxKilledAction();
    public BoxKilledAction BoxKilled;
    public delegate void BoxDestroyedAction();
    public BoxDestroyedAction BoxDestroyed;

    private void FixedUpdate()
    {
        transform.Rotate(transform.up, -rotationSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Missile")
        {
            Instantiate(gun, transform.position, Quaternion.identity);
            Die();
        }
    }

    private void Die()
    {
        BoxKilled?.Invoke();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Floor")
        {
            Explode();
        }
    }

    private void Explode()
    {
        BoxDestroyed?.Invoke();
        Destroy(this.gameObject);
    }
}
