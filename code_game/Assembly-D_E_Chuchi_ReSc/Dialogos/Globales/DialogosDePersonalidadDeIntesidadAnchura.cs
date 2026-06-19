using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales
{
	// Token: 0x020001EB RID: 491
	public class DialogosDePersonalidadDeIntesidadAnchura : DialogosDePersonalidadesBase<DialogosDePersonalidadDeIntesidadAnchura>
	{
		// Token: 0x06000BA7 RID: 2983 RVA: 0x00034998 File Offset: 0x00032B98
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
