using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Genetica.Randomizacion.Mapas.Abstracts
{
	// Token: 0x02000068 RID: 104
	public abstract class MapaDeModificacionDeRandomizadoBase : ScriptableObject
	{
		// Token: 0x060004C7 RID: 1223 RVA: 0x000114DE File Offset: 0x0000F6DE
		private void CheckInit()
		{
			if (!this.m_initiated)
			{
				this.OnInit();
				this.m_initiated = true;
			}
		}

		// Token: 0x060004C8 RID: 1224
		protected abstract void OnInit();

		// Token: 0x060004C9 RID: 1225 RVA: 0x000114F5 File Offset: 0x0000F6F5
		public void ApplyTo(IReadOnlyDictionary<string, ModificadoresDeAlterador> modificadoresDeAlterador, IReadOnlyDictionary<string, ModificadoresDeAlterador> defaults)
		{
			this.CheckInit();
			this.OnApplyTo(modificadoresDeAlterador, defaults);
		}

		// Token: 0x060004CA RID: 1226
		protected abstract void OnApplyTo(IReadOnlyDictionary<string, ModificadoresDeAlterador> modificadoresDeAlterador, IReadOnlyDictionary<string, ModificadoresDeAlterador> defaults);

		// Token: 0x04000228 RID: 552
		[NonSerialized]
		private bool m_initiated;
	}
}
