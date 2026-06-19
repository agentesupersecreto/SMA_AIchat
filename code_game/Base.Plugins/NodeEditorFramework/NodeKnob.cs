using System;
using System.Linq;
using NodeEditorFramework.Utilities;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x02000095 RID: 149
	[Serializable]
	public class NodeKnob : ScriptableObject
	{
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x00013A14 File Offset: 0x00011C14
		protected virtual GUIStyle defaultLabelStyle
		{
			get
			{
				return GUI.skin.label;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600046A RID: 1130 RVA: 0x00013A20 File Offset: 0x00011C20
		protected virtual NodeSide defaultSide
		{
			get
			{
				return NodeSide.Right;
			}
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00013A23 File Offset: 0x00011C23
		protected void InitBase(Node nodeBody, NodeSide nodeSide, float nodeSidePosition, string knobName)
		{
			this.body = nodeBody;
			this.side = nodeSide;
			this.sidePosition = nodeSidePosition;
			base.name = knobName;
			nodeBody.nodeKnobs.Add(this);
			this.ReloadKnobTexture();
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00013A54 File Offset: 0x00011C54
		internal void Check()
		{
			if (this.side == (NodeSide)0)
			{
				this.side = this.defaultSide;
			}
			if (this.knobTexture == null)
			{
				this.ReloadKnobTexture();
			}
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00013A80 File Offset: 0x00011C80
		protected void ReloadKnobTexture()
		{
			this.ReloadTexture();
			if (this.knobTexture == null)
			{
				throw new UnityException("Knob texture could not be loaded!");
			}
			if (this.side != this.defaultSide)
			{
				ResourceManager.SetDefaultResourcePath(NodeEditor.editorPath + "Resources/");
				int rotationStepsAntiCW = NodeKnob.getRotationStepsAntiCW(this.defaultSide, this.side);
				ResourceManager.MemoryTexture memoryTexture = ResourceManager.FindInMemory(this.knobTexture);
				if (memoryTexture != null)
				{
					string[] array = new string[memoryTexture.modifications.Length + 1];
					memoryTexture.modifications.CopyTo(array, 0);
					array[array.Length - 1] = "Rotation:" + rotationStepsAntiCW.ToString();
					Texture2D texture = ResourceManager.GetTexture(memoryTexture.path, array);
					if (texture != null)
					{
						this.knobTexture = texture;
						return;
					}
					this.knobTexture = RTEditorGUI.RotateTextureCCW(this.knobTexture, rotationStepsAntiCW);
					ResourceManager.AddTextureToMemory(memoryTexture.path, this.knobTexture, array.ToArray<string>());
					return;
				}
				else
				{
					this.knobTexture = RTEditorGUI.RotateTextureCCW(this.knobTexture, rotationStepsAntiCW);
				}
			}
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00013B81 File Offset: 0x00011D81
		protected virtual void ReloadTexture()
		{
			this.knobTexture = RTEditorGUI.ColorToTex(1, Color.red);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00013B94 File Offset: 0x00011D94
		protected internal virtual ScriptableObject[] GetScriptableObjects()
		{
			return new ScriptableObject[0];
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00013B9C File Offset: 0x00011D9C
		protected internal virtual void CopyScriptableObjects(Func<ScriptableObject, ScriptableObject> replaceSerializableObject)
		{
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00013B9E File Offset: 0x00011D9E
		public virtual void DrawKnob()
		{
			GUI.DrawTexture(this.GetGUIKnob(), this.knobTexture);
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00013BB1 File Offset: 0x00011DB1
		public void DisplayLayout()
		{
			this.DisplayLayout(new GUIContent(base.name), this.defaultLabelStyle);
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00013BCA File Offset: 0x00011DCA
		public void DisplayLayout(GUIStyle style)
		{
			this.DisplayLayout(new GUIContent(base.name), style);
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x00013BDE File Offset: 0x00011DDE
		public void DisplayLayout(GUIContent content)
		{
			this.DisplayLayout(content, this.defaultLabelStyle);
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00013BED File Offset: 0x00011DED
		public void DisplayLayout(GUIContent content, GUIStyle style)
		{
			GUILayout.Label(content, style, Array.Empty<GUILayoutOption>());
			if (Event.current.type == EventType.Repaint)
			{
				this.SetPosition();
			}
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00013C0E File Offset: 0x00011E0E
		public void SetPosition(float position, NodeSide nodeSide)
		{
			if (this.side != nodeSide)
			{
				this.side = nodeSide;
				this.ReloadKnobTexture();
			}
			this.SetPosition(position);
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00013C2D File Offset: 0x00011E2D
		public void SetPosition(float position)
		{
			this.sidePosition = position;
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00013C38 File Offset: 0x00011E38
		public void SetPosition()
		{
			Vector2 vector = GUILayoutUtility.GetLastRect().center + this.body.contentOffset;
			this.sidePosition = ((this.side == NodeSide.Bottom || this.side == NodeSide.Top) ? vector.x : vector.y);
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00013C8C File Offset: 0x00011E8C
		public Rect GetGUIKnob()
		{
			this.Check();
			Vector2 vector = new Vector2((float)(this.knobTexture.width / this.knobTexture.height * NodeEditorGUI.knobSize), (float)(this.knobTexture.height / this.knobTexture.width * NodeEditorGUI.knobSize));
			Vector2 vector2 = new Vector2(this.body.rect.x + ((this.side == NodeSide.Bottom || this.side == NodeSide.Top) ? this.sidePosition : ((this.side == NodeSide.Left) ? (-this.sideOffset - vector.x / 2f) : (this.body.rect.width + this.sideOffset + vector.x / 2f))), this.body.rect.y + ((this.side == NodeSide.Left || this.side == NodeSide.Right) ? this.sidePosition : ((this.side == NodeSide.Top) ? (-this.sideOffset - vector.y / 2f) : (this.body.rect.height + this.sideOffset + vector.y / 2f))));
			return new Rect(vector2.x - vector.x / 2f + NodeEditor.curEditorState.zoomPanAdjust.x, vector2.y - vector.y / 2f + NodeEditor.curEditorState.zoomPanAdjust.y, vector.x, vector.y);
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00013E1C File Offset: 0x0001201C
		internal Rect GetScreenKnob()
		{
			Rect guiknob = this.GetGUIKnob();
			guiknob.position -= NodeEditor.curEditorState.zoomPanAdjust;
			return NodeEditor.CanvasGUIToScreenRect(guiknob);
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00013E52 File Offset: 0x00012052
		public Vector2 GetDirection()
		{
			if (this.side == NodeSide.Right)
			{
				return Vector2.right;
			}
			if (this.side == NodeSide.Bottom)
			{
				return Vector2.up;
			}
			if (this.side != NodeSide.Top)
			{
				return Vector2.left;
			}
			return Vector2.down;
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x00013E86 File Offset: 0x00012086
		private static int getRotationStepsAntiCW(NodeSide sideA, NodeSide sideB)
		{
			return sideB - sideA + ((sideA > sideB) ? 4 : 0);
		}

		// Token: 0x04000122 RID: 290
		public Node body;

		// Token: 0x04000123 RID: 291
		[NonSerialized]
		protected internal Texture2D knobTexture;

		// Token: 0x04000124 RID: 292
		public NodeSide side;

		// Token: 0x04000125 RID: 293
		public float sidePosition;

		// Token: 0x04000126 RID: 294
		public float sideOffset;
	}
}
