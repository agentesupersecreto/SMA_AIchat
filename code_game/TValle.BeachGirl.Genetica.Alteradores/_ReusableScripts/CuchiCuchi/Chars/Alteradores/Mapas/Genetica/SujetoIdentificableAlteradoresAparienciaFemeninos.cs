using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using Assets._ReusableScripts.Genetica;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica
{
	// Token: 0x0200006F RID: 111
	[CreateAssetMenu(fileName = "SujetoIdentificableAlteradoresAparienciaFemeninos", menuName = "Objetos/Genetica/Sujeto Identificable Alteradores Apariencia Femeninos")]
	public class SujetoIdentificableAlteradoresAparienciaFemeninos : SujetoAlteradoresAparienciaFemeninos, ISujetoIdentificable, ISujeto, ISujetoNivel
	{
		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x00012470 File Offset: 0x00010670
		// (set) Token: 0x06000519 RID: 1305 RVA: 0x00012478 File Offset: 0x00010678
		public int nivel
		{
			get
			{
				return this.m_nivel;
			}
			set
			{
				this.m_nivel = value;
			}
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x00012481 File Offset: 0x00010681
		void ISujetoNivel.SubirNivel()
		{
			this.m_nivel++;
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x00012494 File Offset: 0x00010694
		// (set) Token: 0x0600051C RID: 1308 RVA: 0x000124E4 File Offset: 0x000106E4
		public Guid sujetoID
		{
			get
			{
				if (this.m_sujetoID == null)
				{
					try
					{
						this.m_sujetoID = new Guid?(new Guid(this.m_ID));
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
				return this.m_sujetoID.Value;
			}
			set
			{
				this.m_sujetoID = new Guid?(value);
				this.m_ID = this.m_sujetoID.ToString();
			}
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x00012509 File Offset: 0x00010709
		public void SetStringID(string value)
		{
			this.m_ID = value;
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x00012512 File Offset: 0x00010712
		public IReadOnlyList<ModificadoresDeAlterador> ObtenerAlteradorModificadores()
		{
			return this.@base.ObtenerAlteradorModificadores();
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00012532 File Offset: 0x00010732
		string ISujeto.get_name()
		{
			return base.name;
		}

		// Token: 0x0400023D RID: 573
		[Space]
		[SerializeField]
		private int m_nivel;

		// Token: 0x0400023E RID: 574
		[SerializeField]
		private string m_ID = "default";

		// Token: 0x0400023F RID: 575
		private Guid? m_sujetoID;
	}
}
