using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BurgerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;

    // Update is called once per frame

    void Update()
    {
        float step = speed * Time.deltaTime;

        Vector3 serveerSpot = new Vector3(11f, 1.19f, 4f);
        transform.position = Vector3.MoveTowards(transform.position, serveerSpot, step);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Mens_Obj" + GameObject.Find("Koeien&MensenCounter").GetComponent<Script_Counter>().mensCount)
        {
            GameObject.Find("Koeien&MensenCounter").GetComponent<Script_Counter>().burgerCount++;
            Destroy(gameObject);
        }
    }
}
