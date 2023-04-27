using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public GameObject prototypeBomb;
    public float speed = 8.0f;

    private void Update()
    {
        if (Mathf.Approximately(this.transform.position.z, -3.0f))
        {
            print("I'm here");
            Instantiate(prototypeBomb, new Vector3(0, 10, 0), Quaternion.identity);
        }
    }


    private void FixedUpdate()
    {
        transform.Translate(-(speed * Time.deltaTime), 0, 0);
    }
}
