using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private GameObject targetReticle;
    private Rigidbody rigi;
    private bool accelerate;

    public float initialSpeed;
    public float speed;
    public float superHomingDistance;
    public float rotationSpeed;
    public GameObject target;

    private void Start()
    {
        accelerate = true;
        targetReticle = new GameObject();
        rigi = transform.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        targetReticle.transform.position = transform.position;
        targetReticle.transform.LookAt(target.transform);
        if (Vector3.Distance(transform.position, target.transform.position) > superHomingDistance)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetReticle.transform.rotation, rotationSpeed);
        }
        else
        {
            transform.LookAt(target.transform.position);
        }
        if (accelerate)
        {
            rigi.AddForce(transform.forward * initialSpeed, ForceMode.Impulse);
            accelerate = false;
        }
        rigi.AddForce(transform.forward * speed, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}
