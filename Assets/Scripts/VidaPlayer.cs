using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    int vida = 150;
    public GameObject Vermelho;
    public AudioSource Danin;
    public AudioSource grito;
    bool morto = false;
    // Update is called once per frame
    void Update()
    {
        if (Vermelho.GetComponent<Image>().color.a > 0)
        {
            var color = Vermelho.GetComponent<Image>().color;
            color.a -= 0.01f;
            Vermelho.GetComponent<Image>().color = color;
        }

        if (vida <= 0 && morto == false)
        {
            morto = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameObject.Find("PlayerCapsule").SetActive(false);
            grito.Play();
            Invoke("Morre", 3f);
        }
    }

    public void TomaDmg(int dano)
    {
        vida -= dano;
        Debug.Log(vida);
        Danin.Play();
        MostraDano();
    }

    void MostraDano()
    {
        var color = Vermelho.GetComponent<Image>().color;
        color.a = 0.7f;
        Vermelho.GetComponent<Image>().color = color;
    }

    void Morre()
    {
        SceneManager.LoadScene("Morreu");
    }
}
