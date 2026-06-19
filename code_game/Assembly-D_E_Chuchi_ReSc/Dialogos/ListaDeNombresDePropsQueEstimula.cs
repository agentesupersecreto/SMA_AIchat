using System;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.NombresDePartesDelCuerpo;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos
{
	// Token: 0x020001CF RID: 463
	[CreateAssetMenu(fileName = "ListaDeNombresDePropsQueEstimula", menuName = "Objetos/Dialogos/Partes/Lista De Nombres De Props Que Estimula")]
	public class ListaDeNombresDePropsQueEstimula : BaseListaDeNombresDeParte<DialogoInfoParteDelCuerpo, TipoDeProp>
	{
		// Token: 0x04000906 RID: 2310
		public TipoDeEstimuloFlags contexto = (TipoDeEstimuloFlags)(-1);
	}
}
