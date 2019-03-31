using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    /*
     Weaponmananger script/class dat ervoor zorgt 
     dat je tussen 2 verschillende wapens kan switchen als speler.
     */

    [SerializeField] GameObject currentWeapon;
    [SerializeField] GameObject[] Weapons;

    [SerializeField] Text wpNameUI;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].SetActive(false);
            Weapons[0].SetActive(true);

            currentWeapon = Weapons[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        wpNameUI.text = currentWeapon.name;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < Weapons.Length; i++)
            {
                Weapons[i].SetActive(false);
                Weapons[0].SetActive(true);

                currentWeapon = Weapons[0];
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int i = 0; i < Weapons.Length; i++)
            {
                Weapons[i].SetActive(false);
                Weapons[1].SetActive(true);
                currentWeapon = Weapons[1];
            }
        }
    }
}
