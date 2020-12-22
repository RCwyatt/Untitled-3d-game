using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitCheck : MonoBehaviour
{
    public float rotSpeed = 30f;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<playerMovement>().points++;
            Destroy(this.gameObject);

        }
    }
}
