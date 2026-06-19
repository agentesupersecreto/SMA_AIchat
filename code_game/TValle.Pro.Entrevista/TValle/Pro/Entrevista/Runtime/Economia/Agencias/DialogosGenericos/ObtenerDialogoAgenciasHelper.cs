using System;
using System.Collections.Generic;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Mapas;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.DialogosGenericos
{
	// Token: 0x020000D8 RID: 216
	public static class ObtenerDialogoAgenciasHelper
	{
		// Token: 0x06000806 RID: 2054 RVA: 0x0002F380 File Offset: 0x0002D580
		public static bool ObtenerDialogo(ObtenerDialogosUtil Util, IReadOnlyList<DialogoInfoGenerico> dialogosInfo, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, Character conversante, Agencia.AI.Par par, ParteDelCuerpoHumano estimulada, ReaccionHumana reaccion, DireccionDeEstimulo direccion, object productor, out string dialogo, bool ignorarRedundancia, bool ignorarContextoErrado)
		{
			return ObtenerDialogoHelper.ObtenerDialogo(Util, dialogosInfo, tipoDeRespuesta, conversante, reaccion, direccion, productor, par.tipoDeEstimulo, estimulada, par.estimulante, par.tag, out dialogo, ignorarRedundancia, ignorarContextoErrado);
		}
	}
}
