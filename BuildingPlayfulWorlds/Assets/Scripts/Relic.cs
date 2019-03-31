using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Relic : MonoBehaviour
{
    /*
    Dit script zorgt ervoor dat je een objective (relic) kan verzamelen in de game,
    en hiermee deuren kan openen.
    */
    Text textUI;
    [SerializeField] string UI_Message;

    public List<Door> doorObjects;

    private void Start()
    {
        textUI = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<Text>();
        textUI.text = "";
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            textUI.text = UI_Message;
            if (Input.GetKey(KeyCode.E))
            {
                for (int i = 0; i < doorObjects.Count; i++)
                {
                    doorObjects[i].collected++;
                }
                
                textUI.text = "";
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            textUI.text = "";
        }
    }
}
