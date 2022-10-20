using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PuzzleScript : MonoBehaviour
{
    public bool _win = false;
    [SerializeField] public int width;
    [SerializeField] public int height;
    [SerializeField] public float pic_width;
    [SerializeField] public float pic_height;
    private bool kek = true;
    // Start is called before the first frame update
    void Start()
    {
        //  Delete first picture of parent
        GameObject gameObject0 = GameObject.Find(this.gameObject.transform.GetChild(0).name);
        Destroy(gameObject0);



        
        int index = 1;
        float y = 1.89f;
        System.Random random = new System.Random();
       for (int i = 0; i < height; i++)
        {
            float x = -7.188f;
            for (int j = 0; j < width; j++)
            {   //  Place pictures in order
                GameObject gameObject = GameObject.Find(this.gameObject.transform.GetChild(index).name);
                gameObject.transform.position = new Vector3(x, y, 0);
                //  Give everyone random rotation %90==0
                //  Give them script and collider in order to rotate them by clicking
                gameObject.AddComponent<BoxCollider>();
                gameObject.AddComponent<RotateImage>();
                float rand_rotation = random.Next(0,360);
                /*this.gameObject.transform.GetChild(index).rotation = Quaternion.Euler(0,0, rand_rotation- (rand_rotation%90));*/
                index++;
                x += pic_width/100;//4.788f
            }
            y -= pic_height/100;//-2.7f

        }
       
    

    }

    // Update is called once per frame
    void Update()
    {
        // check if pictures are in correct order and logout if true
        List<GameObject> zalupa = new List<GameObject>();
        System.Random random = new System.Random();
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            zalupa.Add(GameObject.Find(this.gameObject.transform.GetChild(i).name));
        }
        if (kek)
        {
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                
                    float rand_rotation = random.Next(0, 360);
                    zalupa[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, rand_rotation - (rand_rotation % 90)));

                
            }
            kek = false;
        }
        kek = false;
        _win = zalupa.TrueForAll(isWin);
        Debug.Log(_win);
                       
        
    }
    private static bool isWin(GameObject i) 
    {
        return (i.transform.rotation.eulerAngles.z == 0); 
    }
}
