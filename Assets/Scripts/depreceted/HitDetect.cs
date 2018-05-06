using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetect : MonoBehaviour {

    public GameControl gm;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                if (hit.collider != null) {
                    print("Tadaaa:  " + hit.collider.tag);
                    if (hit.collider.tag.Equals("Target")) {
                        gm.inc(1);
                    }
                    if (hit.collider.tag.Equals("Target1"))
                    {
                        gm.inc(3);
                    }
                    if (hit.collider.tag.Equals("Target2"))
                    {
                        gm.inc(5);
                    }
                    if (hit.collider.tag.Equals("Wall"))
                    {
                        gm.inc(-10);
                    }
                }
        }
    }
}
