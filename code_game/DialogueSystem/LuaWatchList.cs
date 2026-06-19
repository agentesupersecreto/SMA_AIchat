using System;
using System.Collections.Generic;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000009 RID: 9
	public class LuaWatchList
	{
		// Token: 0x0600003F RID: 63 RVA: 0x00003040 File Offset: 0x00001240
		public void AddObserver(string luaExpression, LuaChangedDelegate luaChangedHandler)
		{
			this.watchList.Add(new LuaWatchItem(luaExpression, luaChangedHandler));
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003054 File Offset: 0x00001254
		public void RemoveObserver(string luaExpression, LuaChangedDelegate luaChangedHandler)
		{
			this.watchList.RemoveAll((LuaWatchItem watchItem) => watchItem.Matches(luaExpression, luaChangedHandler));
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003090 File Offset: 0x00001290
		public void RemoveAllObservers()
		{
			this.watchList.Clear();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000030A0 File Offset: 0x000012A0
		public void NotifyObservers()
		{
			if (this.watchList.Count > 0)
			{
				try
				{
					int count = this.watchList.Count;
					for (int i = count - 1; i >= 0; i--)
					{
						this.watchList[i].Check();
					}
				}
				catch (InvalidOperationException)
				{
				}
			}
		}

		// Token: 0x0400001F RID: 31
		private List<LuaWatchItem> watchList = new List<LuaWatchItem>();
	}
}
