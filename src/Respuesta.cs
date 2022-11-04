using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respuesta : MonoBehaviour
{
     public delegate void mensaje();
    public event mensaje Aumentar;
    public event mensaje Mover;
    public event mensaje CambiaColor;
    public event mensaje Saltar;
    public event mensaje Orientar;
    private float MoveSpeed = 0.75f;
    public Notificador notificador;
    public float RayDistance = 50f;
    // Start is called before the first frame update
    void Start() {
        notificador.OnMyEvent += MyAnswer;
    }

    // Update is called once per frame
    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float horSpeed = horizontal * MoveSpeed;
        float verSpeed = vertical * MoveSpeed;
        gameObject.transform.Translate(horSpeed, 0, verSpeed);
        
        GameObject tipoC = GameObject.FindWithTag("TypeC");
        Vector3 direction =  tipoC.transform.position - gameObject.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, direction, out hit, RayDistance)) {
            if (hit.transform.tag == "TypeC") {
                CambiaColor();
                Saltar();
                Orientar();
            }
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "TypeA") {
            Aumentar();
        } else if (collision.transform.tag == "TypeB") {
            Mover();
        }
    }

    void MyAnswer() {
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
