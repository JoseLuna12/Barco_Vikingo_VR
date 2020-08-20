using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTutorial : MonoBehaviour {

    public GameObject tutorial;

    // Use this for initialization
    void Start () {
        tutorial.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Camera")
        {
            tutorial.SetActive(true);
        }
        //this.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Camera")
        {
            tutorial.SetActive(false);
        }
        //this.gameObject.SetActive(false);
    }


}
