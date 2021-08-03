using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("dino");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 updatePosition = player.transform.position;

        updatePosition.z = -10;

        transform.position = updatePosition;
    }
}
