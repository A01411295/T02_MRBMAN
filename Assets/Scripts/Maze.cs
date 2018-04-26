using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {

    public static int iteration = 1;
    public int rays;

	// Use this for initialization
	void Start () {
        rays = GameObject.FindGameObjectsWithTag("rayo").Length;
        Debug.Log("" + rays);
    }
	
	// Update is called once per frame
	void Update () {
        
        if(rays==0)
        {
            LevelManager levelMgr = new LevelManager();
            iteration++;
            levelMgr.LoadLevel("level");
        }
    }
}
