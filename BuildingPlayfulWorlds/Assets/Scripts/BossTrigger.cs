using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] Torch[] torches;


    bool isActive = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !isActive)
        {
            StartBossBattle();
            isActive = true;
        }
    }

    void StartBossBattle()
    {
        for (int i = 0; i < torches.Length; i++)
        {
            torches[i].Fire.SetActive(true);
            torches[i].isIgnited = true;
        }
    }


}
