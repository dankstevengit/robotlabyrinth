using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoleVvoda : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;

    }
    private void SubmitName(string arg0)
    {

        Debug.Log(arg0);
        GameObject GM = GameObject.Find("GameManager");

        mazegen MZ = GM.GetComponent<mazegen>();
        MZ.xSize = int.Parse(arg0);
        MZ.ySize = MZ.xSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
