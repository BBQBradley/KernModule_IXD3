using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Trigger2 : MonoBehaviour
{
    public static int rijDoorloopCount;

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == ("Mens_Obj" + GameObject.Find("Koeien&MensenCounter").GetComponent<Script_Counter>().mensCount))
        {
            //rijDoorloopCount = 1;
            GameObject.Find("Koeien&MensenCounter").GetComponent<Script_Counter>().mensCount++;
        }
    }

}
