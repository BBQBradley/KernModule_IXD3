using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Script_Spawn2 : MonoBehaviour
{
    public float timeLeft = 30.0f;

    public float timeRound0 = 30.0f;
    public float timeRound1 = 30.0f;
    public float timeRound2 = 30.0f;
    public float timeRound3 = 30.0f;
    public float timeRound5 = 30.0f;

    private bool TimerStart = true;

    public Text TimerText;

// ------------------------------------------

    public GameObject Koe;
    public GameObject Koe2;
    public GameObject Mens;
    public GameObject Hamburger;

    public Vector3 Center;
    public Vector3 Size;

    public Vector3 Center3;
    public Vector3 Size3;

    public Quaternion min;

    private int spawnedKoeien;

    private int spawnedMensen;
    private int spawnedMensenCount;
    private bool boolSpawnMensen = false;


    private int spawnedBurgers;


    // ---------------
    public GameObject nextKnop;


    public GameObject textWolk;
    public TMP_Text textInWolk;

    public GameObject textWolk2;
    public TMP_Text textInWolk2;


    private int Rounds;

    public Animator Anim;
    public Animator Anim2;
    public Animator Anim3;

    // ------------------ QuickTime Event

    public GameObject quickTime;
    public RectTransform quickTimeMask;
    private float heightRect = 3.00f;

    private bool quickTimeBool = false;

    private bool quickTimeGehaald = false;


    void Update()
    {

        timeLeft -= Time.deltaTime;

        GameObject[] Koeien;

        Koeien = GameObject.FindGameObjectsWithTag("Koe");

        GameObject[] Burgers;

        Burgers = GameObject.FindGameObjectsWithTag("Burger");

        if (TimerStart == false & Rounds == 0)
        {
            if (timeLeft > 0.1f)
            {
                TimerText.text = timeLeft.ToString("0"); 
                //Debug.Log(timeLeft);
            }
            else
            {
                TimerText.text = ("0");
                Rounds = 1;
                TimerStart = true;
            }
        }

        if (TimerStart == false && Rounds == 1)
        {
            if (timeLeft > 0.1f)
            {
                TimerText.text = timeLeft.ToString("0");
                textWolk.SetActive(true);
                textInWolk.text = ("Heey! jij daar! Wil jij mij helpen met het vinden van hamburger eters?");
            }
            else
            {
                TimerText.text = ("0");
                nextKnop.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    textWolk.SetActive(false);
                    textInWolk.text = (" ");
                    Rounds = 2;
                    TimerStart = true;
                    nextKnop.SetActive(false);
                }

            }
        }

        if (TimerStart == false && Rounds == 2)
        {
            if (timeLeft > 0.1f)
            {
                TimerText.text = timeLeft.ToString("0");
            }
            else
            {
                TimerText.text = ("0");
                Rounds = 3;
                TimerStart = true;
            }
        }

        if (TimerStart == false && Rounds == 3)
        {
            if (timeLeft > 0.1f)
            {
                TimerText.text = timeLeft.ToString("0");
                textWolk.SetActive(true);
                textInWolk.text = ("Ik regel de koeien, als jij er voor zorgt dat mensen mijn hamburgers kopen en eten!");
            }
            else
            {
                TimerText.text = ("0");
                nextKnop.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Anim.SetBool("NextDay", true);
                    textWolk.SetActive(false);
                    textInWolk.text = (" ");
                    nextKnop.SetActive(false);

                    Rounds = 4;
                    TimerStart = true;
                }
            }
        }

        if (TimerStart == false & Rounds == 4)
        {
            if (quickTimeBool == true)
            {
                quickTime.SetActive(true);

                if (heightRect > 3.0f && heightRect <= 17.1f)
                {
                    heightRect = heightRect - 0.018f;
                }
                else if (heightRect > 17.1f)
                {
                    Debug.Log("Gehaald");
                    quickTimeGehaald = true;
                    quickTimeBool = false;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    heightRect = heightRect + 0.5f;
                }

                quickTimeMask.sizeDelta = new Vector2(2.7f, heightRect);
            }

            if (quickTimeGehaald == true)
            {
                quickTime.SetActive(false);
                heightRect = 3.00f;


                // hier de code wat die moet doen

                for (int i = 0; i < 10; i++)
                    SpawnMensen();

                quickTimeGehaald = false;

                textInWolk.text = ("Wat goed! We hebben genoeg klanten!");
            }

            if (spawnedMensenCount == 1)
            {
                textWolk.SetActive(false);
            }
            if (spawnedMensenCount < 10)
            {
                Anim.SetBool("NextDay", false);
                boolSpawnMensen = true;

                textWolk.SetActive(true);
                textInWolk.text = ("Jij kan mij vast helpen met het vinden van hamburger vreters?");
            }
            else
            {
                boolSpawnMensen = false;
            }

            if (Koeien.Length == 9)
            {
                textWolk.SetActive(false);
            }


            if (Koeien.Length >= 5 && Koeien.Length <= 6)
            {
                textWolk.SetActive(true);
                textInWolk.text = ("1 Hamburgertje per persoon kan toch geen kwaad? Dus iedereen koop mijn hamburgers!");
            }
            else if (Koeien.Length == 2)
            {
                textWolk.SetActive(false);
            }
            else if (Koeien.Length == 0 && Burgers.Length == 0)
            {
                textWolk.SetActive(true);
                textInWolk.text = ("Wow alles is verkocht! Zolang er mensen zijn die hamburgers eten, blijf ik lekker koeien in de wei zetten!");

                nextKnop.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Anim.SetBool("NextDay", true);

                    nextKnop.SetActive(false);
                    textWolk.SetActive(false);
                    quickTimeBool = true;
                    Rounds = 5;
                    TimerStart = true;
                }
            }
        }

        if (TimerStart == false & Rounds == 5)
        {
            if (quickTimeBool == true)
            {
                quickTime.SetActive(true);

                if (heightRect > 3.0f && heightRect <= 17.1f)
                {
                    heightRect = heightRect - 0.018f;
                }
                else if (heightRect > 17.1f)
                {
                    Debug.Log("Gehaald");
                    quickTimeGehaald = true;
                    quickTimeBool = false;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    heightRect = heightRect + 0.5f;
                }

                quickTimeMask.sizeDelta = new Vector2(2.7f, heightRect);
            }

            if (quickTimeGehaald == true)
            {
                quickTime.SetActive(false);
                heightRect = 3.00f;


                // hier de code wat die moet doen

                for (int i = 0; i < 15; i++)
                    SpawnMensen();

                quickTimeGehaald = false;

                if (textWolk.active == false)
                {
                    textWolk.SetActive(true);
                    textInWolk.text = ("Hamburgers voor iedereen!");
                }
                else 
                {
                    textWolk.SetActive(false);
                }
            }

            if (spawnedMensenCount < 30)
            {
                boolSpawnMensen = true;
            }
            else
            {
                boolSpawnMensen = false;
            }

            if (spawnedMensenCount == 30)
            {
                textWolk.SetActive(true);
                textInWolk.text = ("Yeah er zijn nog meer klanten dan gister!!");
            }

            if (Koeien.Length == 20)
            {
                textWolk.SetActive(true);
                textInWolk.text = ("We hebben meer mensen nodig!");
                quickTimeBool = true;

            }
            else if (Koeien.Length >= 26 && Koeien.Length <= 27)
            {
                textWolk.SetActive(false);
            }
            else if (Koeien.Length >= 20 && Koeien.Length <= 25)
            {
                textWolk.SetActive(true);
                textInWolk.text = ("Ahh nice! Ga zo door. Hamburgers te koop!");
            }
            else if (Koeien.Length == 17)
            {
                textWolk.SetActive(false);
            }


            if (Koeien.Length == 0 && Burgers.Length == 0)
            {
                Anim.SetBool("NextDay", false);

                textWolk.SetActive(true);
                textInWolk.text = ("Iedereen blijft maar hamburgers eten. Daarom ben ik er morgen weer met heel veel koeien!");

                nextKnop.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Anim3.SetBool("Sky", true);
                    Anim.SetBool("NextDay", true);

                    nextKnop.SetActive(false);
                    textWolk.SetActive(false);
                    Rounds = 6;
                    TimerStart = true;
                }
            }
        }

        if (TimerStart == false & Rounds == 6)
        {
            Anim2.SetBool("cameraMove", true);
            textWolk2.SetActive(false);

            if (timeLeft < 60.0f && timeLeft > 45.0f)
            {
                textWolk2.SetActive(true);
                textInWolk2.text = ("Misschien zijn al die Koeien toch niet zo een slim idee..");
            }
            if (timeLeft < 43.0f && timeLeft > 27.0f)
            {
                textWolk2.SetActive(true);
                textInWolk2.text = ("Al die koeien scheten zorgen er voor dat de aarde opwarmt. Dat is dus slecht voor het milieu..");
            }

            if (timeLeft > 10.0f && timeLeft < 24.0f)
            {
                textWolk2.SetActive(true);
                textInWolk2.text = ("Er zijn heel veel koeien op aarde omdat er heel veel vlees gegeten wordt..");
            }

            if (timeLeft < 10.0f && timeLeft < 0)
            {
                textWolk2.SetActive(true);
                textInWolk2.text = ("Daarom kunen we maar beter minder vlees eten.. De Volgende keer sla ik toch maar die hamburger over!");
            }

        }
            // ----------------------------------------

        if (TimerStart == true)
        {
            if(Rounds == 0)
            {
                timeLeft = timeRound0;
            }
            if (Rounds == 1)
            {
                timeLeft = timeRound1;
            }
            if (Rounds == 2)
            {
                timeLeft = timeRound2;
            }
            if (Rounds == 3)
            {
                timeLeft = timeRound3;
            }
            if (Rounds == 4)
            {
                quickTimeBool = true;

                for (int i = 0; i < 10; i++)
                    SpawnKoeien();
            }
            if (Rounds == 5)
            {
                for (int i = 0; i < 30; i++)
                    SpawnKoeien();

                spawnedMensenCount = 0;
            }
            if (Rounds == 6)
            {
                for (int i = 0; i < 60; i++)
                    SpawnKoeien2();

                spawnedMensenCount = 0;
                timeLeft = 60;
            }

            TimerStart = false;
        }
    }


    

    public void SpawnHamburgers()
    {
        Hamburger.name = "Hamburger_Obj" + spawnedBurgers;

        Vector3 pos = new Vector3(2.84f, 1.19f, 4f);

        GameObject Hamburger_Obj = Instantiate(Hamburger, pos, Quaternion.identity);

        Hamburger_Obj.name = Hamburger_Obj.name.Replace("(Clone)", "");

        spawnedBurgers++;
    }

    public void SpawnKoeien()
    {
        Vector3 pos = Center + new Vector3(Random.Range(-Size.x / 2, Size.x / 2), Random.Range(-Size.y / 2, Size.y / 2), Random.Range(-Size.z / 2, Size.z / 2));

        Koe.name = "Koe_Obj" + spawnedKoeien;

        GameObject Koe_Obj = Instantiate(Koe, pos, Quaternion.identity);

        Koe_Obj.name = Koe_Obj.name.Replace("(Clone)", "");

        spawnedKoeien++;
    }

    public void SpawnKoeien2()
    {
        Vector3 pos = Center + new Vector3(Random.Range(-Size.x / 2, Size.x / 2), Random.Range(-Size.y / 2, Size.y / 2), Random.Range(-Size.z / 2, Size.z / 2));

        Koe2.name = "Koe_Obj" + spawnedKoeien;

        GameObject Koe_Obj = Instantiate(Koe2, pos, Quaternion.identity);

        Koe_Obj.name = Koe_Obj.name.Replace("(Clone)", "");

        spawnedKoeien++;

    }

    public void SpawnMensen()
    {
        spawnedMensenCount++;

        if (boolSpawnMensen == true)
        {
            Vector3 pos = Center3 + new Vector3(Random.Range(-Size3.x / 2, Size3.x / 2), Random.Range(-Size3.y / 2, Size3.y / 2), Random.Range(-Size3.z / 2, Size3.z / 2));

            Mens.name = "Mens_Obj" + spawnedMensen;

            GameObject Mens_Obj = Instantiate(Mens, pos, Quaternion.identity);

           // Mens_Obj.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));

            Mens_Obj.name = Mens_Obj.name.Replace("(Clone)", "");

            spawnedMensen++;
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);

        Gizmos.DrawCube(Center, Size);

        Gizmos.color = new Color(0, 2, 100, 0.5f);

        Gizmos.DrawCube(Center3, Size3);
    }
}
