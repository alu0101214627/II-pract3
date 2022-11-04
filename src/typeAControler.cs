using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typeAControler : MonoBehaviour
{
    public Respuesta notificadorA;
    public bool canJump = true;
    
    private float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        notificadorA.Mover += MyAnswer;
        notificadorA.Saltar += Salta;
        notificadorA.CambiaColor += Cambia;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MyAnswer() {
        gameObject.transform.LookAt(GameObject.FindWithTag("TypeC").transform);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * Time.deltaTime * moveSpeed;
    }

    void Salta() {
        if (canJump && gameObject.transform.position.y <= 10.5) {
            canJump = false;
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
        } else {
            canJump = true;
        }
    }

    void Cambia() {
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
