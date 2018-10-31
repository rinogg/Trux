using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollingStreet : MonoBehaviour
{
    static public bool isDead = false;
    static public Vector2 scrollingSpeed = new Vector2(0f, 0f);
    public float clampedSpeed;
    public Rigidbody2D rb2d;
    public float gearIncrement = -0.100f;
    public float gearCap = -8f;
    public int gear = 0;
    public static float speed;
    public static float currentgear;
    public float speedDecay;
    public float timer;

    void Start()
    {
        rb2d.velocity = scrollingSpeed;
    }
    
    void Update()
    {
        
        speed = -scrollingSpeed.y;
        currentgear = gear;
        gearCap = Mathf.Clamp(gearCap, -80f, 0f);
        gearIncrement = Mathf.Clamp(gearIncrement, -0.100f, -0.010f);
        scrollingSpeed.y = Mathf.Clamp(scrollingSpeed.y, gearCap, 0f);
        gear = Mathf.Clamp(gear, 0, 7);

        RepositionBackground();
        Accelerate();  
        ChangeGears();
        ReloadLevel();
        RestartLevel();
    }

    void RepositionBackground()
    {
        if (this.transform.position.y < -13f)
        {
            this.transform.position = new Vector2(0f, 30f);
            this.transform.position = new Vector2(0f, 30f);
        }
        
    }

    void Gears(string shift)
    {
        if (shift == "down")
        {
            gearIncrement = Mathf.Clamp(gearIncrement, -0.100f, -0.040f);
            gearCap += 5f + (-gearIncrement) * 100;
            gear--;
            gearIncrement -= 0.010f;
        } 

        if (shift == "up")
        {   
            gearIncrement = Mathf.Clamp(gearIncrement, -0.100f, -0.040f);
            gearCap -= 5f + (-gearIncrement) * 100;
            gear++;
            gearIncrement += 0.010f;
        }
    }

    void ChangeGears()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Gears("up");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Gears("down");
        }
    }

    void ReloadLevel()
    {
        
        if (isDead)
        {
            timer += Time.deltaTime;
            
            if (timer > 3f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                isDead = false;
                
            }
        }
    }

    void Accelerate()
    {
        if (Input.GetKey("w") & isDead == false)
        {
            scrollingSpeed.y = scrollingSpeed.y + gearIncrement;
        }
        else { scrollingSpeed.y = scrollingSpeed.y + 0.04f; }

        if (Input.GetKey("s") & isDead == false)
        {
            scrollingSpeed.y = scrollingSpeed.y + 0.2f;

        }

        if (scrollingSpeed.y >= 0) //Can't reverse car
        {
            scrollingSpeed.y = 0;
        }
        rb2d.velocity = scrollingSpeed;
        scrollingSpeed = new Vector2(0f, scrollingSpeed.y);
    }

    void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void RestartLevel()
    {
        if (Input.GetKeyDown("r"))
        {
            TruckMovement.score = 0f;
            PlayerMovement.driftPoints = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
    

