using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField]
    Vector2 forseDir;
    [SerializeField]
    int spin;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(forseDir);
        rb.AddTorque(spin);
    }
}
