using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearProjectile : MonoBehaviour
{
    
    public GameObject explosion;

    public float shotProgress = 0;

    public float explosionRadius = 3f;
    public float explosionPower = 15f;

    private void Start()
    {
        Destroy(gameObject, 5f);
        shotProgress = 1;
    }

    private void OnTriggerEnter(Collider col)
    {
        shotProgress = 2;
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Spear")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.gameObject.GetComponent<Collider>());
            shotProgress = 0;
        }
        else
        {
            shotProgress = 3;
        
            InactExplosion(gameObject.transform.position);
            Destroy(gameObject);
        }
    }
   

    public void InactExplosion(Vector3 pos)
    {
        shotProgress = 4;

        var explosionObj = Instantiate(explosion, pos, Quaternion.identity) as GameObject;

        /*
        float power = explosionRadius - getExplosionDistance(pos);

        shotProgress = 6;
        if (power > 0)
        {
            shotProgress = 7;
            Vector3 push = player.GetComponent<Collider>().transform.position - gameObject.transform.position;
            shotProgress = 8;
            player.GetComponent<playerMovement>().PushPlayer(push * (power + explosionPower));
        }*/
    }

    
    /*
    public float getExplosionDistance(Vector3 p1)
    {
        shotProgress = 5;
        Vector3 p2 = player.GetComponent<Collider>().transform.position;

        shotProgress = 5.2f;

        float x = Mathf.Pow((p1.x - p2.x),2f);
        float y = Mathf.Pow((p1.y - p2.y), 2f);
        float z = Mathf.Pow((p1.z - p2.z), 2f);

        shotProgress = 5.5f;

        return Mathf.Sqrt(x + y + z);
        

    }*/

    

   
}
