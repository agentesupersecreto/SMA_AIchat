using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000008 RID: 8
	public class LuaWatchItem
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00002F00 File Offset: 0x00001100
		public LuaWatchItem(string luaExpression, LuaChangedDelegate luaChangedHandler)
		{
			this.LuaExpression = ((!luaExpression.StartsWith("return ")) ? ("return " + luaExpression) : luaExpression);
			this.currentValue = Lua.Run(this.LuaExpression).AsString;
			this.LuaChanged = luaChangedHandler;
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000038 RID: 56 RVA: 0x00002F5C File Offset: 0x0000115C
		// (remove) Token: 0x06000039 RID: 57 RVA: 0x00002F78 File Offset: 0x00001178
		private event LuaChangedDelegate LuaChanged;

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002F94 File Offset: 0x00001194
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00002F9C File Offset: 0x0000119C
		public string LuaExpression { get; set; }

		// Token: 0x0600003C RID: 60 RVA: 0x00002FA8 File Offset: 0x000011A8
		public bool Matches(string luaExpression, LuaChangedDelegate luaChangedHandler)
		{
			return luaChangedHandler == this.LuaChanged && string.Equals(luaExpression, this.LuaExpression);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002FD8 File Offset: 0x000011D8
		public void Check()
		{
			Lua.Result result = Lua.Run(this.LuaExpression);
			string asString = result.AsString;
			if (!string.Equals(this.currentValue, asString))
			{
				this.currentValue = asString;
				if (this.LuaChanged != null)
				{
					this.LuaChanged(this, result);
				}
			}
		}

		// Token: 0x0400001C RID: 28
		private string currentValue;
	}
}
