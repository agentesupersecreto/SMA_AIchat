using System;
using System.Reflection;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000269 RID: 617
	public static class NWNTools
	{
		// Token: 0x06001A98 RID: 6808 RVA: 0x0002D660 File Offset: 0x0002B860
		public static void RegisterNWScriptFunction(object target, MethodInfo function)
		{
			Lua.RegisterFunction("NWScript", target, function);
		}
	}
}
