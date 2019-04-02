using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_MensText : MonoBehaviour
{
    public GameObject textWolkje;

    private float nextActionTime = 20.0f;
    private float period = 0.1f;
    private bool switchTextWolkje = false;

    void Start()
    {
        textWolkje.SetActive(false);
        nextActionTime = Random.Range(5.0f, 30.0f);
        period = Random.Range(2.0f, 5.0f);
    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            
            if (switchTextWolkje == true)
            {
                //textWolkje.SetActive(true);
            }
            if (switchTextWolkje == false)
            {
                //textWolkje.SetActive(false);
            }

            switchTextWolkje = !switchTextWolkje;
        }
    }
}
