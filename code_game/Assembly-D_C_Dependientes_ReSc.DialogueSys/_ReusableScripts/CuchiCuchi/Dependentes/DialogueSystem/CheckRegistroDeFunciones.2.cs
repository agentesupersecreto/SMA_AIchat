using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000012 RID: 18
	public abstract class CheckRegistroDeFunciones : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x0600008C RID: 140 RVA: 0x00003C80 File Offset: 0x00001E80
		public static T TryGetRegistroDeFunciones<T>() where T : Component
		{
			Transform transform = Singleton<MainDialogueSystemEvents>.instance.dialogueSystemEvents.transform.Find("FuncionesRegistradas");
			if (transform == null)
			{
				return default(T);
			}
			T t;
			if (transform.TryGetComponent<T>(out t))
			{
				return t;
			}
			return default(T);
		}

		// Token: 0x0400002C RID: 44
		public const string rootName = "FuncionesRegistradas";
	}
}
