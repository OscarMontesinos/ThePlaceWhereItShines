using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interactuador : MonoBehaviour
{
    public SpriteRenderer mostrarNota;
    bool tenazas = false;
    public bool cristal = false;
    bool cristalLuz = false;
    public GameObject luz;
    public Text interactuar;
    bool interactuacion;
    public int contador=1200;
    public Text contadorT;
    public bool contar = false;
    float auxCount;

    public GameObject cristalesEncendidos;
    public GameObject cristalesApagados;

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            interactuacion = true;

        }
        else
        {
            interactuacion = false;
        }

        if (contar)
        {
            auxCount += Time.deltaTime;
            if(auxCount > 1)
            {
                auxCount = 0;
                contador--;
                contadorT.text = contador.ToString();
                if(contador == 0)
                {
                    SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                }
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Nota" || other.gameObject.tag == "Tenazas" || other.gameObject.tag == "Cristal" || other.gameObject.tag == "Puerta" || other.gameObject.tag == "CristalLuz")
        {
            interactuar.gameObject.SetActive(true);
        }

        if (interactuacion && other.gameObject.tag == "Nota")
        {
            mostrarNota.sprite = other.gameObject.GetComponent<Nota>().contenido;
        }
        if (interactuacion && other.gameObject.tag == "Tenazas")
        {
            Destroy(other.gameObject);
            tenazas = true;
        }
        if (interactuacion && other.gameObject.tag == "Cristal")
        {
            if (tenazas)
            {
                Destroy(other.gameObject);
                cristal = true;
                cristalesApagados.SetActive(true);
                cristalesEncendidos.SetActive(false);
            }
        }
        if (interactuacion && other.gameObject.tag == "Puerta")
        {
            other.gameObject.GetComponent<Puerta>().AbrirPuerta();
        }
        if (interactuacion && other.gameObject.tag == "CristalLuz")
        {
            luz.SetActive(true);
            Destroy(other.gameObject);

        }


    }
    private void OnTriggerExit(Collider other)
    {
        interactuar.gameObject.SetActive(false);

        if (other.gameObject.tag == "Nota")
        {
            mostrarNota.sprite = null;
        }
    }
}
