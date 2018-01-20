using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;

    private Rigidbody RBody {
        get {
            return GetComponent<Rigidbody>();
        }
    }

	void Start () {
        RBody.velocity = transform.up * speed;
	}
}
