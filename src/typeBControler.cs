using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typeBControler : MonoBehaviour
{
    public Respuesta notificadorB;
    // Start is called before the first frame update
    void Start()
    {
        notificadorB.Aumentar += MyAnswer;
        notificadorB.Orientar += Orienta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MyAnswer() {
        gameObject.transform.localScale += new Vector3(1f, 1f, 1f);
    }

    void Orienta() {
        GameObject tipoC = GameObject.FindWithTag("TypeC");
        gameObject.transform.LookAt(tipoC.transform);
    }
}
