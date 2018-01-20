using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
}

public class PlayerController : MonoBehaviour {

    public Boundary boundary;
    public float speed;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawnLeft;
    public Transform shotSpawnRight;
    public float fireRate;

    private float nextFire;

    private Rigidbody Player {
        get {
            return GetComponent<Rigidbody>();
        }
    }

    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        Player.velocity = movement * speed;

        Player.position = new Vector3
        (
            Mathf.Clamp(Player.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(Player.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );

        Player.rotation = Quaternion.Euler(0.0f, 0.0f, Player.velocity.x * -tilt);
    }

    void Update() {
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawnLeft.position, shotSpawnLeft.rotation);
            Instantiate(shot, shotSpawnRight.position, shotSpawnRight.rotation);
        }
    }
}