using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBase : MonoBehaviour
{
    public float bpm;

    public bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        bpm = bpm / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, 0f, bpm * Time.deltaTime);
        }
    }
}
