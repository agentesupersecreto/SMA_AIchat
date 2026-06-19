using System;
using Assets.TValle.BeachGirl.Runtime;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync
{
	// Token: 0x0200027B RID: 635
	[Serializable]
	public class ValorDePhoneme
	{
		// Token: 0x06000E20 RID: 3616 RVA: 0x00042B71 File Offset: 0x00040D71
		public ValorDePhoneme(Phoneme neme)
		{
			this.m_phoneme = neme;
		}

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06000E21 RID: 3617 RVA: 0x00042B80 File Offset: 0x00040D80
		public Phoneme phoneme
		{
			get
			{
				return this.m_phoneme;
			}
		}

		// Token: 0x04000C12 RID: 3090
		[SerializeField]
		[ReadOnlyUI]
		private Phoneme m_phoneme;

		// Token: 0x04000C13 RID: 3091
		public float valor;
	}
}
