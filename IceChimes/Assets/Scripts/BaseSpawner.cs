using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    public GameObject iceBase;
    public bool startSpawn = false;
    public float startTimeBtwSpawn;
    private float timeBtwSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!startSpawn)
        {
            if (Input.anyKeyDown)
            {
                startSpawn = true;
            }
        }
        else 
        {
            if (timeBtwSpawn <= 0)
            {
                Instantiate(iceBase, transform.position, Quaternion.identity);
                timeBtwSpawn = startTimeBtwSpawn;
            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
    }
}
