using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBattle : MonoBehaviour
{
    public GameObject BossAI;

    public GameObject endScreen;

    private void Start()
    {
        endScreen.SetActive(false);
    }

    public IEnumerator FinishGame()
    {

        Time.timeScale = 0.2f;
        endScreen.SetActive(true);

        yield return new WaitForSeconds(10);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
