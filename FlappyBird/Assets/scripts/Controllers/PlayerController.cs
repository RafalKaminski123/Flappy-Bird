using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Result
    {
        Idle,
        Tap,
        DoubleTap,
    }

    public enum InputState
    {
        NoInput,
        Waiting,
        Performed,
    }

    private Rigidbody2D player;
    private Vector3 direction;
    public float gravity = -9f;
    public float force = 5f;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public PointsCounter pointsCount;

    private float startTime;
    private float currentTime;
    private float duration = .2f;

    private Result touchResult = Result.Idle;
    private InputState inputState = InputState.NoInput;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;

    }

    private void Update()
    {
        if (inputState == InputState.Waiting)
        {
            currentTime = (Time.time - startTime) / duration;
            if (currentTime > 1f)
            {
                inputState = InputState.Performed;
                touchResult = Result.Tap;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            ProcessInputCalculation();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                ProcessInputCalculation();
            }
        }

        if (touchResult != Result.Idle)
        {
            if (touchResult == Result.Tap)
                direction = Vector3.up * force;
            else if (touchResult == Result.DoubleTap)
                FindObjectOfType<PipesController>().DestroyPipes();

            touchResult = Result.Idle;
            inputState = InputState.NoInput;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void ProcessInputCalculation()
    {
        if (inputState == InputState.NoInput)
        {
            inputState = InputState.Waiting;
            startTime = Time.time;
            currentTime = 0f;
        }
        else if (inputState == InputState.Waiting)
        {
            if (currentTime < 1f)
            {
                inputState = InputState.Performed;
                touchResult = Result.DoubleTap;
            }
        }
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameController>().GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<PointHUD>().UpdateHUD();
        }
    }


}

