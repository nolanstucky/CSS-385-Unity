using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody rb;
    public bool grounded = true;
    public float jumpPower;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            pos.z += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            pos.z -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, (speed * Time.deltaTime) * 5f, 0f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, -(speed * Time.deltaTime) * 5f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.Space) && grounded == true) 
        {
            Debug.Log("jumping");
            rb.AddForce(new Vector3(0f, 7f, 0f), ForceMode.Impulse);
            grounded = false;
        }

        transform.position = pos;

        if (IsOnPlatform() == false)
        {
            transform.position = new Vector3 (0f, 1f, 0f);
            transform.localEulerAngles = new Vector3(0f,0f,0f);
        }

    }

    private bool IsOnPlatform()
    {
        if (transform.position.y < -3f)
        {
            return false;
        }    
        return true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

}
