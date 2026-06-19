using System;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync
{
	// Token: 0x02000278 RID: 632
	[Serializable]
	public struct SilabaPronunciableEnTiempo
	{
		// Token: 0x06000E04 RID: 3588 RVA: 0x00041DC9 File Offset: 0x0003FFC9
		public SilabaPronunciableEnTiempo(SilabaPronunciable silabaPronunciable, float tiempo)
		{
			this.tiempo = tiempo;
			this.silabaPronunciable = silabaPronunciable;
		}

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06000E05 RID: 3589 RVA: 0x00041DD9 File Offset: 0x0003FFD9
		public float duration
		{
			get
			{
				return this.silabaPronunciable.duration;
			}
		}

		// Token: 0x04000C08 RID: 3080
		public float tiempo;

		// Token: 0x04000C09 RID: 3081
		public SilabaPronunciable silabaPronunciable;
	}
}
