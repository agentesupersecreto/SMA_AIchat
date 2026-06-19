using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Objetos
{
	// Token: 0x020001DC RID: 476
	public abstract class EnvolturaCondicionalDeGruposDeDialogos<T_GrupoDeDialogos, T_dialogos, T_dialogoInfo> : EnvolturaCondicionalDeGrupoDeDialogos where T_GrupoDeDialogos : SimpleHolderDeDialogosDeCulturas<T_dialogos, T_dialogoInfo>, IHolderDeCollecionDeDialogoInfo where T_dialogos : ListaDeDialogos<T_dialogoInfo> where T_dialogoInfo : DialogoInfo, new()
	{
		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000B60 RID: 2912 RVA: 0x00033FD4 File Offset: 0x000321D4
		public override IReadOnlyList<IHolderDeCollecionDeDialogoInfo> grupos
		{
			get
			{
				return this.gruposDeDialogos;
			}
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000B61 RID: 2913 RVA: 0x00033FDC File Offset: 0x000321DC
		public IReadOnlyList<T_GrupoDeDialogos> gruposDeDialogos
		{
			get
			{
				return this.m_grupos;
			}
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x00033FE4 File Offset: 0x000321E4
		public override bool IsValid()
		{
			for (int i = 0; i < this.m_grupos.Length; i++)
			{
				if (!this.m_grupos[i].IsValid())
				{
					return false;
				}
			}
			return this.m_grupos.Length != 0;
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x00034028 File Offset: 0x00032228
		[Obsolete("no usar envolturas para obtener textos", true)]
		public T_dialogoInfo Obtener(Localizacion? cultura = null, T_dialogoInfo last = default(T_dialogoInfo))
		{
			T_dialogoInfo t_dialogoInfo;
			if (this.m_grupos.Length != 0)
			{
				Debug.LogWarning("No existe grupo", this);
				t_dialogoInfo = default(T_dialogoInfo);
				return t_dialogoInfo;
			}
			try
			{
				if (this.m_grupos == null || this.m_grupos.Length == 0)
				{
					t_dialogoInfo = default(T_dialogoInfo);
					t_dialogoInfo = t_dialogoInfo;
				}
				else
				{
					int num = Random.Range(0, this.m_grupos.Length);
					t_dialogoInfo = this.m_grupos[num].Obtener(cultura, last);
				}
			}
			catch (Exception)
			{
				throw;
			}
			return t_dialogoInfo;
		}

		// Token: 0x04000934 RID: 2356
		[CoolArrayItem]
		[SerializeField]
		private T_GrupoDeDialogos[] m_grupos;
	}
}
