using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SceneManager : MonoBehaviour
{
   public void GOTOGAME()
    {
        SceneManager.LoadScene(1);
    }

    public void GOTOMENU()
    {
        SceneManager.LoadScene(0);
    }
}
