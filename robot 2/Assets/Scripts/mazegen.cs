using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazegen : MonoBehaviour
{
    public static bool start = false;
    [System.Serializable]
    public class Kletka
    {
        public bool visited;
        public GameObject Sever;//1
        public GameObject Yug;//2
        public GameObject Vostok;//3
        public GameObject Zapad;//4
    }
    public GameObject wall;
    public GameObject floor;
    public int xSize = 10;
    public int ySize = 10;
    public static int tkletka = 0;
    public static int VsegoKletok = 0;
    public static int visitedCells = 0;
    public static int sosed = 0;
    public static bool startedbuilding = false;
    public static float zSize = 1.0f;
    public List<int> lastCells;
    public static int BackUp = 0;
    public static int WallToBreak = 0;
    public Vector3 initPos;
    GameObject tempWall;
    GameObject tempFloor;
    private GameObject box;
    public Kletka[] kletkas;
    void CrW()
    {
        box = new GameObject();
        box.name = "Labirynth";
        initPos = new Vector3((-xSize / 2) + zSize / 2, 0.0f, (-ySize / 2) + zSize / 2);
        Vector3 myPos = initPos;
        //строим стены по х
        for (int i = 0; i < ySize; i++)
        {
            for (int j = 0; j <= xSize; j++)
            {
                myPos = new Vector3(initPos.x + (j * zSize) - zSize / 2, 0.0f, initPos.z + (i * zSize) - zSize / 2);
               tempWall = Instantiate(wall, myPos, Quaternion.identity) as GameObject;
               tempWall.transform.parent = box.transform;

            }
        }
        // строим стены по у
         for (int i = 0; i <= ySize; i++)
         {
             for (int j = 0; j < xSize; j++)
             {
                 myPos = new Vector3(initPos.x + (j * zSize) , 0.0f, initPos.z + (i * zSize) - zSize);
                 tempWall = Instantiate(wall, myPos, Quaternion.Euler(0.0f,90.0f,0.0f)) as GameObject;
                 tempWall.transform.parent = box.transform;
            }
         }
        // строим пол
        myPos = new Vector3(0.8f, -(0.5f), -(0.1f));
        tempFloor = Instantiate(floor, myPos, Quaternion.identity) as GameObject;
        tempFloor.transform.localScale = new Vector3(xSize * 2f, 0.15f, ySize * 2f);
        /*for (int i = 0; i <= ySize - 1; i++)
        {
            for (int j = 0; j < xSize; j++)
            {
                myPos = new Vector3(initPos.x + (j * zSize), -0.5f, initPos.z + (i * zSize) - zSize / 2);
                tempFloor = Instantiate(floor, myPos, Quaternion.identity) as GameObject;
                tempFloor.transform.parent = box.transform;
            }
        }*/
        CrK();
    }
    void CrK()
    {
        lastCells = new List<int>();
        lastCells.Clear();
        VsegoKletok = xSize * ySize;
        GameObject[] AllWalls;
        int children = box.transform.childCount;// получает все стенки из коробки
        AllWalls = new GameObject[children];
        kletkas = new Kletka[xSize * ySize];
        int ZV = 0, childProcess = 0, TermCount = 0;
        for (int i = 0; i < children; i++)
        {
            AllWalls[i] = box.transform.GetChild(i).gameObject;
        }
        for (int klobr = 0; klobr < kletkas.Length; klobr++)
        {
            if (TermCount == xSize) { ZV++; TermCount = 0; }
            kletkas[klobr] = new Kletka();
            kletkas[klobr].Zapad = AllWalls[ZV];
            kletkas[klobr].Yug = AllWalls[childProcess + (xSize + 1) * ySize];
            ZV++;
            TermCount++;
            childProcess++;
            kletkas[klobr].Vostok = AllWalls[ZV];
            kletkas[klobr].Sever = AllWalls[(childProcess + (xSize + 1) * ySize) + xSize - 1];
        }
        CreateMaze();
    }
    void BreakWall()
    {
        switch (WallToBreak) {
            case 1 : Destroy(kletkas[tkletka].Sever);break;
            case 2 : Destroy(kletkas[tkletka].Zapad); break;
            case 3 : Destroy(kletkas[tkletka].Vostok); break;
            case 4 : Destroy(kletkas[tkletka].Yug); break;
        }
    
    }
    void CreateMaze()
    {
        if (visitedCells <= VsegoKletok)
        {
            if (startedbuilding)
            {
                Sosedi();
                if (kletkas[sosed].visited == false && kletkas[tkletka].visited == true)
                {
                    BreakWall();
                    kletkas[sosed].visited = true;
                    visitedCells++;
                    lastCells.Add(tkletka);
                    tkletka = sosed;
                    if (lastCells.Count > 0)
                    {
                        BackUp = lastCells.Count - 1;
                    }
                }
            }
            else
            {
                tkletka = Random.Range(0, VsegoKletok);
                kletkas[tkletka].visited = true;
                visitedCells++;
                startedbuilding = true;
            }

        }
        
            Invoke("CreateMaze", 0.00000000001f);
            //Debug.Log("Postroeno");
        
    }
    void Sosedi()
    {
        int dlina = 0;
        int[] sosedi = new int[4];
        int[] ConnectingWall = new int[4];
        int check = 0;
        check = ((tkletka + 1) / xSize);
        check -= 1;
        check *= xSize;
        check += xSize;
        // проверяем восток
        if (tkletka + 1 < VsegoKletok && (tkletka + 1) != check)
        {
            if(kletkas[tkletka+1].visited == false) { sosedi[dlina] = tkletka + 1;ConnectingWall[dlina] = 3;  dlina++; }
        }
        // проверяем запад
        if ((tkletka - 1 >= 0) && (tkletka != check))
        {
            if (kletkas[tkletka - 1].visited == false) { sosedi[dlina] = tkletka - 1; ConnectingWall[dlina] = 2; dlina++; }
        }
        // проверяем север
        if (tkletka + xSize < VsegoKletok)
        {
            if (kletkas[tkletka + xSize].visited == false) { sosedi[dlina] = tkletka + xSize; ConnectingWall[dlina] = 1; dlina++; }
        }
        // проверяем юг
        if (tkletka - xSize >= 0)
        {
            if (kletkas[tkletka - xSize].visited == false) { sosedi[dlina] = tkletka - xSize; ConnectingWall[dlina] = 4; dlina++; }
        }
        if (dlina != 0)
        {
            int vybor = Random.Range(0, dlina);
            sosed = sosedi[vybor];
                WallToBreak = ConnectingWall[vybor];
        }
        else
        {
            if (BackUp >0)
            {
                tkletka = lastCells[BackUp];
                BackUp--;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            CrW();
            start = false;
        }
    }
}
