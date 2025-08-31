using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public AudioClip flapSound;
    private int spriteIndex;
    private Vector3 direction;
    private AudioSource audioSource;
    public float gravity = -9.81f;
    public float strength = 5f;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.20f, 0.20f);   
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * strength;
            audioSource.PlayOneShot(flapSound);
        }
        
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
                audioSource.PlayOneShot(flapSound);
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
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
            FindAnyObjectByType<GameManager>().GameOver();   
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindAnyObjectByType<GameManager>().IncreaseScore();
        }
    }
}
