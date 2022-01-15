using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player;
    private Vector3 direction;
    public float gravity = -9f;
    public float force = 5f;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public PointsCounter pointsCount;
   

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
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                direction = Vector3.up * force;
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    direction = Vector3.up * force;
                }
            }
            direction.y += gravity * Time.deltaTime;
            transform.position += direction * Time.deltaTime;



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
