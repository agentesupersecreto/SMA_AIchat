using System;
using System.Collections.Generic;
using System.Linq;
using NodeEditorFramework.Utilities;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x02000091 RID: 145
	public static class NodeEditorSaveManager
	{
		// Token: 0x0600044B RID: 1099 RVA: 0x00013150 File Offset: 0x00011350
		private static void UpdateNodeCanvasAsset(NodeCanvas asset, NodeCanvas instance, string path, NodeEditorState[] editorStates)
		{
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00013152 File Offset: 0x00011352
		private static void CreateNodeCanvasAsset(string path, NodeCanvas nodeCanvas, NodeEditorState[] editorStates)
		{
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00013154 File Offset: 0x00011354
		public static void SaveNodeCanvasModded(string path, bool createWorkingCopy, NodeCanvas nodeCanvas, params NodeEditorState[] editorStates)
		{
			if (string.IsNullOrEmpty(path))
			{
				throw new UnityException("Cannot save NodeCanvas: No spath specified to save the NodeCanvas " + ((nodeCanvas != null) ? nodeCanvas.name : "") + " to!");
			}
			if (nodeCanvas == null)
			{
				throw new UnityException("Cannot save NodeCanvas: The specified NodeCanvas that should be saved to path " + path + " is null!");
			}
			for (int i = 0; i < editorStates.Length; i++)
			{
				if (editorStates[i] == null)
				{
					Debug.LogError("A NodeEditorState that should be saved to path " + path + " is null!");
				}
			}
			path = path.Replace(Application.dataPath, "Assets");
			NodeEditorCallbacks.IssueOnSaveCanvas(nodeCanvas);
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x000131FB File Offset: 0x000113FB
		public static void SaveNodeCanvas(string path, NodeCanvas nodeCanvas, params NodeEditorState[] editorStates)
		{
			NodeEditorSaveManager.SaveNodeCanvas(path, true, nodeCanvas, editorStates);
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00013206 File Offset: 0x00011406
		public static void SaveNodeCanvas(string path, bool createWorkingCopy, NodeCanvas nodeCanvas, params NodeEditorState[] editorStates)
		{
			NodeEditorSaveManager.SaveNodeCanvasModded(path, createWorkingCopy, nodeCanvas, editorStates);
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00013211 File Offset: 0x00011411
		public static NodeCanvas LoadNodeCanvas(string path)
		{
			return NodeEditorSaveManager.LoadNodeCanvas(path, true);
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0001321C File Offset: 0x0001141C
		public static NodeCanvas LoadNodeCanvas(string path, bool createWorkingCopy)
		{
			if (string.IsNullOrEmpty(path))
			{
				throw new UnityException("Cannot Load NodeCanvas: No path specified to load the NodeCanvas from!");
			}
			ScriptableObject[] array = ResourceManager.LoadResources<ScriptableObject>(path);
			if (array == null || array.Length == 0)
			{
				throw new UnityException("Cannot Load NodeCanvas: The specified path '" + path + "' does not point to a save file!");
			}
			NodeCanvas nodeCanvas = array.Single((ScriptableObject obj) => obj as NodeCanvas != null) as NodeCanvas;
			if (nodeCanvas == null)
			{
				throw new UnityException("Cannot Load NodeCanvas: The file at the specified path '" + path + "' is no valid save file as it does not contain a NodeCanvas!");
			}
			NodeEditorCallbacks.IssueOnLoadCanvas(nodeCanvas);
			return nodeCanvas;
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x000132AF File Offset: 0x000114AF
		public static List<NodeEditorState> LoadEditorStates(string path)
		{
			return NodeEditorSaveManager.LoadEditorStates(path, true);
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x000132B8 File Offset: 0x000114B8
		public static List<NodeEditorState> LoadEditorStates(string path, bool createWorkingCopy)
		{
			if (string.IsNullOrEmpty(path))
			{
				throw new UnityException("Cannot load NodeEditorStates: No path specified to load the EditorStates from!");
			}
			ScriptableObject[] array = ResourceManager.LoadResources<ScriptableObject>(path);
			if (array == null || array.Length == 0)
			{
				throw new UnityException("Cannot load NodeEditorStates: The specified path '" + path + "' does not point to a save file!");
			}
			List<NodeEditorState> list = array.OfType<NodeEditorState>().ToList<NodeEditorState>();
			foreach (NodeEditorState nodeEditorState in list)
			{
				NodeEditorCallbacks.IssueOnLoadEditorState(nodeEditorState);
			}
			return list;
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00013348 File Offset: 0x00011548
		public static void CreateWorkingCopy(ref NodeEditorState editorState)
		{
			if (editorState == null)
			{
				return;
			}
			editorState = NodeEditorSaveManager.Clone<NodeEditorState>(editorState);
			editorState.focusedNode = null;
			editorState.selectedNode = null;
			editorState.makeTransition = null;
			editorState.connectOutput = null;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0001337E File Offset: 0x0001157E
		public static void CreateWorkingCopy(ref NodeCanvas nodeCanvas, bool compressed)
		{
			NodeEditorSaveManager.CreateWorkingCopy(ref nodeCanvas, null, compressed);
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00013388 File Offset: 0x00011588
		public static void CreateWorkingCopy(ref NodeCanvas nodeCanvas, NodeEditorState[] editorStates, bool compressed)
		{
			nodeCanvas = NodeEditorSaveManager.Clone<NodeCanvas>(nodeCanvas);
			List<ScriptableObject> allSOs = new List<ScriptableObject>();
			List<ScriptableObject> clonedSOs = new List<ScriptableObject>();
			foreach (Node node in nodeCanvas.nodes)
			{
				node.CheckNodeKnobMigration();
				Node node2 = NodeEditorSaveManager.AddClonedSO<Node>(allSOs, clonedSOs, node);
				foreach (NodeKnob nodeKnob in node2.nodeKnobs)
				{
					foreach (ScriptableObject scriptableObject in NodeEditorSaveManager.AddClonedSO<NodeKnob>(allSOs, clonedSOs, nodeKnob).GetScriptableObjects())
					{
						NodeEditorSaveManager.AddClonedSO<ScriptableObject>(allSOs, clonedSOs, scriptableObject);
					}
				}
				foreach (ScriptableObject scriptableObject2 in node2.GetScriptableObjects())
				{
					NodeEditorSaveManager.AddClonedSO<ScriptableObject>(allSOs, clonedSOs, scriptableObject2);
				}
			}
			Func<ScriptableObject, ScriptableObject> <>9__1;
			Func<ScriptableObject, ScriptableObject> <>9__0;
			for (int j = 0; j < nodeCanvas.nodes.Count; j++)
			{
				Node node3 = (nodeCanvas.nodes[j] = NodeEditorSaveManager.ReplaceSO<Node>(allSOs, clonedSOs, nodeCanvas.nodes[j]));
				node3.Inputs = new List<NodeInput>();
				node3.Outputs = new List<NodeOutput>();
				for (int k = 0; k < node3.nodeKnobs.Count; k++)
				{
					NodeKnob nodeKnob2 = (node3.nodeKnobs[k] = NodeEditorSaveManager.ReplaceSO<NodeKnob>(allSOs, clonedSOs, node3.nodeKnobs[k]));
					nodeKnob2.body = node3;
					if (!compressed)
					{
						if (nodeKnob2 is NodeInput)
						{
							node3.Inputs.Add(nodeKnob2 as NodeInput);
						}
						else if (nodeKnob2 is NodeOutput)
						{
							node3.Outputs.Add(nodeKnob2 as NodeOutput);
						}
					}
					NodeKnob nodeKnob3 = nodeKnob2;
					Func<ScriptableObject, ScriptableObject> func;
					if ((func = <>9__1) == null)
					{
						func = (<>9__1 = (ScriptableObject so) => NodeEditorSaveManager.ReplaceSO<ScriptableObject>(allSOs, clonedSOs, so));
					}
					nodeKnob3.CopyScriptableObjects(func);
				}
				Node node4 = node3;
				Func<ScriptableObject, ScriptableObject> func2;
				if ((func2 = <>9__0) == null)
				{
					func2 = (<>9__0 = (ScriptableObject so) => NodeEditorSaveManager.ReplaceSO<ScriptableObject>(allSOs, clonedSOs, so));
				}
				node4.CopyScriptableObjects(func2);
			}
			if (editorStates != null)
			{
				for (int l = 0; l < editorStates.Length; l++)
				{
					if (!(editorStates[l] == null))
					{
						NodeEditorState nodeEditorState = (editorStates[l] = NodeEditorSaveManager.Clone<NodeEditorState>(editorStates[l]));
						nodeEditorState.canvas = nodeCanvas;
						nodeEditorState.focusedNode = null;
						nodeEditorState.selectedNode = ((nodeEditorState.selectedNode != null) ? NodeEditorSaveManager.ReplaceSO<Node>(allSOs, clonedSOs, nodeEditorState.selectedNode) : null);
						nodeEditorState.makeTransition = null;
						nodeEditorState.connectOutput = null;
					}
				}
			}
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x000136B8 File Offset: 0x000118B8
		private static T Clone<T>(T SO) where T : ScriptableObject
		{
			string name = SO.name;
			SO = Object.Instantiate<T>(SO);
			SO.name = name;
			return SO;
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x000136E8 File Offset: 0x000118E8
		private static T AddClonedSO<T>(List<ScriptableObject> scriptableObjects, List<ScriptableObject> clonedScriptableObjects, T initialSO) where T : ScriptableObject
		{
			if (initialSO == null)
			{
				return default(T);
			}
			scriptableObjects.Add(initialSO);
			T t = NodeEditorSaveManager.Clone<T>(initialSO);
			clonedScriptableObjects.Add(t);
			return t;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00013730 File Offset: 0x00011930
		private static T ReplaceSO<T>(List<ScriptableObject> scriptableObjects, List<ScriptableObject> clonedScriptableObjects, T initialSO) where T : ScriptableObject
		{
			if (initialSO == null)
			{
				return default(T);
			}
			int num = scriptableObjects.IndexOf(initialSO);
			if (num == -1)
			{
				Debug.LogError("GetWorkingCopy: ScriptableObject " + initialSO.name + " was not copied before! It will be null!");
			}
			if (num != -1)
			{
				return (T)((object)clonedScriptableObjects[num]);
			}
			return default(T);
		}
	}
}
