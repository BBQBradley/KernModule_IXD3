using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_World : MonoBehaviour
{
    // Angular speed in radians per sec.
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, -0.009f, 0, Space.Self);
    }
}
