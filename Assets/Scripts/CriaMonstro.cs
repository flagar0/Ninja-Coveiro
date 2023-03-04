using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CriaMonstro : MonoBehaviour
{
    public GameObject Inimigo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (this.gameObject.name)
            {
                case "ATV1":
                    GameObject.Find("M1").GetComponent<ParticleSystem>().Play();
                    Instantiate(Inimigo, GameObject.Find("M1").transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    break;

                case "ATV2":
                    GameObject.Find("M2").GetComponent<ParticleSystem>().Play();
                    Instantiate(Inimigo, GameObject.Find("M2").transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    break;

                case "ATV3":
                    GameObject.Find("M3").GetComponent<ParticleSystem>().Play();
                    Instantiate(Inimigo, GameObject.Find("M3").transform.position, Quaternion.identity);
                    GameObject.Find("M32").GetComponent<ParticleSystem>().Play();
                    Instantiate(Inimigo, GameObject.Find("M32").transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    break;

                case "ATV4":
                    GameObject.Find("M4").GetComponent<ParticleSystem>().Play();
                    Instantiate(Inimigo, GameObject.Find("M4").transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    break;

                case "ATV5":
                    GameObject.Find("M5").GetComponent<ParticleSystem>().Play();
                    Instantiate(Inimigo, GameObject.Find("M5").transform.position, Quaternion.identity);
                    GameObject.Find("M52").GetComponent<ParticleSystem>().Play();
                    Instantiate(Inimigo, GameObject.Find("M52").transform.position, Quaternion.identity);
                    GameObject.Find("M53").GetComponent<ParticleSystem>().Play();
                    Instantiate(Inimigo, GameObject.Find("M53").transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    break;

                case "ATV6":
                    GameObject.Find("M6").GetComponent<ParticleSystem>().Play();
                    Instantiate(Inimigo, GameObject.Find("M6").transform.position, Quaternion.identity);
                    GameObject.Find("M62").GetComponent<ParticleSystem>().Play();
                    Instantiate(Inimigo, GameObject.Find("M62").transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    break;

                case "ATV7":
                    GameObject.Find("M7").GetComponent<ParticleSystem>().Play();
                    GameObject.Find("M7").GetComponent<AudioSource>().Play();
                    GameObject gigante = Instantiate(Inimigo, GameObject.Find("M7").transform.position, Quaternion.identity);
                    gigante.transform.localScale = new Vector3(4.25830793f, 4.25830793f, 4.25830793f);
                    gigante.GetComponent<InimigoVIda>().vida = 400;
                    GameObject.Find("M72").GetComponent<ParticleSystem>().Play();
                    Instantiate(Inimigo, GameObject.Find("M72").transform.position, Quaternion.identity);
                    GameObject.Find("M73").GetComponent<ParticleSystem>().Play();
                    Instantiate(Inimigo, GameObject.Find("M73").transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    break;

                case "final":
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    SceneManager.LoadScene("Venceu");
                break;
            }

        }
    }
}
