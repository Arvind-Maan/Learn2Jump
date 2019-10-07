using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    Collider2D collider; 
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<Movement2D>().isAttacking == true)
            collider.enabled = true;
        else
            collider.enabled = false;
    }
}
