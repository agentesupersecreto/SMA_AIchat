using System;
using Assets.Base.CustomMonoBehaviours.Runtime;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.Spa.Globales
{
	// Token: 0x02000073 RID: 115
	public class SpaSounds : InstantiatedSingleton<SpaSounds>
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060004E7 RID: 1255 RVA: 0x0001C88C File Offset: 0x0001AA8C
		public AudioSource tip
		{
			get
			{
				return this.m_tip;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060004E8 RID: 1256 RVA: 0x0001C894 File Offset: 0x0001AA94
		public AudioSource alarm
		{
			get
			{
				return this.m_alarm;
			}
		}

		// Token: 0x040002F1 RID: 753
		[SerializeField]
		private AudioSource m_tip;

		// Token: 0x040002F2 RID: 754
		[SerializeField]
		private AudioSource m_alarm;
	}
}
