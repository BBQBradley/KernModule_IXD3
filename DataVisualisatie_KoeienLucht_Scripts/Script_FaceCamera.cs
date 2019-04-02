using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_FaceCamera : MonoBehaviour
{
    Transform t;
    public float fixedRotation = 0;

    void Start()
    {
        t = transform;
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform.position);

        t.eulerAngles = new Vector3(fixedRotation, t.eulerAngles.y, t.eulerAngles.z);
    }
}

