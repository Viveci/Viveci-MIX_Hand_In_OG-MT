using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour {

    //Prefab of the 3x3 wall
    public GameObject wall;

    //Timer elements, used for determining spawn periods.
    public float period;
    public float nextActionTime;

    //Ga
    public GameController gc;

	void Start () {
        //Setting first wall
        Instantiate(wall, transform.position, Quaternion.identity);

    }
	
	void Update () {

        
        //Instantiating a wall every period and Incrementing the nextActionTime.
        if (Time.time > nextActionTime) {
            nextActionTime += period;
            Instantiate(wall, transform.position, Quaternion.identity);
        }
        //Moves the position in the worldspace alongside Z axis
        transform.Translate(gc.speed);
    }

    private void FixedUpdate()
    {
        
    }
}
