using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.MaxEmoValue
{
	// Token: 0x020001F5 RID: 501
	public class DiagsPresenteDeMaxEmocionValueCortaLongitud : DialogosDePersonalidadesBase<DiagsPresenteDeMaxEmocionValueCortaLongitud>
	{
		// Token: 0x06000BBB RID: 3003 RVA: 0x00034A92 File Offset: 0x00032C92
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
