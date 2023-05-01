using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool shown;
    private bool flagged;
    private bool mine;
    private Material baseMaterial;
    public Material hiddenmaterial;
    public Material flagMaterial;
    void Start()
    {
        shown = false;
        flagged = false;
        baseMaterial = this.GetComponent<Renderer>().material;
        mine = baseMaterial.name == "Mine (Instance)";
        this.GetComponent<Renderer>().material = hiddenmaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "XR Origin")
        {
            if (!flagged && !shown && mine)
            {
                ExplodedMine();
            }
        }
        else if (other.tag == "Flag")
        {
            if (!shown)
            {
                GetFlagged();
            }
        }
        else if (other.tag == "Shovel")
        {
            if (mine)
            {
                ExplodedMine();
            }
            else if (flagged)
            {
                return;
            }
            else
            {
                GetShown();
            }
        }
    }

    public void GetShown()
    {
        this.GetComponent<Renderer>().material = baseMaterial;
    }

    public void GetFlagged()
    {
        if (flagged)
        {
            this.GetComponent<Renderer>().material = hiddenmaterial;


        }
        else
        {
            this.GetComponent<Renderer>().material = flagMaterial;
        }
        flagged = !flagged;
    }

    public void ExplodedMine()
    {
        Debug.Log("Kaboom! You funcking died!");
    }
}
