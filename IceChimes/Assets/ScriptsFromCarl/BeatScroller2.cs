using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller2 : MonoBehaviour
{

    public float bpm;
    public bool hasStarted;
    List<GameObject> allNotes = new List<GameObject>();

    public GameObject Left_Arrow;
    public GameObject Up_Arrow;
    public GameObject Down_Arrow;
    public GameObject Right_Arrow;
    public int songChoice;

    float next_spawn_time = 0;
    //Test Array GameObjects

    //Test array
    public int i = 0;
    public int spawnNote = 0;


    //Beatmap 1 - Blurred Signs 2.06
    public float[] beatmap1 = { 10.4f, 11.6f, 12.4f, 14.4f, 16.5f, 17.5f, 20.5f, 21.5f, 22.4f, 24.5f, 27.2f, 28.4f, 30.4f, 32.8f, 36.0f, 40.8f,
        41.6f, 43.6f, 44.8f, 45.6f, 46.8f, 47.6f, 48.4f, 49.6f, 50.8f, 51.6f, 52.8f, 60.0f, 61.0f, 62.0f, 63.0f, 64.4f, 65.0f, 66.0f, 67.0f, 68.0f,
        69.0f, 70.0f, 71.0f, 71.6f, 72.0f, 73.0f, 74.0f, 75.0f, 76.0f, 77.0f, 78.0f, 79.2f, 80.4f, 80.8f, 81.2f, 82.4f, 83.4f, 84.4f, 85.2f, 86.5f, 87.5f,
        88.5f, 89.5f, 90.0f, 90.4f, 91.5f, 92.5f, 93.5f, 94.5f, 95.5f, 96.5f, 97.6f, 98.5f, 99.6f, 100.4f, 101.5f, 102.5f, 103.5f, 104.0f, 104.4f, 104.8f,
        110.0f, 112.0f, 114.0f, 117.2f, 118.0f, 120.4f, 122.4f, 126.0f };
    public int[] beatMap1notes = { 1, 2, 3, 2, 2, 1, 3, 1, 2, 1, 1, 3, 3, 2, 3, 1, 3, 2, 1, 1, 2, 3, 2, 3, 1, 2, 3, 1, 3, 2, 1, 3, 2, 3, 1, 3, 2, 1, 2, 2, 1, 3, 3, 1, 2, 1, 2, 3, 2, 3, 2, 3, 1 };

    //Beatmap 2 - Burning out 1.13
    public float[] beatmap2 = { 3f, 7f, 12f, 15f, 16.5f, 20.5f, 21.5f, 22f, 23.5f, 24.5f, 26f, 27f, 28.5f, 29.5f, 30.5f, 
        32f, 33f, 34f, 35.5f, 26.5f, 37.5f, 39f, 40f, 40.5f, 41f, 41.5f, 42f, 42.5f, 43.5f, 44f, 44.5f, 45f, 45.5f, 46.5f, 47f, 47.5f, 48f,
        48.5f, 49f, 50f, 51f, 51.5f, 52f, 53.5f, 54f, 54.5f, 55f, 56f, 56.5f, 57f, 57.5f, 58.5f, 59f, 59.5f, 60f, 60.5f, 61f, 62f, 62.5f, 63f, 
        63.5f, 64f, 65f, 65.5f, 66f, 66.5f, 67.5f, 69.5f, 72f };
    public int[] beatMap2notes = { 1, 2, 3, 2, 2, 1, 3, 1, 2, 1, 1, 3, 3, 2, 3, 1, 3, 2, 1, 1, 2, 3, 2, 3, 1, 2, 3, 1, 3, 2, 1, 3, 2, 3, 1, 3, 2, 1, 2, 2, 1, 3, 3, 1, 2, 1, 2, 3, 2, 3, 2, 3, 1 };


    // Start is called before the first frame update
    void Start()
    {
        bpm = bpm / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {

            //next_spawn_time = Time.time + beatmap1[0];
        }
        else
        {
            transform.position -= new Vector3(0f, 0f, bpm * Time.deltaTime);
            switch (songChoice)
            {
                case 1:
                    if (Time.time > next_spawn_time)
                    {
                        if (i > 0)
                        {
                            next_spawn_time += beatmap1[i];
                        }

                        spawnArrow(beatMap1notes[i], i);

                        i++;
                        //increment next_spawn_time
                        UnityEngine.Debug.Log(spawnNote.ToString() + ", x, " + i);

                        if (i == 12) { i--; };
                    }
                    break;
                case 2:
                    if (Time.time > next_spawn_time)
                    {
                        if (i > 0)
                        {
                            next_spawn_time += beatmap2[i];
                        }
                        spawnArrow(beatMap2notes[i], i);
                        i++;
                        if (i == 12) { i--; };
                    }
                    break;
                default: { } break;

            }
            for (int q = 0; q < allNotes.Count; q++)
            {

                GameObject y = allNotes[q];
                y.transform.position -= new Vector3(0f, 0f, bpm * Time.deltaTime);
            }
        }
    }
    public void spawnArrow(int note, int position)
    {
        //Decides what type of gameobject to spawn

        switch (note)
         {
             case 1:
                 allNotes.Add(GameObject.Instantiate(Left_Arrow, new Vector3(-1f, 0, 25), Quaternion.Euler(0f, 0f, 0f)));
                 allNotes[position].SetActive(true);
                break;
             case 2:
                allNotes.Add(GameObject.Instantiate(Up_Arrow, new Vector3(0f, 0, 25), Quaternion.Euler(0f, 0f, 0f)));
                allNotes[position].SetActive(true);
                break;
             case 3:
                allNotes.Add(GameObject.Instantiate(Down_Arrow, new Vector3(1f, 0, 25), Quaternion.Euler(0f, 0f, 0f)));
                allNotes[position].SetActive(true);
                break;
             case 4:
                allNotes.Add(GameObject.Instantiate(Right_Arrow, new Vector3(1.57f, 0, 25), Quaternion.Euler(0f, 0f, 0f)));
                allNotes[position].SetActive(true);
                 break;
             default:
                 UnityEngine.Debug.Log("Something is wrong");
                 break;
         }
    }
    public int getSelectedSong()
    {
        return songChoice;
    }

}
