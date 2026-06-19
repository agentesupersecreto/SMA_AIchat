using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales
{
	// Token: 0x020001F1 RID: 497
	public sealed class DialogosDePersonalidadesMedianaLongitudConHielo : DialogosDePersonalidadesBase<DialogosDePersonalidadesMedianaLongitudConHielo>
	{
		// Token: 0x06000BB3 RID: 2995 RVA: 0x00034A2E File Offset: 0x00032C2E
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
