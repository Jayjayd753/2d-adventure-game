using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour

{

   public float speed;
   public bool vertical;
   public float changeTime = 3.0f;
   Rigidbody2D rigidbody2d;
   float timer;
   int direction = 1;
   
   
   
   
   // Start is called before the first frame update
   void Start()
   {
       rigidbody2d = GetComponent<Rigidbody2D>();
       timer = changeTime;
   }
    // Update is called every frame
    void Update()
    {
       timer  -= Time.deltaTime;


      if (timer < 0)
      {
        direction = -direction;
        timer = changeTime;
      }
    }
    // FixedUpdate has the same call rate as the physics system
    void FixedUpdate()
    {   
       Vector2 position = rigidbody2d.position;
     
       if (vertical)
       {
           position.y = position.y + speed * direction * Time.deltaTime;
       }
       else
       {
           position.x = position.x + speed * direction * Time.deltaTime;
       }


       rigidbody2d.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    
    
    }


}



