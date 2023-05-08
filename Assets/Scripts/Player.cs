using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] private InputActionReference swapActionReference;

    public GameObject shovel;
    public GameObject flag;
    public bool isActive = false;
    public GameObject canvas;
    public AudioSource reward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (swapActionReference.action.triggered)
        {
            isActive = !isActive;
            shovel.SetActive(!isActive);
            flag.SetActive(isActive);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ocean")
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
