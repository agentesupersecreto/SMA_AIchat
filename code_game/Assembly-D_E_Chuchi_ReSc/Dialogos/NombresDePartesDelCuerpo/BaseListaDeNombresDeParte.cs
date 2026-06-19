using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.NombresDePartesDelCuerpo
{
	// Token: 0x020001E8 RID: 488
	public abstract class BaseListaDeNombresDeParte<T_dialogoInfo, T_ParteEnum> : ListaDeDialogos<T_dialogoInfo> where T_dialogoInfo : DialogoInfoParteDelCuerpo, new() where T_ParteEnum : struct
	{
		// Token: 0x06000B95 RID: 2965 RVA: 0x000346C8 File Offset: 0x000328C8
		public void CopiarDe(BaseListaDeNombresDeParte<T_dialogoInfo, T_ParteEnum> other)
		{
			this.m_Localizacion = other.m_Localizacion;
			this.m_parte = other.m_parte;
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000B96 RID: 2966 RVA: 0x000346E2 File Offset: 0x000328E2
		public T_ParteEnum parte
		{
			get
			{
				return this.m_parte;
			}
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000B97 RID: 2967 RVA: 0x000346EA File Offset: 0x000328EA
		public Localizacion paraCulturas
		{
			get
			{
				return this.m_Localizacion;
			}
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000B98 RID: 2968 RVA: 0x000346EA File Offset: 0x000328EA
		public int paraCulturasFlags
		{
			get
			{
				return (int)this.m_Localizacion;
			}
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x000346F2 File Offset: 0x000328F2
		public bool ParaCultura(Localizacion localization)
		{
			return this.paraCulturasFlags.IsAnyFlagSet((int)localization);
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x00034700 File Offset: 0x00032900
		protected override void OnInitiated()
		{
			base.OnInitiated();
			if (this.m_Localizacion == Localizacion.None)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x00034718 File Offset: 0x00032918
		public DialogoInfoParteDelCuerpo ObtenerReal()
		{
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo;
			try
			{
				base.CheckInit();
				if (this.m_items.Count == 0)
				{
					dialogoInfoParteDelCuerpo = null;
				}
				else
				{
					for (int i = 0; i < this.m_items.Count; i++)
					{
						T_dialogoInfo t_dialogoInfo = this.m_items[i];
						if (t_dialogoInfo.esNombreReal)
						{
							return t_dialogoInfo;
						}
					}
					dialogoInfoParteDelCuerpo = base.ObtenerPrimero();
				}
			}
			catch (Exception)
			{
				throw;
			}
			return dialogoInfoParteDelCuerpo;
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x00034798 File Offset: 0x00032998
		public DialogoInfoParteDelCuerpo ObtenerPluralOrFirst()
		{
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo;
			try
			{
				base.CheckInit();
				if (this.m_items.Count == 0)
				{
					dialogoInfoParteDelCuerpo = null;
				}
				else
				{
					for (int i = 0; i < this.m_items.Count; i++)
					{
						T_dialogoInfo t_dialogoInfo = this.m_items[i];
						if (t_dialogoInfo.plural)
						{
							return t_dialogoInfo;
						}
					}
					Debug.LogError("No Plural Found For " + this.m_parte.ToString(), this);
					dialogoInfoParteDelCuerpo = base.ObtenerPrimero();
				}
			}
			catch (Exception)
			{
				throw;
			}
			return dialogoInfoParteDelCuerpo;
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x00034838 File Offset: 0x00032A38
		public DialogoInfoParteDelCuerpo ObtenerSingularOrFirst()
		{
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo;
			try
			{
				base.CheckInit();
				if (this.m_items.Count == 0)
				{
					dialogoInfoParteDelCuerpo = null;
				}
				else
				{
					for (int i = 0; i < this.m_items.Count; i++)
					{
						T_dialogoInfo t_dialogoInfo = this.m_items[i];
						if (t_dialogoInfo.singular)
						{
							return t_dialogoInfo;
						}
					}
					Debug.LogError("No Singular Found For " + this.m_parte.ToString(), this);
					dialogoInfoParteDelCuerpo = base.ObtenerPrimero();
				}
			}
			catch (Exception)
			{
				throw;
			}
			return dialogoInfoParteDelCuerpo;
		}

		// Token: 0x04000948 RID: 2376
		[SerializeField]
		private Localizacion m_Localizacion = (Localizacion)(-1);

		// Token: 0x04000949 RID: 2377
		[SerializeField]
		private T_ParteEnum m_parte;
	}
}
