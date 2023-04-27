using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool shown;
    private bool flagged;
    private Material baseMaterial;
    public Material hiddenmaterial;
    public Material flagMaterial;
    void Start()
    {
        flagged = false;
        shown = false;
        baseMaterial = this.GetComponent<Renderer>().material;
        if (shown)
        {
            this.GetComponent<Renderer>().material = baseMaterial;
        }
        else if (flagged)
        {
            this.GetComponent<Renderer>().material = flagMaterial;
        }
        else
        {
            this.GetComponent<Renderer>().material = hiddenmaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
