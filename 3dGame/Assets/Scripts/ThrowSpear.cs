using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpear : MonoBehaviour
{

    public Camera playerCam;

    public GameObject explosiveProj;
    public Transform firePoint;


    public float fireRate = 1f;
    public float projectileSpeed = 30f;

    private float reload;

    private void Start()
    {
       reload = fireRate;
    }

    private Vector3 destination;

    // Update is called once per frame
    void Update()
    {




        if (Input.GetButtonDown("Fire1") && reload >= fireRate)
        {

            reload = 0f;

            Shoot();

        } else
        {
            reload += Time.deltaTime;
        }

      

    }

    void Shoot()
    {
        

        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        } else
        {
            destination = ray.GetPoint(100);
        }


        InstaProj();
    }
    void InstaProj()
    {
        var projectileObj = Instantiate(explosiveProj, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
        projectileObj.transform.position = playerCam.transform.position;
        projectileObj.transform.rotation = playerCam.transform.rotation;
    }

  
}
