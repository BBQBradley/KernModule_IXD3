﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_FaceCameraText : MonoBehaviour
{

    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}
