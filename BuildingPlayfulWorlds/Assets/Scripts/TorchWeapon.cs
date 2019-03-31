using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchWeapon : MonoBehaviour
{
    /*
    Trigger voor alles met een ignitable interface, hiermee steek je nieuwe torches aan.
    */

    private void OnTriggerStay(Collider other)
    {

        if (Input.GetButton("Fire1"))
            try
            {
                other.GetComponent<Ignitable>().Ignite();
            }
            catch 
            {

            }
    }
}
