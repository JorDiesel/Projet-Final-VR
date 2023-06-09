using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Tile : MonoBehaviour
{
    private bool shown;
    private bool flagged;
    private bool mine;
    public bool flageable;
    private Material baseMaterial;
    public Material hiddenmaterial;
    public Material flagMaterial;
    //public GameObject mainCamera;
    private AudioSource bombAudio;

    public UnityEvent flagEvent;
    public UnityEvent unflagEvent;

    void Start()
    {
        shown = false;
        flagged = false;
        flageable = true;
        baseMaterial = this.GetComponent<Renderer>().material;
        mine = baseMaterial.name == "Mine (Instance)";
        this.GetComponent<Renderer>().material = hiddenmaterial;
        bombAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "XR Origin")
        {
            if (!flagged && !shown && mine && flageable)
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
            if (flagged)
            {
                return;
            }
            else if (mine && flageable)
            {
                ExplodedMine();
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
        shown = true;
    }

    public void GetFlagged()
    {
        if(flageable)
        {
            if (flagged)
            {
                this.GetComponent<Renderer>().material = hiddenmaterial;
                unflagEvent.Invoke();
            }
            else
            {
                this.GetComponent<Renderer>().material = flagMaterial;
                flagEvent.Invoke();
            }
            StartCoroutine("WaitFlagged");
            flagged = !flagged;
        }
    }

    public void ExplodedMine()
    {
        flageable = false;
        GetShown();
        StartCoroutine("Died");
    }

    IEnumerator Died()
    {
        bombAudio.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    IEnumerator WaitFlagged()
    {
        flageable = false;
        yield return new WaitForSeconds(1);
        flageable = true;
    }
}