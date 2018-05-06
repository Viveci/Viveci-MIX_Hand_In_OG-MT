using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //Counters and game conditions
    private int level;
    private int points;
    private float timeLeft;
    private float shootTimer;
    public bool game;
    public bool death;
    private Vector3 init_pos;
    private Vector3 init_sld;
    private float CountDown;

    //Canvas control
    public Text Display_Points;
    public Text Display_Level;
    public Text Display_Timer;
    public Text Display_PauseScore;
    public Text Display_CountDown;

    //Slider
    public UnityEngine.UI.Slider Display_Reload;

    //Buttons
    public UnityEngine.UI.Button ResumeButton;
    public UnityEngine.UI.Button PauseButton;

    //Debug
    public Text Display_Debug;

    //Possible camera quatarnioins<
    public GameObject cam;
    public GameObject slider;
    public GameObject Display_PauseMenu;
    public GameObject DeathBoard;
    

    //movement
    public float horizontalSpeed = 1.0F;
    public float verticalSpeed = 1.0F;
    public Vector3 speed;
    private object rayHit;


    void Start()
    {
        game = false;
        death = false;
        points = 0;
        level = 1;
        timeLeft = 30f;
        shootTimer = 10f;
        CountDown = 5f;
        Display_Level.text = "" + level;
        init_pos = transform.position;
        init_sld = slider.transform.position;
    }

    void Update()
    {

        OVRInput.Update();
        float h = horizontalSpeed * OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote).x;
        float v = verticalSpeed * OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote).y;

        if (!death && !game && !Display_PauseMenu.activeSelf)
        {
            Display_CountDown.gameObject.SetActive(true);
            CountDown -= Time.deltaTime;
            Display_CountDown.text = "" + (int)CountDown;
        }
        else
        {
            Display_CountDown.gameObject.SetActive(false);
        }

        if (game)
        {
            //if game is true moves player alongside z axis.
            transform.Translate(h,v,speed.z);

            //Timer related calculations
            timeLeft -= Time.deltaTime;
            Display_Timer.text = " " + (int)timeLeft;
            Display_Reload.value = shootTimer;
        }

        if (death) {
            ButtonPressPause();
        }

        if (shootTimer >= 10f && Input.GetKey(KeyCode.Mouse1)) {
            Debug.Log("Shoot");

            //Null shootTimer
            shootTimer = 0;

            Debug.DrawRay(transform.position, new Vector3() * 10, Color.white);

        }

        if (shootTimer < 10f) {
            shootTimer += Time.deltaTime; ;
        }

        //If time is up, it stops player
        if (timeLeft <= 0) {
            game = false;
            Display_Timer.text = "" + 0;
        }

        //Start the "flying"
        if (Input.GetKeyDown(KeyCode.Space) /* || OVRInput.GetDown(OVRInput.Button.Any)*/ || CountDown <= 1f && ! death) {
            game = true;
        }

        if (OVRInput.Get(OVRInput.Button.Back)) {
            ButtonPressPause();
        }

        //Directions
        //TODO - Implement 4 axis d-pad control + trigger for shooting
        //transform.Translate(new Vector3(cam.transform.rotation.x*-0.2f,cam.transform.rotation.y*-0.2f,speed.z* cam.transform.rotation.z));

        //dummy movement on pc
        if ((Input.GetKeyDown(KeyCode.D) || OVRInput.GetDown(OVRInput.Button.DpadRight)) && transform.position.x <= 1) {
            transform.Translate(new Vector3(1f,0f,0f));
        }
        if ((Input.GetKeyDown(KeyCode.A) || OVRInput.GetDown(OVRInput.Button.DpadLeft)) && transform.position.x >= 0)
        {
            transform.Translate(new Vector3(-1f, 0f, 0f));
        }
        if ((Input.GetKeyDown(KeyCode.W) || OVRInput.GetDown(OVRInput.Button.DpadUp)) && transform.position.y < 2.5)
        {
            transform.Translate(new Vector3(0f, 1f, 0f));
        }
        if ((Input.GetKeyDown(KeyCode.S) || OVRInput.GetDown(OVRInput.Button.DpadDown)) && transform.position.y > 0.5)
        {
            transform.Translate(new Vector3(0f, -1f, 0f));
        }
       
    }

    public void inc(int n)
    {
        if (game)
        {
            points += n;
            Display_Points.text = "" + points;
            Debug.Log(Time.time + "; Game Controler: Increment called, end result is: " + points);
        }
    }

    //Detects wall hit.
    private void OnTriggerEnter(Collider other)
    {

        //Colllision with active wall element.
        if (other.GetComponent<MeshRenderer>().enabled)
        {
            Debug.Log("Hit");
            game = false;
            death = true;
        }
        else
        {
            //Collision with empty space. increments score
            Debug.Log("Score");
            this.inc(1);
            other.gameObject.transform.parent.gameObject.GetComponent<WallController>().kill();
        }

    }

    //Stops game and Shows Display_PauseMenu
    public void ButtonPressPause() {
        game = false;
        Display_PauseMenu.SetActive(true);
        if (death) {
            ResumeButton.gameObject.SetActive(false);
            DeathBoard.SetActive(true);
            Display_PauseScore.text = "Your score is " + points;
        }
    }

    //Start game and hides Display_PauseMenu
    public void ButtonPressResume() {
        game = true;
        Display_PauseMenu.SetActive(false);
    }

    //TODO - Main menu
    public void ButtonPressMainMenu() {
        Debug.Log("Not yet done");
    }

    //Resets scene
    public void ButtonPressRetry() {
        Display_PauseMenu.SetActive(false);
        game = false;
        death = false;
        points = 0;
        level = 1;
        CountDown = 5f;
        timeLeft = 30f;
        shootTimer = 10f;
        Display_Level.text = "" + level;
        transform.position = init_pos;
        slider.transform.position = init_sld;
    }


}
