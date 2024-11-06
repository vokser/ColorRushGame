using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _colorChangeCoolDown;
    [SerializeField] private Camera _mainCamera;

    private const float touchArea = 0.3f;
    
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private float colorChangeTime = 0.2f;
    private Color[] colors = { Color.red, Color.blue, Color.green };
    private int currentColorIndex = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        spriteRenderer.color = colors[currentColorIndex];
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * _speed, rb.velocity.y);
    }

    private void Update()
    {

        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            Vector2 targetPosition;

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                
                if (touch.position.y < Screen.height * touchArea)
                {
                    targetPosition = Camera.main.ScreenToWorldPoint(touch.position);
                }
                else
                {
                    return;
                }
            }
            else
            {
                if(Input.mousePosition.y < Screen.height * touchArea)
                {
                    targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
                else
                {
                    return;
                }
            }

            targetPosition.y = transform.position.y;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        }



        Vector2 position = transform.position;      

        Vector2 minScreenBounds = _mainCamera.ViewportToWorldPoint(new Vector2(0, _mainCamera.transform.position.z));
        Vector2 maxScreenBounds = _mainCamera.ViewportToWorldPoint(new Vector2(1, _mainCamera.transform.position.z));

        
        position.x = Mathf.Clamp(position.x, minScreenBounds.x, maxScreenBounds.x);        
        transform.position = position;
    }

    public void ChangeColor()
    {
        if (Time.time > colorChangeTime)
        {
            colorChangeTime = Time.time + _colorChangeCoolDown;
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            spriteRenderer.color = colors[currentColorIndex];
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Strip"))
        {
            SpriteRenderer stripRenderer = other.GetComponent<SpriteRenderer>();
            if (stripRenderer.color == spriteRenderer.color)
            {
                GameManager.instance.ScoreCounter(1);
                Destroy(other.gameObject);
            }
            else
            {
                GameManager.instance.GameOver();
            }
        }
        else if (other.CompareTag("Obstacle"))
        {
            GameManager.instance.GameOver();
        }
    }


}
