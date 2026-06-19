using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Objetos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos
{
	// Token: 0x0200020A RID: 522
	[CreateAssetMenu(fileName = "DialogosLocalizadosDeTipoDeRespuesta", menuName = "Objetos/Dialogos/Genericos/Dialogos Localizados De Tipo De Respuesta")]
	public class DialogosLocalizadosDeTipoDeRespuesta : ListaDeDialogosLocalizados<DialogoInfo>
	{
		// Token: 0x040009C1 RID: 2497
		public Personalidad.TipoDeRespuestaDeDialogoDeHeroina para = (Personalidad.TipoDeRespuestaDeDialogoDeHeroina)(-1);
	}
}
