using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changescene : MonoBehaviour {

    public Transform cam;
    public SpriteRenderer render;

    float maxVal;
    public Slider mislider;

    public float tiempo = 10f;
    float contador = 0;

    bool fadeinUnaVez = true;
    bool viendo = false;

    Ray ray;

	// Use this for initialization
	void Start () {
        //render = GetComponent<SpriteRenderer>();

        maxVal = mislider.maxValue;

        Color c = render.material.color;
        c.a = 0f;

        render.material.color = c;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 adelante = cam.transform.TransformDirection(Vector3.forward) * 25;
        ray = new Ray(cam.position, adelante);
        Debug.DrawRay(cam.position, adelante, Color.blue);
        RaycastHit hit;

        if (viendo) {
            if (mislider.value < maxVal)
            {
                contador += Time.deltaTime;
                mislider.value = contador * maxVal / tiempo;
            }

            if(mislider.value >= maxVal)
            {
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            if (mislider.value > 0)
            {
                contador -= Time.deltaTime;
                mislider.value = contador * maxVal / tiempo;
            }
        }

        if (Physics.Raycast(ray, out hit, 25))
        {
            if (hit.transform.gameObject.name == "FadeIn" || hit.transform.gameObject.name == "iniciarJuego" && fadeinUnaVez )
            {
                Debug.Log("fade in iniciado");
                iniciarFadeIn();
                if (hit.transform.gameObject.name == "FadeIn") {
                    hit.transform.gameObject.SetActive(false);
                }

                fadeinUnaVez = false;
            }



            if (hit.transform.gameObject.name == "iniciarJuego") {
                viendo = true;
            }
           

                if (hit.transform.gameObject.name == "iniciarJuego")
            {
                if (Input.GetMouseButton(0)){
                    
                }
            }

            if (hit.transform.gameObject.name == "JugarDeNuevo") {
                if (Input.GetMouseButton(0)) {
                    SceneManager.LoadScene(0);
                }
            }


        }
        else
        {
            viendo = false;
        }
    }

    IEnumerator fadeIn() {
        for (float i = 0.05f; i <= 1; i += 0.05f) {
            Color c = render.material.color;
            c.a = i;
            render.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void iniciarFadeIn() {
        StartCoroutine("fadeIn");
    }

}
