using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactuador : MonoBehaviour
{
    public SpriteRenderer mostrarNota;
    bool tenazas = false;
    bool cristal = false;
    bool cristalLuz = false;
    public GameObject luz;
    public Text interactuar;
    bool interactuacion;
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            interactuacion = true;
            Debug.Log("22222222222");

        }
        else
        {
            interactuacion = false;
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
            Debug.Log("11111111111");
        }
        if (interactuacion && other.gameObject.tag == "Tenazas")
        {
            Destroy(other);
            tenazas = true;
        }
        if (interactuacion && other.gameObject.tag == "Cristal")
        {
            if (tenazas)
            {
                Destroy(other);
                cristal = true;
            }
        }
        if (interactuacion && other.gameObject.tag == "Puerta")
        {
            other.gameObject.GetComponent<Puerta>().AbrirPuerta();
        }
        if (interactuacion && other.gameObject.tag == "CristalLuz")
        {
            luz.SetActive(true);
            Destroy(other);

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
