using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptMoneda : MonoBehaviour {

    //public AudioSource moneda;
    private float vuelta =60;


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(Vector3.right * Time.deltaTime * vuelta);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<JugadorManager>().monedaNueva();
            other.gameObject.GetComponent<JugadorManager>().monedaSonido();
            Debug.Log(other.gameObject.tag + " entro al trigger de moneda ");
            vuelta = 10;
            this.gameObject.SetActive(false);
        }
        //this.gameObject.SetActive(false);
        

    }

}
