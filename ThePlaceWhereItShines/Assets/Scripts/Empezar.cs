using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Empezar : MonoBehaviour
{
    public void Starting()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
