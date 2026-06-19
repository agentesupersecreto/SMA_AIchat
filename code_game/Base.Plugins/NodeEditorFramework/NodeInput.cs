using System;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x02000093 RID: 147
	public class NodeInput : NodeKnob
	{
		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600045C RID: 1116 RVA: 0x000137DB File Offset: 0x000119DB
		protected override NodeSide defaultSide
		{
			get
			{
				return NodeSide.Left;
			}
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x000137DE File Offset: 0x000119DE
		public static NodeInput Create(Node nodeBody, string inputName, string inputType)
		{
			return NodeInput.Create(nodeBody, inputName, inputType, NodeSide.Left, 20f);
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x000137EE File Offset: 0x000119EE
		public static NodeInput Create(Node nodeBody, string inputName, string inputType, NodeSide nodeSide)
		{
			return NodeInput.Create(nodeBody, inputName, inputType, nodeSide, 20f);
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00013800 File Offset: 0x00011A00
		public static NodeInput Create(Node nodeBody, string inputName, string inputType, NodeSide nodeSide, float sidePosition)
		{
			NodeInput nodeInput = ScriptableObject.CreateInstance<NodeInput>();
			nodeInput.type = inputType;
			nodeInput.InitBase(nodeBody, nodeSide, sidePosition, inputName);
			nodeBody.Inputs.Add(nodeInput);
			return nodeInput;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00013832 File Offset: 0x00011A32
		protected internal override void CopyScriptableObjects(Func<ScriptableObject, ScriptableObject> replaceSerializableObject)
		{
			this.connection = replaceSerializableObject(this.connection) as NodeOutput;
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0001384B File Offset: 0x00011A4B
		protected override void ReloadTexture()
		{
			this.CheckType();
			this.knobTexture = this.typeData.InKnobTex;
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00013864 File Offset: 0x00011A64
		private void CheckType()
		{
			if (this.typeData == null || !this.typeData.isValid())
			{
				this.typeData = ConnectionTypes.GetTypeData(this.type, true);
			}
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0001388D File Offset: 0x00011A8D
		public T GetValue<T>()
		{
			if (!(this.connection != null))
			{
				return NodeOutput.GetDefault<T>();
			}
			return this.connection.GetValue<T>();
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x000138AE File Offset: 0x00011AAE
		public void SetValue<T>(T value)
		{
			if (this.connection != null)
			{
				this.connection.SetValue<T>(value);
			}
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x000138CC File Offset: 0x00011ACC
		public bool CanApplyConnection(NodeOutput output)
		{
			if (output == null || this.body == output.body || this.connection == output || this.typeData.Type != output.typeData.Type)
			{
				return false;
			}
			if (output.body.isChildOf(this.body) && !output.body.allowsLoopRecursion(this.body))
			{
				Debug.LogWarning("Cannot apply connection: Recursion detected!");
				return false;
			}
			return true;
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x00013958 File Offset: 0x00011B58
		public void ApplyConnection(NodeOutput output)
		{
			if (output == null)
			{
				return;
			}
			if (this.connection != null)
			{
				NodeEditorCallbacks.IssueOnRemoveConnection(this);
				this.connection.connections.Remove(this);
			}
			this.connection = output;
			output.connections.Add(this);
			NodeEditor.RecalculateFrom(this.body);
			output.body.OnAddOutputConnection(output);
			this.body.OnAddInputConnection(this);
			NodeEditorCallbacks.IssueOnAddConnection(this);
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x000139D1 File Offset: 0x00011BD1
		public void RemoveConnection()
		{
			if (this.connection == null)
			{
				return;
			}
			NodeEditorCallbacks.IssueOnRemoveConnection(this);
			this.connection.connections.Remove(this);
			this.connection = null;
			NodeEditor.RecalculateFrom(this.body);
		}

		// Token: 0x0400011A RID: 282
		public NodeOutput connection;

		// Token: 0x0400011B RID: 283
		public string type;

		// Token: 0x0400011C RID: 284
		[NonSerialized]
		internal TypeData typeData;
	}
}
