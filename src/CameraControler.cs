using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    public Transform player;

    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position + new Vector3(0, 2, -5);
        //Debug.Log(player.transform.rotation);
        transform.rotation = player.transform.rotation = new Quaternion(0, 0, 0, 1);
    }
}
