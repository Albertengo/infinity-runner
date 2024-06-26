using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interfaz;

namespace player
{

    public class PlayerHealth : MonoBehaviour
    {
        public int MaxHealth = 9;
        public static int Health;
        //public SliderHealth healthbar;
        [SerializeField] private int HPdropHealing; //lo que cure el objeto de curacion
        public Win_Lose screenL;
        void Start()
        {
            Health = MaxHealth;
            //healthbar.startHealthBar(Health);
        }

        public void OnCollisionEnter(Collision collision) //OnCollisionStay2D funciona pero baja muy rapido la vida
        {
            if (collision.gameObject.CompareTag("Obstacle"))
                Da�o(2);
        }
        public void Da�o(int da�oRecibido) //funcion con la mecanica de tomar da�o.
        {
            Health -= da�oRecibido;
            Debug.Log("Da�o recibido. Health: " + Health);
            //healthbar.SetHealth(Salud);
            if (Health <= 0)
            {
                Health = 0;
                Debug.Log("Moriste.");
                screenL.ActiveScreen();
                //healthbar.Desactivar();
            }
        }

        private void OnTriggerEnter(Collider collision) //para hacer curar y hacer desaparecer
        {
            if (collision.gameObject.CompareTag("Curar"))
            {
                if ((Health + HPdropHealing) > MaxHealth)
                {
                    Health = MaxHealth;
                }
                else
                {
                    Health += HPdropHealing;
                }
                //healthbar.SetHealth(Health);
                Debug.Log("El nuevo nivel de vida es:" + Health);
                collision.gameObject.SetActive(false);
            }

        }

    }
}
