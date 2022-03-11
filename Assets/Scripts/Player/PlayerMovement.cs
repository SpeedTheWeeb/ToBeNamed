using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speedMultiplier = 10;
    float hInput;
    float vInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //Check if Rigidbody is on player
        if (rb != null)
        {
            Vector3 direction = new Vector3(hInput, 0, vInput);
            rb.velocity = direction * speedMultiplier;
        }
    }
}
