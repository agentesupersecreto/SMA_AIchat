using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000284 RID: 644
	[AddComponentMenu("Dialogue System/Trigger/On Dialogue Event/Lua On Dialogue Event")]
	public class LuaOnDialogueEvent : ActOnDialogueEvent
	{
		// Token: 0x06001BA9 RID: 7081 RVA: 0x00032244 File Offset: 0x00030444
		public override void TryStartActions(Transform actor)
		{
			this.TryActions(this.onStart, actor);
		}

		// Token: 0x06001BAA RID: 7082 RVA: 0x00032254 File Offset: 0x00030454
		public override void TryEndActions(Transform actor)
		{
			this.TryActions(this.onEnd, actor);
		}

		// Token: 0x06001BAB RID: 7083 RVA: 0x00032264 File Offset: 0x00030464
		private void TryActions(LuaOnDialogueEvent.LuaAction[] actions, Transform actor)
		{
			if (actions == null)
			{
				return;
			}
			foreach (LuaOnDialogueEvent.LuaAction luaAction in actions)
			{
				if (luaAction != null && luaAction.condition != null && luaAction.condition.IsTrue(actor))
				{
					this.DoAction(luaAction, actor);
				}
			}
		}

		// Token: 0x06001BAC RID: 7084 RVA: 0x000322BC File Offset: 0x000304BC
		public void DoAction(LuaOnDialogueEvent.LuaAction action, Transform actor)
		{
			if (action == null)
			{
				return;
			}
			Lua.Run(action.luaCode, this.debugLua);
			DialogueManager.SendUpdateTracker();
		}

		// Token: 0x04000F99 RID: 3993
		public LuaOnDialogueEvent.LuaAction[] onStart = new LuaOnDialogueEvent.LuaAction[0];

		// Token: 0x04000F9A RID: 3994
		public LuaOnDialogueEvent.LuaAction[] onEnd = new LuaOnDialogueEvent.LuaAction[0];

		// Token: 0x04000F9B RID: 3995
		public bool debugLua;

		// Token: 0x02000285 RID: 645
		[Serializable]
		public class LuaAction : ActOnDialogueEvent.Action
		{
			// Token: 0x04000F9C RID: 3996
			[Multiline]
			public string luaCode = string.Empty;
		}
	}
}
