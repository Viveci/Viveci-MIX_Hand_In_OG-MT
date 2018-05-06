using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

    public GameObject[] cubes;

    bool[,] formations;

    void Start() {

        //Loads the formations using the LoadFormations(), later can be expanded to data loading.
        formations = LoadFormations();
        
        //Creates the random formation by setActive .
        create(formations);

        //Auto destroy after 10 seconds.
        //Object.Destroy(gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update() {

    }

    public void create (bool[,] f){
        for (int i = 0; i < cubes.Length; i++) {
            //Actual seting active true|flase by formations data.
            // cubes[i].SetActive(f[(int)Random.Range(0f, 4f), i]);
            cubes[i].GetComponent<MeshRenderer>().enabled = f[(int)Random.Range(0f, 4f), i];
            //Excellent randomizator.
            //cubes[i].SetActive(f[(int)Random.Range(0f,4f),i]);
        }
    }


    private bool[,] LoadFormations() {
        bool[,] rtrn = new bool[4, 9];

        rtrn[0, 0] = true;
        rtrn[0, 1] = false;
        rtrn[0, 2] = true;
        rtrn[0, 3] = true;
        rtrn[0, 4] = false;
        rtrn[0, 5] = true;
        rtrn[0, 6] = true;
        rtrn[0, 7] = false;
        rtrn[0, 8] = true;

        rtrn[1, 0] = false;
        rtrn[1, 1] = true;
        rtrn[1, 2] = false;
        rtrn[1, 3] = true;
        rtrn[1, 4] = true;
        rtrn[1, 5] = true;
        rtrn[1, 6] = false;
        rtrn[1, 7] = true;
        rtrn[1, 8] = false;

        rtrn[2, 0] = false;
        rtrn[2, 1] = true;
        rtrn[2, 2] = false;
        rtrn[2, 3] = true;
        rtrn[2, 4] = false;
        rtrn[2, 5] = true;
        rtrn[2, 6] = false;
        rtrn[2, 7] = true;
        rtrn[2, 8] = false;

        rtrn[3, 0] = true;
        rtrn[3, 1] = false;
        rtrn[3, 2] = true;
        rtrn[3, 3] = false;
        rtrn[3, 4] = false;
        rtrn[3, 5] = false;
        rtrn[3, 6] = true;
        rtrn[3, 7] = false;
        rtrn[3, 8] = true;

        return rtrn;
    }



    public void kill() {
        Object.Destroy(gameObject, 3f);
    }
}
