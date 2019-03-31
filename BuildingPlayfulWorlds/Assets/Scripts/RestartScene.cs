using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    [SerializeField] float timeBeforeRestart = 5;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForRestart());
    }

    IEnumerator waitForRestart()
    {
        yield return new WaitForSeconds(timeBeforeRestart);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
