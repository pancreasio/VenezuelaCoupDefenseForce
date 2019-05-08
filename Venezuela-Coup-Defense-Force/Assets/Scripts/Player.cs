using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    GameObject target;
    Transform targetPos;

    private void Start()
    {
        target = null;
    }

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                target = hit.transform.gameObject;
                targetPos = hit.transform;
                Debug.Log(hit.collider.name);
                Debug.DrawRay(ray.origin, ray.direction * Vector3.Distance(ray.origin, hit.transform.position), Color.red, 1);
            }
            if (target != null)
            {
              
            }
        }
    }

    private void Fire()
    {

    }
}

