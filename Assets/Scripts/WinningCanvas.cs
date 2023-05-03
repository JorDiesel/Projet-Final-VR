using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinningCanvas : MonoBehaviour
{

    private Button[] buttons;

    void Start()
    {
        buttons = gameObject.GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(ReturnToMenu);
    }

    private void ReturnToMenu()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
