using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactuador : MonoBehaviour
{
    Image mostrarNota;
    bool tenazas = false;
    bool cristal = false;
    bool cristalLuz = false;
    public GameObject luz;
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E) && other.tag == "Nota")
        {
            mostrarNota = other.gameObject.GetComponent<Nota>().contenido;
        }
        if (Input.GetKeyDown(KeyCode.E) && other.tag == "Tenazas")
        {
            Destroy(other);
            tenazas = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && other.tag == "Cristal")
        {
            if (tenazas)
            {
                Destroy(other);
                cristal = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && other.tag == "Puerta")
        {
            other.gameObject.GetComponent<Puerta>().AbrirPuerta();
        }
        if (Input.GetKeyDown(KeyCode.E) && other.tag == "CristalLuz")
        {
            luz.SetActive(true);
            Destroy(other);

        }


    }
}
