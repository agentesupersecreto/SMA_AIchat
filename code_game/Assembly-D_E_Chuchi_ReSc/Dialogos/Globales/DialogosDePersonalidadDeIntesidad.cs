using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales
{
	// Token: 0x020001EA RID: 490
	public class DialogosDePersonalidadDeIntesidad : DialogosDePersonalidadesBase<DialogosDePersonalidadDeIntesidad>
	{
		// Token: 0x06000BA5 RID: 2981 RVA: 0x0003497F File Offset: 0x00032B7F
		public override void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			base.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}
	}
}
