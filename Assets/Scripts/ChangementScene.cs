using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour
{
    public void ChangerScene(string nomScene)
    {
        SceneManager.LoadScene(nomScene);
    }
}