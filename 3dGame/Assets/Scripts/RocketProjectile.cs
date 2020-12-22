using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : MonoBehaviour
{
    
    public GameObject explosion; //the prefab to be created when the projectile hits somthing

    private void Start()
    {
        Destroy(gameObject, 5f); //destroy the projectile after 5 seconds of life
    }

    //on collsion with an collider
    private void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Projectile") 
        {
            //ignore collsiions wiht the player and other projectiles
            Physics.IgnoreCollision(GetComponent<Collider>(), col.gameObject.GetComponent<Collider>());
        }
        else
        {
            //on htiting a collider, create the explosion and then destory the projectile
            InactExplosion(gameObject.transform.position);
            Destroy(gameObject);
        }
    }
   

    public void InactExplosion(Vector3 pos)
    {
        //create explosion which pushes the player away
        var explosionObj = Instantiate(explosion, pos, Quaternion.identity) as GameObject;
      
    }

 

   
}
