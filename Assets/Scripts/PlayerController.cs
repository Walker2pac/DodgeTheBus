using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    public Boundary boundary;

    public float speed;

    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal")) MoveHorizontal();
        if (Input.GetButton("Vertical")) MoveVertical();
    }

    private void MoveHorizontal()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        if (transform.position.x + direction.x < 9 && transform.position.x + direction.x > -9)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        }

    }
    private void MoveVertical()
    {
        Vector3 direction = transform.up * Input.GetAxis("Vertical");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }


}
