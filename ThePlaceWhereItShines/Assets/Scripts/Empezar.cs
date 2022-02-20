using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Empezar : MonoBehaviour
{
    public GameObject panel;
    public AudioSource audioCine;
    public void Empieza()
    {
        StartCoroutine(Starting());
    }
    public IEnumerator Starting()
    {
        panel.SetActive(true);
        audioCine.Play();
        yield return new WaitForSeconds(23);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
