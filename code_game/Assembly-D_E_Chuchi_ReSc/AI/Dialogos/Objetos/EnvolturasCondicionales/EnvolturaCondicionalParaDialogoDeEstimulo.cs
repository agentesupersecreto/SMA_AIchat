using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Objetos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.EnvolturasCondicionales
{
	// Token: 0x02000543 RID: 1347
	[CreateAssetMenu(fileName = "EnvolturaCondicionalParaDialogoDeEstimulo", menuName = "Objetos/Dialogos/AI/EnvolturaCondicionalParaDialogoDeEstimulo")]
	public class EnvolturaCondicionalParaDialogoDeEstimulo : EnvolturaCondicionalDeGruposDeDialogosDeRasgosDePersonalidad, IDialogosDePersonalidadesPuntajeCalculador
	{
		// Token: 0x06002119 RID: 8473 RVA: 0x0007B699 File Offset: 0x00079899
		float IDialogosDePersonalidadesPuntajeCalculador.Calcular(object arg)
		{
			return this.condiciones.Puntaje(arg as ICalculoDeEstimulo);
		}

		// Token: 0x0400157D RID: 5501
		public CondicionesDeEvolturaCondicional condiciones = new CondicionesDeEvolturaCondicional();
	}
}
