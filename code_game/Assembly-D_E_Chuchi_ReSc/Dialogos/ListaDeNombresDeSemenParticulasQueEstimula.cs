using System;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.NombresDePartesDelCuerpo;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos
{
	// Token: 0x020001D0 RID: 464
	[CreateAssetMenu(fileName = "ListaDeNombresDeSemenParticulasQueEstimula", menuName = "Objetos/Dialogos/Partes/Lista De Nombres De Semen Particulas Que Estimula")]
	public class ListaDeNombresDeSemenParticulasQueEstimula : BaseListaDeNombresDeParte<DialogoInfoParteDelCuerpo, SemenParticulaQuePuedeEstimular>
	{
		// Token: 0x04000907 RID: 2311
		public TipoDeEstimuloFlags contexto = (TipoDeEstimuloFlags)(-1);
	}
}
