using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface Ignitable
{
    void Ignite();
}

public class Torch : MonoBehaviour, Ignitable
{
    /*
     Main class voor de Ignitable interface,
     in combinatie met TorchWeapon.cs kan je torches aansteken
     */

    Text textUI;
    [SerializeField] string UI_Message;

    public GameObject Fire;
    public bool isIgnited;

    void Start()
    {
        textUI = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<Text>();
        textUI.text = "";

        Fire.SetActive(false);
    }

    void Ignitable.Ignite()
    {
        if(!isIgnited)
        Fire.SetActive(true);
        isIgnited = true;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && !isIgnited)
        {
            textUI.text = UI_Message;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            textUI.text = "";
        }
    }

}
