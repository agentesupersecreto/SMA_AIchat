using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200000A RID: 10
[ExecuteInEditMode]
public class ToDoList : MonoBehaviour
{
	// Token: 0x06000036 RID: 54 RVA: 0x0000601C File Offset: 0x0000421C
	private void Awake()
	{
		if (this.textList.Count == 0)
		{
			ToDoList.TextObject textObject = new ToDoList.TextObject();
			this.textList.Add(textObject);
		}
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00006048 File Offset: 0x00004248
	public void CreateNewText()
	{
		this.textList.Add(new ToDoList.TextObject());
	}

	// Token: 0x06000038 RID: 56 RVA: 0x0000605A File Offset: 0x0000425A
	public void RequestDelete(int id)
	{
		this.textList[id].deleteQuestion = true;
	}

	// Token: 0x06000039 RID: 57 RVA: 0x0000606E File Offset: 0x0000426E
	public void DeleteText(int id)
	{
		this.textList.Remove(this.textList[id]);
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00006088 File Offset: 0x00004288
	public void SortText()
	{
		for (int i = 0; i < this.textList.Count - 1; i++)
		{
			for (int j = 0; j < this.textList.Count - 1; j++)
			{
				if (this.textList[j].state > this.textList[j + 1].state)
				{
					ToDoList.TextObject textObject = this.textList[j];
					this.textList[j] = this.textList[j + 1];
					this.textList[j + 1] = textObject;
				}
			}
		}
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00006128 File Offset: 0x00004328
	public void MoveUp(int id)
	{
		ToDoList.TextObject textObject = this.textList[id];
		this.textList[id] = this.textList[id - 1];
		this.textList[id - 1] = textObject;
	}

	// Token: 0x0600003C RID: 60 RVA: 0x0000616C File Offset: 0x0000436C
	public void MoveDown(int id)
	{
		ToDoList.TextObject textObject = this.textList[id];
		this.textList[id] = this.textList[id + 1];
		this.textList[id + 1] = textObject;
	}

	// Token: 0x04000082 RID: 130
	public string title = "LIST TITLE";

	// Token: 0x04000083 RID: 131
	public List<ToDoList.TextObject> textList = new List<ToDoList.TextObject>();

	// Token: 0x020000D2 RID: 210
	[Serializable]
	public class TextObject
	{
		// Token: 0x0400029D RID: 669
		public string s = "empty content item";

		// Token: 0x0400029E RID: 670
		public ToDoList.TextObject.State state;

		// Token: 0x0400029F RID: 671
		public bool show = true;

		// Token: 0x040002A0 RID: 672
		public bool deleteQuestion;

		// Token: 0x0200013A RID: 314
		public enum State
		{
			// Token: 0x040003E7 RID: 999
			Default,
			// Token: 0x040003E8 RID: 1000
			Bug,
			// Token: 0x040003E9 RID: 1001
			Active,
			// Token: 0x040003EA RID: 1002
			Finished
		}
	}
}
