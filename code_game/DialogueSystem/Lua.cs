using System;
using System.Reflection;
using Language.Lua;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000004 RID: 4
	public sealed class Lua
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000A RID: 10 RVA: 0x0000230C File Offset: 0x0000050C
		// (set) Token: 0x0600000B RID: 11 RVA: 0x00002314 File Offset: 0x00000514
		public static bool WasInvoked { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000C RID: 12 RVA: 0x0000231C File Offset: 0x0000051C
		// (set) Token: 0x0600000D RID: 13 RVA: 0x00002324 File Offset: 0x00000524
		public static bool MuteExceptions
		{
			get
			{
				return Lua.muteExceptions;
			}
			set
			{
				Lua.muteExceptions = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000E RID: 14 RVA: 0x0000232C File Offset: 0x0000052C
		// (set) Token: 0x0600000F RID: 15 RVA: 0x00002334 File Offset: 0x00000534
		public static bool WarnRegisteringExistingFunction
		{
			get
			{
				return Lua.warnRegisteringExistingFunction;
			}
			set
			{
				Lua.warnRegisteringExistingFunction = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000010 RID: 16 RVA: 0x0000233C File Offset: 0x0000053C
		public static LuaTable Environment
		{
			get
			{
				return Lua.environment;
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002344 File Offset: 0x00000544
		public static Lua.Result Run(string luaCode, bool debug, bool allowExceptions)
		{
			return new Lua.Result(Lua.RunRaw(luaCode, debug, allowExceptions));
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002354 File Offset: 0x00000554
		public static Lua.Result Run(string luaCode, bool debug)
		{
			return Lua.Run(luaCode, debug, false);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002360 File Offset: 0x00000560
		public static Lua.Result Run(string luaCode)
		{
			return Lua.Run(luaCode, false, false);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000236C File Offset: 0x0000056C
		public static bool IsTrue(string luaCondition, bool debug, bool allowExceptions)
		{
			return Tools.IsStringNullOrEmptyOrWhitespace(luaCondition) || Lua.Run("return " + luaCondition, debug, allowExceptions).AsBool;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000023A4 File Offset: 0x000005A4
		public static bool IsTrue(string luaCondition, bool debug)
		{
			return Lua.IsTrue(luaCondition, debug, false);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000023B0 File Offset: 0x000005B0
		public static bool IsTrue(string luaCondition)
		{
			return Lua.IsTrue(luaCondition, false, false);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000023BC File Offset: 0x000005BC
		public static LuaValue RunRaw(string luaCode, bool debug, bool allowExceptions)
		{
			LuaValue luaValue;
			try
			{
				if (string.IsNullOrEmpty(luaCode))
				{
					luaValue = null;
				}
				else
				{
					if (Debug.isDebugBuild && debug)
					{
						Debug.Log(string.Format("{0}: Lua({1})", new object[] { "Dialogue System", luaCode }));
					}
					Lua.WasInvoked = true;
					luaValue = LuaInterpreter.Interpreter(luaCode, Lua.environment);
				}
			}
			catch (Exception ex)
			{
				if (Debug.isDebugBuild && !Lua.MuteExceptions)
				{
					Debug.LogError(string.Format("{0}: Lua code '{1}' threw exception '{2}'", new object[] { "Dialogue System", luaCode, ex.Message }));
				}
				if (allowExceptions)
				{
					throw ex;
				}
				luaValue = null;
			}
			return luaValue;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002498 File Offset: 0x00000698
		public static LuaValue RunRaw(string luaCode, bool debug)
		{
			return Lua.RunRaw(luaCode, debug, false);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000024A4 File Offset: 0x000006A4
		public static LuaValue RunRaw(string luaCode)
		{
			return Lua.RunRaw(luaCode, false, false);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000024B0 File Offset: 0x000006B0
		public static void RegisterFunction(string functionName, object target, MethodInfo method)
		{
			if (Lua.environment.ContainsKey(new LuaString(functionName)))
			{
				if (Lua.warnRegisteringExistingFunction && DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Can't register Lua function {1}. A function with that name is already registered.", new object[] { "Dialogue System", functionName }));
				}
			}
			else
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Registering Lua function {1}", new object[] { "Dialogue System", functionName }));
				}
				Lua.environment.RegisterMethodFunction(functionName, target, method);
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002548 File Offset: 0x00000748
		public static void UnregisterFunction(string functionName)
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Unregistering Lua function {1}", new object[] { "Dialogue System", functionName }));
			}
			Lua.environment.SetNameValue(functionName, LuaNil.Nil);
		}

		// Token: 0x04000006 RID: 6
		public static readonly Lua.Result NoResult = new Lua.Result(null);

		// Token: 0x04000007 RID: 7
		private static bool muteExceptions = false;

		// Token: 0x04000008 RID: 8
		private static bool warnRegisteringExistingFunction = false;

		// Token: 0x04000009 RID: 9
		private static LuaTable environment = LuaInterpreter.CreateGlobalEnviroment();

		// Token: 0x02000005 RID: 5
		public struct Result
		{
			// Token: 0x0600001C RID: 28 RVA: 0x00002588 File Offset: 0x00000788
			public Result(LuaValue luaValue)
			{
				this.luaValue = luaValue;
				this.luaTableWrapper = new LuaTableWrapper(luaValue as LuaTable);
			}

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x0600001D RID: 29 RVA: 0x000025A4 File Offset: 0x000007A4
			public bool HasReturnValue
			{
				get
				{
					return this.luaValue != null;
				}
			}

			// Token: 0x17000007 RID: 7
			// (get) Token: 0x0600001E RID: 30 RVA: 0x000025B4 File Offset: 0x000007B4
			public string AsString
			{
				get
				{
					return (!this.HasReturnValue) ? string.Empty : this.luaValue.ToString();
				}
			}

			// Token: 0x17000008 RID: 8
			// (get) Token: 0x0600001F RID: 31 RVA: 0x000025E4 File Offset: 0x000007E4
			public bool AsBool
			{
				get
				{
					return (!this.HasReturnValue || !(this.luaValue is LuaBoolean)) ? (string.Compare(this.AsString, "True", StringComparison.OrdinalIgnoreCase) == 0) : (this.luaValue as LuaBoolean).BoolValue;
				}
			}

			// Token: 0x17000009 RID: 9
			// (get) Token: 0x06000020 RID: 32 RVA: 0x00002638 File Offset: 0x00000838
			public float AsFloat
			{
				get
				{
					return (!this.HasReturnValue) ? 0f : Tools.StringToFloat(this.luaValue.ToString());
				}
			}

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x06000021 RID: 33 RVA: 0x00002660 File Offset: 0x00000860
			public int AsInt
			{
				get
				{
					return (!this.HasReturnValue) ? 0 : Tools.StringToInt(this.luaValue.ToString());
				}
			}

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000022 RID: 34 RVA: 0x00002684 File Offset: 0x00000884
			public bool IsTable
			{
				get
				{
					return this.HasReturnValue & (this.luaValue is LuaTable);
				}
			}

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x06000023 RID: 35 RVA: 0x0000269C File Offset: 0x0000089C
			public LuaTableWrapper AsTable
			{
				get
				{
					return this.luaTableWrapper;
				}
			}

			// Token: 0x0400000B RID: 11
			public LuaValue luaValue;

			// Token: 0x0400000C RID: 12
			public LuaTableWrapper luaTableWrapper;
		}
	}
}
