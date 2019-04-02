using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Ozon : MonoBehaviour
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
        transform.Rotate(0, speed, 0, Space.Self);
    }
}
