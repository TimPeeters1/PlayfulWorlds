using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] float DestroyTime;

    void Update()
    {
        Destroy(this.gameObject, DestroyTime);   
    }
}
