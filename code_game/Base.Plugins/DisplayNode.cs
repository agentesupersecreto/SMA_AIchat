using System;
using NodeEditorFramework;
using UnityEngine;

// Token: 0x02000020 RID: 32
[Node(false, "Standard/Float/Display")]
[Serializable]
public class DisplayNode : Node
{
	// Token: 0x1700001B RID: 27
	// (get) Token: 0x06000150 RID: 336 RVA: 0x000089B3 File Offset: 0x00006BB3
	public override string GetID
	{
		get
		{
			return "displayNode";
		}
	}

	// Token: 0x06000151 RID: 337 RVA: 0x000089BC File Offset: 0x00006BBC
	public override Node Create(Vector2 pos)
	{
		DisplayNode displayNode = ScriptableObject.CreateInstance<DisplayNode>();
		displayNode.name = "Display Node";
		displayNode.rect = new Rect(pos.x, pos.y, 150f, 50f);
		NodeInput.Create(displayNode, "Value", "Float");
		return displayNode;
	}

	// Token: 0x06000152 RID: 338 RVA: 0x00008A0C File Offset: 0x00006C0C
	protected internal override void NodeGUI()
	{
		this.Inputs[0].DisplayLayout(new GUIContent("Value : " + (this.assigned ? this.value.ToString() : ""), "The input value to display"));
	}

	// Token: 0x06000153 RID: 339 RVA: 0x00008A58 File Offset: 0x00006C58
	public override bool Calculate()
	{
		if (!base.allInputsReady())
		{
			this.value = 0f;
			this.assigned = false;
			return false;
		}
		this.value = this.Inputs[0].connection.GetValue<float>();
		this.assigned = true;
		return true;
	}

	// Token: 0x0400003D RID: 61
	public const string ID = "displayNode";

	// Token: 0x0400003E RID: 62
	[HideInInspector]
	public bool assigned;

	// Token: 0x0400003F RID: 63
	public float value;
}
