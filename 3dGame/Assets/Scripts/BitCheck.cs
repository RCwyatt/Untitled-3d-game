using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitCheck : MonoBehaviour
{
    public float rotSpeed = 30f; //speed that the bit rotate

    // Update is called once per frame
    void Update()
    {
        //rotate the bit
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        //when the player enters the pickup area
        if (other.tag == "Player")
        {
            //give the player a poitn and detroy the bit
            other.GetComponent<PlayerMovement>().points++;
            Destroy(this.gameObject);

        }
    }
}
