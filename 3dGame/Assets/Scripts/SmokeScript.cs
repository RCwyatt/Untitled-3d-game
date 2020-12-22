using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    public float lifeTime = 3f; //the amount of time the smoke will last for
    public float size = 5f;     //the size of the smoke at it's max

    public GameObject smoke;    //the gameobject of the visual smoke

    private float time = 0;     //the amount of time the smoke has existed

    private void Start()
    {
        time = lifeTime / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < lifeTime)
        {
            //increase the smoke size and add the time passed
            SetSmokeSize();
            time += Time.deltaTime / 2;
        } else
        {
            Destroy(gameObject); //once the lifetime has been reached, destroy the object
        }
    }

    public void SetSmokeSize()
    {
        //increase the size of the smoke
        smoke.transform.localScale = new Vector3(1,1,1) * (time / lifeTime) * size;
    }
}
