using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    
    public float power = 1f;
    public float radius = 30f;

    public string colide;
    public int count;

    public GameObject smoke;

    private void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        count = colliders.Length;

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                if (rb.gameObject.tag == "Player")
                {
                    Vector3 push = (gameObject.transform.position - rb.transform.position).normalized; 
                    rb.GetComponentInParent<playerMovement>().PushPlayer(-push * power);
                }
            }
        }

        var explosionObj = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;

        Destroy(gameObject);
    }

    

    

}
