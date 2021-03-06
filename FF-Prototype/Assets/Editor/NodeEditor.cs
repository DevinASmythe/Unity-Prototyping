﻿using UnityEngine;
using UnityEditor;

public class NodeEditor : EditorWindow
{

    Rect window1,window2,window3;
    

    [MenuItem("Window/Node editor")]
    static void ShowEditor()
    {
        NodeEditor editor = EditorWindow.GetWindow<NodeEditor>();
        editor.Init();
    }

    public void Init()
    {
        window1 = new Rect(10, 10, 100, 100);
        window2 = new Rect(210, 210, 100, 100);
        window3 = new Rect(210, 210, 100, 100);
    }

    void OnGUI()
    {
        DrawNodeCurve(window1, window2); // Here the curve is drawn under the windows
        DrawNodeCurve(window2, window3); // Here the curve is drawn under the windows

        BeginWindows();
        window1 = GUI.Window(1, window1, DrawNodeWindow, "exit");   // Updates the Rect's when these are dragged
        window2 = GUI.Window(2, window2, DrawNodeWindow, "idle");
        window3 = GUI.Window(3, window3, DrawNodeWindow, "init");
        EndWindows();
    }

    void DrawNodeWindow(int id)
    {
        GUI.DragWindow();
    }

    void DrawNodeCurve(Rect start, Rect end)
    {
        Vector3 startPos = new Vector3(start.x + start.width, start.y + start.height / 2, 0);
        Vector3 endPos = new Vector3(end.x, end.y + end.height / 2, 0);
        Vector3 startTan = startPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Color shadowCol = new Color(0, 0, 0, 0.06f);
        for (int i = 0; i < 3; i++) // Draw a shadow
            Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);
        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 1);
    }
}