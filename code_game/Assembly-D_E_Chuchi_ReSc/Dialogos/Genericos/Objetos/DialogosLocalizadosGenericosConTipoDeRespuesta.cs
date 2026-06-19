using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos
{
	// Token: 0x0200020E RID: 526
	[CreateAssetMenu(fileName = "DialogosLocalizadosGenericosConTipoDeRespuesta", menuName = "Objetos/Dialogos/Genericos/Dialogos Localizados Genericos Con Tipo De Respuesta")]
	public sealed class DialogosLocalizadosGenericosConTipoDeRespuesta : ListaDeDialogos<DialogoInfoGenericoConTipoDeRespuesta>, ICollecionDeDialogoInfoLocalizados, ICollecionDeDialogoInfo
	{
		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000C15 RID: 3093 RVA: 0x00035E82 File Offset: 0x00034082
		public Localizacion paraCulturas
		{
			get
			{
				return this.m_Localizacion;
			}
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000C16 RID: 3094 RVA: 0x00035E8A File Offset: 0x0003408A
		public Personalidad.TipoDeRespuestaDeDialogoDeHeroina paraTipos
		{
			get
			{
				return this.m_para;
			}
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06000C17 RID: 3095 RVA: 0x00035E82 File Offset: 0x00034082
		public int paraCulturasFlags
		{
			get
			{
				return (int)this.m_Localizacion;
			}
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000C18 RID: 3096 RVA: 0x00035E8A File Offset: 0x0003408A
		public int paraTiposFlags
		{
			get
			{
				return (int)this.m_para;
			}
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x00035E92 File Offset: 0x00034092
		public bool ParaCultura(Localizacion localization)
		{
			return this.paraCulturasFlags.IsAnyFlagSet((int)localization);
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x00035EA0 File Offset: 0x000340A0
		public bool ParaTipo(Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipo)
		{
			return this.paraTiposFlags.IsAnyFlagSet((int)tipo);
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x00035EAE File Offset: 0x000340AE
		protected override void OnInitiated()
		{
			base.OnInitiated();
			if (this.m_Localizacion == Localizacion.None)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x040009C8 RID: 2504
		[SerializeField]
		private Localizacion m_Localizacion = (Localizacion)(-1);

		// Token: 0x040009C9 RID: 2505
		[SerializeField]
		private Personalidad.TipoDeRespuestaDeDialogoDeHeroina m_para = (Personalidad.TipoDeRespuestaDeDialogoDeHeroina)(-1);
	}
}
