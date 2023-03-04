using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clicke : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ajuda;
    public GameObject normal;
    public void jogar()
    {
        SceneManager.LoadScene("Cemiterio");

    }

    public void Volta()
    {
        ajuda.gameObject.SetActive(false);
        normal.gameObject.SetActive(true);

    }

    public void ajuda1(){
        normal.gameObject.SetActive(false);
        ajuda.gameObject.SetActive(true);
    }

    public void sair(){
        Application.Quit();
    }
}
