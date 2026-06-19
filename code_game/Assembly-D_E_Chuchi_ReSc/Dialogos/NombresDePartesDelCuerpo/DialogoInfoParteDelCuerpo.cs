using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.NombresDePartesDelCuerpo
{
	// Token: 0x020001E9 RID: 489
	[Serializable]
	public class DialogoInfoParteDelCuerpo : DialogoInfo
	{
		// Token: 0x06000B9F RID: 2975 RVA: 0x000348E8 File Offset: 0x00032AE8
		protected override void OnCloneNoInicializado<T>(T clonado)
		{
			base.OnCloneNoInicializado<T>(clonado);
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo = clonado as DialogoInfoParteDelCuerpo;
			if (dialogoInfoParteDelCuerpo != null)
			{
				dialogoInfoParteDelCuerpo.m_plural = this.m_plural;
				dialogoInfoParteDelCuerpo.m_singular = this.m_singular;
				dialogoInfoParteDelCuerpo.m_esNombreReal = this.m_esNombreReal;
			}
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x0003492F File Offset: 0x00032B2F
		public override void Init(float provTotal, int index, IList<DialogoInfo> anteriores)
		{
			base.Init(provTotal, index, anteriores);
			if (!this.m_singular && !this.m_plural)
			{
				Debug.LogError("DialogoInfoParteDelCuerpo no es para plurar ni singular: " + base.seccionado);
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000BA1 RID: 2977 RVA: 0x0003495F File Offset: 0x00032B5F
		public bool singular
		{
			get
			{
				return this.m_singular;
			}
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000BA2 RID: 2978 RVA: 0x00034967 File Offset: 0x00032B67
		public bool plural
		{
			get
			{
				return this.m_plural;
			}
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000BA3 RID: 2979 RVA: 0x0003496F File Offset: 0x00032B6F
		public bool esNombreReal
		{
			get
			{
				return this.m_esNombreReal;
			}
		}

		// Token: 0x0400094A RID: 2378
		[SerializeField]
		private bool m_esNombreReal;

		// Token: 0x0400094B RID: 2379
		[SerializeField]
		private bool m_singular;

		// Token: 0x0400094C RID: 2380
		[SerializeField]
		private bool m_plural;
	}
}
