using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatmapSequence : MonoBehaviour
{
    public GameObject leftArrow;
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject rightArrow;

    float next_spawn_time = 0;

    //Test array
    public float[] notesTest = { 2.1f, 4.2f, 5.2f };
    public int i = 0;
    public int[] nextNoteTest = { 1, 2, 3 };
    public int spawnNote = 0;
    //Beatmap 1 notes-timer
    public float[] beatmap1 = { 10.4f, 11.6f, 12.4f, 14.4f, 16.5f, 17.5f, 20.5f, 21.5f, 22.4f, 24.5f, 27.2f, 28.4f, 30.4f, 32.8f, 36.0f, 40.8f, 
        41.6f, 43.6f, 44.8f, 45.6f, 46.8f, 47.6f, 48.4f, 49.6f, 50.8f, 51.6f, 52.8f, 60.0f, 61.0f, 62.0f, 63.0f, 64.4f, 65.0f, 66.0f, 67.0f, 68.0f, 
        69.0f, 70.0f, 71.0f, 71.6f, 72.0f, 73.0f, 74.0f, 75.0f, 76.0f, 77.0f, 78.0f, 79.2f, 80.4f, 80.8f, 81.2f, 82.4f, 83.4f, 84.4f, 85.2f, 86.5f, 87.5f, 
        88.5f, 89.5f, 90.0f, 90.4f, 91.5f, 92.5f, 93.5f, 94.5f, 95.5f, 96.5f, 97.6f, 98.5f, 99.6f, 100.4f, 101.5f, 102.5f, 103.5f, 104.0f, 104.4f, 104.8f, 
        110.0f, 112.0f, 114.0f, 117.2f, 118.0f, 120.4f, 122.4f, 126.0f };

    //Beatmap 1 notes

    // Start is called before the first frame update
    void Start()
    {
        next_spawn_time = Time.time + notesTest[i];
    }

    // Update is called once per frame
    void Update()
    {
        //Spawns the next correct note
        if (Time.time > next_spawn_time)
        {
            //Instantiate(myPrefab, new Vector3(-1.4f, 4, 0), Quaternion.identity);
            spawnNote = nextNoteTest[i];
            spawnArrow(spawnNote);
            //increment next_spawn_time
            next_spawn_time += notesTest[i];
                i++;
            if (i == 3) { i--; };
            UnityEngine.Debug.Log(spawnNote.ToString()+", x, "+i);

        }

    }
    //Spawns the correct note as listed in the note array that aligns with the beat array.
    public void spawnArrow(int note)
    {
        switch (note) {
            case 1: Instantiate(leftArrow, new Vector3(-1.4f, 4, 0), Quaternion.identity);
                break;
            case 2: Instantiate(upArrow, new Vector3(-0.4f, 5, 0), Quaternion.identity);
                break;
            case 3: Instantiate(downArrow, new Vector3(0.55f, 6, 0), Quaternion.identity);
                break;
            case 4: Instantiate(rightArrow, new Vector3(1.57f, 7, 0), Quaternion.identity);
                break;
            default: break;
        }
    }
}
