using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Scenas
{
	// Token: 0x020000C9 RID: 201
	[RequireComponent(typeof(InteraccionesEnScena))]
	public sealed class InteraccionesEnScenaUpdater : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x00014087 File Offset: 0x00012287
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0001408F File Offset: 0x0001228F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteraccionesEnScena = base.GetComponent<InteraccionesEnScena>();
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x000140A3 File Offset: 0x000122A3
		public override void OnUpdateEvent1()
		{
			this.m_InteraccionesEnScena.UpdateBuffered();
		}

		// Token: 0x04000354 RID: 852
		private InteraccionesEnScena m_InteraccionesEnScena;
	}
}
