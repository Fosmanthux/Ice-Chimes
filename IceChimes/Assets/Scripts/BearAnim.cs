using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAnim : MonoBehaviour
{
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.startPlaying == true)
        {
            anim.Play("BearRun");
        }

    }
}
