using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.ExclamacionesDiags
{
	// Token: 0x020001F8 RID: 504
	public class DialogosDePersonalidadesExclamacionCortaLongitud : DialogosDePersonalidadesBase<DialogosDePersonalidadesExclamacionCortaLongitud>
	{
		// Token: 0x06000BC1 RID: 3009 RVA: 0x00034ADD File Offset: 0x00032CDD
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
