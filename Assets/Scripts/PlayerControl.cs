using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    // public Rigidbody rigidbody;
    private float speed = 10f;
    private float speed1 = 11f;
    private float force = 1020f;
    private float minX = -4.5f;
    private float maxX = 4.5f;
    private float minY = 1f;
    private float maxY = 3f;

    // private float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        // horizontalInput = Input.GetAxis("Horizontal");
        // transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        Vector3 playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, minX, maxX);                     // Clamp the position of player so that it will stay on track
        playerPos.y = Mathf.Clamp(playerPos.y, minY, maxY);                     // Clamp the position of player so that it will stay on track
        transform.position = playerPos;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            transform.position = transform.position - new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) {
            transform.position = transform.position + new Vector3(0, speed1 * Time.deltaTime, 0);
            GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }

    // FixedUpdate is called every 0.02
    private void FixedUpdate() {
        // rigidbody.AddForce(0, 0, force * Time.deltaTime);                       // ----> This takes the rigidbody input
        GetComponent<Rigidbody>().AddForce(0, 0, force * Time.fixedDeltaTime);          // ----> This doesn't requires rigidbody input. It gets the rigidbody on which this script is applied
    }
}