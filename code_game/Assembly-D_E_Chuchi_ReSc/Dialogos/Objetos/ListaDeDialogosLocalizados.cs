using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Objetos
{
	// Token: 0x020001DE RID: 478
	public class ListaDeDialogosLocalizados<T_item> : ListaDeDialogos<T_item>, ICollecionDeDialogoInfoLocalizados, ICollecionDeDialogoInfo where T_item : DialogoInfo, new()
	{
		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000B66 RID: 2918 RVA: 0x000340C4 File Offset: 0x000322C4
		[Obsolete("", true)]
		public string cultura
		{
			get
			{
				return this.m_cultura;
			}
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000B67 RID: 2919 RVA: 0x000340CC File Offset: 0x000322CC
		public Localizacion paraCulturas
		{
			get
			{
				return this.m_Localizacion;
			}
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000B68 RID: 2920 RVA: 0x000340CC File Offset: 0x000322CC
		public int paraCulturasFlags
		{
			get
			{
				return (int)this.m_Localizacion;
			}
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x000340D4 File Offset: 0x000322D4
		public bool ParaCultura(Localizacion localization)
		{
			return this.paraCulturasFlags.IsAnyFlagSet((int)localization);
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x000340E2 File Offset: 0x000322E2
		protected override void OnInitiated()
		{
			base.OnInitiated();
			if (this.m_Localizacion == Localizacion.None)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x04000935 RID: 2357
		[HideInInspector]
		[SerializeField]
		private string m_cultura = "US";

		// Token: 0x04000936 RID: 2358
		[SerializeField]
		private Localizacion m_Localizacion;
	}
}
