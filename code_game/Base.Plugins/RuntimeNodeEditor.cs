using System;
using System.Collections.Generic;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEngine;

// Token: 0x02000022 RID: 34
public class RuntimeNodeEditor : MonoBehaviour
{
	// Token: 0x0600015A RID: 346 RVA: 0x00008B6B File Offset: 0x00006D6B
	public void Start()
	{
		if (!string.IsNullOrEmpty(this.canvasPath))
		{
			this.LoadNodeCanvas(this.canvasPath);
		}
		else
		{
			this.NewNodeCanvas();
		}
		NodeEditor.initiated = false;
		FPSCounter.Create();
	}

	// Token: 0x0600015B RID: 347 RVA: 0x00008B99 File Offset: 0x00006D99
	public void Update()
	{
		NodeEditor.Update();
		FPSCounter.Update();
	}

	// Token: 0x0600015C RID: 348 RVA: 0x00008BA8 File Offset: 0x00006DA8
	public void OnGUI()
	{
		if (this.canvas != null && this.state != null)
		{
			NodeEditor.checkInit();
			if (NodeEditor.InitiationError)
			{
				GUILayout.Label("Initiation failed! Check console for more information!", Array.Empty<GUILayoutOption>());
				return;
			}
			try
			{
				if (!this.screenSize && this.specifiedRootRect.max != this.specifiedRootRect.min)
				{
					GUI.BeginGroup(this.specifiedRootRect, NodeEditorGUI.nodeSkin.box);
				}
				this.canvasRect = (this.screenSize ? new Rect(0f, 0f, (float)Screen.width, (float)Screen.height) : this.specifiedCanvasRect);
				this.canvasRect.width = this.canvasRect.width - 200f;
				this.state.canvasRect = this.canvasRect;
				NodeEditor.DrawCanvas(this.canvas, this.state);
				this.SideGUI();
				if (!this.screenSize && this.specifiedRootRect.max != this.specifiedRootRect.min)
				{
					GUI.EndGroup();
				}
			}
			catch (Exception ex)
			{
				this.NewNodeCanvas();
				NodeEditor.ReInit(true);
				Debug.LogError("Unloaded Canvas due to exception in Draw!");
				Debug.LogException(ex);
			}
		}
	}

	// Token: 0x0600015D RID: 349 RVA: 0x00008CF8 File Offset: 0x00006EF8
	public void SideGUI()
	{
		GUILayout.BeginArea(new Rect(this.canvasRect.x + this.state.canvasRect.width, this.state.canvasRect.y, 200f, this.state.canvasRect.height), NodeEditorGUI.nodeSkin.box);
		GUILayout.Label(new GUIContent("Node Editor (" + this.canvas.name + ")", "The currently opened canvas in the Node Editor"), Array.Empty<GUILayoutOption>());
		this.screenSize = GUILayout.Toggle(this.screenSize, "Adapt to Screen", Array.Empty<GUILayoutOption>());
		GUILayout.Label("FPS: " + FPSCounter.currentFPS.ToString(), Array.Empty<GUILayoutOption>());
		GUILayout.Label(new GUIContent("Node Editor (" + this.canvas.name + ")"), NodeEditorGUI.nodeLabelBold, Array.Empty<GUILayoutOption>());
		if (GUILayout.Button(new GUIContent("New Canvas", "Loads an empty Canvas"), Array.Empty<GUILayoutOption>()))
		{
			this.NewNodeCanvas();
		}
		if (GUILayout.Button(new GUIContent("Recalculate All", "Initiates complete recalculate. Usually does not need to be triggered manually."), Array.Empty<GUILayoutOption>()))
		{
			NodeEditor.RecalculateAll(this.canvas);
		}
		if (GUILayout.Button("Force Re-Init", Array.Empty<GUILayoutOption>()))
		{
			NodeEditor.ReInit(true);
		}
		NodeEditorGUI.knobSize = RTEditorGUI.IntSlider(new GUIContent("Handle Size", "The size of the Node Input/Output handles"), NodeEditorGUI.knobSize, 12, 20, Array.Empty<GUILayoutOption>());
		this.state.zoom = RTEditorGUI.Slider(new GUIContent("Zoom", "Use the Mousewheel. Seriously."), this.state.zoom, 0.6f, 2f, Array.Empty<GUILayoutOption>());
		GUILayout.EndArea();
	}

	// Token: 0x0600015E RID: 350 RVA: 0x00008EB4 File Offset: 0x000070B4
	public void LoadNodeCanvas(string path)
	{
		this.canvas = NodeEditorSaveManager.LoadNodeCanvas(path);
		if (this.canvas == null)
		{
			this.NewNodeCanvas();
			return;
		}
		List<NodeEditorState> list = NodeEditorSaveManager.LoadEditorStates(path);
		if (list.Count == 0)
		{
			this.state = ScriptableObject.CreateInstance<NodeEditorState>();
		}
		else
		{
			this.state = list.Find((NodeEditorState x) => x.name == "MainEditorState");
			if (this.state == null)
			{
				this.state = list[0];
			}
		}
		this.state.canvas = this.canvas;
		NodeEditor.RecalculateAll(this.canvas);
	}

	// Token: 0x0600015F RID: 351 RVA: 0x00008F60 File Offset: 0x00007160
	public void NewNodeCanvas()
	{
		this.canvas = ScriptableObject.CreateInstance<NodeCanvas>();
		this.state = ScriptableObject.CreateInstance<NodeEditorState>();
		this.state.canvas = this.canvas;
		this.state.name = "MainEditorState";
	}

	// Token: 0x04000042 RID: 66
	public string canvasPath;

	// Token: 0x04000043 RID: 67
	public NodeCanvas canvas;

	// Token: 0x04000044 RID: 68
	private NodeEditorState state;

	// Token: 0x04000045 RID: 69
	public bool screenSize;

	// Token: 0x04000046 RID: 70
	private Rect canvasRect;

	// Token: 0x04000047 RID: 71
	public Rect specifiedRootRect;

	// Token: 0x04000048 RID: 72
	public Rect specifiedCanvasRect;
}
