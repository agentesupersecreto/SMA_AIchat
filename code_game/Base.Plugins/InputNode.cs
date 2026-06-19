using System;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEngine;

// Token: 0x02000021 RID: 33
[Node(false, "Standard/Float/Input")]
[Serializable]
public class InputNode : Node
{
	// Token: 0x1700001C RID: 28
	// (get) Token: 0x06000155 RID: 341 RVA: 0x00008AAD File Offset: 0x00006CAD
	public override string GetID
	{
		get
		{
			return "inputNode";
		}
	}

	// Token: 0x06000156 RID: 342 RVA: 0x00008AB4 File Offset: 0x00006CB4
	public override Node Create(Vector2 pos)
	{
		InputNode inputNode = ScriptableObject.CreateInstance<InputNode>();
		inputNode.name = "Input Node";
		inputNode.rect = new Rect(pos.x, pos.y, 200f, 50f);
		NodeOutput.Create(inputNode, "Value", "Float");
		return inputNode;
	}

	// Token: 0x06000157 RID: 343 RVA: 0x00008B03 File Offset: 0x00006D03
	protected internal override void NodeGUI()
	{
		this.value = RTEditorGUI.FloatField(new GUIContent("Value", "The input value of type float"), this.value, Array.Empty<GUILayoutOption>());
		base.OutputKnob(0);
		if (GUI.changed)
		{
			NodeEditor.RecalculateFrom(this);
		}
	}

	// Token: 0x06000158 RID: 344 RVA: 0x00008B3E File Offset: 0x00006D3E
	public override bool Calculate()
	{
		this.Outputs[0].SetValue<float>(this.value);
		return true;
	}

	// Token: 0x04000040 RID: 64
	public const string ID = "inputNode";

	// Token: 0x04000041 RID: 65
	public float value = 1f;
}
