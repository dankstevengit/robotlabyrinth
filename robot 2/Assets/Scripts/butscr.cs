using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class butscr : MonoBehaviour
{
    public GameObject but ;
    public GameObject Button;
    int k = 0;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void work()
    {
        k++;
        /*GameObject GM = GameObject.Find("GameManager");
        bool mazegen;
        mazegen = GM.GetComponent<mazegen>();*/
        mazegen.start = true;
        if (k > 1)
        {
            mazegen.start = false;
            GameObject LB = GameObject.Find("Labirynth");
            Destroy(LB);
            GameObject LF = GameObject.Find("floor(Clone)");
            Destroy(LF);
            mazegen.tkletka = 0;
    mazegen.VsegoKletok = 0;
    mazegen.visitedCells = 0;
    mazegen.sosed = 0;
    mazegen.startedbuilding = false;
    mazegen.zSize = 1.0f;
    mazegen.start = true;
    mazegen.BackUp = 0;
    mazegen.WallToBreak = 0;

}
       
        Destroy(but);
        Destroy(Button);
    }
    
    
    // Update is called once per frame
    void Update()
    {
      
    }
}
