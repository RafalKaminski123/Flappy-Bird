using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private enum Result
    {
        Idle,
        Tap,
        DoubleTap,
    }

    private enum InputState
    {
        NoInput,
        Waiting,
        Performed,
    }

    private bool isEnabled;
    private UnityAction onObstacleHit;
    private UnityAction onScoreColliderHit;
    
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private Vector3 direction;
    
    public float gravity = -9f;
    public float force = 5f;
    private int spriteIndex;

    private float startTime;
    private float currentTime;
    private float duration = .2f;

    private Result touchResult = Result.Idle;
    private InputState inputState = InputState.NoInput;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }
    
    public void OnObstacleHitAddListener(UnityAction callback)
    {
        onObstacleHit += callback;
    }

    public void OnScoreColliderHitAddListener(UnityAction callback)
    {
        onScoreColliderHit += callback;
    }

    public void RemoveAllListener()
    {
        onObstacleHit = null;
        onScoreColliderHit = null;
    }
    
    public void EnableController()
    {
        isEnabled = true;
        Vector3 position = transform.position;
        position.y = 0f;
    }

    public void DisableController()
    {
        isEnabled = false;
    }

    public void UpdateController(PointsController pointsController, PipesController pipesController)
    {
        if (!isEnabled)
            return;
        
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
            if (pointsController.Bombs == 0 && touchResult == Result.DoubleTap)
                touchResult = Result.Tap;
            
            switch (touchResult)
            {
                case Result.Tap:
                    direction = Vector3.up * force;
                    break;
                case Result.DoubleTap:
                    pipesController.DestroyPipes();
                    pointsController.RemoveBomb();
                    break;
            }

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
        if (other.gameObject.CompareTag("Obstacle"))
        {
            onObstacleHit?.Invoke();
        }
        else if (other.gameObject.CompareTag("Scoring"))
        {
           onScoreColliderHit.Invoke();
        }
    }
}

