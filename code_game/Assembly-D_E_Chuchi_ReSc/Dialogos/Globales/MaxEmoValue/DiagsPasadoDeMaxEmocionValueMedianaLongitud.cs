using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.MaxEmoValue
{
	// Token: 0x020001F4 RID: 500
	public class DiagsPasadoDeMaxEmocionValueMedianaLongitud : DialogosDePersonalidadesBase<DiagsPasadoDeMaxEmocionValueMedianaLongitud>
	{
		// Token: 0x06000BB9 RID: 3001 RVA: 0x00034A79 File Offset: 0x00032C79
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
