using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.FuncionesRegistradas
{
	// Token: 0x02000052 RID: 82
	public class DebugLogFunciones : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x0600026B RID: 619 RVA: 0x0000CBE8 File Offset: 0x0000ADE8
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("DebugLog", this, typeof(DebugLogFunciones).GetMethod("DebugLog"));
			Lua.RegisterFunction("DebugLogError", this, typeof(DebugLogFunciones).GetMethod("DebugLogError"));
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000CC39 File Offset: 0x0000AE39
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("DebugLog");
			Lua.UnregisterFunction("DebugLogError");
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000CC56 File Offset: 0x0000AE56
		public bool DebugLog(string log)
		{
			if (string.IsNullOrEmpty(log))
			{
				return false;
			}
			Debug.Log(log, this);
			return true;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000CC6A File Offset: 0x0000AE6A
		public bool DebugLogError(string log)
		{
			if (string.IsNullOrEmpty(log))
			{
				return false;
			}
			Debug.LogWarning(log, this);
			return true;
		}
	}
}
