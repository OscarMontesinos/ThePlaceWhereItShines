using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            panel.SetActive(true);
            other.transform.position = new Vector3(10000, 1000, 1000);
            other.GetComponent<PJ>().grounded = false;
        }
    }
}
