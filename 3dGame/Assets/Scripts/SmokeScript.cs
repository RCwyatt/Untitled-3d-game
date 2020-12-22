using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    public float lifeTime = 3f;
    public float size = 3f;

    public GameObject smoke;

    private float time = 0;

    // Update is called once per frame
    void Update()
    {
        if (time < lifeTime)
        {
            setSmokeSize();
            time += Time.deltaTime;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void setSmokeSize()
    {
        smoke.transform.localScale = new Vector3(1,1,1) * (time / lifeTime) * size;
    }
}
