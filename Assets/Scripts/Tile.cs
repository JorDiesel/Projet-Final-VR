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
        baseMaterial = this.GetComponent<Renderer>().material;
        mine = baseMaterial.name == "Mine (Instance)";
        this.GetComponent<Renderer>().material = hiddenmaterial;
        bombAudio = GetComponent<AudioSource>();
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
            unflagEvent.Invoke();
        }
        else
        {
            this.GetComponent<Renderer>().material = flagMaterial;
            flagEvent.Invoke();
        }
        flagged = !flagged;
    }

    public void ExplodedMine()
    {
        //mainCamera.SetActive(false);
        StartCoroutine("Died");
    }

    IEnumerator Died()
    {
        bombAudio.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
