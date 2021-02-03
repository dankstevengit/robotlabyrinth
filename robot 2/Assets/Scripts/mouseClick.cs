using UnityEngine;

using System.Collections;

public class mouseClick : MonoBehaviour
{
    public GameObject finish; public GameObject robot;
    bool createdF = true; bool createdR = false; 

    void Update()
    {
        if (mazegen.start == false)
            if (Input.GetMouseButton(0))
            {
                        if (createdF == true)
                        {
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hit; // Точка пересечения
                            if (Physics.Raycast(ray, out hit))
                                if (hit.collider.tag == "Floor")
                                {
                                    finish.transform.position = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
                                    createdF = false;
                                    createdR = true;
                                }
                        }

                        else if (createdR == true)
                        {
                            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hit1; // Точка пересечения
                            if (Physics.Raycast(ray2, out hit1))
                                if (hit1.collider.tag == "Floor")
                                { 
                                    robot.transform.position = new Vector3(hit1.point.x, hit1.point.y + 0.25f, hit1.point.z);
                                    createdR = false;
                                }
                        }
            }
    }
}