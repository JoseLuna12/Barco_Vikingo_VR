using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TechTweaking.Bluetooth;

public class juegoMenus : MonoBehaviour {
    private BluetoothDevice device;

    public Transform camera;

    public GameObject pausa;
    public GameObject seguro;
    public GameObject cursor;

    bool curso = false;

    // Use this for initialization
    void Start()
    {        
        pausa.SetActive(false);
        seguro.SetActive(false);
        cursor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 forward = camera.transform.TransformDirection(Vector3.forward) * 1000;
        Debug.DrawRay(camera.position, forward, Color.green);
        Ray rayo = new Ray(camera.position, forward);
        RaycastHit hit;

        if (Physics.Raycast(rayo, out hit))
        {
            //Objeto.text = hit.collider.name;
            //hit.collider.gameObject.SetActive(false);
            if (hit.collider.name == "Jugar")
            {
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    SceneManager.LoadScene(1);
                }
                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene(1);
                }
            }
            if (hit.collider.name == "Salir")
            {
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    salir();
                }
                if (Input.GetMouseButtonDown(0))
                {
                    salir();
                }
            }
            if (hit.collider.name == "Continuar")
            {
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    continuar();
                }
                if (Input.GetMouseButtonDown(0))
                {
                    continuar();
                }
            }
            if (hit.collider.name == "si")
            {
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    exit();
                }
                if (Input.GetMouseButtonDown(0))
                {
                    exit();
                }
            }
            if (hit.collider.name == "no")
            {
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    continuar();
                }
                if (Input.GetMouseButtonDown(0))
                {
                    continuar();
                }
            }
            if (hit.collider.name == "ConectarBT")
            {
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    device.connect();
                }
                if (Input.GetMouseButtonDown(0))
                {
                    device.connect();
                }
            }
            
        }

        if (Input.GetKey("escape"))
        {
            salir();
        }

        if (Input.GetKeyDown("space"))
        {
            //curso = !curso;
            salir();
            //cursor.SetActive(curso);
        }

        if (OVRInput.Get(OVRInput.Button.Back))
        {
            salir();
        }

    }

    void salir()
    {
        cursor.SetActive(true);
        Time.timeScale = 0f;
        pausa.SetActive(true);
        seguro.SetActive(false);
        
    }

    void continuar()
    {
        Time.timeScale = 1f;
        pausa.SetActive(false);
        seguro.SetActive(false);
        cursor.SetActive(false);
    }

    void exit()
    {
        Application.Quit();
    }
}
