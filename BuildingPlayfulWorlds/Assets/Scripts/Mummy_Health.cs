using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public interface IDamagable {
    void DoDamage(int damage);
}

public class Mummy_Health : MonoBehaviour, IDamagable
{
    /*
    Dit is het script/de class die er voor zorgt dat mummy's damage nemen van bullets,
    deze zijn te vinden onder bullet.cs.
    */

    [SerializeField] bool isBoss;
    BossBattle battleScript;

    [SerializeField] Image healthBar;
    MummyAI ai;

    [SerializeField] float MaxHealth;
    public float currentHealth;

    Rigidbody[] rb;

    public void DoDamage(int damage)
    {
        currentHealth -= damage;
    }

    void Start()
    {
        ai = GetComponent<MummyAI>();

        currentHealth = MaxHealth;
        rb = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody child in rb)
        {
            child.isKinematic = true;
        }

        battleScript = FindObjectOfType<BossBattle>();
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            UnfreezeRagdoll();
        }

        healthBar.fillAmount = currentHealth / MaxHealth;
    }

    void UnfreezeRagdoll()
    {
        GetComponentInChildren<Animator>().enabled = false;
        foreach (Rigidbody child in rb)
        {
            child.isKinematic = false;
        }
        this.transform.DetachChildren();

        if (isBoss)
        {
            battleScript.StartCoroutine("FinishGame");
        }

        Destroy(this.gameObject);
    }

}
