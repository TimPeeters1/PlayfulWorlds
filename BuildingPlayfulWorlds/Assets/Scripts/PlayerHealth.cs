using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

interface iDamagable
{
    void DoDamage(int Damage);
}

public class PlayerHealth : MonoBehaviour, iDamagable
{
    /*
     Player Health class dat ervoor zorgt dat je als speler
     damage kan nemen van enemies.
     */

    [Space]
    [SerializeField] int maxHealth;

    [Space]
    [SerializeField] int currentHealth;

    [Space]
    [SerializeField] Text healthUI;

    [Space]
    PostProcessProfile currentProfile;
    [SerializeField] PostProcessProfile normalProfile;
    [SerializeField] PostProcessProfile hitProfile;

    GameObject mainCam;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        currentProfile = normalProfile;

        currentHealth = maxHealth;
    }

    void Update()
    {
        healthUI.text = currentHealth + "/" + maxHealth;

        if(currentHealth <= 0)
        {
            Die();
        }

        mainCam.GetComponent<PostProcessVolume>().profile = currentProfile;
    }

    void iDamagable.DoDamage(int Damage)
    {
        currentHealth -= Damage;

        StartCoroutine(changeProfile());
    }

    IEnumerator changeProfile()
    {
        currentProfile = hitProfile;

        yield return new WaitForSeconds(1);

        currentProfile = normalProfile;
    }

    void Die()
    {
        currentProfile = hitProfile;
        foreach (Transform child in mainCam.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        mainCam.AddComponent<Light>();
        mainCam.AddComponent<Rigidbody>();
        mainCam.AddComponent<CapsuleCollider>();
        mainCam.AddComponent<RestartScene>();

        mainCam.transform.parent = null;

        Destroy(this.gameObject);
    }

}
