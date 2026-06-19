using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.FuncionesRegistradas
{
	// Token: 0x02000053 RID: 83
	public class NpcFunciones : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000270 RID: 624 RVA: 0x0000CC86 File Offset: 0x0000AE86
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("NpcExisteEmMemoria", this, typeof(NpcFunciones).GetMethod("NpcExisteEmMemoria"));
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000CCAD File Offset: 0x0000AEAD
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("NpcExisteEmMemoria");
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000CCC0 File Offset: 0x0000AEC0
		public bool NpcExisteEmMemoria()
		{
			Debug.LogException(new NotImplementedException(), this);
			return false;
		}
	}
}
