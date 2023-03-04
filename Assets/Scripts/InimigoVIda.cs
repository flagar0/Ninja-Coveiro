using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoVIda : MonoBehaviour
{
    public float vida;
    public Animator controle;
    public bool para = false;
    public GameObject Pacote;
    public bool morto = false;

    private void Start()
    {
        vida = Random.Range(100, 300);

        if (vida > 200)
        {
            GameObject.Find("Boximon Fiery").GetComponent<SkinnedMeshRenderer>().material.color = Color.yellow;
        }
    }
    public void TomaDano(float dano)
    {
        if (vida > 0)
        {

            vida -= dano;

            if (vida <= 0) //Morte
            {
                Debug.Log("MORRI");
                para = true;
                morto = true;
                bool saco = GeraSaco();
                this.GetComponent<AudioSource>().Play();

                if (saco)
                {
                    Instantiate(Pacote, new Vector3(this.transform.position.x, this.transform.position.y + 5, this.transform.position.z), Quaternion.identity);
                }
                Destroy(this.gameObject, 6f);
            }
            else
            {
                if (controle.GetBool("Walk Forward") == true)
                {
                    controle.SetBool("Walk Forward", false);
                    para = true;
                }
                controle.StopPlayback();
                controle.SetTrigger("Take Damage");
                Invoke("Volta", 0.8f);
            }
        }
    }

    void Volta()
    {
        para = false;
    }

    bool GeraSaco()
    {
        float num = Random.Range(0, 10);
        if (num <= 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
