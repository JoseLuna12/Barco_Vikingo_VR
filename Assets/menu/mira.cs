using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mira : MonoBehaviour {

    public Transform pistola;
    public Text Objeto;
    public GameObject cubo;
    bool tengo = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 forward = pistola.transform.TransformDirection(Vector3.right) * 1000;
        Debug.DrawRay(pistola.position, forward, Color.green);
        Ray rayo = new Ray(pistola.position, forward);
        RaycastHit hit;

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) {
       

        if (Physics.Raycast(rayo, out hit)) {
                //Objeto.text = hit.collider.name;
                //hit.collider.gameObject.SetActive(false);
            if (hit.collider.tag == "levantable") {
                    tengo = true;
                    cubo = hit.transform.gameObject;
                    cubo.transform.SetParent(pistola);
                    cubo.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    cubo.gameObject.GetComponent<Rigidbody>().Sleep();

                    if (OVRInput.Get(OVRInput.Button.DpadDown)) {
                        cubo.transform.Translate(Vector3.back * Time.deltaTime);
                    }

                    if (OVRInput.Get(OVRInput.Button.DpadDown)) {
                        cubo.transform.Translate(Vector3.forward * Time.deltaTime);
                    }

                }

        } 

          

        } else {
            if (tengo) {
                cubo.transform.SetParent(null);
                cubo.gameObject.GetComponent<Rigidbody>().useGravity = true;
                cubo.gameObject.GetComponent<Rigidbody>().WakeUp();
            }
            tengo = false;
        }

    }
}
