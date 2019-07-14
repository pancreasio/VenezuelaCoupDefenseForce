using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Missile")
        {
            Destroy(this.gameObject);
        }
        if (collision.transform.tag == "Floor")
        {
            Destroy(this.gameObject);
        }
    }
}
