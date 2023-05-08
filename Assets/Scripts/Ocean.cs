using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean : MonoBehaviour
{
    public GameObject canvas;
    public AudioSource reward;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "XR Origin")
        {
            canvas.SetActive(true);
            StartCoroutine("WaitBeforeDisable");
        }
    }

    IEnumerator WaitBeforeDisable()
    {
        reward.Play();
        yield return new WaitForSeconds(6);
        canvas.SetActive(false);
    }
}
