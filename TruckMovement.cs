using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour {
    static public float score;
    public Rigidbody2D rb2d;
    public float velo;
    public Vector2 truckSpeed;
    public bool scoreEarned = false;
    public GameObject car;
    
  
	// Use this for initialization
	void Start () {
        //truckSpeed = new Vector2(0f, 20f);
        rb2d.velocity = truckSpeed;
        velo = rb2d.velocity.y;
        
    }
	
	// Update is called once per frame
	void Update ()
    {

        rb2d.velocity = truckSpeed - (-ScrollingStreet.scrollingSpeed);
        ScorePoints();
        DestroyOutOfBounds();
 
	}

    void ScorePoints()
    {
        if (this.gameObject.transform.position.y < -2f & scoreEarned == false)
        {
            score += (100f + ((ScrollingStreet.speed * 3 + 0.1f)/5f)) * Mathf.Round(PlayerMovement.driftPoints);
            Debug.Log((ScrollingStreet.speed + 1f) / 5f);
            gameObject.GetComponent<TruckMovement>().boolTrue();
            var scoreSound = gameObject.GetComponent<AudioSource>();
            scoreSound.pitch += PlayerMovement.driftPoints / 2f;
            scoreSound.Play(0);

            
        }
    }

    void boolTrue()
    {
        scoreEarned = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.transform.position.y > 37f)
        {
            Destroy(gameObject);
            Debug.Log("HIT HIT HIT");
        }
        
      
    }

    void DestroyOutOfBounds()
    {
        if (this.gameObject.transform.position.y < -80f)
        {
            Destroy(gameObject);
        }
    }
}   
