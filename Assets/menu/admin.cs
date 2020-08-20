using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class admin : MonoBehaviour {

    public Text info;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) {
            info.text = "hache hache ";
        }

        if (OVRInput.Get(OVRInput.Button.One)) {
            info.text = "hache central";
        }

        if (OVRInput.Get(OVRInput.Button.DpadDown)) {
            info.text = "hache abajo";
        }

        if (OVRInput.Get(OVRInput.Button.DpadUp)) {
            info.text = "hache arriba";
        }

        if (OVRInput.Get(OVRInput.Button.DpadRight)) {
            info.text = "hache derecha";
        }

        if (OVRInput.Get(OVRInput.Button.DpadLeft)) {
            info.text = "hache izquierda";
        }

    }
}
