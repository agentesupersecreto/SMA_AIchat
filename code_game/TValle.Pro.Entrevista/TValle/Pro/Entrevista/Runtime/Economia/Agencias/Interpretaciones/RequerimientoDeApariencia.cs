using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Interpretaciones
{
	// Token: 0x020000F8 RID: 248
	[Serializable]
	public class RequerimientoDeApariencia<Tenum> : RequerimientoGenetico<Tenum>, AgenciaBase.IRequerimiento where Tenum : Enum, IConvertible
	{
		// Token: 0x06000869 RID: 2153 RVA: 0x000303E8 File Offset: 0x0002E5E8
		public RequerimientoDeApariencia(string field, params Tenum[] aceptables)
			: base(field, aceptables)
		{
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x000303F2 File Offset: 0x0002E5F2
		protected override string ObtenerLocalizadoDeField(string localizacion)
		{
			return InterpretacionDeAparienciaFisica.Localizado(this.m_field, localizacion);
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x00030400 File Offset: 0x0002E600
		public override bool Cumplido(ref IIntrepretacion postulantePersonalidad, ref IIntrepretacion postulanteApariencia)
		{
			int valor = postulanteApariencia.GetValor(this.m_field);
			return this.m_condicionesValores.Contains(valor);
		}
	}
}
