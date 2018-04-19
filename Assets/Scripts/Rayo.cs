using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayo : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "Lamb")
            Destroy(gameObject);
    }
}

