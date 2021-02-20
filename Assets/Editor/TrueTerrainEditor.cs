using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(TerrainEditor))]
public class TrueTerrainEditor : Editor
{
    public static TrueTerrainEditor i;
    public TerrainEditor grid;
    public Object prefab;
    public MaterialHolder materialHolder;
    public Sprite sprite;
    private GameObject obj;
    //public Object terrain;
    public void OnEnable()
    {
        i = this;
        grid = (TerrainEditor)target;
        //SceneView.onSceneGUIDelegate += GridUpdate;
        SceneView.duringSceneGui += GridUpdate;
    }

    public void OnDisable()
    {
        
        //SceneView.onSceneGUIDelegate -= GridUpdate;
        SceneView.duringSceneGui -= GridUpdate;
    }

    void GridUpdate(SceneView sceneview)
    {
        Event e = Event.current;

        Ray r = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
        Vector3 mousePos = r.origin;
        Vector3 aligned = new Vector3(Mathf.Floor(mousePos.x / grid.width) * grid.width + grid.width / 2.0f,
                                              Mathf.Floor(mousePos.y / grid.height) * grid.height + grid.height / 2.0f, 0.0f);
        Vector3 coords = new Vector3(10 * aligned.x + 100 - .5f, 10 * aligned.y + 50 - .5f,0);

        prefab = materialHolder.Materials[grid.currentMaterial];

        if (e.isKey && e.character == 'a')
        {
            //Debug.Log(materialHolder.Materials[grid.currentMaterial]);
            //Object prefab = EditorUtility.GetPrefabParent(Selection.activeObject);
            //Debug.Log(coords);

            if (prefab)
            {
                if (grid.TerrainBlocks[(int)coords.x,(int)coords.y] == null && (int)coords.x < 200 && (int)coords.x > 0 && (int)coords.y < 100 )
                {
                    obj = (GameObject)PrefabUtility.InstantiatePrefab(prefab);


                    /*Vector3 aligned = new Vector3(Mathf.Floor(mousePos.x / grid.width) * grid.width + grid.width / 2.0f,
                                                  Mathf.Floor(mousePos.y / grid.height) * grid.height + grid.height / 2.0f, 0.0f);*/

                    obj.transform.position = aligned;

                    grid.TerrainBlocks[(int)coords.x,(int)coords.y] = obj;
                    //obj.transform.parent = terrain.transform;
                    Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
                }
            }
        }
        else if (e.isKey && e.character == 'd')
        {
            Undo.IncrementCurrentGroup();            
            Undo.RegisterSceneUndo("Delete Selected Objects");
            foreach (GameObject obj in Selection.gameObjects)
                DestroyImmediate(obj);
        }
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.BeginHorizontal();
        GUILayout.Label(" Grid Width ");
        grid.width = EditorGUILayout.FloatField(grid.width, GUILayout.Width(50));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label(" Grid Height ");
        grid.height = EditorGUILayout.FloatField(grid.height, GUILayout.Width(50));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label(" Sprite ");
        grid.sprite = (Sprite)EditorGUILayout.ObjectField(sprite, typeof(Sprite), allowSceneObjects: true);
        grid.sprite = sprite;
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label(" Selector de material ");
        grid.currentMaterial = GUILayout.Toolbar(grid.currentMaterial, new string[] { "Tierra Normal", "Roca", "Agua", "Comida" });
        GUILayout.EndHorizontal();

        /*if (GUILayout.Button("Open Grid Window", GUILayout.Width(255)))
        {
            TerrainEditorWindow window = (TerrainEditorWindow)EditorWindow.GetWindow(typeof(TerrainEditorWindow));
            window.Init();
        }       */

        SceneView.RepaintAll();
    }
}