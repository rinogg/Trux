using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    
    public float steer;
    public Rigidbody2D rb2d;
    public Transform car;
    public Quaternion carRotation;
    public bool lockDirection = false;
    public ParticleSystem driftSmoke;
    static public float driftPoints = 1f; // multiplier
    public Image bar;
    public float barpos;
 

	// Use this for initialization
	void Start () {
        car.transform.position = new Vector3(-1f, -2f, -1f);
        
    }
	
	// Update is called once per frame
	void Update () {
        Steer();
        Drift();
        GatherPower();
    }

    void Steer()
    {
        steer = Mathf.Clamp(steer, -2.4f, 2.4f);
        if (Input.GetKey("a") & !lockDirection)
        {
            steer -= 0.3f;
        }
        if (Input.GetKeyDown("a"))
        {
            transform.Rotate(0f, 0f, +10f, Space.Self);
        }
        if (Input.GetKeyUp("a"))
        {
            transform.Rotate(0f, 0f, -10f, Space.Self);
        }


        if (Input.GetKey("d") & !lockDirection)
        {
            steer += 0.3f;
        }
        if (Input.GetKeyDown("d"))
        {
            transform.Rotate(0f, 0f, -10f, Space.Self);
        }
        if (Input.GetKeyUp("d"))
        {
            transform.Rotate(0f, 0f, +10f, Space.Self);
        }
        this.transform.position = new Vector2(steer, this.transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        driftSmoke.Play();
    }

    void OnCollisionExit2D(Collision2D collision)
    {   

        PlayerDeath();
    }

    void PlayerDeath()
    {
        driftSmoke.Play();
        ScrollingStreet.isDead = true;
        ScrollingStreet.scrollingSpeed.y = 0f;
        driftPoints = 1f;
        Destroy(gameObject);
    }

    void Drift()
    {
        driftPoints = Mathf.Clamp(driftPoints, 1f, 5f);
        if (Input.GetKey(KeyCode.Space))
        {

            ScrollingStreet.scrollingSpeed.y = ScrollingStreet.scrollingSpeed.y + 0.28f;
            if (ScrollingStreet.scrollingSpeed.y > -35f)
            {
                driftSmoke.Stop();
            }
            if (ScrollingStreet.scrollingSpeed.y < -33f)
            {
                
                driftPoints += 1f * Time.deltaTime;
            }

        }
        else { driftPoints -= 0.5f * Time.deltaTime; }
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            transform.Rotate(0f, 0f, 25f, Space.Self);
            lockDirection = true;
            if (ScrollingStreet.scrollingSpeed.y < -35f)
            {
                driftSmoke.Play();
            }
            //ScrollingStreet.scrollingSpeed.y = ScrollingStreet.scrollingSpeed.y + 10f;
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.Rotate(0f, 0f, -25f, Space.Self);
            lockDirection = false; 
            driftSmoke.Stop();
        }
    }
    void GatherPower()
    {
        
        
        if (driftPoints > 4.9f)
        {
            bar.fillAmount += 0.16f * Time.deltaTime;
        }
        else { bar.fillAmount -= 0.05f * Time.deltaTime; }
        
    }
}   

