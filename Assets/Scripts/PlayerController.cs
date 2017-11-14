﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private GameObject levelCompletedImage, nextLevelButtonObject;

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
        levelCompletedImage = GameObject.FindWithTag("LevelCompletedImage");
        nextLevelButtonObject = GameObject.FindWithTag("NextLevelButton");
        Debug.Log("GameObject" + GameObject.FindWithTag("LevelCompletedImage"));
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
            /* При старте уровня создается куча объектов под тегом CameraPoint*/
            cameraCoordinates = cameraController.transform.position;
            StartCoroutine(CameraMovementCoroutine());
        }
        if(coll.gameObject.tag == "Finish")
        {
            /* При столкновении коллизии игрока с коллизей GameObject Finish происходит следующее:
             * отключается управление игроком с помощью переменной speed, так со скоростью 0 невозможно перемещаться
             * в переменную типа Gameobject например levelCompletedImage заносим результат поиска Gameobject по тэгу: "LevelCompletedImage".
             * создаем переменную типа Image и заносим туда компонент с помощью метода GetComponent<Image>
             * по дефолту в сцене image выключен, но при столкновении он будет включаться с помощью метода enabled = true
             */
            speed = 0;
            Image levelCompletedRenderer = levelCompletedImage.GetComponent<Image>();
            levelCompletedRenderer.enabled = true;
            Image nextLevelButtonRenderer = nextLevelButtonObject.GetComponent<Image>();
            nextLevelButtonRenderer.enabled = true;
            Button nextLevelButton = nextLevelButtonObject.GetComponent<Button>();
            nextLevelButton.enabled = true;
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
        }
    }


}
