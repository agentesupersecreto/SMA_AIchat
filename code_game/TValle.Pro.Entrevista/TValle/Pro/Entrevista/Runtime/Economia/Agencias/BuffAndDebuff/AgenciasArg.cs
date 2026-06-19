using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff
{
	// Token: 0x020000D9 RID: 217
	public abstract class AgenciasArg<T> : ArgumentoDeEfecto<T> where T : AgenciasArg<T>
	{
		// Token: 0x04000496 RID: 1174
		public List<string> agenciasID;
	}
}
