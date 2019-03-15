using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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
