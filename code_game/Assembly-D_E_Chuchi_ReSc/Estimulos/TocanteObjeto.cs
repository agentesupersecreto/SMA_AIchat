using System;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos
{
	// Token: 0x020002A6 RID: 678
	public class TocanteObjeto : ObjetoEstimulanteDeCharacter
	{
		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06000F30 RID: 3888 RVA: 0x00045F72 File Offset: 0x00044172
		public bool deshabilitadoParaTocar
		{
			get
			{
				return this.m_deshabilitadoOR.Or(this.m_deshabilitadoParaTocar);
			}
		}

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06000F31 RID: 3889 RVA: 0x00045F85 File Offset: 0x00044185
		public ModificableDeBool deshabilitadoParaTocarOR
		{
			get
			{
				return this.m_deshabilitadoOR;
			}
		}

		// Token: 0x04000CBB RID: 3259
		[SerializeField]
		private bool m_deshabilitadoParaTocar;

		// Token: 0x04000CBC RID: 3260
		[SerializeField]
		private ModificableDeBool m_deshabilitadoOR = new ModificableDeBool(false);
	}
}
