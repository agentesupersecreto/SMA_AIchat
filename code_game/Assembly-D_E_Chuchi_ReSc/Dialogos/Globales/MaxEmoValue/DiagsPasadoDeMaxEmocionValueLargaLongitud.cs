using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.MaxEmoValue
{
	// Token: 0x020001F3 RID: 499
	public class DiagsPasadoDeMaxEmocionValueLargaLongitud : DialogosDePersonalidadesBase<DiagsPasadoDeMaxEmocionValueLargaLongitud>
	{
		// Token: 0x06000BB7 RID: 2999 RVA: 0x00034A60 File Offset: 0x00032C60
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
