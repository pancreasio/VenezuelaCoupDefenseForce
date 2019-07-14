using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float speed, rotationSpeed;
    public GameObject gun;

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
            Destroy(this.gameObject);
        }
        if (collision.transform.tag == "Floor")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Floor")
        {
            Destroy(this.gameObject);
        }
    }
}
