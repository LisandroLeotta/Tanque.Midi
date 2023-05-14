using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Inicio : MonoBehaviour
{
    public GameObject CanvasMenu;
    public GameObject CanvasOpciones;


    private void Start()
    {
        Time.timeScale = 1;
        CanvasOpciones.gameObject.SetActive(false);
    }
    public void IniciarJuego (string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
    }

    public void Opciones()
    {
        CanvasMenu.gameObject.SetActive(false);
        CanvasOpciones.gameObject.SetActive(true);
    }
    public void OpcionesCerrar()
    {
        CanvasOpciones.gameObject.SetActive(false);
        CanvasMenu.gameObject.SetActive(true);
    }
    public void Cerrar()
    {
        Application.Quit();
    }
}
