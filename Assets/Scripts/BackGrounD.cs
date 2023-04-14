using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackGrounD : MonoBehaviour
{
    public Transform ball; // topun transform component'i
    public int initalOffset=7;
    
    public List<GameObject> BackgroundList;

    private int i = 0;
    
    private int increas=1;
    //20-120
    void FixedUpdate()
    {
        if (ball.position.x >initalOffset + (20*increas))
        {
            var k = initalOffset + (20 * increas);
            Debug.Log("ball.position.x "+ball.position.x);
            Debug.Log("initalOffset + 20*increas" +k);
            
            BackgroundList[i].transform.position = new Vector2(60+initalOffset+(20*increas),0);
            var s = 60 + initalOffset + (20 * increas);
            
            Debug.Log("BackgroundList[i].transform.position"+BackgroundList[i].transform.position);
            increas++;
            i++;
            if (i == BackgroundList.Count)
                i = 0;

        }
    }
}