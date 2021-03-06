﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    List<GameObject> allNotes = new List<GameObject>();
   // public GameObject[] arrows
   // public GameObject[] arrowsToChooseFrom = new GameObject[4];

    public GameObject Left_Arrow;
    public GameObject Up_Arrow;
    public GameObject Down_Arrow;
    public GameObject Right_Arrow;


    float next_spawn_time = 0;
    //Test Array GameObjects

    //Test array
    public float[] notesTest = { 2.1f, 3.1f, 4.2f, 5.2f, 5.6f };
    public int i = 0;
    public int[] nextNoteTest = { 1, 2, 3, 4, 2, 1 };
    public int spawnNote = 0;
    public int[] beatMap1notes = {1, 2, 3, 4, 1, 2, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2};


    //Beatmap 1
    public float[] beatmap1 = { 10.4f, 11.6f, 12.4f, 14.4f, 16.5f, 17.5f, 20.5f, 21.5f, 22.4f, 24.5f, 27.2f, 28.4f, 30.4f, 32.8f, 36.0f, 40.8f,
        41.6f, 43.6f, 44.8f, 45.6f, 46.8f, 47.6f, 48.4f, 49.6f, 50.8f, 51.6f, 52.8f, 60.0f, 61.0f, 62.0f, 63.0f, 64.4f, 65.0f, 66.0f, 67.0f, 68.0f,
        69.0f, 70.0f, 71.0f, 71.6f, 72.0f, 73.0f, 74.0f, 75.0f, 76.0f, 77.0f, 78.0f, 79.2f, 80.4f, 80.8f, 81.2f, 82.4f, 83.4f, 84.4f, 85.2f, 86.5f, 87.5f,
        88.5f, 89.5f, 90.0f, 90.4f, 91.5f, 92.5f, 93.5f, 94.5f, 95.5f, 96.5f, 97.6f, 98.5f, 99.6f, 100.4f, 101.5f, 102.5f, 103.5f, 104.0f, 104.4f, 104.8f,
        110.0f, 112.0f, 114.0f, 117.2f, 118.0f, 120.4f, 122.4f, 126.0f };


    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            /* if (Input.anyKeyDown)
             {
                 hasStarted = true;
             }
         */
            next_spawn_time = Time.time + beatmap1[i];
        }
        else
        {

            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
            if (Time.time > next_spawn_time)
            {
                //Instantiate(myPrefab, new Vector3(-1.4f, 4, 0), Quaternion.identity);
                // spawnNote = nextNoteTest[i];
                //increment next_spawn_time
                if (i > 1) {
                    next_spawn_time += (beatmap1[i] - beatmap1[i - 1]);
                }
                else
                {
                    next_spawn_time += beatmap1[i];
                }
                
                spawnArrow(beatMap1notes[i], i);
                
                i++;
                
                if (i == 12) { i--; };
               // UnityEngine.Debug.Log(spawnNote.ToString() + ", x, " + i);
                
            }
            /*for (int n = 0; n < arrows.Length; n++)
            {
                arrows[n].transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
                n++;
            }*/
        }
        for (int q = 0; q < allNotes.Count; q++)
        {
            // if (obj.activeSelf)
            // {
            GameObject y = allNotes[q];
            y.transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
            // }
        }
    }
    public void spawnArrow(int note, int position)
    {
        //Decides what type of gameobject to spawn
        //Below is old script that didnt use manually pointing out the game objects in the inspecto
        switch (note)
         {
             case 1:
                 allNotes.Add(GameObject.Instantiate(Left_Arrow, new Vector3(-1.4f, 5, 0), Quaternion.Euler(0f, 180f, 0f)));
                 allNotes[position].SetActive(true);
                break;
             case 2:
                allNotes.Add(GameObject.Instantiate(Up_Arrow, new Vector3(-0.4f, 5, 0), Quaternion.Euler(0f, 0f, 90f)));
                allNotes[position].SetActive(true);
                break;
             case 3:
                allNotes.Add(GameObject.Instantiate(Down_Arrow, new Vector3(0.55f, 5, 0), Quaternion.Euler(0f, 0f, -90f)));
                allNotes[position].SetActive(true);
                break;
             case 4:
                allNotes.Add(GameObject.Instantiate(Right_Arrow, new Vector3(1.57f, 5, 0), Quaternion.Euler(0f, 0f, 0f)));
                allNotes[position].SetActive(true);
                 break;
             default:
                 UnityEngine.Debug.Log("Something is wrong");
                 break;
         }
      /*  switch (note)
        {
            case 1:
                arrows[arrowNumber] = arrowsToChooseFrom[0];
                break;
            case 2:
                arrows[arrowNumber] = arrowsToChooseFrom[1];
                break;
            case 3:
                arrows[arrowNumber] = arrowsToChooseFrom[2];
                break;
            case 4:
                arrows[arrowNumber] = arrowsToChooseFrom[3];
                break;

        }*/
    }
    /* public void createBeatmap()
     {
         spawnArrow(nextNoteTest[x], x);

             UnityEngine.Debug.Log(nextNoteTest[x]);

     }*/
}
