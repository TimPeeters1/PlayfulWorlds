using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    public int menuLevel;

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuLevel);
    }
}
