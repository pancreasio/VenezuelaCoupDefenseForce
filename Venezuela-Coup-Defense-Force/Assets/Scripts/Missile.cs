using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    public GameObject target;

    private void FixedUpdate()
    {
        transform.LookAt(target.transform);
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Box")
        {
            Destroy(this.gameObject);
        }
    }
}
