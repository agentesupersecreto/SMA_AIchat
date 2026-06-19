using System;
using Assets.Base.Behaviours.Runtime.Anims;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.StandardizedPatient
{
	// Token: 0x02000065 RID: 101
	public class CamillaMedica : CustomMonobehaviour
	{
		// Token: 0x060004AB RID: 1195 RVA: 0x0001BD54 File Offset: 0x00019F54
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_mainSentadero == null)
			{
				throw new ArgumentNullException("m_mainSentadero", "m_mainSentadero null reference.");
			}
		}

		// Token: 0x04000293 RID: 659
		[SerializeField]
		private SillaGenerica m_mainSentadero;
	}
}
