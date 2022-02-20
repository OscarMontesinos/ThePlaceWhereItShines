using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ascensor : MonoBehaviour
{
    public GameObject plataforma;
    public int planta = 0;
    bool ready;
    bool mov;
    public GameObject planta0;
    public GameObject planta1;
    public GameObject planta2;
    public GameObject planta3;
    public GameObject pj;
    public Text interactuarAsc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && ready && !mov)
        {
            if (planta == 0)
            {
                planta = 1;
                StartCoroutine(MoverAscensor(planta1));
            }
            else if (planta == 1)
            {
                planta = 2;
                StartCoroutine(MoverAscensor(planta2));
            }
            else if (planta == 2)
            {
                planta = 3;
                StartCoroutine(MoverAscensor(planta3));
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && ready && !mov)
        {
            if (planta == 1)
            {
                planta = 0;
                StartCoroutine(MoverAscensor(planta0));
            }
            else if (planta == 2)
            {
                planta = 1;
                StartCoroutine(MoverAscensor(planta1));
            }
            else if (planta == 3)
            {
                planta = 2;
                StartCoroutine(MoverAscensor(planta2));
            }
        }
    }
    
    public IEnumerator MoverAscensor(GameObject planta)
    {
        mov = true;
        var distancia = planta.transform.position - plataforma.transform.position;
        while(distancia.magnitude > 0.3)
        {
            plataforma.transform.Translate(distancia.normalized * 4 * Time.deltaTime);
            if (ready)
            {
                pj.transform.Translate(distancia.normalized * 4 * Time.deltaTime);
            }
            distancia = planta.transform.localPosition - plataforma.transform.localPosition;
            yield return new WaitForSeconds(0.01f);
        }
        mov = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactuarAsc.gameObject.SetActive(true);
            ready = true;
            pj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ready = false;
            interactuarAsc.gameObject.SetActive(false);
        }
    }

}
