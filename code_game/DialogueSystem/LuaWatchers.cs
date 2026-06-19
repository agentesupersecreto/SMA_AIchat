using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200000F RID: 15
	public class LuaWatchers
	{
		// Token: 0x0600010A RID: 266 RVA: 0x00005208 File Offset: 0x00003408
		public void AddObserver(string luaExpression, LuaWatchFrequency frequency, LuaChangedDelegate luaChangedHandler)
		{
			switch (frequency)
			{
			case LuaWatchFrequency.EveryUpdate:
				this.everyUpdateList.AddObserver(luaExpression, luaChangedHandler);
				break;
			case LuaWatchFrequency.EveryDialogueEntry:
				this.everyDialogueEntryList.AddObserver(luaExpression, luaChangedHandler);
				break;
			case LuaWatchFrequency.EndOfConversation:
				this.endOfConversationList.AddObserver(luaExpression, luaChangedHandler);
				break;
			default:
				Debug.LogError(string.Format("{0}: Internal error - unexpected Lua watch frequency {1}", new object[] { "Dialogue System", frequency }));
				break;
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00005290 File Offset: 0x00003490
		public void RemoveObserver(string luaExpression, LuaWatchFrequency frequency, LuaChangedDelegate luaChangedHandler)
		{
			switch (frequency)
			{
			case LuaWatchFrequency.EveryUpdate:
				this.everyUpdateList.RemoveObserver(luaExpression, luaChangedHandler);
				break;
			case LuaWatchFrequency.EveryDialogueEntry:
				this.everyDialogueEntryList.RemoveObserver(luaExpression, luaChangedHandler);
				break;
			case LuaWatchFrequency.EndOfConversation:
				this.endOfConversationList.RemoveObserver(luaExpression, luaChangedHandler);
				break;
			default:
				Debug.LogError(string.Format("{0}: Internal error - unexpected Lua watch frequency {1}", new object[] { "Dialogue System", frequency }));
				break;
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00005318 File Offset: 0x00003518
		public void RemoveAllObservers(LuaWatchFrequency frequency)
		{
			switch (frequency)
			{
			case LuaWatchFrequency.EveryUpdate:
				this.everyUpdateList.RemoveAllObservers();
				break;
			case LuaWatchFrequency.EveryDialogueEntry:
				this.everyDialogueEntryList.RemoveAllObservers();
				break;
			case LuaWatchFrequency.EndOfConversation:
				this.endOfConversationList.RemoveAllObservers();
				break;
			default:
				Debug.LogError(string.Format("{0}: Internal error - unexpected Lua watch frequency {1}", new object[] { "Dialogue System", frequency }));
				break;
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000539C File Offset: 0x0000359C
		public void RemoveAllObservers()
		{
			this.everyUpdateList.RemoveAllObservers();
			this.everyDialogueEntryList.RemoveAllObservers();
			this.endOfConversationList.RemoveAllObservers();
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000053C0 File Offset: 0x000035C0
		public void NotifyObservers(LuaWatchFrequency frequency)
		{
			switch (frequency)
			{
			case LuaWatchFrequency.EveryUpdate:
				this.everyUpdateList.NotifyObservers();
				break;
			case LuaWatchFrequency.EveryDialogueEntry:
				this.everyDialogueEntryList.NotifyObservers();
				break;
			case LuaWatchFrequency.EndOfConversation:
				this.endOfConversationList.NotifyObservers();
				break;
			default:
				Debug.LogError(string.Format("{0}: Internal error - unexpected Lua watch frequency {1}", new object[] { "Dialogue System", frequency }));
				break;
			}
		}

		// Token: 0x0400004E RID: 78
		private LuaWatchList everyUpdateList = new LuaWatchList();

		// Token: 0x0400004F RID: 79
		private LuaWatchList everyDialogueEntryList = new LuaWatchList();

		// Token: 0x04000050 RID: 80
		private LuaWatchList endOfConversationList = new LuaWatchList();
	}
}
