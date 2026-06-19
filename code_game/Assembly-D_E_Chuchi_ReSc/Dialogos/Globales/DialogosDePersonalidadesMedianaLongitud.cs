using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales
{
	// Token: 0x020001F0 RID: 496
	public sealed class DialogosDePersonalidadesMedianaLongitud : DialogosDePersonalidadesBase<DialogosDePersonalidadesMedianaLongitud>
	{
		// Token: 0x06000BB1 RID: 2993 RVA: 0x00034A15 File Offset: 0x00032C15
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
