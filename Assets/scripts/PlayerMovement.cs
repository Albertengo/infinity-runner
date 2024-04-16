using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] public int speed = 1;
        public float speedworld = 1.0f;
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

        }

        //NO ESTA LLEGANDO INFO DE ESTO??? pero funciona igual parece
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = true;
                Debug.Log("Grounded es TRUE");
            }
            else
                isGrounded = false;
            Debug.Log("Grounded es FALSE");
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

        private void OnTriggerEnter(Collider collision) //para boostear la velocidad del pj
        {
            if (collision.gameObject.CompareTag("Boost"))
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
        }
        void EndBoost() //volver a la velocidad normal cuando tgermine el boost
        {
            booster = false;
            speedworld = speedworld - boosterSpeed;
            Debug.Log("Terminó el Boost, velocidad: " + speedworld);
        }
    }
}