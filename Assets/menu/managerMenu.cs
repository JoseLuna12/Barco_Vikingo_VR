using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TechTweaking.Bluetooth;

public class managerMenu : MonoBehaviour {


    
    public AudioSource tap;

    private BluetoothDevice device;

    public Transform camera;

    public GameObject cameraAnim;

    public Text texto;

    public GameObject iniciar;
    public GameObject pausa;
    public GameObject seguro;
    public GameObject cursor;

    public GameObject agua;

    Animator AnimacionComienzo;

    bool boolAnimacionComienzo = false;

    // Use this for initialization
    void Start () {

        AnimacionComienzo = cameraAnim.gameObject.GetComponent<Animator>();
        agua.SetActive(false);
        iniciar.SetActive(true);
        pausa.SetActive(false);
        seguro.SetActive(false);
        cursor.SetActive(true);
        //camera.position = new Vector3(-184, 16227, -13);
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 forward = camera.transform.TransformDirection(Vector3.forward) * 1000;
        Debug.DrawRay(camera.position, forward, Color.green);
        Ray rayo = new Ray(camera.position, forward);
        RaycastHit hit;

        if (Physics.Raycast(rayo, out hit))
        {

            texto.text = hit.collider.name;

            //Objeto.text = hit.collider.name;
            //hit.collider.gameObject.SetActive(false);
            if (hit.collider.name == "Jugar"){
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    tap.Play();
                    //SceneManager.LoadScene(1);
                    agua.SetActive(true);
                    AnimacionComienzo.SetBool("moverCamara", true);
                    inicioJuego();
                }
                if (Input.GetMouseButtonDown(0))
                {
                    tap.Play();
                    agua.SetActive(true);
                    AnimacionComienzo.SetBool("moverCamara", true);
                    inicioJuego();
                    //SceneManager.LoadScene(1);
                }
            }
            if (hit.collider.name == "Salir")
            {
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    tap.Play();
                    salir();
                }
                if (Input.GetMouseButtonDown(0))
                {
                    tap.Play();
                    salir();
                }
            }
            if (hit.collider.name == "Continuar")
            {
                if(OVRInput.Get(OVRInput.Button.One))
                {
                    tap.Play();
                    continuar();
                }
                if (Input.GetMouseButtonDown(0))
                {
                    tap.Play();
                    continuar();
                }
            }
            if (hit.collider.name == "si")
            {
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    tap.Play();
                    exit();
                }
                if (Input.GetMouseButtonDown(0))
                {
                    tap.Play();
                    exit();
                }
            }
            if (hit.collider.name == "no")
            {
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    tap.Play();
                    continuar();
                }
                if (Input.GetMouseButtonDown(0))
                {
                    tap.Play();
                    continuar();
                }
            }
            if (hit.collider.name == "ConectarBT")
            {
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    tap.Play();
                    //device.connect();
                }
                if (Input.GetMouseButtonDown(0))
                {
                    tap.Play();
                    //device.connect();
                }
            } 
        }

        if (Input.GetKey("escape"))
        {
            tap.Play();
            pausar();
        }
        

        if (OVRInput.Get(OVRInput.Button.Back))
        {
            tap.Play();
            pausar();
        }

        

    }

    void pausar()
    {
        Time.timeScale = 0f;
        iniciar.SetActive(false);
        pausa.SetActive(true);
        seguro.SetActive(false);
        cursor.SetActive(true);
    }

    void salir() {
        Time.timeScale = 0f;
        iniciar.SetActive(false);
        pausa.SetActive(false);
        seguro.SetActive(true);
        cursor.SetActive(true);
    }

    void continuar()
    {
        Time.timeScale = 1f;
        iniciar.SetActive(false);
        pausa.SetActive(false);
        seguro.SetActive(false);
        cursor.SetActive(false);
    }

    void exit()
    {
        Application.Quit();
    }

    void inicioJuego()
    {
        iniciar.SetActive(false);
        pausa.SetActive(false);
        seguro.SetActive(false);
        cursor.SetActive(false);
    }
}
