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
    private CameraController cameraController;
    private Rigidbody2D rigidbody;
    private Vector3 playerCoordinates, cameraCoordinates;
    private Transform transform;

    public float speed;
    public float smooth;
    public float rangePerFrame;
    private bool isMovedCamera;
    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        cameraController = FindObjectOfType<CameraController>();
        transform = GetComponent<Transform>();
        isMovedCamera = false;
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

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "CameraPoint")
        {
            playerCoordinates = transform.position;
            cameraCoordinates = cameraController.transform.position;
            StartCoroutine(CameraMovementCoroutine());
        }

    }

    public IEnumerator CameraMovementCoroutine()
    {
        int count = 1;
        int totalCount = 30;
        while(totalCount > count)
        {
            count = count + 1;
            cameraCoordinates.y = cameraCoordinates.y + rangePerFrame;
            cameraController.transform.position = cameraCoordinates;
            yield return null;
            Debug.Log(count);
        }
    }


}
