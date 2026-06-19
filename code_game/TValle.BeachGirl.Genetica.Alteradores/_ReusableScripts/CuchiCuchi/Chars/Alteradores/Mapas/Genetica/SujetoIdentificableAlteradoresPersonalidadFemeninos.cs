using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using Assets._ReusableScripts.Genetica;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica
{
	// Token: 0x02000070 RID: 112
	[CreateAssetMenu(fileName = "SujetoIdentificableAlteradoresPersonalidadFemeninos", menuName = "Objetos/Genetica/Sujeto Identificable Alteradores Personalidad Femeninos")]
	public class SujetoIdentificableAlteradoresPersonalidadFemeninos : SujetoAlteradoresPersonalidadFemeninos, ISujetoIdentificable, ISujeto, ISujetoNivel
	{
		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000521 RID: 1313 RVA: 0x0001253A File Offset: 0x0001073A
		// (set) Token: 0x06000522 RID: 1314 RVA: 0x00012542 File Offset: 0x00010742
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

		// Token: 0x06000523 RID: 1315 RVA: 0x0001254B File Offset: 0x0001074B
		void ISujetoNivel.SubirNivel()
		{
			this.m_nivel++;
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000524 RID: 1316 RVA: 0x0001255C File Offset: 0x0001075C
		// (set) Token: 0x06000525 RID: 1317 RVA: 0x000125AC File Offset: 0x000107AC
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

		// Token: 0x06000526 RID: 1318 RVA: 0x000125D1 File Offset: 0x000107D1
		public void SetStringID(string value)
		{
			this.m_ID = value;
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x000125DA File Offset: 0x000107DA
		public IReadOnlyList<ModificadoresDeAlterador> ObtenerAlteradorModificadores()
		{
			return this.@base.ObtenerAlteradorModificadores();
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x000125FA File Offset: 0x000107FA
		string ISujeto.get_name()
		{
			return base.name;
		}

		// Token: 0x04000240 RID: 576
		[Space]
		[SerializeField]
		private int m_nivel;

		// Token: 0x04000241 RID: 577
		[SerializeField]
		private string m_ID = "default";

		// Token: 0x04000242 RID: 578
		private Guid? m_sujetoID;
	}
}
