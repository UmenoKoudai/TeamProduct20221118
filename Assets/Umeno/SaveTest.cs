using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    GameObject[] weaponArray;
    List<GameObject> weaponList;
    //class Data
    //{
    //    public int score;
    //    public int hiscore;
    //}

    int score;
    int hiscore;

    //Data data = new Data();
    // Start is called before the first frame update
    void Start()
    {
        hiscore = ExpansionMethod.OnLoad(hiscore);
        //hiscore = data.hiscore;
        Debug.Log($"HiScore:{hiscore}");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            score++;
            Debug.Log($"Score:{score}");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(hiscore < score)
            {
                hiscore = score;
            }
            ExpansionMethod.OnSave(hiscore);
            Debug.Log("Save");
        }
    }
}
