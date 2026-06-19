using System;
using System.Collections.Generic;
using System.Linq;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x0200000C RID: 12
	public static class LuaListUtility
	{
		// Token: 0x06000070 RID: 112 RVA: 0x00002F8A File Offset: 0x0000118A
		public static bool IsLuaNullOrEmpty(string value)
		{
			return string.IsNullOrEmpty(value) || value == "nil";
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00002FA4 File Offset: 0x000011A4
		public static List<string> GetList(string variableName)
		{
			List<string> list;
			try
			{
				string asString = DialogueLua.GetVariable(variableName).AsString;
				if (LuaListUtility.IsLuaNullOrEmpty(asString))
				{
					list = new List<string>();
				}
				else
				{
					list = (from x in asString.Split('|', StringSplitOptions.None)
						where !string.IsNullOrWhiteSpace(x)
						select x).ToList<string>();
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				list = new List<string>();
			}
			return list;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003024 File Offset: 0x00001224
		public static void SetList(string variableName, IEnumerable<string> values)
		{
			try
			{
				string text = string.Join('|'.ToString(), values.Where((string x) => !string.IsNullOrWhiteSpace(x)));
				DialogueLua.SetVariable(variableName, text);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003088 File Offset: 0x00001288
		public static bool AddUnique(string variableName, string value)
		{
			bool flag;
			try
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					flag = false;
				}
				else
				{
					List<string> list = LuaListUtility.GetList(variableName);
					if (list.Contains(value))
					{
						flag = false;
					}
					else
					{
						list.Add(value);
						LuaListUtility.SetList(variableName, list);
						flag = true;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000030E4 File Offset: 0x000012E4
		public static bool AddUniqueWithLimit(string variableName, string value, int max)
		{
			bool flag;
			try
			{
				List<string> list = LuaListUtility.GetList(variableName);
				if (list.Count >= max)
				{
					flag = false;
				}
				else if (list.Contains(value))
				{
					flag = false;
				}
				else
				{
					list.Add(value);
					LuaListUtility.SetList(variableName, list);
					flag = true;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003140 File Offset: 0x00001340
		public static bool Contains(string variableName, string value)
		{
			return LuaListUtility.GetList(variableName).Contains(value);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003150 File Offset: 0x00001350
		public static bool CanAdd(string variableName, string value, int max)
		{
			List<string> list = LuaListUtility.GetList(variableName);
			return list.Count < max && !list.Contains(value);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000317C File Offset: 0x0000137C
		public static bool Remove(string variableName, string value)
		{
			bool flag2;
			try
			{
				List<string> list = LuaListUtility.GetList(variableName);
				bool flag = list.Remove(value);
				if (flag)
				{
					LuaListUtility.SetList(variableName, list);
				}
				flag2 = flag;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000031C0 File Offset: 0x000013C0
		public static void Clear(string variableName)
		{
			try
			{
				DialogueLua.SetVariable(variableName, string.Empty);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000031F4 File Offset: 0x000013F4
		public static int Count(string variableName)
		{
			return LuaListUtility.GetList(variableName).Count;
		}

		// Token: 0x0400001B RID: 27
		private const char Separator = '|';
	}
}
