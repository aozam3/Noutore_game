using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    bool flag = true;

    // Update is called once per frame
    void Update()
    {
        if(flag)
        {
            this.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.005f);
            if(this.GetComponent<SpriteRenderer>().color.a >= 1.0f)
            {
                flag = false;
            }
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.005f);
            if(this.GetComponent<SpriteRenderer>().color.a <= 0.0f)
            {
                flag = true;
            }
        }
        
    }
}
