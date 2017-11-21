using System.Collections;
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
    private GameObject levelCompletedImage, nextLevelButtonObject, gameOverObject, playAgainButtonObject, playAgainTextObject;

    public float speed;
    private float move;
    private float xInput, yInput;
    private bool isMoving;
    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        cameraController = FindObjectOfType<CameraController>();
        transform = GetComponent<Transform>();
        levelCompletedImage = GameObject.FindWithTag("LevelCompletedImage");
        nextLevelButtonObject = GameObject.FindWithTag("NextLevelButton");
        gameOverObject = GameObject.Find("Game Over");
        playAgainButtonObject = GameObject.Find("Play Again");
        playAgainTextObject = GameObject.Find("PlayAgainText");
        isMoving = false;
        move = 1.16f;
    }

    void FixedUpdate()
    {
        //if (Input.GetButton("Horizontal")) MoveHorizontal();
        //if (Input.GetButton("Vertical")) MoveVertical();
    }
    void Update()
    {
        /*xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        isMoving = (xInput != 0 || yInput != 0);

        if(isMoving)
        {
            var moveVector = new Vector3(xInput, yInput, 0);
            Debug.Log(moveVector);
            rigidbody.MovePosition(new Vector2((transform.position.x + moveVector.x * speed * Time.deltaTime),
                transform.position.y + moveVector.y * speed * Time.deltaTime));
        }*/

        if(Input.GetKeyDown("w"))
        {
            rigidbody.MovePosition(new Vector2(transform.position.x, (transform.position.y + move)));
        }
        else if (Input.GetKeyDown("s"))
        {
            rigidbody.MovePosition(new Vector2(transform.position.x, (transform.position.y - move)));
        }
        else if (Input.GetKeyDown("a"))
        {
            rigidbody.MovePosition(new Vector2(transform.position.x - move, transform.position.y));
        }
        else if (Input.GetKeyDown("d"))
        {
            rigidbody.MovePosition(new Vector2(transform.position.x + move, transform.position.y));
        }


    }

    private void MoveHorizontal()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        Debug.Log("transform right = " + transform.right);
        Debug.Log("input.getaxis = " + Input.GetAxis("Horizontal"));
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
    private void MoveVertical()
    {
        Vector3 direction = transform.up * Input.GetAxis("Vertical");
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        transform.Translate((Vector3.up * Input.GetAxis("Vertical")) * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Finish")
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
        if (coll.gameObject.tag == "Deathline")
        {
            speed = 0;
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

}
