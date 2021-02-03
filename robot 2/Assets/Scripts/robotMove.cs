using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotMove : MonoBehaviour
{
    public static float movespeed = 0.4f; //скорость робота;

    void Update() //каждую секунду...
    {
        transform.Translate(new Vector3(1f, 0, 0) * movespeed * Time.deltaTime); //движение вперед.
    }
}