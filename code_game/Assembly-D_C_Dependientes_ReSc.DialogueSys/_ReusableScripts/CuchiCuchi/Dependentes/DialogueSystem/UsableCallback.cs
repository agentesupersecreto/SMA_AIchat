using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000025 RID: 37
	public class UsableCallback : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000134 RID: 308 RVA: 0x00006807 File Offset: 0x00004A07
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000681B File Offset: 0x00004A1B
		public void Init(IUsadoListener listiner)
		{
			if (listiner == null)
			{
				throw new ArgumentNullException("listiner", "listiner null reference.");
			}
			this.m_listiner = listiner;
			this.m_listinerDebug = listiner as Object;
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000684F File Offset: 0x00004A4F
		public void OnUse(Transform player)
		{
			if (this.m_listiner != null)
			{
				this.m_listiner.OnUsado(base.GetComponentInParent<IUsable>(), player);
			}
		}

		// Token: 0x040000A7 RID: 167
		private IUsadoListener m_listiner;

		// Token: 0x040000A8 RID: 168
		[ReadOnlyUI]
		[SerializeField]
		private Object m_listinerDebug;
	}
}
