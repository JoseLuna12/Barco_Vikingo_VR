using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaScript : MonoBehaviour {

    public GameObject agua;

	// Use this for initialization
	void Start () {
        agua.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger

        agua.SetActive(true);
        if (other.gameObject.name == "Camera"){
            agua.SetActive(true);
        }

    }
}
