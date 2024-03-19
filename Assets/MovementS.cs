using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
   public float speed;
    private float MoveH;
    private float MoveV;

   

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       MoveH = Input.GetAxis("Horizontal");

       rb.velocity = new Vector2 (speed * MoveH, rb.velocity.y);

       MoveV = Input.GetAxis("Vertical");

       rb.velocity = new Vector2 (speed * MoveV, rb.velocity.x);

        
    }
}
