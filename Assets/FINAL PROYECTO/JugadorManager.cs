using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JugadorManager : MonoBehaviour {

    public int monedas;
    public int vida;
    public int vidaMax;

    int vidaActualElimin = 0;

    public Image[] barco;

    public Text monedaUI;

    public GameObject gameOver;
    public GameObject win, UI;
    public GameObject[] luces;

    public AudioSource moneda;
    public AudioSource crackWood;
    MeshRenderer m;

    Rigidbody rb;

    private Scene scene;

    public 

	// Use this for initialization
	void Start () {
        
        m = this.GetComponent<MeshRenderer>();
        m.enabled = true;
        UI.SetActive(true);
        for(int i = 0; i < luces.Length; i++)
        {
            luces[i].SetActive(true);
        }
            scene = SceneManager.GetActiveScene();

        rb = GetComponent<Rigidbody>();

        vidaMax = barco.Length-1;

        for (int i = 0; i < barco.Length; i++)
        {
            barco[i].enabled = true;
        }

        gameOver.SetActive(false);
        win.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        monedaUI.text = monedas.ToString();


        //if (vidaActualElimin == vidaMax+1)
        //{
        //    m.enabled = false;
        //    UI.SetActive(false);
        //    //Time.timeScale = 0f;
        //    for (int i = 0; i < luces.Length; i++)
        //    {
        //        luces[i].SetActive(false);
        //    }

        //    gameOver.SetActive(true);

        //    if (OVRInput.Get(OVRInput.Button.One))
        //    {
        //        Application.LoadLevel(scene.name);
        //    }
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        Application.LoadLevel(scene.name);
        //    }

        //}

        if (gameOver.activeSelf == true || win.activeSelf == true)
        {
            if (OVRInput.Get(OVRInput.Button.One))
            {
                Application.LoadLevel(scene.name);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Application.LoadLevel(scene.name);
            }
        }

    }

    


    public void monedaNueva()
    {
        monedas++;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "roca")
        {
            crackWood.Play();

                        
            barco[vidaActualElimin].enabled = false;
            

            if (vidaActualElimin < vidaMax)
            {
                vidaActualElimin++;
                //gameOverFin();
            }
            else
            {
                gameOverFin();
            }

        }

        if (other.gameObject.name == "Win")
        {
            win.SetActive(true);
        }
        //this.gameObject.SetActive(false);
    }

    public void monedaSonido()
    {
        moneda.Play();
    }

    public void gameOverFin()
    {
        m.enabled = false;
        UI.SetActive(false);
        //Time.timeScale = 0f;
        for (int i = 0; i < luces.Length; i++)
        {
            luces[i].SetActive(false);
        }

        gameOver.SetActive(true);

        
    }
}
