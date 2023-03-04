using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shuriken : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 10f;
    public GameObject arma;
    public Transform spawn;
    [SerializeField] float velocidade = 5f;
    public Animator Ani_Atirar;
    public int Qtd_Shu = 10;
    public GameObject Conta_bala;
    public GameObject aperte;
    public GameObject pausa;
    public AudioSource JogaShu;
    
    public AudioSource abrino;

    // Update is called once per frame

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            if (hit.collider.gameObject.tag == "Saco")
            {
                if (aperte.GetComponent<TextMeshProUGUI>().enabled == false)
                {
                    aperte.GetComponent<TextMeshProUGUI>().enabled = true;
                }

                if (Input.GetKeyDown("e"))
                {
                    PegaSaco(hit);
                }
            }
        }
        else
        {
            aperte.GetComponent<TextMeshProUGUI>().enabled = false;
        }



        Conta_bala.GetComponent<TextMeshProUGUI>().text = Qtd_Shu.ToString();
        if (Input.GetButtonDown("Fire1") && this.GetComponent<Pause>().pausado == false)
        {
            Atire();
            Ani_Atirar.SetTrigger("Atirar");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown("l"))
        {
            Qtd_Shu++;
        }

    }
    void Atire()
    {
        ///Pega AOnde vai nascer
        if (Qtd_Shu > 0)
        {
            var bullet = Instantiate(arma, spawn.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = spawn.forward * velocidade;
            JogaShu.Play();
            Qtd_Shu--;

        }

    }

    void PegaSaco(RaycastHit hit)
    {
        Qtd_Shu += 10;
        abrino.Play();
        Destroy(hit.collider.gameObject);

    }
}

