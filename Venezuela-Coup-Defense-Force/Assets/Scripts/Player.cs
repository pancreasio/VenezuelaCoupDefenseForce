using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Ray ray;
    private RaycastHit hit;
    private GameObject target;
    private Vector3 baseTargetPos;
    private Vector3 cannonTargetPos;
    private Transform baseTargetRotation;
    private Transform cannonTargetRotation;
    private bool shot;

    public float baseRotationSpeed;
    public float cannonRotationSpeed;
    public Transform chamber;
    public Transform missileSpawnPoint;
    public GameObject missile;

    private void Start()
    {
        target = null;
        baseTargetRotation = new GameObject().transform;
        cannonTargetRotation = new GameObject().transform;
        shot = false;
    }

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                target = hit.transform.gameObject;
                baseTargetPos = new Vector3(hit.transform.position.x, 0, hit.transform.position.z);
                cannonTargetPos = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
                shot = false;
                Debug.DrawRay(ray.origin, ray.direction * Vector3.Distance(ray.origin, hit.transform.position), Color.red, 1);
            }
        }
        if (target != null)
        {
            baseTargetRotation.transform.LookAt(baseTargetPos);
            cannonTargetRotation.transform.LookAt(cannonTargetPos);
            transform.rotation = Quaternion.Lerp(transform.rotation, baseTargetRotation.rotation, baseRotationSpeed * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, baseTargetRotation.rotation) <3)
            {
                chamber.rotation = Quaternion.Lerp(chamber.rotation, cannonTargetRotation.rotation, cannonRotationSpeed * Time.deltaTime);
                if (Quaternion.Angle(chamber.rotation, cannonTargetRotation.rotation) < 1 && !shot)
                {
                    Fire();
                    shot = true;
                }
            }
        }
    }

    private void Fire()
    {
        GameObject newMissile = Instantiate(missile, missileSpawnPoint.transform.position, chamber.rotation * Quaternion.AngleAxis(90, Vector3.right));
        newMissile.GetComponent<Missile>().target = target.gameObject;
    }
}

