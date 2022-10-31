using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    AudioSource audiosource;

    [SerializeField] private float thrustForce = 1000f;
    [SerializeField] private float rotationForce = 500f;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
    }
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
       
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustForce *Time.deltaTime);
            if (!audiosource.isPlaying)
            {
                audiosource.Play();

            }
        }
        else
        {
            audiosource.Stop();
        }
        
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotationForce);
        }

        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotationForce);
        }


    }

     void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Kullan�c� girdi verdi�i zaman rotation'� dondurur.
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // Kullan�c� girdi vermeyi b�rakt��� zaman rotation'� serbest b�rak�r.
    }
}
