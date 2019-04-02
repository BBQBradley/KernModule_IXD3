using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Script_KoeMovement : MonoBehaviour
{
    public Vector3 Center2;
    public Vector3 Size2;

    public Vector3 koeFabriekSpot;

    public Vector3 koeFabriekSlachtSpot;
    private Vector3 koeIdleSpot;

    private float speed = 40.0f;

    private bool inDeRijStaan = false;
    private bool inDeRijStaanBool = false;
    private bool inDeFabriekGaan = false;

    
    private static int WachtRijCount;

    private float tweeSeconde = 1.0f;

    // ---------------
    
    public Animator Anim;

    // ------------- Particle / puf en boer time

    public ParticleSystem Puf;
    protected bool letPlay = true;
    private float pufStartTime = 0f;

    private int randomKoe;

    public static int slicedKoeien = 0; 

    private float time;
    private float time2;

    private float boeStartTime = 0f;



    // ----------------- Audio

    AudioSource AudioSource;

    public AudioSource AudioSource2;

    public AudioClip pufSound1;
    public AudioClip pufSound2;

    public AudioClip boeSound1;

    void Awake()
    {
        koeIdleSpot = Center2 + new Vector3(Random.Range(-Size2.x / 2, Size2.x / 2), 1f, Random.Range(-Size2.z / 2, Size2.z / 2));

        AudioSource = GetComponent<AudioSource>();

        AudioSource2 = GetComponent<AudioSource>();
    }

    void SetRandomTime()
    {
        pufStartTime = (Random.Range(2.0f, 8.0f));
        boeStartTime = (Random.Range(8.0f, 20.0f));
    }


    void Update()
    {
        GameObject[] Koeien;
        Koeien = GameObject.FindGameObjectsWithTag("Koe");

        randomKoe = Random.Range(slicedKoeien, (slicedKoeien + Koeien.Length));

        Debug.Log(randomKoe);


        WachtRijCount = Script_Trigger.wachtRijCount;

        GameObject[] Burgers;
        Burgers = GameObject.FindGameObjectsWithTag("Burger");

        SetRandomTime();
        
        // de getalen tellen op van de koeien

        

        time += Time.deltaTime;

        time2 += Time.deltaTime;


        if (time > pufStartTime)
        {
            if (gameObject.name == ("Koe_Obj" + randomKoe))
            {
                AudioSource.PlayOneShot(pufSound1, 1.0F);
                Puf.Play();
            }
            time = 0;
        }

        if (time2 > boeStartTime)
        {
            if (gameObject.name == ("Koe_Obj" + randomKoe))
            {
                AudioSource2.PlayOneShot(boeSound1, 1.0F);
            }
            time2 = 0;
        }

        


        float step = speed * Time.deltaTime;

        

        if (Burgers.Length == 0)
        {
            inDeRijStaanBool = true;
        }

        if (inDeRijStaan == false && inDeFabriekGaan == false)
        {
            Anim.SetBool("isWalking", true);
            transform.position = Vector3.MoveTowards(transform.position, koeIdleSpot, step);
        }

        if (transform.position == koeIdleSpot)
        {
            Anim.SetBool("isWalking", false);

            if (gameObject.name == ("Koe_Obj" + GameObject.Find("Koeien&MensenCounter").GetComponent<Script_Counter>().koeCount))
            {
                    inDeRijStaan = true;
            }
        }

        if (inDeRijStaan == true)
        {
            Anim.SetBool("isWalking", true);
            transform.position = Vector3.MoveTowards(transform.position, koeFabriekSpot, (20.0f * Time.deltaTime));
        }

        if (transform.position == koeFabriekSpot && WachtRijCount == 1)
        {
            inDeRijStaan = false;
            inDeFabriekGaan = true;
        }


        if (inDeFabriekGaan == true)
        {
            Anim.SetBool("isWalking", true);
            transform.position = Vector3.MoveTowards(transform.position, koeFabriekSlachtSpot, (10.0f * Time.deltaTime));
        }

        if (transform.position == koeFabriekSlachtSpot)
        {
            Anim.SetBool("isWalking", false);

            GameObject.Find("Koeien&MensenCounter").GetComponent<Script_Counter>().koeCount++;

            GameObject.Find("Scripts").GetComponent<Script_Spawn2>().SpawnHamburgers();
            
            Debug.Log("Geslacht");
            slicedKoeien++;
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawCube(Center2, Size2);
    }
}
