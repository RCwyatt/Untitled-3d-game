using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
   
    public Camera playerCam;             //the camera object

    public GameObject explosiveProj;    //the prefab to be launched
    public Transform firePoint;         //the point to fire from


    public float fireRate = 1f;         //the time between shots
    public float projectileSpeed = 30f; //the speed the projectile will be launched at

    private float reload;               //float for calculating time between shots

    private void Start()
    {
        reload = fireRate; //start with the reload at the firerate to indicate the laucnher can be shot
    }


    // Update is called once per frame
    void Update()
    {
        //allow a shot if the key associated with fire1(M1 by default)
        //is pressed and the amount of time since the last shot is more than
        //the reload time
        if (Input.GetButtonDown("Fire1") && reload >= fireRate)
        {
            //reset the time since the last shot
            reload = 0f;
            //call the method to deal with shooting a projectile
            Shoot();

        } else if (reload < fireRate)
        {
            //add to the time since last reload
            reload += Time.deltaTime;
        }

      

    }

    //method whcih calculates the direction to
    //shoot in and then passes it to the projectile
    //creation method
    private void Shoot()
    {
        Vector3 destination; //vector for holding the direction to shoot in

        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //create a point to start the raycast from
        RaycastHit hit; //create a raycast hit to deal with the where the raycast connects with

        if (Physics.Raycast(ray, out hit)) //calculate the raycast
        {
            destination = hit.point; //get the direcitonal verctor towards the point of connection
        } else
        {
            destination = ray.GetPoint(100); //get a point in space to head towards if the raycast connects with nothing
        }

        //call method for creating a projectile
        InstaProj(destination);
    }

    //method for creating and sending a projectile
    void InstaProj(Vector3 destination)
    {
        //instantiate a new projectile
        var projectileObj = Instantiate(explosiveProj, firePoint.position, Quaternion.identity) as GameObject;
        //push the projectile towards the destiniation
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;

        //move the projectile relative to the player
        projectileObj.transform.position = playerCam.transform.position;
        projectileObj.transform.rotation = playerCam.transform.rotation;
    }

  
}
