using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public GameObject prototypeBomb;
    public float speed = 8.0f;

    private void Start()
    {
        StartCoroutine("DeletePlane");
    }


    private void FixedUpdate()
    {
        transform.Translate(-(speed * Time.deltaTime), 0, 0);
    }

    IEnumerable DeletePlane()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
