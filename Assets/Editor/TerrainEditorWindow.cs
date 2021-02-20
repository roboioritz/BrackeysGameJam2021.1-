using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class TerrainEditorWindow : EditorWindow
{
    TerrainEditor grid;
    public Object Materials;

    public void Init()
    {
        grid = (TerrainEditor)FindObjectOfType(typeof(TerrainEditor));
    }

    void OnGUI()
    {
        /*GUILayout.BeginHorizontal();
        GUILayout.Label(" Grid Color ");
        grid.color = EditorGUILayout.ColorField(grid.color, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginScrollView(Vector2.zero);

        GUILayout.EndScrollView();*/
    }
}