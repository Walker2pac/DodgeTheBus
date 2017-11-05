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

    public float speed;
    public float smooth;
    private bool isMovedCamera;
    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        cameraController = FindObjectOfType<CameraController>();
        isMovedCamera = false;
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal")) MoveHorizontal();
        if (Input.GetButton("Vertical")) MoveVertical();
    }

    void LateUpdate()
    {
        if (isMovedCamera) MoveCamera();
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

    void MoveCamera()
    {
        Vector3 startPosition = new Vector3(cameraController.transform.position.x, cameraController.transform.position.y, cameraController.transform.position.z);
        Vector3 endPosition = new Vector3(cameraController.transform.position.x, transform.position.y + 1.5F, cameraController.transform.position.z);
        cameraController.transform.position = Vector3.Lerp(startPosition, endPosition, smooth * Time.deltaTime);
        Debug.Log("Camera Point");
    }

    public IEnumerator CameraMovementCoroutine()
    {
        int count = 1;
        while(30 > count)
        {
            count = count + 1;
            cameraCoordinates.y = cameraCoordinates.y + 0.07F;
            cameraController.transform.position = cameraCoordinates;
            yield return null;
            Debug.Log(count);
        }
        Debug.Log("Movement Done");
    }


}
