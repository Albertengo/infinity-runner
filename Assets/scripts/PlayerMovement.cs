using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using interfaz;

namespace player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] public int speed = 1;//se puede modificar
        public float speedworld = 5.0f;
        private Rigidbody rb;
        public float jumpHeight = 1.0f;
        public bool isGrounded;

        public float boosterSpeed;
        public int boosterTime;
        bool booster;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }


        // Update is called once per frame
        void Update()
        {
            Movement();
            speedworld = speedworld + 0.001f;
        }

        private void Movement()
        {
            if (isGrounded == true) //mientras estes en el piso, se podra saltar, es para evitar volar
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    rb.AddForce(Vector3.up * jumpHeight);
                    isGrounded = false;
                    //Debug.Log("Estas saltando");
                }
                //Debug.Log("Estas en el piso");
            }

            float horizontalInput = Input.GetAxis("Horizontal");
            //float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontalInput, 0f, 0f); // verticalInput);

            movement.Normalize();

            transform.Translate(movement * Time.deltaTime * speed); //para moverse a los cpstados segun el player
            transform.Translate(Vector3.forward * Time.deltaTime * speedworld, Space.World); //constantemente se mueve al frente
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Boost")) //para boostear la velocidad del pj
            {
                booster = true;
                if (booster == true)
                {
                    speedworld = boosterSpeed;
                    Invoke("EndBoost", boosterTime);
                    Debug.Log("Boosteando, velocidad: " + speedworld);
                }
                collision.gameObject.SetActive(false);
            }

            //if (collision.gameObject.CompareTag("coleccionable") == true) //para sumar puntaje con los coleccionables
            //{
            //    UI.scoreValue++;
            //    collision.gameObject.SetActive(false);
            //}
        }
        void EndBoost() //volver a la velocidad normal cuando termine el boost
        {
            booster = false;
            speedworld = speedworld - boosterSpeed;
            if (speedworld <= 5f)
            {
                speedworld = 5f;
            }
            Debug.Log("Terminó el Boost, velocidad: " + speedworld);
        }
    }
}