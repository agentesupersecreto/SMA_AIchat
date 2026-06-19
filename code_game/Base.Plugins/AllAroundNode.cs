using System;
using NodeEditorFramework;
using UnityEngine;

// Token: 0x0200001D RID: 29
[Node(false, "Standard/Example/AllAround Node")]
public class AllAroundNode : Node
{
	// Token: 0x17000016 RID: 22
	// (get) Token: 0x0600013E RID: 318 RVA: 0x000083AD File Offset: 0x000065AD
	public override string GetID
	{
		get
		{
			return "allaroundNode";
		}
	}

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x0600013F RID: 319 RVA: 0x000083B4 File Offset: 0x000065B4
	public override bool AllowRecursion
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x06000140 RID: 320 RVA: 0x000083B7 File Offset: 0x000065B7
	public override bool ContinueCalculation
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000141 RID: 321 RVA: 0x000083BC File Offset: 0x000065BC
	public override Node Create(Vector2 pos)
	{
		AllAroundNode allAroundNode = ScriptableObject.CreateInstance<AllAroundNode>();
		allAroundNode.rect = new Rect(pos.x, pos.y, 60f, 60f);
		allAroundNode.name = "AllAround Node";
		allAroundNode.CreateInput("Input Top", "Float", NodeSide.Top, 20f);
		allAroundNode.CreateInput("Input Bottom", "Float", NodeSide.Bottom, 20f);
		allAroundNode.CreateInput("Input Right", "Float", NodeSide.Right, 20f);
		allAroundNode.CreateInput("Input Left", "Float", NodeSide.Left, 20f);
		allAroundNode.CreateOutput("Output Top", "Float", NodeSide.Top, 40f);
		allAroundNode.CreateOutput("Output Bottom", "Float", NodeSide.Bottom, 40f);
		allAroundNode.CreateOutput("Output Right", "Float", NodeSide.Right, 40f);
		allAroundNode.CreateOutput("Output Left", "Float", NodeSide.Left, 40f);
		return allAroundNode;
	}

	// Token: 0x06000142 RID: 322 RVA: 0x000084AC File Offset: 0x000066AC
	protected internal override void DrawNode()
	{
		Rect rect = this.rect;
		rect.position += NodeEditor.curEditorState.zoomPanAdjust;
		Rect rect2 = new Rect(rect.x, rect.y, rect.width, rect.height);
		GUI.changed = false;
		GUILayout.BeginArea(rect2, GUI.skin.box);
		this.NodeGUI();
		GUILayout.EndArea();
	}

	// Token: 0x06000143 RID: 323 RVA: 0x0000851D File Offset: 0x0000671D
	protected internal override void NodeGUI()
	{
	}

	// Token: 0x06000144 RID: 324 RVA: 0x00008520 File Offset: 0x00006720
	public override bool Calculate()
	{
		this.Outputs[0].SetValue<float>(this.Inputs[0].GetValue<float>());
		this.Outputs[1].SetValue<float>(this.Inputs[1].GetValue<float>());
		this.Outputs[2].SetValue<float>(this.Inputs[2].GetValue<float>());
		this.Outputs[3].SetValue<float>(this.Inputs[3].GetValue<float>());
		return true;
	}

	// Token: 0x04000037 RID: 55
	public const string ID = "allaroundNode";
}
