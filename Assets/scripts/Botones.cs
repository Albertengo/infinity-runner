using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using enemigos;

namespace interfaz
{
    public class Botones : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene("Game");
            UI.scoreValue = 0;
            //ControlJuego.CantidadEnemigos = 0;
            Time.timeScale = 1f;
        }
        public void Menu()
        {
            SceneManager.LoadScene("menu");
        }
        public void PlayButton()
        {
            SceneManager.LoadScene("Game");
            UI.scoreValue = 0;
            //ControlJuego.CantidadEnemigos = 0;
            Time.timeScale = 1f;
        }
        public void QuitGame()
        {
            Debug.Log("Saliste.");
            Application.Quit();
        }
    }
}
