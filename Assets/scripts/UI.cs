using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using player;
using TMPro;

namespace interfaz
{

    public class UI : MonoBehaviour
    {
        public static int scoreValue = 0;
        public TextMeshProUGUI textoScore;
        public TextMeshProUGUI textoVida;
        
        void Update()
        {
            
            textoScore.text = "Score: " + scoreValue;
            textoVida.text = "Lives left: " + PlayerHealth.Health;
            Debug.Log("Score: " +  scoreValue);
            Debug.Log("Lives left: " + PlayerHealth.Health);
        }
        private void FixedUpdate()
        {
            scoreValue++;
        }
    }

}
