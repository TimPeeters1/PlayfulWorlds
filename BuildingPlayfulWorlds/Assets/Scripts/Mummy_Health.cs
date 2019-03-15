using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable {
    void DoDamage(int damage);
}

public class Mummy_Health : MonoBehaviour, IDamagable
{
    [SerializeField] int MaxHealth;
    [SerializeField] int currentHealth;

    Rigidbody[] rb;

    public void DoDamage(int damage)
    {
        currentHealth -= damage;
    }

    void Start()
    {
        currentHealth = MaxHealth;
        rb = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody child in rb)
        {
            child.isKinematic = true;
        }
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            UnfreezeRagdoll();
        }
    }

    void UnfreezeRagdoll()
    {
        GetComponentInChildren<Animator>().enabled = false;
        foreach (Rigidbody child in rb)
        {
            child.isKinematic = false;
        }
        this.transform.DetachChildren();
        Destroy(this.gameObject);

    }

}
