using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementS : MonoBehaviour
{
   public float speed;
    private float MoveH;
    private float MoveV;

   public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite; 
    }

    // Update is called once per frame
    void Update()
    {
       MoveH = Input.GetAxis("Horizontal");

       rb.velocity = new Vector2 (speed * MoveH, rb.velocity.y);

       MoveV = Input.GetAxis("Vertical");

       rb.velocity = new Vector2 (speed * MoveV, rb.velocity.x);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<WallManager>().TargetHit(gameObject.transform.position);
        }
        
    }
}
