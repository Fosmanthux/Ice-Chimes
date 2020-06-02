using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BeatScroller2 : MonoBehaviour
{

    public float bpm;
    public bool hasStarted=false;
    List<GameObject> allNotes = new List<GameObject>();
    List<GameObject> allNotesExtra = new List<GameObject>();
    List<GameObject> allCones = new List<GameObject>();

    public GameObject Note;
    public GameObject Coin;
    public GameObject Cone;
    public GameObject Finish_line;

    public int songChoice;

    float next_spawn_time = 0;
    //Test Array GameObjects

    //Test array
    public int coneIndex = 0;
    public int index = 0;
    public int spawnNote = 0;


    //Beatmap 1 - Blurred Signs 2.06min/126f 85 notes
    public float[] beatmap1 = { 10.4f, 11.6f, 12.4f, 14.4f, 16.5f, 17.5f, 20.5f, 21.5f, 22.4f, 24.5f, 27.2f, 28.4f, 30.4f, 32.8f, 36.0f, 40.8f,
        41.6f, 43.6f, 44.8f, 45.6f, 46.8f, 47.6f, 48.4f, 49.6f, 50.8f, 51.6f, 52.8f, 60.0f, 61.0f, 62.0f, 63.0f, 64.4f, 65.0f, 66.0f, 67.0f, 68.0f,
        69.0f, 70.0f, 71.0f, 71.6f, 72.0f, 73.0f, 74.0f, 75.0f, 76.0f, 77.0f, 78.0f, 79.2f, 80.4f, 80.8f, 81.2f, 82.4f, 83.4f, 84.4f, 85.2f, 86.5f, 87.5f,
        88.5f, 89.5f, 90.0f, 90.4f, 91.5f, 92.5f, 93.5f, 94.5f, 95.5f, 96.5f, 97.6f, 98.5f, 99.6f, 100.4f, 101.5f, 102.5f, 103.5f, 104.0f, 104.4f, 104.8f,
        110.0f, 112.0f, 114.0f, 117.2f, 118.0f, 120.4f, 122.4f, 126.0f };

    public int[] beatMap1notes = { 1, 1, 2, 1, 2, 2, 3, 1, 2, 3, 1, 3, 2, 3, 3, 3, 2, 1, 3, 3, 3, 1, 3, 2, 3, 3, 3, 2, 1, 3, 2, 3, 2, 1, 3, 2, 1, 1, 2, 2, 2, 3, 2, 1, 3, 2, 2, 2, 3, 2, 2, 3, 2, 3, 3, 3, 3, 
        1, 3, 3, 1, 1, 1, 1, 1, 1, 3, 1, 1, 3, 3, 3, 2, 1, 3, 2, 3, 2, 1, 1, 2, 3, 1, 3, 3, };
    public int[] beatMap1notesExtra = { 7, 14, 0, 0, 7, 0, 0, 0, 9, 0, 7, 4, 0, 13, 0, 0, 0, 8, 9, 0, 7, 0, 0, 0, 0, 0, 0, 12, 6, 12, 0, 0, 0, 0, 0, 0, 0, 0, 13, 5,
        11, 0, 0, 0, 0, 7, 11, 0, 0, 0, 0, 0, 11, 0, 0, 8, 9, 0, 14, 0, 0, 13, 14, 9, 0, 0, 9, 13, 13, 11, 0, 0, 7, 13, 0, 0, 9, 13, 0, 14, 0, 0, 12, 13, 0 };

    //Beatmap 2 - Burning out 1.13min/72f 69 notes
    public float[] beatmap2 = { 3f, 7f, 12f, 15f, 16.5f, 20.5f, 21.5f, 22f, 23.5f, 24.5f, 26f, 27f, 28.5f, 29.5f, 30.5f, 
        32f, 33f, 34f, 35.5f, 26.5f, 37.5f, 39f, 40f, 40.5f, 41f, 41.5f, 42f, 42.5f, 43.5f, 44f, 44.5f, 45f, 45.5f, 46.5f, 47f, 47.5f, 48f,
        48.5f, 49f, 50f, 51f, 51.5f, 52f, 53.5f, 54f, 54.5f, 55f, 56f, 56.5f, 57f, 57.5f, 58.5f, 59f, 59.5f, 60f, 60.5f, 61f, 62f, 62.5f, 63f, 
        63.5f, 64f, 65f, 65.5f, 66f, 66.5f, 67.5f, 69.5f, 72f };
    public int[] beatMap2notes = { 2, 3, 1, 2, 1, 3, 3, 1, 1, 1, 2, 2, 2, 3, 1, 3, 1, 2, 3, 3, 3, 2, 2, 1, 3, 1, 1, 2, 3, 3, 2, 3, 2, 3, 3, 2, 1, 1,
        1, 2, 3, 2, 1, 3, 1, 2, 1, 2, 2, 1, 3, 2, 2, 3, 2, 2, 1, 3, 3, 1, 3, 1, 1, 1, 1, 3, 2, 2, 1 };
    public int[] beatMap2notesExtra = { 9, 0, 0, 12, 0, 12, 13, 9, 0, 0, 0, 7, 14, 0, 0, 13, 0, 7, 0, 8, 6, 0, 0, 0, 7, 9, 11, 12, 0, 6, 12, 9, 0, 0, 11, 9, 0, 14, 0, 0, 8, 13, 12, 13, 8, 
            11, 4, 0, 0, 8, 12, 12, 0, 12, 0, 11, 0, 13, 7, 0, 0, 14, 8, 11, 0, 0, 9, 7, 0 };

    //Beatmap 3 - Mist 1.29min/82f - 79 notes
    public float[] beatmap3 = {8.5f, 9.5f, 10f, 11f, 12f, 12.5f, 13f, 15f, 16f, 17f, 18.5f, 20f, 20.5f, 21.5f, 22f, 23.5f, 24f, 25f, 25.5f, 27.5f, 28f, 29f, 30f, 31.5f, 32f,
    32.5f, 33.5f, 35f, 36f, 37f, 39f, 39.5f, 40f, 41.5f, 43f, 44f, 44.5f, 46.5f, 47f, 48.5f, 49f, 50.5f, 51.5f, 53f, 54f, 54.5f, 55.5f, 56f, 57f, 58f, 58.5f, 59.5f, 60f,
    60.5f, 62f, 62.5f, 63f, 64f, 64.5f, 65.5f, 66.5f, 67f, 67.5f, 68.5f, 69.5f, 70f, 71f, 72f, 72.5f, 73.5f, 74f, 74.5f, 75.5f, 76f, 77.5f, 78f, 79f, 80f, 82f };
    public int[] beatMap3notes = { 1, 3, 2, 1, 2, 3, 1, 3, 2, 1, 3, 2, 3, 3, 3, 2, 2, 1, 1, 3, 1, 2, 3, 2, 3, 3, 2, 2, 3, 1, 3, 3, 1, 3, 3, 3, 1, 3, 2, 3, 3, 2, 2, 1, 2, 2, 1, 1, 1, 3, 3, 2, 1, 3, 1, 2,
        1, 2, 1, 3, 2, 3, 3, 2, 1, 2, 1, 1, 2, 3, 1, 2, 2, 3, 2, 2, 3, 1, 1 };
    public int[] beatMap3notesExtra = { 7, 0, 13, 11, 5, 0, 8, 9, 7, 0, 14, 14, 0, 8, 0, 12, 0, 11, 0, 9, 7, 5, 11, 0, 12, 0, 14, 13, 8, 8, 0, 12, 11, 0, 8, 9, 14, 13, 0, 8, 9, 0, 7, 0, 0, 12, 12, 0, 13, 14, 0, 11, 4, 12, 0, 9,
        0, 9, 11, 0, 7, 8, 9, 0, 4, 11, 7, 8, 9, 11, 0, 12, 8, 9, 0, 12, 13, 0, 0 };



    public float timeOffset = 0;
    // Start is called before the first frame update
    void Start()
    {
            bpm = bpm / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log("Next spawn time: "+next_spawn_time);
        UnityEngine.Debug.Log("i is: " + index);
        if (!hasStarted)
        {
            timeOffset = Time.time;
            //next_spawn_time = Time.time + beatmap1[0];
        }
        else
        {
            transform.position -= new Vector3(0f, 0f, bpm * Time.deltaTime);
            switch (songChoice)
            {
                case 1:
                    if ((Time.time-timeOffset) > next_spawn_time)
                    {
                        next_spawn_time = beatmap1[index];
                        spawnArrow(beatMap1notes[index], index, beatMap1notesExtra[index]);

                        index++;
                        if (beatMap1notes.Length == index)
                        {
                            index--;
                        }
                        //increment next_spawn_time

                    }
                    break;
                case 2:
                    if (Time.time-timeOffset > next_spawn_time)
                    {
                        next_spawn_time = beatmap2[index];
                        spawnArrow(beatMap2notes[index], index, beatMap2notesExtra[index]);
                        if (beatMap2notes.Length == index)
                        {
                            index--;
                        }
                        index++;
                    }
                    break;
                case 3:
                    if (Time.time - timeOffset > next_spawn_time)
                    {
                        next_spawn_time = beatmap3[index];
                        spawnArrow(beatMap3notes[index], index, beatMap3notesExtra[index]);
                        
                        index++;
                        if (beatMap3notes.Length == index)
                        {
                            index--;
                        }
                    }
                    break;
                default: { 
                    } 
                    break;

            }
            //Moves all of the notes
            for (int q = 0; q < allNotes.Count(); q++)
            {
               //buggTesting UnityEngine.Debug.Log("ok maybe here " + allNotesExtra.Count() + "Or here: " + allNotes.Count());
                GameObject y = allNotes[q];
                y.transform.position -= new Vector3(0f, 0f, bpm * Time.deltaTime);
                GameObject z = allNotesExtra[q];
                z.transform.position -= new Vector3(0f, 0f, bpm * Time.deltaTime);
            }
            //Moves all of the Cones
            if (allCones.Count() != 0) { 
              for(int q = 0; q < allCones.Count(); q++)
              {
                GameObject y = allCones[q];
                y.transform.position -= new Vector3(0f, 0f, bpm * Time.deltaTime);
              }
            }
        }
    }
    public void spawnArrow(int note, int position, int extra)
    {
        //Decides what type of gameobject to spawn
        // buggTesting   UnityEngine.Debug.Log("2222ok maybe here " + allNotesExtra.Count() + "Or here: " + allNotes.Count());
        // buggTesting  UnityEngine.Debug.Log("22222xxxxx note: "+note+ " position: "+ position + " extra: "+ extra);
        if (extra!=0)
        {
            note = extra;
        }
        else
        {
            allNotesExtra.Add(GameObject.Instantiate(Note, new Vector3(-1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
            allNotesExtra[position].SetActive(false);
        }    

        switch (note)
         {
            
             case 1:
                 allNotes.Add(GameObject.Instantiate(Note, new Vector3(-1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                 allNotes[position].SetActive(true);
                break;
             case 2:
                allNotes.Add(GameObject.Instantiate(Note, new Vector3(0f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotes[position].SetActive(true);
                break;
             case 3:
                allNotes.Add(GameObject.Instantiate(Note, new Vector3(1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotes[position].SetActive(true);
                break;

            case 4:
                allNotes.Add(GameObject.Instantiate(Note, new Vector3(-1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotes[position].SetActive(true);
                allNotesExtra.Add(GameObject.Instantiate(Coin, new Vector3(-1f, 1, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotesExtra[position].SetActive(true);
                break;
            case 5:
                allNotes.Add(GameObject.Instantiate(Note, new Vector3(0f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotes[position].SetActive(true);
                allNotesExtra.Add(GameObject.Instantiate(Coin, new Vector3(0f, 1, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotesExtra[position].SetActive(true);
                break;
            case 6:
                allNotes.Add(GameObject.Instantiate(Note, new Vector3(1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotes[position].SetActive(true);
                allNotesExtra.Add(GameObject.Instantiate(Coin, new Vector3(1f, 1, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotesExtra[position].SetActive(true);
                break;

                //Cones. Yes this will be a long method. 7-9 = One cone next to a note on the left. 11-13 Two cones next to a note. 14 Single cone on the right instead of left (case8)
            case 7:
                 allNotes.Add(GameObject.Instantiate(Note, new Vector3(-1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                 allNotes[position].SetActive(true);
                 allNotesExtra.Add(GameObject.Instantiate(Note, new Vector3(-1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                 allNotesExtra[position].SetActive(false);

                 allCones.Add(GameObject.Instantiate(Cone, new Vector3(0.37f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                 allCones[coneIndex].SetActive(true);
                 coneIndex++;
                 break;
             case 8:
                 allNotes.Add(GameObject.Instantiate(Note, new Vector3(0f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                 allNotes[position].SetActive(true);
                 allNotesExtra.Add(GameObject.Instantiate(Note, new Vector3(-1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                 allNotesExtra[position].SetActive(false);

                 allCones.Add(GameObject.Instantiate(Cone, new Vector3(-1.1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                 allCones[coneIndex].SetActive(true);
                 coneIndex++;
                 break;
             case 9:
                 allNotes.Add(GameObject.Instantiate(Note, new Vector3(1.2f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                 allNotes[position].SetActive(true);
                 allNotesExtra.Add(GameObject.Instantiate(Note, new Vector3(-1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                 allNotesExtra[position].SetActive(false);

                 allCones.Add(GameObject.Instantiate(Cone, new Vector3(0.37f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                 allCones[coneIndex].SetActive(true);
                 coneIndex++;
                 break;
                //Placeholder for instantiated finishline. Not in use.
            case 10:
                allNotes.Add(GameObject.Instantiate(Note, new Vector3(1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotes[position].SetActive(false);
                allNotesExtra.Add(GameObject.Instantiate(Finish_line, new Vector3(1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotesExtra[position].SetActive(true);
                break;
                // Two cones
            case 11:
                allNotes.Add(GameObject.Instantiate(Note, new Vector3(-1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotes[position].SetActive(true);
                allNotesExtra.Add(GameObject.Instantiate(Note, new Vector3(-1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotesExtra[position].SetActive(false);

                allCones.Add(GameObject.Instantiate(Cone, new Vector3(0.37f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allCones[coneIndex].SetActive(true);
                coneIndex++;
                allCones.Add(GameObject.Instantiate(Cone, new Vector3(1.37f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allCones[coneIndex].SetActive(true);
                coneIndex++;
                break;
            case 12:
                allNotes.Add(GameObject.Instantiate(Note, new Vector3(0f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotes[position].SetActive(true);
                allNotesExtra.Add(GameObject.Instantiate(Note, new Vector3(-1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotesExtra[position].SetActive(false);

                allCones.Add(GameObject.Instantiate(Cone, new Vector3(-1.1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allCones[coneIndex].SetActive(true);
                coneIndex++;
                allCones.Add(GameObject.Instantiate(Cone, new Vector3(1.37f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allCones[coneIndex].SetActive(true);
                coneIndex++;
                break;
            case 13:
                allNotes.Add(GameObject.Instantiate(Note, new Vector3(1.1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotes[position].SetActive(true);
                allNotesExtra.Add(GameObject.Instantiate(Note, new Vector3(-1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotesExtra[position].SetActive(false);

                allCones.Add(GameObject.Instantiate(Cone, new Vector3(0.37f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allCones[coneIndex].SetActive(true);
                coneIndex++;
                allCones.Add(GameObject.Instantiate(Cone, new Vector3(-1.1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allCones[coneIndex].SetActive(true);
                coneIndex++;
                break;
                //One Cone right side for middle
            case 14:
                allNotes.Add(GameObject.Instantiate(Note, new Vector3(0f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotes[position].SetActive(true);
                allNotesExtra.Add(GameObject.Instantiate(Note, new Vector3(-1f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allNotesExtra[position].SetActive(false);

                allCones.Add(GameObject.Instantiate(Cone, new Vector3(1.37f, 0, 12), Quaternion.Euler(0f, 0f, 0f)));
                allCones[coneIndex].SetActive(true);
                coneIndex++;
                break;

            default:
                UnityEngine.Debug.Log("Something is wrong");
                 break;
         }
     //buggTesting   UnityEngine.Debug.Log("33333ok maybe here " + allNotesExtra.Count() + "Or here: " + allNotes.Count());
    }
    public int getSelectedSong()
    {
        return songChoice;
    }

}
