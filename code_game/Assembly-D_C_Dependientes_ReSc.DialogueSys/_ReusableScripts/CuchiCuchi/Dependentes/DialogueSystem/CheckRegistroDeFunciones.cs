using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000011 RID: 17
	public abstract class CheckRegistroDeFunciones<T> : CheckRegistroDeFunciones where T : Component
	{
		// Token: 0x06000089 RID: 137 RVA: 0x00003C3C File Offset: 0x00001E3C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			T componentNotNull = Singleton<MainDialogueSystemEvents>.instance.dialogueSystemEvents.transform.Find("FuncionesRegistradas").GetComponentNotNull<T>();
			this.OnAdded(componentNotNull);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003C75 File Offset: 0x00001E75
		protected virtual void OnAdded(T registroDeFunciones)
		{
		}
	}
}
