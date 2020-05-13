using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    public float widthTimes, heightTimes;
    public float posX, posY;

    void Update()
    {
        if (Screen.width < Screen.height)
        {
            this.transform.position = new Vector2(Screen.width * widthTimes, Screen.height * heightTimes);
        }

       else if (Screen.width > Screen.height)
        {
            this.transform.position = new Vector2(Screen.width * posX, Screen.height * posY);

        }

    }
}
