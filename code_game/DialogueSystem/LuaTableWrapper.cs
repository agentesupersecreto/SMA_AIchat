using System;
using System.Collections.Generic;
using Language.Lua;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000007 RID: 7
	public class LuaTableWrapper
	{
		// Token: 0x06000030 RID: 48 RVA: 0x00002CE4 File Offset: 0x00000EE4
		public LuaTableWrapper(LuaTable luaTable)
		{
			this.luaTable = luaTable;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002CF4 File Offset: 0x00000EF4
		public bool IsValid
		{
			get
			{
				return this.luaTable != null;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002D04 File Offset: 0x00000F04
		public int Count
		{
			get
			{
				return (this.luaTable == null) ? 0 : Mathf.Max(this.luaTable.Length, this.luaTable.Count);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00002D40 File Offset: 0x00000F40
		public IEnumerable<string> Keys
		{
			get
			{
				if (this.luaTable != null && this.Count > 0)
				{
					foreach (LuaValue key in this.luaTable.Keys)
					{
						yield return key.ToString();
					}
				}
				yield break;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002D64 File Offset: 0x00000F64
		public IEnumerable<object> Values
		{
			get
			{
				if (this.luaTable != null)
				{
					if (this.luaTable.Length > 0)
					{
						foreach (LuaValue value in this.luaTable.ListValues)
						{
							yield return (!(value is LuaTable)) ? LuaInterpreterExtensions.LuaValueToObject(value) : new LuaTableWrapper(value as LuaTable);
						}
					}
					else if (this.luaTable.Count > 0)
					{
						foreach (KeyValuePair<LuaValue, LuaValue> kvp in this.luaTable.KeyValuePairs)
						{
							yield return (!(kvp.Value is LuaTable)) ? LuaInterpreterExtensions.LuaValueToObject(kvp.Value) : new LuaTableWrapper(kvp.Value as LuaTable);
						}
					}
				}
				yield break;
			}
		}

		// Token: 0x17000011 RID: 17
		public object this[string key]
		{
			get
			{
				if (this.luaTable == null)
				{
					if (DialogueDebug.LogErrors)
					{
						Debug.LogError(string.Format("{0}: Lua table is null; lookup[{1}] failed", new object[] { "Dialogue System", key }));
					}
					return null;
				}
				LuaValue luaValue = LuaNil.Nil;
				if (this.luaTable.Length > 0)
				{
					luaValue = this.luaTable.GetValue(Tools.StringToInt(key));
				}
				else
				{
					LuaValue key2 = this.luaTable.GetKey(key);
					if (key2 == LuaNil.Nil)
					{
						return null;
					}
					luaValue = this.luaTable.GetValue(key);
				}
				if (luaValue is LuaTable)
				{
					return new LuaTableWrapper(luaValue as LuaTable);
				}
				return LuaInterpreterExtensions.LuaValueToObject(luaValue);
			}
		}

		// Token: 0x17000012 RID: 18
		public object this[int key]
		{
			get
			{
				if (this.luaTable == null)
				{
					if (DialogueDebug.LogErrors)
					{
						Debug.LogError(string.Format("{0}: Lua table is null; lookup[{1}] failed", new object[] { "Dialogue System", key }));
					}
					return null;
				}
				LuaValue luaValue = LuaNil.Nil;
				if (this.luaTable.Length > 0)
				{
					luaValue = this.luaTable.GetValue(key);
				}
				else
				{
					LuaValue key2 = this.luaTable.GetKey(key.ToString());
					if (key2 == LuaNil.Nil)
					{
						return null;
					}
					luaValue = this.luaTable.GetValue(key);
				}
				if (luaValue is LuaTable)
				{
					return new LuaTableWrapper(luaValue as LuaTable);
				}
				return LuaInterpreterExtensions.LuaValueToObject(luaValue);
			}
		}

		// Token: 0x0400001B RID: 27
		public LuaTable luaTable;
	}
}
