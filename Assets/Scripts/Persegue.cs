using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Persegue : MonoBehaviour
{
    public Animator controle;
    ///public Animator soco;
    bool socando = false;
    [SerializeField] Transform alvo;
    [SerializeField] float limiteOlhar = 8f;
    NavMeshAgent navMesh;
    public bool atacar, perseguir = false;
    float distanciaAlvo = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        alvo = GameObject.Find("PlayerCapsule").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<InimigoVIda>().morto == false)
        {
            distanciaAlvo = Vector3.Distance(alvo.position, transform.position);
            if (distanciaAlvo <= limiteOlhar && distanciaAlvo > navMesh.stoppingDistance)
            {
                perseguir = true;
            }


            if (distanciaAlvo <= navMesh.stoppingDistance)
            {
                perseguir = false;
                if (socando == false)
                {
                    socando = true;
                    Invoke("Ataque", 0.9f);
                }

            }

            if (perseguir && this.GetComponent<InimigoVIda>().para == false)
            {
                Corre();
                controle.SetBool("Walk Forward", true);
            }
            else
            {
                controle.SetBool("Walk Forward", false);
            }
        }
        else
        {
            controle.SetBool("Walk Forward", false);
            controle.StopPlayback();
            controle.SetTrigger("Die");
        }

    }

    public void Corre()
    {
        if (this.gameObject.GetComponent<InimigoVIda>().morto == false)
        {
            if (distanciaAlvo >= navMesh.stoppingDistance && navMesh.enabled == true)
            {
                socando = false;
                navMesh.SetDestination(alvo.position);
            }
        }
        else
        {
            controle.SetBool("Walk Forward", false);
            controle.StopPlayback();
            controle.SetTrigger("Die");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, limiteOlhar);
    }

    void Ataque()
    {
        if (this.gameObject.GetComponent<InimigoVIda>().morto == false)
        {
            if (this.GetComponent<InimigoVIda>().para == false)
            {
                controle.SetTrigger("Attack 01");
                Invoke("DaDano", 0.2f);

                socando = false;
            }
        }
        else
        {
            controle.SetBool("Walk Forward", false);
            controle.StopPlayback();
            controle.SetTrigger("Die");
        }

    }
    void DaDano()
    {
        if (this.gameObject.GetComponent<InimigoVIda>().morto == false)
        {
            if (distanciaAlvo <= navMesh.stoppingDistance && this.GetComponent<InimigoVIda>().para == false)
            {
                GameObject.Find("Player").GetComponent<VidaPlayer>().TomaDmg(25);
            }
        }
        else
        {
            controle.SetBool("Walk Forward", false);
            controle.StopPlayback();
            controle.SetTrigger("Die");
        }
    }

}
