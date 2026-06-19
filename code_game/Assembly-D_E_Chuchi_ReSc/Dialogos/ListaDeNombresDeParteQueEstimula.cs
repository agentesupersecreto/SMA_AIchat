using System;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.NombresDePartesDelCuerpo;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos
{
	// Token: 0x020001CE RID: 462
	[CreateAssetMenu(fileName = "ListaDeNombresDeParteQueEstimula", menuName = "Objetos/Dialogos/Partes/Lista De Nombres De Parte Que Estimula")]
	public class ListaDeNombresDeParteQueEstimula : BaseListaDeNombresDeParte<DialogoInfoParteDelCuerpo, ParteQuePuedeEstimular>
	{
		// Token: 0x04000905 RID: 2309
		public TipoDeEstimuloFlags contexto = (TipoDeEstimuloFlags)(-1);
	}
}
