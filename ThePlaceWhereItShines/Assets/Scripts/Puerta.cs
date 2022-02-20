using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    GameObject puerta1;
    GameObject puerta2;
    bool abrir =false;

    private void Start()
    {
        puerta1 = transform.GetChild(0).gameObject;
        puerta2 = transform.GetChild(1).gameObject;
    }
    private void Update()
    {
        if (abrir)
        {
            puerta1.transform.position = new Vector3(puerta1.transform.position.x, puerta1.transform.position.y + 1 * Time.deltaTime, puerta1.transform.position.z);
            puerta2.transform.position = new Vector3(puerta2.transform.position.x, puerta2.transform.position.y - 1 * Time.deltaTime, puerta2.transform.position.z);
        }
    }
    public void AbrirPuerta() 
    {
        abrir = true;   
    }
}
