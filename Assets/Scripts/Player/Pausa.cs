using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject pausa;
    public GameObject PrimeraPantalla;
    public GameObject Opciones;

    private void Start()
    {
        pausa.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausa.gameObject.SetActive(true);
            Opciones.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void despausar()
    {
        pausa.gameObject.SetActive(false);
        Time.timeScale = 1;
    } 

    public void opciones()
    {
        Opciones.gameObject.SetActive(true);
        PrimeraPantalla.gameObject.SetActive(false);
    }

    public void SalirOpciones()
    {
        PrimeraPantalla.gameObject.SetActive(true);
        Opciones.gameObject.SetActive(false);
    }
    public void MenuPrincipal(string MenuPrincipal)
    {
        pausa.gameObject.SetActive(false);
        SceneManager.LoadScene(MenuPrincipal);
    }
}
