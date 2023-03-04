using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject escrito;
    public GameObject bot;
    public GameObject mouse;
    public bool pausado = false;
    // Update is called once per frame

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {


        ///if (Input.GetKeyDown("escape"))
        //{
        // Pausar();
        ///}

    }

    public void Pausar()
    {
        pausado = true;
        escrito.SetActive(true);
        bot.SetActive(true);
        Time.timeScale = 0;
        mouse.GetComponent<StarterAssets.StarterAssetsInputs>().cursorLocked = false;
        mouse.GetComponent<StarterAssets.StarterAssetsInputs>().cursorInputForLook = false;
    }

    public void Resume()
    {
        mouse.GetComponent<StarterAssets.StarterAssetsInputs>().SetCursorState(mouse.GetComponent<StarterAssets.StarterAssetsInputs>().cursorLocked);
        pausado = false;
        Time.timeScale = 1;
        escrito.SetActive(false);
        bot.SetActive(false);
        mouse.GetComponent<StarterAssets.StarterAssetsInputs>().cursorLocked = false;
        mouse.GetComponent<StarterAssets.StarterAssetsInputs>().cursorInputForLook = false;

    }
}
