using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaBala : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Saco")
        {
            GameObject.Find("Player").GetComponent<Shuriken>().Qtd_Shu += 10;
            Destroy(other.gameObject);
        }
    }
}
