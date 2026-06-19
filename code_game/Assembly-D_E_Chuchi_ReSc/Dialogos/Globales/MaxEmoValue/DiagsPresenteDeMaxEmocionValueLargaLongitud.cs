using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.MaxEmoValue
{
	// Token: 0x020001F6 RID: 502
	public class DiagsPresenteDeMaxEmocionValueLargaLongitud : DialogosDePersonalidadesBase<DiagsPresenteDeMaxEmocionValueLargaLongitud>
	{
		// Token: 0x06000BBD RID: 3005 RVA: 0x00034AAB File Offset: 0x00032CAB
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
