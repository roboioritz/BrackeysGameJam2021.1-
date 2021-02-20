using UnityEngine;
using System.Collections.Generic;

public class TerrainEditor : MonoBehaviour
{
    public float width = .1f;
    public float height = .1f;
    public Sprite sprite;    
    public GameObject[,] TerrainBlocks = new GameObject[200, 100];
    GroundBlock[,] TerraiBlocksScipt = new GroundBlock[200,100];
    public Color color = Color.black;
    public List<GameObject> Materials;
    [HideInInspector]
    public int currentMaterial;

    void Start()
    {
        
        for(int i = 0; i < transform.childCount; i++)
        {
            TerraiBlocksScipt[(int)(10 * (transform.GetChild(i).transform.position.x  - .5f) + 100), (int)(10 * (transform.GetChild(i).transform.position.y  - .5f) + 50)] = transform.GetChild(i).GetComponent<GroundBlock>();           
        }

        for (int i = 0; i < 200; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                if(TerraiBlocksScipt[i,j] == null)
                {
                    GameObject obj = new GameObject();                    
                    TerraiBlocksScipt[i, j] = obj.AddComponent<GroundBlock>();
                    TerraiBlocksScipt[i, j].spriteRenderer = obj.AddComponent<SpriteRenderer>();                    
                    TerraiBlocksScipt[i, j].state = 0;
                    //TerraiBlocksScipt[i, j].sprites = new Sprite[1];
                    TerraiBlocksScipt[i, j].sprite = sprite;                    
                }
                //Debug.Log(TerraiBlocksScipt[i, j].state);
                else
                {
                    TerraiBlocksScipt[i, j].X = i;
                    TerraiBlocksScipt[i, j].Y = j;
                }
            }
        }
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

                if (TerraiBlocksScipt[i, j].state != 0)
                {
                    
                    UpdateBlock(i, j);
                }
            }
        }

    }

    public void UpdateBlock(int i, int j)
    {
        
        int count = 0;
        if (TerraiBlocksScipt[i,j].state != 0)
        {
            if (i > 0)
            {
                if (TerraiBlocksScipt[i - 1, j].state > 0)
                {
                    count++;
                    TerraiBlocksScipt[i, j].state = 7;
                }
            }
            if (i < 199)
            {
                if (TerraiBlocksScipt[i + 1, j].state > 0)
                {
                    count++;
                    TerraiBlocksScipt[i, j].state = 9;
                }
            }
            if (j > 0)
            {
                if (TerraiBlocksScipt[i,j - 1].state > 0)
                {
                    count++;
                    TerraiBlocksScipt[i, j].state = 6;
                }
            }
            if (j < 99)
            {
                if (TerraiBlocksScipt[i, j + 1].state > 0)
                {
                    count++;
                    TerraiBlocksScipt[i, j].state = 8;
                }
            }

            if (count == 0 || count > 2) TerraiBlocksScipt[i, j].state = 1;
            if (count == 2)
            {
                if (i > 0 && i < 199)
                {
                    if (TerraiBlocksScipt[i - 1, j].state > 0 && TerraiBlocksScipt[i + 1, j].state > 0) TerraiBlocksScipt[i, j].state = 1;
                }
                if (j > 0 && j < 99)
                {
                    if (TerraiBlocksScipt[i, j - 1].state > 0 && TerraiBlocksScipt[i, j + 1].state > 0) TerraiBlocksScipt[i, j].state = 1;
                }
                if (i > 0 && j > 0)
                {
                    if (TerraiBlocksScipt[i - 1, j].state > 0 && TerraiBlocksScipt[i, j - 1].state > 0) TerraiBlocksScipt[i, j].state = 3;
                }
                if (i > 0 && j < 99)
                {
                    if (TerraiBlocksScipt[i - 1, j].state > 0 && TerraiBlocksScipt[i, j + 1].state > 0) TerraiBlocksScipt[i, j].state = 4;
                }
                if (i < 199 && j > 0)
                {
                    if (TerraiBlocksScipt[i + 1, j].state > 0 && TerraiBlocksScipt[i, j - 1].state > 0) TerraiBlocksScipt[i, j].state = 2;
                }
                if (i < 199 && j < 99)
                {
                    if (TerraiBlocksScipt[i + 1, j].state > 0 && TerraiBlocksScipt[i, j + 1].state > 0) TerraiBlocksScipt[i, j].state = 5;
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

    private void OnDrawGizmos()
    {
        //Vector3 pos = Camera.current.transform.position;
        Vector3 pos = Vector3.zero;
        Gizmos.color = color;       
        for (float y = pos.y - 5.0f ; y < pos.y + 5.0f; y += height)
        {
            Gizmos.DrawLine(new Vector3(-10.0f, Mathf.Floor(y / height) * height, 0.0f),
                            new Vector3(10.0f, Mathf.Floor(y / height) * height, 0.0f));
        }
        
        for (float x = pos.x - 10.0f; x < pos.x + 10.0f; x += width)
        {
            Gizmos.DrawLine(new Vector3(Mathf.Floor(x / width) * width, -5.0f, 0.0f),
                            new Vector3(Mathf.Floor(x / width) * width, 5.0f, 0.0f));
        }
    }
}