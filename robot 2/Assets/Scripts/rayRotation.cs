using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayRotation : MonoBehaviour
{
    public Transform TR, TF;
    bool povR, povF;
    RaycastHit hitR, hitF;

    void Start()
    {
        povR = false; povF = false;
    }

    void Update()
    {
        Debug.DrawRay(TR.transform.position, TR.transform.forward * -1/2f, Color.yellow); //Луч Справа
        Debug.DrawRay(TF.transform.position, TF.transform.right * 1 / 8f, Color.yellow); // Луч Спереди

        if (!(Physics.Raycast(TR.transform.position, -TR.transform.forward, out hitR, 3/4f))) //Условие поворота направо
        {
            if (povR == false)
            {
                povR = true;
                transform.Rotate(new Vector3(0, 1, 0), 90);
                Debug.Log("povr = true");
            }
        }
        if (Physics.Raycast(TR.transform.position, -TR.transform.forward, out hitR, 3/4f))
        {
            if (povR == true)
            { povR = false; }
            Debug.Log("povr = false");
        }

        if (Physics.Raycast(TF.transform.position, TF.transform.right, out hitF, 1 / 8f)) //Условие поворота налево (при стенке спереди)
        {
            if (povF == false)
            {
                povF = true;
                transform.Rotate(new Vector3(0, -1, 0), 90); Debug.Log("povf = true");
            }
            if (hitF.collider.tag == "Finish")
            {
                Debug.Log("ЛАБИРИНТ ПРОЙДЕН.");
                robotMove.movespeed = 0f;
            }
        }
        if (!(Physics.Raycast(TF.transform.position, TF.transform.right, out hitF, 1 / 8f)))
        {
            if (povF == true)
            { povF = false; }
            //Debug.Log("povf = false");
        }
    }
}
