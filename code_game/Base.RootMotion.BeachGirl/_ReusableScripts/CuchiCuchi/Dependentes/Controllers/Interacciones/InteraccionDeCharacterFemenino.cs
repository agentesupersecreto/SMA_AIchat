using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000E8 RID: 232
	public abstract class InteraccionDeCharacterFemenino : InteraccionDeCharacter
	{
		// Token: 0x04000580 RID: 1408
		[Obsolete("", true)]
		[NonSerialized]
		public TipoDePose posesValidas = (TipoDePose)(-1);

		// Token: 0x04000581 RID: 1409
		[Header("Va a ser reemplazado por Interaction Checkers")]
		public TipoDePose posesNoValidas;
	}
}
