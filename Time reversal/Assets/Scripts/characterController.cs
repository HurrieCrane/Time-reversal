using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

    public float speed;

    private Rigidbody R;

	void Start () {
        R = GetComponent<Rigidbody>();
	}
	
	void Update () {

        float z = 0;
        float y = 0;
        float x = 0;

        if (Input.GetKey(KeyCode.W))
        {
            z += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            z -= speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x += speed;
        }

        transform.position += new Vector3(x, y, z);
    }
}
