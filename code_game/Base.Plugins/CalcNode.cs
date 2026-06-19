using System;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEngine;

// Token: 0x0200001F RID: 31
[Node(false, "Standard/Float/Calculation")]
[Serializable]
public class CalcNode : Node
{
	// Token: 0x1700001A RID: 26
	// (get) Token: 0x0600014B RID: 331 RVA: 0x000086D0 File Offset: 0x000068D0
	public override string GetID
	{
		get
		{
			return "calcNode";
		}
	}

	// Token: 0x0600014C RID: 332 RVA: 0x000086D8 File Offset: 0x000068D8
	public override Node Create(Vector2 pos)
	{
		CalcNode calcNode = ScriptableObject.CreateInstance<CalcNode>();
		calcNode.name = "Calc Node";
		calcNode.rect = new Rect(pos.x, pos.y, 200f, 100f);
		calcNode.CreateInput("Input 1", "Float");
		calcNode.CreateInput("Input 2", "Float");
		calcNode.CreateOutput("Output 1", "Float");
		return calcNode;
	}

	// Token: 0x0600014D RID: 333 RVA: 0x00008748 File Offset: 0x00006948
	protected internal override void NodeGUI()
	{
		GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
		GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
		if (this.Inputs[0].connection != null)
		{
			GUILayout.Label(this.Inputs[0].name, Array.Empty<GUILayoutOption>());
		}
		else
		{
			this.Input1Val = RTEditorGUI.FloatField(GUIContent.none, this.Input1Val, Array.Empty<GUILayoutOption>());
		}
		base.InputKnob(0);
		if (this.Inputs[1].connection != null)
		{
			GUILayout.Label(this.Inputs[1].name, Array.Empty<GUILayoutOption>());
		}
		else
		{
			this.Input2Val = RTEditorGUI.FloatField(GUIContent.none, this.Input2Val, Array.Empty<GUILayoutOption>());
		}
		base.InputKnob(1);
		GUILayout.EndVertical();
		GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
		this.Outputs[0].DisplayLayout();
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		GUILayout.Label(new GUIContent("Calculation Type: " + this.type.ToString(), "The type of calculation performed on Input 1 and Input 2"), Array.Empty<GUILayoutOption>());
		if (GUI.changed)
		{
			NodeEditor.RecalculateFrom(this);
		}
	}

	// Token: 0x0600014E RID: 334 RVA: 0x00008880 File Offset: 0x00006A80
	public override bool Calculate()
	{
		if (this.Inputs[0].connection != null)
		{
			this.Input1Val = this.Inputs[0].connection.GetValue<float>();
		}
		if (this.Inputs[1].connection != null)
		{
			this.Input2Val = this.Inputs[1].connection.GetValue<float>();
		}
		switch (this.type)
		{
		case CalcNode.CalcType.Add:
			this.Outputs[0].SetValue<float>(this.Input1Val + this.Input2Val);
			break;
		case CalcNode.CalcType.Substract:
			this.Outputs[0].SetValue<float>(this.Input1Val - this.Input2Val);
			break;
		case CalcNode.CalcType.Multiply:
			this.Outputs[0].SetValue<float>(this.Input1Val * this.Input2Val);
			break;
		case CalcNode.CalcType.Divide:
			this.Outputs[0].SetValue<float>(this.Input1Val / this.Input2Val);
			break;
		}
		return true;
	}

	// Token: 0x04000039 RID: 57
	public CalcNode.CalcType type;

	// Token: 0x0400003A RID: 58
	public const string ID = "calcNode";

	// Token: 0x0400003B RID: 59
	public float Input1Val = 1f;

	// Token: 0x0400003C RID: 60
	public float Input2Val = 1f;

	// Token: 0x0200019A RID: 410
	public enum CalcType
	{
		// Token: 0x040003E3 RID: 995
		Add,
		// Token: 0x040003E4 RID: 996
		Substract,
		// Token: 0x040003E5 RID: 997
		Multiply,
		// Token: 0x040003E6 RID: 998
		Divide
	}
}
