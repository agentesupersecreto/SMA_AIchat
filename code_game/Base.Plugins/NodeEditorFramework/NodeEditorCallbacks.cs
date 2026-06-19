using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x0200008F RID: 143
	public static class NodeEditorCallbacks
	{
		// Token: 0x06000437 RID: 1079 RVA: 0x0001297A File Offset: 0x00010B7A
		public static void SetupReceivers()
		{
			NodeEditorCallbacks.callbackReceiver = new List<NodeEditorCallbackReceiver>(Object.FindObjectsOfType<NodeEditorCallbackReceiver>());
			NodeEditorCallbacks.receiverCount = NodeEditorCallbacks.callbackReceiver.Count;
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x0001299C File Offset: 0x00010B9C
		public static void IssueOnEditorStartUp()
		{
			if (NodeEditorCallbacks.OnEditorStartUp != null)
			{
				NodeEditorCallbacks.OnEditorStartUp();
			}
			for (int i = 0; i < NodeEditorCallbacks.receiverCount; i++)
			{
				if (NodeEditorCallbacks.callbackReceiver[i] == null)
				{
					NodeEditorCallbacks.callbackReceiver.RemoveAt(i--);
				}
				else
				{
					NodeEditorCallbacks.callbackReceiver[i].OnEditorStartUp();
				}
			}
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00012A00 File Offset: 0x00010C00
		public static void IssueOnLoadCanvas(NodeCanvas canvas)
		{
			if (NodeEditorCallbacks.OnLoadCanvas != null)
			{
				NodeEditorCallbacks.OnLoadCanvas(canvas);
			}
			for (int i = 0; i < NodeEditorCallbacks.receiverCount; i++)
			{
				if (NodeEditorCallbacks.callbackReceiver[i] == null)
				{
					NodeEditorCallbacks.callbackReceiver.RemoveAt(i--);
				}
				else
				{
					NodeEditorCallbacks.callbackReceiver[i].OnLoadCanvas(canvas);
				}
			}
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00012A64 File Offset: 0x00010C64
		public static void IssueOnLoadEditorState(NodeEditorState editorState)
		{
			if (NodeEditorCallbacks.OnLoadEditorState != null)
			{
				NodeEditorCallbacks.OnLoadEditorState(editorState);
			}
			for (int i = 0; i < NodeEditorCallbacks.receiverCount; i++)
			{
				if (NodeEditorCallbacks.callbackReceiver[i] == null)
				{
					NodeEditorCallbacks.callbackReceiver.RemoveAt(i--);
				}
				else
				{
					NodeEditorCallbacks.callbackReceiver[i].OnLoadEditorState(editorState);
				}
			}
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00012AC8 File Offset: 0x00010CC8
		public static void IssueOnSaveCanvas(NodeCanvas canvas)
		{
			if (NodeEditorCallbacks.OnSaveCanvas != null)
			{
				NodeEditorCallbacks.OnSaveCanvas(canvas);
			}
			for (int i = 0; i < NodeEditorCallbacks.receiverCount; i++)
			{
				if (NodeEditorCallbacks.callbackReceiver[i] == null)
				{
					NodeEditorCallbacks.callbackReceiver.RemoveAt(i--);
				}
				else
				{
					NodeEditorCallbacks.callbackReceiver[i].OnSaveCanvas(canvas);
				}
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00012B2C File Offset: 0x00010D2C
		public static void IssueOnSaveEditorState(NodeEditorState editorState)
		{
			if (NodeEditorCallbacks.OnSaveEditorState != null)
			{
				NodeEditorCallbacks.OnSaveEditorState(editorState);
			}
			for (int i = 0; i < NodeEditorCallbacks.receiverCount; i++)
			{
				if (NodeEditorCallbacks.callbackReceiver[i] == null)
				{
					NodeEditorCallbacks.callbackReceiver.RemoveAt(i--);
				}
				else
				{
					NodeEditorCallbacks.callbackReceiver[i].OnSaveEditorState(editorState);
				}
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00012B90 File Offset: 0x00010D90
		public static void IssueOnAddNode(Node node)
		{
			if (NodeEditorCallbacks.OnAddNode != null)
			{
				NodeEditorCallbacks.OnAddNode(node);
			}
			for (int i = 0; i < NodeEditorCallbacks.receiverCount; i++)
			{
				if (NodeEditorCallbacks.callbackReceiver[i] == null)
				{
					NodeEditorCallbacks.callbackReceiver.RemoveAt(i--);
				}
				else
				{
					NodeEditorCallbacks.callbackReceiver[i].OnAddNode(node);
				}
			}
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00012BF4 File Offset: 0x00010DF4
		public static void IssueOnDeleteNode(Node node)
		{
			if (NodeEditorCallbacks.OnDeleteNode != null)
			{
				NodeEditorCallbacks.OnDeleteNode(node);
			}
			for (int i = 0; i < NodeEditorCallbacks.receiverCount; i++)
			{
				if (NodeEditorCallbacks.callbackReceiver[i] == null)
				{
					NodeEditorCallbacks.callbackReceiver.RemoveAt(i--);
				}
				else
				{
					NodeEditorCallbacks.callbackReceiver[i].OnDeleteNode(node);
					node.OnDelete();
				}
			}
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00012C60 File Offset: 0x00010E60
		public static void IssueOnMoveNode(Node node)
		{
			if (NodeEditorCallbacks.OnMoveNode != null)
			{
				NodeEditorCallbacks.OnMoveNode(node);
			}
			for (int i = 0; i < NodeEditorCallbacks.receiverCount; i++)
			{
				if (NodeEditorCallbacks.callbackReceiver[i] == null)
				{
					NodeEditorCallbacks.callbackReceiver.RemoveAt(i--);
				}
				else
				{
					NodeEditorCallbacks.callbackReceiver[i].OnMoveNode(node);
				}
			}
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00012CC4 File Offset: 0x00010EC4
		public static void IssueOnAddConnection(NodeInput input)
		{
			if (NodeEditorCallbacks.OnAddConnection != null)
			{
				NodeEditorCallbacks.OnAddConnection(input);
			}
			for (int i = 0; i < NodeEditorCallbacks.receiverCount; i++)
			{
				if (NodeEditorCallbacks.callbackReceiver[i] == null)
				{
					NodeEditorCallbacks.callbackReceiver.RemoveAt(i--);
				}
				else
				{
					NodeEditorCallbacks.callbackReceiver[i].OnAddConnection(input);
				}
			}
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00012D28 File Offset: 0x00010F28
		public static void IssueOnRemoveConnection(NodeInput input)
		{
			if (NodeEditorCallbacks.OnRemoveConnection != null)
			{
				NodeEditorCallbacks.OnRemoveConnection(input);
			}
			for (int i = 0; i < NodeEditorCallbacks.receiverCount; i++)
			{
				if (NodeEditorCallbacks.callbackReceiver[i] == null)
				{
					NodeEditorCallbacks.callbackReceiver.RemoveAt(i--);
				}
				else
				{
					NodeEditorCallbacks.callbackReceiver[i].OnRemoveConnection(input);
				}
			}
		}

		// Token: 0x040000F0 RID: 240
		private static int receiverCount;

		// Token: 0x040000F1 RID: 241
		private static List<NodeEditorCallbackReceiver> callbackReceiver;

		// Token: 0x040000F2 RID: 242
		public static Action OnEditorStartUp;

		// Token: 0x040000F3 RID: 243
		public static Action<NodeCanvas> OnLoadCanvas;

		// Token: 0x040000F4 RID: 244
		public static Action<NodeEditorState> OnLoadEditorState;

		// Token: 0x040000F5 RID: 245
		public static Action<NodeCanvas> OnSaveCanvas;

		// Token: 0x040000F6 RID: 246
		public static Action<NodeEditorState> OnSaveEditorState;

		// Token: 0x040000F7 RID: 247
		public static Action<Node> OnAddNode;

		// Token: 0x040000F8 RID: 248
		public static Action<Node> OnDeleteNode;

		// Token: 0x040000F9 RID: 249
		public static Action<Node> OnMoveNode;

		// Token: 0x040000FA RID: 250
		public static Action<NodeInput> OnAddConnection;

		// Token: 0x040000FB RID: 251
		public static Action<NodeInput> OnRemoveConnection;
	}
}
