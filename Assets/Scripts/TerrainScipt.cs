using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScipt : MonoBehaviour
{    
    public static TerrainScipt i;
    public GameObject Block;
    GameObject[][] TerrainBlocks = new GameObject[200][];
    GroundBlock[][] TerraiBlocksScipt = new GroundBlock[200][];

    void Start()
    {
        i = this;
        for (int i = 0; i < 200; i++)
        {
            TerrainBlocks[i] = new GameObject[100];
            TerraiBlocksScipt[i] = new GroundBlock[100];
            for (int j = 0; j < 100; j++)
            {
                TerrainBlocks[i][j] = Instantiate(Block);
                TerrainBlocks[i][j].transform.parent = this.transform;
                TerrainBlocks[i][j].transform.position = new Vector3(((float)i)/10  + transform.position.x, ((float)j) /10 + transform.position.y, 0);
                TerraiBlocksScipt[i][j] = TerrainBlocks[i][j].GetComponent<GroundBlock>();
            }
        }
        UpdateAll();
    }

    void Update()
    {
        UpdateAll();
    }

    void UpdateAll()
    {
        for (int i = 0; i < 200; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                UpdateBlock(i, j);
            }
        }

    }

    public void UpdateBlock(int i, int j)
    {
        int count = 0;
        if (TerraiBlocksScipt[i][j].state != 0)
        {
            if (i > 0)
            {
                if (TerraiBlocksScipt[i - 1][j].state > 0)
                {
                    count++;
                    TerraiBlocksScipt[i][j].state = 7;
                }
            }
            if (i < 199)
            {
                if (TerraiBlocksScipt[i + 1][j].state > 0)
                {
                    count++;
                    TerraiBlocksScipt[i][j].state = 9;
                }
            }
            if (j > 0)
            {
                if (TerraiBlocksScipt[i][j - 1].state > 0)
                {
                    count++;
                    TerraiBlocksScipt[i][j].state = 6;
                }
            }
            if (j < 99)
            {
                if (TerraiBlocksScipt[i][j + 1].state > 0)
                {
                    count++;
                    TerraiBlocksScipt[i][j].state = 8;
                }
            }

            if (count == 0 || count > 2) TerraiBlocksScipt[i][j].state = 1;
            if (count == 2)
            {
                if (i > 0 && i < 199)
                {
                    if (TerraiBlocksScipt[i - 1][j].state > 0 && TerraiBlocksScipt[i + 1][j].state > 0) TerraiBlocksScipt[i][j].state = 1;
                }
                if (j > 0 && j < 99)
                {
                    if (TerraiBlocksScipt[i][j - 1].state > 0 && TerraiBlocksScipt[i][j + 1].state > 0) TerraiBlocksScipt[i][j].state = 1;
                }
                if (i > 0 && j > 0)
                {
                    if (TerraiBlocksScipt[i - 1][j].state > 0 && TerraiBlocksScipt[i][j - 1].state > 0) TerraiBlocksScipt[i][j].state = 3;
                }
                if (i > 0 && j < 99)
                {
                    if (TerraiBlocksScipt[i - 1][j].state > 0 && TerraiBlocksScipt[i][j + 1].state > 0) TerraiBlocksScipt[i][j].state = 4;
                }
                if (i < 199 && j > 0)
                {
                    if (TerraiBlocksScipt[i + 1][j].state > 0 && TerraiBlocksScipt[i][j - 1].state > 0) TerraiBlocksScipt[i][j].state = 2;
                }
                if (i < 199 && j < 99)
                {
                    if (TerraiBlocksScipt[i + 1][j].state > 0 && TerraiBlocksScipt[i][j + 1].state > 0) TerraiBlocksScipt[i][j].state = 5;
                }

            }
        }
        //Debug.Log(count);
    }

    public void UpdateBlocksArround(int i, int j)
    {
        if (i > 0) UpdateBlock(i - 1, j);
        if (i < 199) UpdateBlock(i + 1, j);
        if (j > 0) UpdateBlock(i, j - 1);
        if (j < 99) UpdateBlock(i + 1, j + 1);

    }
}
