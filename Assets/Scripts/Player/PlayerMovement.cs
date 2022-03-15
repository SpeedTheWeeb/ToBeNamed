using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speedMultiplier = 10;
    public float rotateMultiplier = 100;
    Vector3 rotation;
    float hInput;
    float vInput;

    public CharacterController _controller;
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

        Vector3 direction = new Vector3(hInput, 0, vInput);
        rb.velocity = direction * speedMultiplier;

        //float angle = Mathf.Atan2(hInput, vInput) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle * -1, Vector3.forward);
        transform.rotation = Quaternion.LookRotation(new Vector3(hInput, 0, vInput));
    }
}
