using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interfaz;

namespace player
{

    public class PlayerHealth : MonoBehaviour
    {
        public int MaxHealth = 9;
        public int Health;
        //public SliderHealth healthbar;
        [SerializeField] private int HPdropHealing; //lo que cure el objeto de curacion
        public Win_Lose screenL;
        void Start()
        {
            Health = MaxHealth;
            //healthbar.startHealthBar(Health);
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void OnCollisionEnter2D(Collision2D collision) //OnCollisionStay2D funciona pero baja muy rapido la vida
        {
            if (collision.gameObject.CompareTag("Obstacle"))
                Daño(2);
        }
        public void Daño(int dañoRecibido) //funcion con la mecanica de tomar daño.
        {
            Health -= dañoRecibido;
            //healthbar.SetHealth(Salud);
            if (Health <= 0)
            {
                Debug.Log("Moriste.");
                screenL.ActiveScreen();
                //healthbar.Desactivar();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) //para hacer curar y hacer desaparecer
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
