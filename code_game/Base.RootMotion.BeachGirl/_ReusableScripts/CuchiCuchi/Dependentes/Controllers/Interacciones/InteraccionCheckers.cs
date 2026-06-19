using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000E6 RID: 230
	[RequireComponent(typeof(Interaccion))]
	public class InteraccionCheckers : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000867 RID: 2151 RVA: 0x00026714 File Offset: 0x00024914
		public Transform checkersRoot
		{
			get
			{
				return this.m_checkersRoot;
			}
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x0002671C File Offset: 0x0002491C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.m_checkersRoot == null)
			{
				throw new ArgumentNullException("checkersRoot", "checkersRoot null reference.");
			}
		}

		// Token: 0x0400057D RID: 1405
		[SerializeField]
		private Transform m_checkersRoot;
	}
}
