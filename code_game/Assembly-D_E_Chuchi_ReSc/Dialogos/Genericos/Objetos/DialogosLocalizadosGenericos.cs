using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos
{
	// Token: 0x0200020B RID: 523
	[CreateAssetMenu(fileName = "DialogosLocalizadosGenericos", menuName = "Objetos/Dialogos/Genericos/Dialogos Localizados Genericos")]
	public sealed class DialogosLocalizadosGenericos : ListaDeDialogos<DialogoInfoGenerico>, ICollecionDeDialogoInfoLocalizados, ICollecionDeDialogoInfo
	{
		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000BF2 RID: 3058 RVA: 0x0003568A File Offset: 0x0003388A
		public Localizacion paraCulturas
		{
			get
			{
				return this.m_Localizacion;
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000BF3 RID: 3059 RVA: 0x0003568A File Offset: 0x0003388A
		public int paraCulturasFlags
		{
			get
			{
				return (int)this.m_Localizacion;
			}
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x00035692 File Offset: 0x00033892
		public bool ParaCultura(Localizacion localization)
		{
			return this.paraCulturasFlags.IsAnyFlagSet((int)localization);
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x000356A0 File Offset: 0x000338A0
		protected override void OnInitiated()
		{
			base.OnInitiated();
			if (this.m_Localizacion == Localizacion.None)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x040009C2 RID: 2498
		[SerializeField]
		private Localizacion m_Localizacion = (Localizacion)(-1);
	}
}
