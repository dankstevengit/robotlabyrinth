using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
