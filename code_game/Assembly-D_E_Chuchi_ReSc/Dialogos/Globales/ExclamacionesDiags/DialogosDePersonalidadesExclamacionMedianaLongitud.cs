using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.ExclamacionesDiags
{
	// Token: 0x020001FA RID: 506
	public class DialogosDePersonalidadesExclamacionMedianaLongitud : DialogosDePersonalidadesBase<DialogosDePersonalidadesExclamacionMedianaLongitud>
	{
		// Token: 0x06000BC5 RID: 3013 RVA: 0x00034B0F File Offset: 0x00032D0F
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
