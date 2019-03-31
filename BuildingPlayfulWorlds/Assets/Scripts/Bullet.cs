using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Bullet script dat damage doet op alles met een IDamagable interface.
    //Dit script zit vast aan rigidbody bullets die gebruik maken van physics.

    public int Damage;

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            other.GetComponentInParent<IDamagable>().DoDamage(Damage);
        }

        catch
        {

        }
    }   
}
