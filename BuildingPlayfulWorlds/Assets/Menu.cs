using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int level;

    public void LoadLevel()
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
