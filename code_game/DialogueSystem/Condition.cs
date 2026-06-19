using System;
using System.Linq;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200027C RID: 636
	[Serializable]
	public class Condition
	{
		// Token: 0x06001B8D RID: 7053 RVA: 0x00031DF8 File Offset: 0x0002FFF8
		public bool IsTrue(Transform interactor)
		{
			bool flag = this.LuaConditionsAreTrue() && this.QuestConditionsAreTrue() && this.IsAcceptedTag(interactor) && this.IsAcceptedGameObject(interactor);
			this.lastEvaluationValue = ((!flag) ? Condition.LastEvaluationValue.False : Condition.LastEvaluationValue.True);
			return flag;
		}

		// Token: 0x06001B8E RID: 7054 RVA: 0x00031E48 File Offset: 0x00030048
		private bool LuaConditionsAreTrue()
		{
			if (this.luaConditions != null)
			{
				for (int i = 0; i < this.luaConditions.Length; i++)
				{
					string text = this.luaConditions[i];
					if (!Lua.IsTrue(text, DialogueDebug.LogInfo))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06001B8F RID: 7055 RVA: 0x00031E98 File Offset: 0x00030098
		private bool QuestConditionsAreTrue()
		{
			if (this.questConditions != null)
			{
				for (int i = 0; i < this.questConditions.Length; i++)
				{
					QuestCondition questCondition = this.questConditions[i];
					if (questCondition != null && !questCondition.IsTrue)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06001B90 RID: 7056 RVA: 0x00031EE8 File Offset: 0x000300E8
		private bool IsAcceptedTag(Transform interactor)
		{
			return interactor == null || this.acceptedTags == null || this.acceptedTags.Length <= 0 || this.acceptedTags.Contains(interactor.tag);
		}

		// Token: 0x06001B91 RID: 7057 RVA: 0x00031F30 File Offset: 0x00030130
		private bool IsAcceptedGameObject(Transform interactor)
		{
			return interactor == null || this.acceptedGameObjects == null || this.acceptedGameObjects.Length <= 0 || this.acceptedGameObjects.Contains(interactor.gameObject);
		}

		// Token: 0x04000F7D RID: 3965
		public string[] luaConditions = new string[0];

		// Token: 0x04000F7E RID: 3966
		public QuestCondition[] questConditions = new QuestCondition[0];

		// Token: 0x04000F7F RID: 3967
		public string[] acceptedTags = new string[0];

		// Token: 0x04000F80 RID: 3968
		public GameObject[] acceptedGameObjects = new GameObject[0];

		// Token: 0x04000F81 RID: 3969
		[HideInInspector]
		public int luaWizardIndex = -1;

		// Token: 0x04000F82 RID: 3970
		[HideInInspector]
		public Condition.LastEvaluationValue lastEvaluationValue;

		// Token: 0x0200027D RID: 637
		public enum LastEvaluationValue
		{
			// Token: 0x04000F84 RID: 3972
			None,
			// Token: 0x04000F85 RID: 3973
			True,
			// Token: 0x04000F86 RID: 3974
			False
		}
	}
}
