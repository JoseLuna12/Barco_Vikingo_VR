using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {
    Rigidbody rb;
    float h;
    float x;
    float rot;
    bool adelante;

    Vector3 rotDir;

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        Vector3 moveVector = new Vector3(300, 0, 0) * (Time.deltaTime * 10);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            x = 1;
            Debug.Log("Push " + x+ " " + h);
            //rb.AddForce(1000, 0, 0, ForceMode.Impulse);
            //rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 10, Space.World);
            //transform.Translate(moveVector, Space.Self);
            //rb.AddForce(moveVector, ForceMode.Acceleration);
        }else if (Input.GetKeyUp(KeyCode.Space))
        {
            x = 0;
        }

        h = Mathf.Lerp(h, x, Time.deltaTime*10);


        transform.Translate(h*(-1), 0, 0);



        if (Input.GetKeyDown(KeyCode.A))
        {
            //h = -15;
            //rb.AddTorque(transform.right * h);
            //transform.Rotate(new Vector3(0, 10, 0) * (Time.deltaTime * 10), Space.Self);
            //Debug.Log("RotarA " + h );
            rot = 100;
        } else if (Input.GetKeyUp(KeyCode.A))
        {
            rot = 0;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rot = -100;
            //Debug.Log("RotarD" + h);
            //h = 15;
            //rb.AddTorque(transform.right * h);
            //transform.Rotate(new Vector3(0, -10, 0) * (Time.deltaTime * 10), Space.Self);
            //rb.AddForce(transform.forward * 5);
            //rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 10);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rot = 0;
        }

        rotDir = new Vector3(0, rot, 0);

        Quaternion deltaRotation = Quaternion.Euler(rotDir * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);



    }
}
