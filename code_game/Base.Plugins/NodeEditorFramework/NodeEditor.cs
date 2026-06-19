using System;
using System.Collections.Generic;
using NodeEditorFramework.Utilities;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x0200008D RID: 141
	public static class NodeEditor
	{
		// Token: 0x06000416 RID: 1046 RVA: 0x0001147C File Offset: 0x0000F67C
		public static void Update()
		{
			Action neupdate = NodeEditor.NEUpdate;
			if (neupdate == null)
			{
				return;
			}
			neupdate();
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x0001148D File Offset: 0x0000F68D
		public static void RepaintClients()
		{
			if (NodeEditor.ClientRepaints != null)
			{
				NodeEditor.ClientRepaints();
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x000114A0 File Offset: 0x0000F6A0
		public static void checkInit()
		{
			if (!NodeEditor.initiated && !NodeEditor.InitiationError)
			{
				NodeEditor.ReInit(true);
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000114B8 File Offset: 0x0000F6B8
		public static void ReInit(bool GUIFunction)
		{
			NodeEditor.CheckEditorPath();
			ResourceManager.SetDefaultResourcePath(NodeEditor.editorPath + "Resources/");
			if (!NodeEditorGUI.Init(GUIFunction))
			{
				NodeEditor.InitiationError = true;
				return;
			}
			ConnectionTypes.FetchTypes();
			NodeTypes.FetchNodes();
			NodeEditorCallbacks.SetupReceivers();
			NodeEditorCallbacks.IssueOnEditorStartUp();
			GUIScaleUtility.CheckInit();
			NodeEditor.initiated = true;
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0001150C File Offset: 0x0000F70C
		public static void CheckEditorPath()
		{
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0001150E File Offset: 0x0000F70E
		public static void DrawCanvas(NodeCanvas nodeCanvas, NodeEditorState editorState)
		{
			if (!editorState.drawing)
			{
				return;
			}
			NodeEditor.checkInit();
			NodeEditorGUI.StartNodeGUI();
			OverlayGUI.StartOverlayGUI();
			NodeEditor.DrawSubCanvas(nodeCanvas, editorState);
			OverlayGUI.EndOverlayGUI();
			NodeEditorGUI.EndNodeGUI();
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0001153C File Offset: 0x0000F73C
		public static void DrawSubCanvas(NodeCanvas nodeCanvas, NodeEditorState editorState)
		{
			if (!editorState.drawing)
			{
				return;
			}
			NodeCanvas nodeCanvas2 = NodeEditor.curNodeCanvas;
			NodeEditorState nodeEditorState = NodeEditor.curEditorState;
			NodeEditor.curNodeCanvas = nodeCanvas;
			NodeEditor.curEditorState = editorState;
			if (Event.current.type == EventType.Repaint)
			{
				GUI.BeginClip(NodeEditor.curEditorState.canvasRect);
				float num = (float)NodeEditorGUI.Background.width / NodeEditor.curEditorState.zoom;
				float num2 = (float)NodeEditorGUI.Background.height / NodeEditor.curEditorState.zoom;
				Vector2 vector = NodeEditor.curEditorState.zoomPos + NodeEditor.curEditorState.panOffset / NodeEditor.curEditorState.zoom;
				vector = new Vector2(vector.x % num - num, vector.y % num2 - num2);
				int num3 = Mathf.CeilToInt((NodeEditor.curEditorState.canvasRect.width + (num - vector.x)) / num);
				int num4 = Mathf.CeilToInt((NodeEditor.curEditorState.canvasRect.height + (num2 - vector.y)) / num2);
				for (int i = 0; i < num3; i++)
				{
					for (int j = 0; j < num4; j++)
					{
						GUI.DrawTexture(new Rect(vector.x + (float)i * num, vector.y + (float)j * num2, num, num2), NodeEditorGUI.Background);
					}
				}
				GUI.EndClip();
			}
			NodeEditor.InputEvents();
			if (Event.current.type != EventType.Layout)
			{
				NodeEditor.curEditorState.ignoreInput = new List<Rect>();
			}
			Rect canvasRect = NodeEditor.curEditorState.canvasRect;
			NodeEditor.curEditorState.zoomPanAdjust = GUIScaleUtility.BeginScale(ref canvasRect, NodeEditor.curEditorState.zoomPos, NodeEditor.curEditorState.zoom, false);
			if (NodeEditor.curEditorState.navigate)
			{
				RTEditorGUI.DrawLine(((NodeEditor.curEditorState.selectedNode != null) ? NodeEditor.curEditorState.selectedNode.rect.center : NodeEditor.curEditorState.panOffset) + NodeEditor.curEditorState.zoomPanAdjust, NodeEditor.ScreenToGUIPos(NodeEditor.mousePos) + NodeEditor.curEditorState.zoomPos * NodeEditor.curEditorState.zoom, Color.black, null, 3f);
				NodeEditor.RepaintClients();
			}
			if (NodeEditor.curEditorState.connectOutput != null)
			{
				NodeOutput connectOutput = NodeEditor.curEditorState.connectOutput;
				Vector2 center = connectOutput.GetGUIKnob().center;
				Vector2 vector2 = NodeEditor.ScreenToGUIPos(NodeEditor.mousePos) + NodeEditor.curEditorState.zoomPos * NodeEditor.curEditorState.zoom;
				Vector2 direction = connectOutput.GetDirection();
				NodeEditorGUI.DrawConnection(center, direction, vector2, NodeEditorGUI.GetSecondConnectionVector(center, vector2, direction), ConnectionTypes.GetTypeData(connectOutput.type, true).Color);
				NodeEditor.RepaintClients();
			}
			if (NodeEditor.curEditorState.makeTransition != null)
			{
				RTEditorGUI.DrawLine(NodeEditor.curEditorState.makeTransition.rect.center + NodeEditor.curEditorState.zoomPanAdjust, NodeEditor.ScreenToGUIPos(NodeEditor.mousePos) + NodeEditor.curEditorState.zoomPos * NodeEditor.curEditorState.zoom, Color.grey, null, 3f);
				NodeEditor.RepaintClients();
			}
			if (Event.current.type == EventType.Layout && NodeEditor.curEditorState.selectedNode != null)
			{
				NodeEditor.curNodeCanvas.nodes.Remove(NodeEditor.curEditorState.selectedNode);
				NodeEditor.curNodeCanvas.nodes.Add(NodeEditor.curEditorState.selectedNode);
			}
			foreach (Node node in NodeEditor.curNodeCanvas.nodes)
			{
				if (node != null)
				{
					node.DrawConnections();
				}
			}
			foreach (Node node2 in NodeEditor.curNodeCanvas.nodes)
			{
				if (node2 != null)
				{
					node2.DrawNode();
					if (Event.current.type == EventType.Repaint)
					{
						node2.DrawKnobs();
					}
				}
			}
			GUIScaleUtility.EndScale();
			NodeEditor.LateEvents();
			NodeEditor.curNodeCanvas = nodeCanvas2;
			NodeEditor.curEditorState = nodeEditorState;
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x000119A0 File Offset: 0x0000FBA0
		public static Node NodeAtPosition(Vector2 pos)
		{
			return NodeEditor.NodeAtPosition(NodeEditor.curEditorState, NodeEditor.curNodeCanvas, pos);
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x000119B4 File Offset: 0x0000FBB4
		public static Node NodeAtPosition(NodeEditorState editorState, NodeCanvas nodeCanvas, Vector2 pos)
		{
			if (!editorState.canvasRect.Contains(pos))
			{
				return null;
			}
			for (int i = nodeCanvas.nodes.Count - 1; i >= 0; i--)
			{
				Node node = nodeCanvas.nodes[i];
				if (NodeEditor.CanvasGUIToScreenRect(node.rect).Contains(pos))
				{
					return node;
				}
				using (List<NodeKnob>.Enumerator enumerator = node.nodeKnobs.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.GetScreenKnob().Contains(pos))
						{
							return node;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00011A68 File Offset: 0x0000FC68
		public static Rect CanvasGUIToScreenRect(Rect rect)
		{
			return NodeEditor.CanvasGUIToScreenRect(NodeEditor.curEditorState, rect);
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00011A78 File Offset: 0x0000FC78
		public static Rect CanvasGUIToScreenRect(NodeEditorState editorState, Rect rect)
		{
			rect.position += editorState.zoomPos;
			rect = GUIScaleUtility.ScaleRect(rect, editorState.zoomPos, (editorState.parentEditor != null) ? new Vector2(1f / (editorState.parentEditor.zoom * editorState.zoom), 1f / (editorState.parentEditor.zoom * editorState.zoom)) : new Vector2(1f / editorState.zoom, 1f / editorState.zoom));
			rect.position += editorState.canvasRect.position;
			return rect;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00011B2B File Offset: 0x0000FD2B
		public static Vector2 ScreenToGUIPos(Vector2 pos)
		{
			return NodeEditor.ScreenToGUIPos(NodeEditor.curEditorState, pos);
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00011B38 File Offset: 0x0000FD38
		public static Vector2 ScreenToGUIPos(NodeEditorState editorState, Vector2 pos)
		{
			return Vector2.Scale(pos - editorState.zoomPos - editorState.canvasRect.position, new Vector2(editorState.zoom, editorState.zoom));
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00011B6C File Offset: 0x0000FD6C
		private static bool ignoreInput(Vector2 mousePos)
		{
			if (OverlayGUI.HasPopupControl())
			{
				return true;
			}
			if (!NodeEditor.curEditorState.canvasRect.Contains(mousePos))
			{
				return true;
			}
			foreach (Rect rect in NodeEditor.curEditorState.ignoreInput)
			{
				if (rect.Contains(mousePos))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00011BEC File Offset: 0x0000FDEC
		public static void InputEvents()
		{
			Event current = Event.current;
			NodeEditor.mousePos = current.mousePosition;
			bool flag = current.button == 0;
			bool flag2 = current.button == 1;
			bool flag3 = current.type == EventType.MouseDown;
			bool flag4 = current.type == EventType.MouseUp;
			if (NodeEditor.ignoreInput(NodeEditor.mousePos))
			{
				return;
			}
			NodeEditor.curEditorState.focusedNode = null;
			if (flag3 || flag4)
			{
				NodeEditor.curEditorState.focusedNode = NodeEditor.NodeAtPosition(NodeEditor.mousePos);
				if (NodeEditor.curEditorState.focusedNode != NodeEditor.curEditorState.selectedNode)
				{
					NodeEditor.unfocusControls = true;
				}
				if (flag3 && flag)
				{
					NodeEditor.curEditorState.selectedNode = NodeEditor.curEditorState.focusedNode;
					NodeEditor.RepaintClients();
				}
			}
			if (NodeEditor.unfocusControls && Event.current.type == EventType.Repaint)
			{
				GUIUtility.hotControl = 0;
				GUIUtility.keyboardControl = 0;
				NodeEditor.unfocusControls = false;
			}
			switch (current.type)
			{
			case EventType.MouseDown:
				NodeEditor.curEditorState.dragNode = false;
				NodeEditor.curEditorState.panWindow = false;
				if (NodeEditor.curEditorState.focusedNode != null)
				{
					if (flag2)
					{
						GenericMenu genericMenu = new GenericMenu();
						genericMenu.AddItem(new GUIContent("Delete Node"), false, new PopupMenu.MenuFunctionData(NodeEditor.ContextCallback), new NodeEditor.NodeEditorMenuCallback("deleteNode", NodeEditor.curNodeCanvas, NodeEditor.curEditorState));
						genericMenu.AddItem(new GUIContent("Duplicate Node"), false, new PopupMenu.MenuFunctionData(NodeEditor.ContextCallback), new NodeEditor.NodeEditorMenuCallback("duplicateNode", NodeEditor.curNodeCanvas, NodeEditor.curEditorState));
						if (NodeEditor.curEditorState.focusedNode.AcceptsTranstitions)
						{
							genericMenu.AddSeparator("Seperator");
							genericMenu.AddItem(new GUIContent("Make Transition"), false, new PopupMenu.MenuFunctionData(NodeEditor.ContextCallback), new NodeEditor.NodeEditorMenuCallback("startTransition", NodeEditor.curNodeCanvas, NodeEditor.curEditorState));
						}
						genericMenu.ShowAsContext();
						current.Use();
						return;
					}
					if (flag && !NodeEditor.CanvasGUIToScreenRect(NodeEditor.curEditorState.focusedNode.rect).Contains(NodeEditor.mousePos))
					{
						NodeOutput outputAtPos = NodeEditor.curEditorState.focusedNode.GetOutputAtPos(current.mousePosition);
						if (outputAtPos != null)
						{
							NodeEditor.curEditorState.connectOutput = outputAtPos;
							current.Use();
							return;
						}
						NodeInput inputAtPos = NodeEditor.curEditorState.focusedNode.GetInputAtPos(current.mousePosition);
						if (inputAtPos != null && inputAtPos.connection != null)
						{
							NodeEditor.curEditorState.connectOutput = inputAtPos.connection;
							inputAtPos.RemoveConnection();
							current.Use();
							return;
						}
					}
				}
				else if (flag2)
				{
					GenericMenu genericMenu2 = new GenericMenu();
					if (NodeEditor.curEditorState.connectOutput != null)
					{
						using (Dictionary<Node, NodeData>.KeyCollection.Enumerator enumerator = NodeTypes.nodes.Keys.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								Node node = enumerator.Current;
								using (List<NodeInput>.Enumerator enumerator2 = node.Inputs.GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										if (enumerator2.Current.type == NodeEditor.curEditorState.connectOutput.type)
										{
											genericMenu2.AddItem(new GUIContent("Add " + NodeTypes.nodes[node].adress), false, new PopupMenu.MenuFunctionData(NodeEditor.ContextCallback), new NodeEditor.NodeEditorMenuCallback(node.GetID, NodeEditor.curNodeCanvas, NodeEditor.curEditorState));
											break;
										}
									}
								}
							}
							goto IL_04D6;
						}
					}
					if (NodeEditor.curEditorState.makeTransition != null && NodeEditor.curEditorState.makeTransition.AcceptsTranstitions)
					{
						using (Dictionary<Node, NodeData>.KeyCollection.Enumerator enumerator = NodeTypes.nodes.Keys.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								Node node2 = enumerator.Current;
								if (node2.AcceptsTranstitions)
								{
									genericMenu2.AddItem(new GUIContent("Add " + NodeTypes.nodes[node2].adress), false, new PopupMenu.MenuFunctionData(NodeEditor.ContextCallback), new NodeEditor.NodeEditorMenuCallback(node2.GetID, NodeEditor.curNodeCanvas, NodeEditor.curEditorState));
								}
							}
							goto IL_04D6;
						}
					}
					foreach (Node node3 in NodeTypes.nodes.Keys)
					{
						genericMenu2.AddItem(new GUIContent("Add " + NodeTypes.nodes[node3].adress), false, new PopupMenu.MenuFunctionData(NodeEditor.ContextCallback), new NodeEditor.NodeEditorMenuCallback(node3.GetID, NodeEditor.curNodeCanvas, NodeEditor.curEditorState));
					}
					IL_04D6:
					genericMenu2.ShowAsContext();
					current.Use();
					return;
				}
				break;
			case EventType.MouseUp:
				if (NodeEditor.curEditorState.focusedNode != null && NodeEditor.curEditorState.connectOutput != null)
				{
					if (!NodeEditor.curEditorState.focusedNode.Outputs.Contains(NodeEditor.curEditorState.connectOutput))
					{
						NodeInput inputAtPos2 = NodeEditor.curEditorState.focusedNode.GetInputAtPos(current.mousePosition);
						if (inputAtPos2 && inputAtPos2.CanApplyConnection(NodeEditor.curEditorState.connectOutput))
						{
							inputAtPos2.ApplyConnection(NodeEditor.curEditorState.connectOutput);
						}
					}
					current.Use();
				}
				NodeEditor.curEditorState.makeTransition = null;
				NodeEditor.curEditorState.connectOutput = null;
				NodeEditor.curEditorState.dragNode = false;
				NodeEditor.curEditorState.panWindow = false;
				return;
			case EventType.MouseMove:
				break;
			case EventType.MouseDrag:
				if (NodeEditor.curEditorState.panWindow)
				{
					NodeEditor.curEditorState.panOffset += current.delta * NodeEditor.curEditorState.zoom;
					foreach (Node node4 in NodeEditor.curNodeCanvas.nodes)
					{
						node4.rect.position = node4.rect.position + current.delta * NodeEditor.curEditorState.zoom;
					}
					current.delta = Vector2.zero;
					NodeEditor.RepaintClients();
				}
				if (NodeEditor.curEditorState.dragNode && NodeEditor.curEditorState.selectedNode != null && GUIUtility.hotControl == 0)
				{
					Node selectedNode = NodeEditor.curEditorState.selectedNode;
					selectedNode.rect.position = selectedNode.rect.position + current.delta * NodeEditor.curEditorState.zoom;
					NodeEditorCallbacks.IssueOnMoveNode(NodeEditor.curEditorState.selectedNode);
					current.delta = Vector2.zero;
					NodeEditor.RepaintClients();
					return;
				}
				NodeEditor.curEditorState.dragNode = false;
				break;
			case EventType.KeyDown:
				if (current.keyCode == KeyCode.N)
				{
					NodeEditor.curEditorState.navigate = true;
				}
				if (current.keyCode == KeyCode.LeftControl && NodeEditor.curEditorState.selectedNode != null)
				{
					Vector2 vector = NodeEditor.curEditorState.selectedNode.rect.position;
					vector = (vector - NodeEditor.curEditorState.panOffset) / 10f;
					vector = new Vector2((float)Mathf.RoundToInt(vector.x), (float)Mathf.RoundToInt(vector.y));
					NodeEditor.curEditorState.selectedNode.rect.position = vector * 10f + NodeEditor.curEditorState.panOffset;
				}
				NodeEditor.RepaintClients();
				return;
			case EventType.KeyUp:
				if (current.keyCode == KeyCode.N)
				{
					NodeEditor.curEditorState.navigate = false;
				}
				NodeEditor.RepaintClients();
				return;
			case EventType.ScrollWheel:
				NodeEditor.curEditorState.zoom = (float)Math.Round((double)Math.Min(2f, Math.Max(0.6f, NodeEditor.curEditorState.zoom + current.delta.y / 15f)), 2);
				NodeEditor.RepaintClients();
				return;
			default:
				return;
			}
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00012428 File Offset: 0x00010628
		public static void LateEvents()
		{
			Event current = Event.current;
			if (NodeEditor.ignoreInput(NodeEditor.mousePos))
			{
				return;
			}
			if (current.type == EventType.MouseDown && current.button == 0 && GUIUtility.hotControl <= 0)
			{
				if (NodeEditor.curEditorState.selectedNode != null && NodeEditor.CanvasGUIToScreenRect(NodeEditor.curEditorState.selectedNode.rect).Contains(current.mousePosition))
				{
					NodeEditor.curEditorState.dragNode = true;
					current.delta = Vector2.zero;
					NodeEditor.RepaintClients();
					return;
				}
				if (NodeEditor.curEditorState.focusedNode == null && (current.button == 0 || current.button == 2))
				{
					NodeEditor.curEditorState.panWindow = true;
					current.delta = Vector2.zero;
				}
			}
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x000124F4 File Offset: 0x000106F4
		public static void ContextCallback(object obj)
		{
			NodeEditor.NodeEditorMenuCallback nodeEditorMenuCallback = obj as NodeEditor.NodeEditorMenuCallback;
			if (nodeEditorMenuCallback == null)
			{
				throw new UnityException("Callback Object passed by context is not of type NodeEditorMenuCallback!");
			}
			NodeEditor.curNodeCanvas = nodeEditorMenuCallback.canvas;
			NodeEditor.curEditorState = nodeEditorMenuCallback.editor;
			string message = nodeEditorMenuCallback.message;
			if (!(message == "deleteNode"))
			{
				if (!(message == "duplicateNode"))
				{
					if (!(message == "startTransition"))
					{
						Node node = Node.Create(nodeEditorMenuCallback.message, NodeEditor.ScreenToGUIPos(nodeEditorMenuCallback.contextClickPos));
						if (NodeEditor.curEditorState.connectOutput != null)
						{
							foreach (NodeInput nodeInput in node.Inputs)
							{
								if (nodeInput.CanApplyConnection(NodeEditor.curEditorState.connectOutput))
								{
									nodeInput.ApplyConnection(NodeEditor.curEditorState.connectOutput);
									break;
								}
							}
						}
						NodeEditor.curEditorState.makeTransition = null;
						NodeEditor.curEditorState.connectOutput = null;
						NodeEditor.curEditorState.dragNode = false;
						NodeEditor.curEditorState.panWindow = false;
					}
					else
					{
						if (NodeEditor.curEditorState.focusedNode != null)
						{
							NodeEditor.curEditorState.makeTransition = NodeEditor.curEditorState.focusedNode;
							NodeEditor.curEditorState.connectOutput = null;
						}
						NodeEditor.curEditorState.dragNode = false;
						NodeEditor.curEditorState.panWindow = false;
					}
				}
				else if (NodeEditor.curEditorState.focusedNode != null)
				{
					NodeEditor.ContextCallback(new NodeEditor.NodeEditorMenuCallback(NodeEditor.curEditorState.focusedNode.GetID, NodeEditor.curNodeCanvas, NodeEditor.curEditorState));
					Node node2 = NodeEditor.curNodeCanvas.nodes[NodeEditor.curNodeCanvas.nodes.Count - 1];
					NodeEditor.curEditorState.focusedNode = node2;
					NodeEditor.curEditorState.dragNode = true;
					NodeEditor.curEditorState.makeTransition = null;
					NodeEditor.curEditorState.connectOutput = null;
					NodeEditor.curEditorState.panWindow = false;
				}
			}
			else if (NodeEditor.curEditorState.focusedNode != null)
			{
				NodeEditor.curEditorState.focusedNode.Delete();
			}
			NodeEditor.RepaintClients();
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00012730 File Offset: 0x00010930
		public static void RecalculateAll(NodeCanvas nodeCanvas)
		{
			NodeEditor.workList = new List<Node>();
			foreach (Node node in nodeCanvas.nodes)
			{
				if (node.isInput())
				{
					node.ClearCalculation();
					NodeEditor.workList.Add(node);
				}
			}
			NodeEditor.StartCalculation();
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x000127A4 File Offset: 0x000109A4
		public static void RecalculateFrom(Node node)
		{
			node.ClearCalculation();
			NodeEditor.workList = new List<Node> { node };
			NodeEditor.StartCalculation();
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x000127C4 File Offset: 0x000109C4
		public static void StartCalculation()
		{
			if (NodeEditor.workList == null || NodeEditor.workList.Count == 0)
			{
				return;
			}
			NodeEditor.calculationCount = 0;
			bool flag = false;
			int num = 0;
			while (!flag)
			{
				flag = true;
				for (int i = 0; i < NodeEditor.workList.Count; i++)
				{
					if (NodeEditor.ContinueCalculation(NodeEditor.workList[i]))
					{
						flag = false;
					}
				}
				if (num > 1000)
				{
					flag = true;
				}
				num++;
			}
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00012830 File Offset: 0x00010A30
		public static bool ContinueCalculation(Node node)
		{
			if (node.calculated)
			{
				return false;
			}
			if ((node.descendantsCalculated() || node.isInLoop()) && node.Calculate())
			{
				node.calculated = true;
				NodeEditor.calculationCount++;
				NodeEditor.workList.Remove(node);
				if (node.ContinueCalculation && NodeEditor.calculationCount < 1000)
				{
					using (List<NodeOutput>.Enumerator enumerator = node.Outputs.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							NodeOutput nodeOutput = enumerator.Current;
							foreach (NodeInput nodeInput in nodeOutput.connections)
							{
								NodeEditor.ContinueCalculation(nodeInput.body);
							}
						}
						return true;
					}
				}
				if (NodeEditor.calculationCount >= 1000)
				{
					Debug.LogError("Stopped calculation because of suspected Recursion. Maximum calculation iteration is currently at 1000!");
				}
				return true;
			}
			if (!NodeEditor.workList.Contains(node))
			{
				NodeEditor.workList.Add(node);
			}
			return false;
		}

		// Token: 0x040000E5 RID: 229
		public static string editorPath = "Assets/Plugins/Node_Editor/";

		// Token: 0x040000E6 RID: 230
		public static NodeCanvas curNodeCanvas;

		// Token: 0x040000E7 RID: 231
		public static NodeEditorState curEditorState;

		// Token: 0x040000E8 RID: 232
		private static bool unfocusControls;

		// Token: 0x040000E9 RID: 233
		private static Vector2 mousePos;

		// Token: 0x040000EA RID: 234
		internal static Action NEUpdate = null;

		// Token: 0x040000EB RID: 235
		public static Action ClientRepaints;

		// Token: 0x040000EC RID: 236
		public static bool initiated;

		// Token: 0x040000ED RID: 237
		public static bool InitiationError;

		// Token: 0x040000EE RID: 238
		public static List<Node> workList;

		// Token: 0x040000EF RID: 239
		private static int calculationCount;

		// Token: 0x020001B5 RID: 437
		public class NodeEditorMenuCallback
		{
			// Token: 0x06000C21 RID: 3105 RVA: 0x000267B3 File Offset: 0x000249B3
			public NodeEditorMenuCallback(string Message, NodeCanvas nodecanvas, NodeEditorState editorState)
			{
				this.message = Message;
				this.canvas = nodecanvas;
				this.editor = editorState;
				this.contextClickPos = Event.current.mousePosition;
			}

			// Token: 0x04000411 RID: 1041
			public string message;

			// Token: 0x04000412 RID: 1042
			public NodeCanvas canvas;

			// Token: 0x04000413 RID: 1043
			public NodeEditorState editor;

			// Token: 0x04000414 RID: 1044
			public Vector2 contextClickPos;
		}
	}
}
