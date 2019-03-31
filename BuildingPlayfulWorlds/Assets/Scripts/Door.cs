using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    /*
    Deze code handled de deuren in de puzzel. Als de speler op E drukt en alle objective onderdelen (relics)
    verzameld zijn, opent de deur met een animatie en gebluid.
    In het script relic.cs wordt doorgegeven aan dit script of een object is verzameld.
    */

    public Relic[] objectives;
    public int collected;

    [Space]
    [SerializeField] bool hasOpened;
    [SerializeField] bool gatheredAll = false;

    [Space]
    [SerializeField] Text doorText; //De UI/tekst die zich op de deur bevindt
    Text textUI; // de UI/tekst die zich alleen op de HUD van de player bevindt.
    [SerializeField] string UI_Message;

    Animator anim;
    AudioSource audioSr;

    // Start is called before the first frame update
    void Start()
    {
        textUI = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<Text>();
        textUI.text = "";
        anim = GetComponent<Animator>();
        audioSr = GetComponent<AudioSource>();

        for (int i = 0; i < objectives.Length; i++)
        {
            objectives[i].doorObjects.Add(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        doorText.text = collected + "/" + objectives.Length;

        if(collected >= objectives.Length)
        {
            gatheredAll = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" & gatheredAll & !hasOpened)
        {
            textUI.text = UI_Message;
            if (Input.GetKey(KeyCode.E))
            {
                OpenDoor();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" & gatheredAll)
        {
            textUI.text = "";
        }
    }

    void OpenDoor()
    {
        audioSr.Play();
        anim.Play("OpenDoor");
        hasOpened = true;
    }
}
