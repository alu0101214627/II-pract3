using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typeAControler : MonoBehaviour
{

    public bool canJump = true;
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
            GameObject[] tipoB = GameObject.FindGameObjectsWithTag("TypeB");
            for (int i = 0; i < tipoB.Length; i++) {
                tipoB[i].transform.localScale += new Vector3(1f, 1f, 1f);
            }
        }
    }
}
