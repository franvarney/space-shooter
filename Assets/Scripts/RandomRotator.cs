using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble;

    private Rigidbody Rbody {
        get {
            return GetComponent<Rigidbody>();
        }
    }

    private void Start() {
        Rbody.angularVelocity = new Vector3(0.0F, 0.0F, Random.value * tumble);
    }
}
