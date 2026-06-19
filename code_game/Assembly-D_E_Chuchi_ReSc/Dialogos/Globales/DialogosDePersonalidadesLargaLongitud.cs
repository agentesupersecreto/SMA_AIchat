using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales
{
	// Token: 0x020001EE RID: 494
	public sealed class DialogosDePersonalidadesLargaLongitud : DialogosDePersonalidadesBase<DialogosDePersonalidadesLargaLongitud>
	{
		// Token: 0x06000BAD RID: 2989 RVA: 0x000349E3 File Offset: 0x00032BE3
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
