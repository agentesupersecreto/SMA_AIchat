using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x02000096 RID: 150
	public class NodeOutput : NodeKnob
	{
		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x00013E9C File Offset: 0x0001209C
		protected override NodeSide defaultSide
		{
			get
			{
				return NodeSide.Right;
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600047F RID: 1151 RVA: 0x00013E9F File Offset: 0x0001209F
		protected override GUIStyle defaultLabelStyle
		{
			get
			{
				if (NodeOutput._defaultStyle == null)
				{
					NodeOutput._defaultStyle = new GUIStyle(GUI.skin.label);
					NodeOutput._defaultStyle.alignment = TextAnchor.MiddleRight;
				}
				return NodeOutput._defaultStyle;
			}
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00013ECC File Offset: 0x000120CC
		public static NodeOutput Create(Node nodeBody, string outputName, string outputType)
		{
			return NodeOutput.Create(nodeBody, outputName, outputType, NodeSide.Right, 20f);
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00013EDC File Offset: 0x000120DC
		public static NodeOutput Create(Node nodeBody, string outputName, string outputType, NodeSide nodeSide)
		{
			return NodeOutput.Create(nodeBody, outputName, outputType, nodeSide, 20f);
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x00013EEC File Offset: 0x000120EC
		public static NodeOutput Create(Node nodeBody, string outputName, string outputType, NodeSide nodeSide, float sidePosition)
		{
			NodeOutput nodeOutput = ScriptableObject.CreateInstance<NodeOutput>();
			nodeOutput.type = outputType;
			nodeOutput.InitBase(nodeBody, nodeSide, sidePosition, outputName);
			nodeBody.Outputs.Add(nodeOutput);
			return nodeOutput;
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x00013F20 File Offset: 0x00012120
		protected internal override void CopyScriptableObjects(Func<ScriptableObject, ScriptableObject> replaceSerializableObject)
		{
			for (int i = 0; i < this.connections.Count; i++)
			{
				this.connections[i] = replaceSerializableObject(this.connections[i]) as NodeInput;
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00013F66 File Offset: 0x00012166
		protected override void ReloadTexture()
		{
			this.CheckType();
			this.knobTexture = this.typeData.OutKnobTex;
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00013F7F File Offset: 0x0001217F
		private void CheckType()
		{
			if (this.typeData == null || !this.typeData.isValid())
			{
				this.typeData = ConnectionTypes.GetTypeData(this.type, true);
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x00013FA8 File Offset: 0x000121A8
		public bool IsValueNull
		{
			get
			{
				return this.value == null;
			}
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00013FB4 File Offset: 0x000121B4
		public T GetValue<T>()
		{
			this.CheckType();
			if (this.typeData.Type == typeof(T))
			{
				object obj;
				if ((obj = this.value) == null)
				{
					obj = (this.value = NodeOutput.GetDefault<T>());
				}
				return (T)((object)obj);
			}
			Debug.LogError("Trying to GetValue<" + typeof(T).FullName + "> for Output Type: " + this.typeData.Type.FullName);
			return NodeOutput.GetDefault<T>();
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00014040 File Offset: 0x00012240
		public void SetValue<T>(T Value)
		{
			this.CheckType();
			if (this.typeData.Type == typeof(T))
			{
				this.value = Value;
				return;
			}
			Debug.LogError("Trying to SetValue<" + typeof(T).FullName + "> for Output Type: " + this.typeData.Type.FullName);
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x000140AF File Offset: 0x000122AF
		public void ResetValue()
		{
			this.value = null;
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x000140B8 File Offset: 0x000122B8
		public static T GetDefault<T>()
		{
			if (typeof(T).GetConstructor(Type.EmptyTypes) != null)
			{
				return Activator.CreateInstance<T>();
			}
			return default(T);
		}

		// Token: 0x04000127 RID: 295
		private static GUIStyle _defaultStyle;

		// Token: 0x04000128 RID: 296
		public List<NodeInput> connections = new List<NodeInput>();

		// Token: 0x04000129 RID: 297
		public string type;

		// Token: 0x0400012A RID: 298
		[NonSerialized]
		internal TypeData typeData;

		// Token: 0x0400012B RID: 299
		[NonSerialized]
		private object value;
	}
}
