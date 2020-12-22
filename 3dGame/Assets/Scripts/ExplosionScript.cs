using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    
    public float power = 1f;    //power of the exsplosion   
    public float radius = 30f;  //radius of the explosion

    public GameObject smoke; //prefab for creating visualization for the explosion

    private void Start()
    {

        Vector3 explosionPos = transform.position; //get the explosion position

        //create some smoke at the current position
        var explosionObj = Instantiate(smoke, explosionPos, Quaternion.identity) as GameObject;

        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);// check what colliders are within the explosion's radius

        //loop through all the colliders hit
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();//get the collider's asociated rigidbody 

            if (rb != null) //if that rigidbody exists
            {
                if (rb.gameObject.tag == "Player") //and is asociated with a player entity
                {
                    //push the player
                    Vector3 push = (gameObject.transform.position - rb.transform.position).normalized; 
                    rb.GetComponentInParent<PlayerMovement>().PushPlayer(-push * power);
                }
            }
        }

        

        Destroy(gameObject);
    }

    

    

}
