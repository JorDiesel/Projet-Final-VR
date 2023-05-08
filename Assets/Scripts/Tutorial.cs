using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public InputActionReference AActionReference;

    private bool playerIsEnter = false;
    public int swapState = 0;

    private void Start()
    {
        textMesh.text = "Appuyer sur la touche A pour changer entre la pelle et le drapeau";
    }

    private void Update()
    {

        if (AActionReference.action.triggered)
        {
            textMesh.text = "Utiliser la pelle pour decouvrir la case ou bien le drapeau pour marqué un case ";
        }
    }
}