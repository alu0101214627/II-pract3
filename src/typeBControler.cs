using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typeBControler : MonoBehaviour
{
    private float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Player") {
            GameObject[] tipoA = GameObject.FindGameObjectsWithTag("TypeA");
            for (int i = 0; i < tipoA.Length; i++) {
                tipoA[i].transform.LookAt(GameObject.FindWithTag("TypeC").transform);
                tipoA[i].GetComponent<Rigidbody>().velocity = Vector3.forward * Time.deltaTime * moveSpeed;
            }
        }
    }
}
