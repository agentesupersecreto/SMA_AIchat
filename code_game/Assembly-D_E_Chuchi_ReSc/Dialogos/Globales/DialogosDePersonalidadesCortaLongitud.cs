using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales
{
	// Token: 0x020001EC RID: 492
	public sealed class DialogosDePersonalidadesCortaLongitud : DialogosDePersonalidadesBase<DialogosDePersonalidadesCortaLongitud>
	{
		// Token: 0x06000BA9 RID: 2985 RVA: 0x000349B1 File Offset: 0x00032BB1
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
