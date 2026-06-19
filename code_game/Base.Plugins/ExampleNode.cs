using System;
using NodeEditorFramework;
using UnityEngine;

// Token: 0x0200001E RID: 30
[Node(false, "Standard/Example/Basic Node")]
public class ExampleNode : Node
{
	// Token: 0x17000019 RID: 25
	// (get) Token: 0x06000146 RID: 326 RVA: 0x000085BE File Offset: 0x000067BE
	public override string GetID
	{
		get
		{
			return "exampleNode";
		}
	}

	// Token: 0x06000147 RID: 327 RVA: 0x000085C8 File Offset: 0x000067C8
	public override Node Create(Vector2 pos)
	{
		ExampleNode exampleNode = ScriptableObject.CreateInstance<ExampleNode>();
		exampleNode.rect = new Rect(pos.x, pos.y, 150f, 60f);
		exampleNode.name = "Example Node";
		exampleNode.CreateInput("Value", "Float");
		exampleNode.CreateOutput("Output val", "Float");
		return exampleNode;
	}

	// Token: 0x06000148 RID: 328 RVA: 0x00008628 File Offset: 0x00006828
	protected internal override void NodeGUI()
	{
		GUILayout.Label("This is a custom Node!", Array.Empty<GUILayoutOption>());
		GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
		GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
		this.Inputs[0].DisplayLayout();
		GUILayout.EndVertical();
		GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
		this.Outputs[0].DisplayLayout();
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
	}

	// Token: 0x06000149 RID: 329 RVA: 0x00008693 File Offset: 0x00006893
	public override bool Calculate()
	{
		if (!base.allInputsReady())
		{
			return false;
		}
		this.Outputs[0].SetValue<float>(this.Inputs[0].GetValue<float>() * 5f);
		return true;
	}

	// Token: 0x04000038 RID: 56
	public const string ID = "exampleNode";
}
