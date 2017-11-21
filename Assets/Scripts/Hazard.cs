using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hazard : MonoBehaviour {

    private GroupOfHazards groupOfHazards; //Объект SpawnPositionRight на сцене

    private Vector3 defaultPosition;
    private Vector3 spawnPosition; //хранит в себе координаты объекта SpawnPositionRight на сцене
    private Transform transform;
    private Vector3 position;
    private Rigidbody2D rigidbody;
    private Rigidbody2D playerRigidbody;
    private GameObject gameOverObject, playAgainButtonObject, playAgainTextObject;

    private float speed;

	void Start () {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
        spawnPosition = gameObject.GetComponentInParent<GroupOfHazards>().getSpawnPosition();
        speed = gameObject.GetComponentInParent<GroupOfHazards>().getMovementSpeed();
        defaultPosition = new Vector3(spawnPosition.x, transform.position.y, transform.position.z);
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        gameOverObject = GameObject.Find("Game Over");
        playAgainButtonObject = GameObject.Find("Play Again");
        playAgainTextObject = GameObject.Find("PlayAgainText");
	}
	
	void Update () {      
	}
    void FixedUpdate()
    {
        rigidbody.velocity = (Vector3.right * -1) * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //Перемещаем игрока прямо на коробку и фризим по всем осям
            playerRigidbody = coll.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.MovePosition(new Vector2(coll.gameObject.transform.position.x, (coll.gameObject.transform.position.y + 0.7f)));
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

            //Выводим UI о том что игрок проиграл и кнопку переиграть
            Text gameOverText = gameOverObject.GetComponent<Text>();
            gameOverText.enabled = true;
            Button playAgainButton = playAgainButtonObject.GetComponent<Button>();
            playAgainButton.enabled = true;
            Image playAgainImage = playAgainButtonObject.GetComponent<Image>();
            playAgainImage.enabled = true;
            Text playAgainText = playAgainTextObject.GetComponent<Text>();
            playAgainText.enabled = true;
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Boundary")
        {
            transform.position = defaultPosition;
        }
    }
}
