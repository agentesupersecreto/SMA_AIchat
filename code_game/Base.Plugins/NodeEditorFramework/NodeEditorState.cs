using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x02000092 RID: 146
	public class NodeEditorState : ScriptableObject
	{
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x0001379F File Offset: 0x0001199F
		public Vector2 zoomPos
		{
			get
			{
				return this.canvasRect.size / 2f;
			}
		}

		// Token: 0x0400010B RID: 267
		public NodeCanvas canvas;

		// Token: 0x0400010C RID: 268
		public NodeEditorState parentEditor;

		// Token: 0x0400010D RID: 269
		public bool drawing = true;

		// Token: 0x0400010E RID: 270
		public Node selectedNode;

		// Token: 0x0400010F RID: 271
		[NonSerialized]
		public Node focusedNode;

		// Token: 0x04000110 RID: 272
		[NonSerialized]
		public bool dragNode;

		// Token: 0x04000111 RID: 273
		[NonSerialized]
		public Node makeTransition;

		// Token: 0x04000112 RID: 274
		[NonSerialized]
		public NodeOutput connectOutput;

		// Token: 0x04000113 RID: 275
		public Vector2 panOffset;

		// Token: 0x04000114 RID: 276
		public float zoom = 1f;

		// Token: 0x04000115 RID: 277
		[NonSerialized]
		public bool navigate;

		// Token: 0x04000116 RID: 278
		[NonSerialized]
		public bool panWindow;

		// Token: 0x04000117 RID: 279
		[NonSerialized]
		public Rect canvasRect;

		// Token: 0x04000118 RID: 280
		[NonSerialized]
		public Vector2 zoomPanAdjust;

		// Token: 0x04000119 RID: 281
		[NonSerialized]
		public List<Rect> ignoreInput = new List<Rect>();
	}
}
