using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject flecha;
    [SerializeField]
    private GameObject lista;

    private int indice = 0;

    void Start()
    {
        dibujar();
    }

    
    void Update()
    {
        bool up = Input.GetKeyDown("up");
        bool down = Input.GetKeyDown("down");

        if (up) { indice--; }
        
        if(down) { indice++; }

        if(indice > lista.transform.childCount - 1)
        {
            indice = 0;
        }else if(indice < 0)
        {
            indice = lista.transform.childCount - 1;
        }

        if(up || down) { dibujar(); }

        if (Input.GetKeyDown(KeyCode.Return)) { ejecutarAccion(); }
        
    }

    public void dibujar()
    {
        Transform posOpciones = lista.transform.GetChild(indice);
        flecha.transform.position = posOpciones.position;
    }

    private void ejecutarAccion()
    {
        Transform posOpciones = lista.transform.GetChild(indice);

        if (indice == lista.transform.childCount - 1)
        {
            print("Saliendo....");
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(posOpciones.gameObject.name);
        }
    }
}
