using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x0200008B RID: 139
	public abstract class Node : ScriptableObject
	{
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x00010904 File Offset: 0x0000EB04
		public NodeCanvas owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0001090C File Offset: 0x0000EB0C
		public void SetOwner(NodeCanvas canvas)
		{
			this.m_owner = canvas;
		}

		// Token: 0x1700008D RID: 141
		// (set) Token: 0x060003E9 RID: 1001 RVA: 0x00010915 File Offset: 0x0000EB15
		public bool defaultColor
		{
			set
			{
				if (value)
				{
					this.currentColor = Color.white;
				}
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x00010925 File Offset: 0x0000EB25
		protected virtual Color nodeColor
		{
			get
			{
				return Color.white;
			}
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0001092C File Offset: 0x0000EB2C
		protected internal void InitBase()
		{
			this.Calculate();
			if (!NodeEditor.curNodeCanvas.nodes.Contains(this))
			{
				NodeEditor.curNodeCanvas.nodes.Add(this);
			}
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00010958 File Offset: 0x0000EB58
		public void Delete()
		{
			if (!NodeEditor.curNodeCanvas.nodes.Contains(this))
			{
				throw new UnityException(string.Concat(new string[]
				{
					"The Node ",
					base.name,
					" does not exist on the Canvas ",
					NodeEditor.curNodeCanvas.name,
					"!"
				}));
			}
			NodeEditorCallbacks.IssueOnDeleteNode(this);
			NodeEditor.curNodeCanvas.nodes.Remove(this);
			for (int i = 0; i < this.Outputs.Count; i++)
			{
				NodeOutput nodeOutput = this.Outputs[i];
				while (nodeOutput.connections.Count != 0)
				{
					nodeOutput.connections[0].RemoveConnection();
				}
				Object.DestroyImmediate(nodeOutput, true);
			}
			for (int j = 0; j < this.Inputs.Count; j++)
			{
				NodeInput nodeInput = this.Inputs[j];
				if (nodeInput.connection != null)
				{
					nodeInput.connection.connections.Remove(nodeInput);
				}
				Object.DestroyImmediate(nodeInput, true);
			}
			for (int k = 0; k < this.nodeKnobs.Count; k++)
			{
				if (this.nodeKnobs[k] != null)
				{
					Object.DestroyImmediate(this.nodeKnobs[k], true);
				}
			}
			Object.DestroyImmediate(this, true);
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00010AAA File Offset: 0x0000ECAA
		public static Node Create(string nodeID, Vector2 position)
		{
			Node defaultNode = NodeTypes.getDefaultNode(nodeID);
			if (defaultNode == null)
			{
				throw new UnityException("Cannot create Node with id " + nodeID + " as no such Node type is registered!");
			}
			Node node = defaultNode.Create(position);
			node.InitBase();
			NodeEditorCallbacks.IssueOnAddNode(node);
			return node;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00010AE4 File Offset: 0x0000ECE4
		public void CheckNodeKnobMigration()
		{
			if (this.nodeKnobs.Count == 0 && (this.Inputs.Count != 0 || this.Outputs.Count != 0))
			{
				this.nodeKnobs.AddRange(this.Inputs.Cast<NodeKnob>());
				this.nodeKnobs.AddRange(this.Outputs.Cast<NodeKnob>());
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060003EF RID: 1007
		public abstract string GetID { get; }

		// Token: 0x060003F0 RID: 1008
		public abstract Node Create(Vector2 pos);

		// Token: 0x060003F1 RID: 1009
		protected internal abstract void NodeGUI();

		// Token: 0x060003F2 RID: 1010 RVA: 0x00010B44 File Offset: 0x0000ED44
		public virtual void DrawNodePropertyEditor()
		{
		}

		// Token: 0x060003F3 RID: 1011
		public abstract bool Calculate();

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060003F4 RID: 1012 RVA: 0x00010B46 File Offset: 0x0000ED46
		public virtual bool AllowRecursion
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x00010B49 File Offset: 0x0000ED49
		public virtual bool ContinueCalculation
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060003F6 RID: 1014 RVA: 0x00010B4C File Offset: 0x0000ED4C
		public virtual bool AcceptsTranstitions
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00010B4F File Offset: 0x0000ED4F
		protected internal virtual void OnDelete()
		{
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00010B51 File Offset: 0x0000ED51
		protected internal virtual void OnAddInputConnection(NodeInput input)
		{
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00010B53 File Offset: 0x0000ED53
		protected internal virtual void OnAddOutputConnection(NodeOutput output)
		{
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00010B55 File Offset: 0x0000ED55
		protected internal virtual ScriptableObject[] GetScriptableObjects()
		{
			return new ScriptableObject[0];
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00010B5D File Offset: 0x0000ED5D
		protected internal virtual void CopyScriptableObjects(Func<ScriptableObject, ScriptableObject> replaceSerializableObject)
		{
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00010B60 File Offset: 0x0000ED60
		protected internal virtual void DrawNode()
		{
			Rect rect = this.rect;
			rect.position += NodeEditor.curEditorState.zoomPanAdjust;
			this.contentOffset = new Vector2(0f, 20f);
			GUI.Label(new Rect(rect.x, rect.y, rect.width, this.contentOffset.y), base.name, (NodeEditor.curEditorState.selectedNode == this) ? NodeEditorGUI.nodeBoxBold : NodeEditorGUI.nodeBox);
			Rect rect2 = new Rect(rect.x, rect.y + this.contentOffset.y, rect.width, rect.height - this.contentOffset.y);
			GUI.BeginGroup(rect2, GUI.skin.box);
			rect2.position = Vector2.zero;
			GUI.color = (this.currentColor + this.nodeColor) / 2f;
			GUILayout.BeginArea(rect2, GUI.skin.box);
			GUI.color = Color.white;
			GUI.changed = false;
			this.NodeGUI();
			GUILayout.EndArea();
			GUI.EndGroup();
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00010C9C File Offset: 0x0000EE9C
		protected internal virtual void DrawKnobs()
		{
			this.CheckNodeKnobMigration();
			foreach (NodeKnob nodeKnob in this.nodeKnobs)
			{
				nodeKnob.DrawKnob();
			}
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00010CF4 File Offset: 0x0000EEF4
		protected internal virtual void DrawConnections()
		{
			this.CheckNodeKnobMigration();
			if (Event.current.type != EventType.Repaint)
			{
				return;
			}
			foreach (NodeOutput nodeOutput in this.Outputs)
			{
				Vector2 center = nodeOutput.GetGUIKnob().center;
				Vector2 direction = nodeOutput.GetDirection();
				foreach (NodeInput nodeInput in nodeOutput.connections)
				{
					NodeEditorGUI.DrawConnection(center, direction, nodeInput.GetGUIKnob().center, nodeInput.GetDirection(), ConnectionTypes.GetTypeData(nodeOutput.type, true).Color);
				}
			}
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00010DDC File Offset: 0x0000EFDC
		protected internal bool allInputsReady()
		{
			foreach (NodeInput nodeInput in this.Inputs)
			{
				if (nodeInput.connection == null || nodeInput.connection.IsValueNull)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00010E4C File Offset: 0x0000F04C
		protected internal bool hasUnassignedInputs()
		{
			using (List<NodeInput>.Enumerator enumerator = this.Inputs.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.connection == null)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x00010EAC File Offset: 0x0000F0AC
		protected internal bool descendantsCalculated()
		{
			foreach (NodeInput nodeInput in this.Inputs)
			{
				if (nodeInput.connection != null && !nodeInput.connection.body.calculated)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00010F20 File Offset: 0x0000F120
		protected internal bool isInput()
		{
			using (List<NodeInput>.Enumerator enumerator = this.Inputs.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.connection != null)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00010F80 File Offset: 0x0000F180
		public void CreateOutput(string outputName, string outputType)
		{
			NodeOutput.Create(this, outputName, outputType);
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00010F8B File Offset: 0x0000F18B
		public void CreateOutput(string outputName, string outputType, NodeSide nodeSide)
		{
			NodeOutput.Create(this, outputName, outputType, nodeSide);
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00010F97 File Offset: 0x0000F197
		public void CreateOutput(string outputName, string outputType, NodeSide nodeSide, float sidePosition)
		{
			NodeOutput.Create(this, outputName, outputType, nodeSide, sidePosition);
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00010FA5 File Offset: 0x0000F1A5
		protected void OutputKnob(int outputIdx)
		{
			if (Event.current.type == EventType.Repaint)
			{
				this.Outputs[outputIdx].SetPosition();
			}
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00010FC8 File Offset: 0x0000F1C8
		public NodeOutput GetOutputAtPos(Vector2 pos)
		{
			foreach (NodeOutput nodeOutput in this.Outputs)
			{
				if (nodeOutput.GetScreenKnob().Contains(new Vector3(pos.x, pos.y)))
				{
					return nodeOutput;
				}
			}
			return null;
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0001103C File Offset: 0x0000F23C
		public void CreateInput(string inputName, string inputType)
		{
			NodeInput.Create(this, inputName, inputType);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00011047 File Offset: 0x0000F247
		public void CreateInput(string inputName, string inputType, NodeSide nodeSide)
		{
			NodeInput.Create(this, inputName, inputType, nodeSide);
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x00011053 File Offset: 0x0000F253
		public void CreateInput(string inputName, string inputType, NodeSide nodeSide, float sidePosition)
		{
			NodeInput.Create(this, inputName, inputType, nodeSide, sidePosition);
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x00011061 File Offset: 0x0000F261
		protected void InputKnob(int inputIdx)
		{
			if (Event.current.type == EventType.Repaint)
			{
				this.Inputs[inputIdx].SetPosition();
			}
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00011084 File Offset: 0x0000F284
		public NodeInput GetInputAtPos(Vector2 pos)
		{
			foreach (NodeInput nodeInput in this.Inputs)
			{
				if (nodeInput.GetScreenKnob().Contains(new Vector3(pos.x, pos.y)))
				{
					return nodeInput;
				}
			}
			return null;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x000110F8 File Offset: 0x0000F2F8
		public bool isChildOf(Node otherNode)
		{
			if (otherNode == null || otherNode == this)
			{
				return false;
			}
			if (this.BeginRecursiveSearchLoop())
			{
				return false;
			}
			foreach (NodeInput nodeInput in this.Inputs)
			{
				NodeOutput connection = nodeInput.connection;
				if (connection != null && connection.body != this.startRecursiveSearchNode && (connection.body == otherNode || connection.body.isChildOf(otherNode)))
				{
					this.StopRecursiveSearchLoop();
					return true;
				}
			}
			this.EndRecursiveSearchLoop();
			return false;
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x000111B4 File Offset: 0x0000F3B4
		internal bool isInLoop()
		{
			if (this.BeginRecursiveSearchLoop())
			{
				return this == this.startRecursiveSearchNode;
			}
			foreach (NodeInput nodeInput in this.Inputs)
			{
				NodeOutput connection = nodeInput.connection;
				if (connection != null && connection.body.isInLoop())
				{
					this.StopRecursiveSearchLoop();
					return true;
				}
			}
			this.EndRecursiveSearchLoop();
			return false;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00011244 File Offset: 0x0000F444
		internal bool allowsLoopRecursion(Node otherNode)
		{
			if (this.AllowRecursion)
			{
				return true;
			}
			if (otherNode == null)
			{
				return false;
			}
			if (this.BeginRecursiveSearchLoop())
			{
				return false;
			}
			foreach (NodeInput nodeInput in this.Inputs)
			{
				NodeOutput connection = nodeInput.connection;
				if (connection != null && connection.body != this.startRecursiveSearchNode && connection.body.allowsLoopRecursion(otherNode))
				{
					this.StopRecursiveSearchLoop();
					return true;
				}
			}
			this.EndRecursiveSearchLoop();
			return false;
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x000112F4 File Offset: 0x0000F4F4
		public void ClearCalculation()
		{
			if (this.BeginRecursiveSearchLoop())
			{
				return;
			}
			this.calculated = false;
			foreach (NodeOutput nodeOutput in this.Outputs)
			{
				foreach (NodeInput nodeInput in nodeOutput.connections)
				{
					nodeInput.body.ClearCalculation();
				}
			}
			this.EndRecursiveSearchLoop();
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00011398 File Offset: 0x0000F598
		internal bool BeginRecursiveSearchLoop()
		{
			if (this.startRecursiveSearchNode == null || this.recursiveSearchSurpassed == null)
			{
				this.recursiveSearchSurpassed = new List<Node>();
				this.startRecursiveSearchNode = this;
			}
			if (this.recursiveSearchSurpassed.Contains(this))
			{
				return true;
			}
			this.recursiveSearchSurpassed.Add(this);
			return false;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x000113EA File Offset: 0x0000F5EA
		internal void EndRecursiveSearchLoop()
		{
			if (this.startRecursiveSearchNode == this)
			{
				this.recursiveSearchSurpassed = null;
				this.startRecursiveSearchNode = null;
			}
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00011408 File Offset: 0x0000F608
		internal void StopRecursiveSearchLoop()
		{
			this.recursiveSearchSurpassed = null;
			this.startRecursiveSearchNode = null;
		}

		// Token: 0x040000D9 RID: 217
		[HideInInspector]
		[SerializeField]
		private NodeCanvas m_owner;

		// Token: 0x040000DA RID: 218
		public const string version = "SaveLoadModded";

		// Token: 0x040000DB RID: 219
		[NonSerialized]
		public Color currentColor = Color.white;

		// Token: 0x040000DC RID: 220
		public Rect rect;

		// Token: 0x040000DD RID: 221
		internal Vector2 contentOffset = Vector2.zero;

		// Token: 0x040000DE RID: 222
		[SerializeField]
		public List<NodeKnob> nodeKnobs = new List<NodeKnob>();

		// Token: 0x040000DF RID: 223
		[SerializeField]
		[HideInInspector]
		public List<NodeInput> Inputs = new List<NodeInput>();

		// Token: 0x040000E0 RID: 224
		[SerializeField]
		[HideInInspector]
		public List<NodeOutput> Outputs = new List<NodeOutput>();

		// Token: 0x040000E1 RID: 225
		[HideInInspector]
		[NonSerialized]
		internal bool calculated = true;

		// Token: 0x040000E2 RID: 226
		private List<Node> recursiveSearchSurpassed;

		// Token: 0x040000E3 RID: 227
		private Node startRecursiveSearchNode;
	}
}
