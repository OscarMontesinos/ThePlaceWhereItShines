using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascensor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator Planta1()
    {
        yield return new WaitForSeconds(2);
    }
    public IEnumerator Planta2()
    {
        yield return new WaitForSeconds(2);

    }
    public IEnumerator Planta3()
    {

        yield return new WaitForSeconds(2);
    }

}
