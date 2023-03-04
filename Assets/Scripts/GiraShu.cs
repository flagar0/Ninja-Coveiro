using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraShu : MonoBehaviour
{
    [SerializeField] float dano = 25f;
    public GameObject faisca;
    public float TempoDeVida = 5f;
    public AudioSource Batida;
    public AudioSource BatidaIni;
    bool girar = true;
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(this.gameObject, TempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {
        if (girar)
        {
            this.gameObject.transform.Rotate(0, 45, 0);
            this.gameObject.transform.Rotate(10, 0, 0);
        }

    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Objs" && girar == true)
        {
            //Debug.Log(other.gameObject.name);

            //this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            girar = false;
            CriaFaisca();
            Batida.Play();
        }
        if (other.gameObject.tag == "Enemy" && girar == true)
        {
            InimigoVIda IniVida = other.transform.GetComponent<InimigoVIda>();
            IniVida.TomaDano(dano);
            other.gameObject.GetComponent<Persegue>().Corre();
            girar = false;
            BatidaIni.Play();
        }

    }

    void CriaFaisca()
    {

        this.gameObject.GetComponent<ParticleSystem>().Play();
        //GameObject fisca = Instantiate(faisca,this.transform.position,Quaternion.identity);
        //Destroy(fisca,1f);

    }

}
