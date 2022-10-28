using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respuesta : MonoBehaviour
{
    private float MoveSpeed = 15f;
    public Notificador notificador;
    public float RayDistance = 50f;
    // Start is called before the first frame update
    void Start() {
        notificador.OnMyEvent += MyAnswer;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("d")) {
            gameObject.transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a")) {
            gameObject.transform.Translate(-MoveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w")) {
            gameObject.transform.Translate(0, 0, MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("s")) {
            gameObject.transform.Translate(0, 0, -MoveSpeed * Time.deltaTime);
        }
        
        GameObject tipoC = GameObject.FindWithTag("TypeC");
        Vector3 direction =  tipoC.transform.position - gameObject.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, direction, out hit, RayDistance)) {
            if (hit.transform.tag == "TypeC") {
                GameObject[] tipoA = GameObject.FindGameObjectsWithTag("TypeA");
                for (int i = 0; i < tipoA.Length; i++) {
                    tipoA[i].GetComponent<Renderer>().material.color = Random.ColorHSV();
                    if (tipoA[i].GetComponent<typeAControler>().canJump && tipoA[i].transform.position.y <= 10.5) {
                       tipoA[i].GetComponent<typeAControler>().canJump = false;
                        tipoA[i].GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
                    } else {
                        tipoA[i].GetComponent<typeAControler>().canJump = true;
                    }
                }
                GameObject[] tipoB = GameObject.FindGameObjectsWithTag("TypeB");
                for (int i = 0; i < tipoB.Length; i++) {
                    tipoB[i].transform.LookAt(tipoC.transform);
                }
            }
        }
    }

    void MyAnswer() {
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
