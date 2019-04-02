using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_MensMovement : MonoBehaviour
{
    public GameObject hamburger;

    public Vector3 Center2;
    public Vector3 Size2;

    private Vector3 MensIdleSpot;
    private Vector3 burgerOphaalSpot;
    private Vector3 wegLoopSpot;
    private Vector3 rijAansluitSpot;


    private bool inDeRijStaan = false;
    private bool wegLopen = false;
    private bool burgerGepakt = false;
    private bool rijAansluiten = false;

    public float speed = 10.0f;

    private static int RijDoorloopCount;

    void Awake()
    {
        MensIdleSpot = Center2 + new Vector3(Random.Range(-Size2.x / 2, Size2.x / 2), 1, Random.Range(-Size2.z / 2, Size2.z / 2));
        burgerOphaalSpot = new Vector3(12.5f, 1f, 4f);
        wegLoopSpot = new Vector3(50f, 1f, 4f);
        rijAansluitSpot = new Vector3(16f, 1f, 4f);
    }

    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move

        RijDoorloopCount = Script_Trigger2.rijDoorloopCount;

        if (inDeRijStaan == false && wegLopen == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, MensIdleSpot, step);
        }

        if (transform.position == MensIdleSpot)
        {
            if (gameObject.name == ("Mens_Obj" + GameObject.Find("Koeien&MensenCounter").GetComponent<Script_Counter>().mensCount))
            {
                inDeRijStaan = true;
            }   
        }

        if (inDeRijStaan == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, burgerOphaalSpot, step);
        }

        if (transform.position == burgerOphaalSpot)
        {
            wegLopen = true;
        }

        if (wegLopen == true && burgerGepakt == true)
        {
            inDeRijStaan = false;
            transform.position = Vector3.MoveTowards(transform.position, wegLoopSpot, step);
            
        }

        if (transform.position == wegLoopSpot)
        {
            wegLopen = false;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Hamburger_Obj" + GameObject.Find("Koeien&MensenCounter").GetComponent<Script_Counter>().burgerCount)
        {
            hamburger.SetActive(true);
            burgerGepakt = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawCube(Center2, Size2);
    }
}
