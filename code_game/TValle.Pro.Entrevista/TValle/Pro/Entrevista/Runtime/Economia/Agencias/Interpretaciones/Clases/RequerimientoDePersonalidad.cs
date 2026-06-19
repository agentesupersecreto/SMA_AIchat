using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Interpretaciones.Clases
{
	// Token: 0x020000FA RID: 250
	[Serializable]
	public class RequerimientoDePersonalidad<Tenum> : RequerimientoGenetico<Tenum>, AgenciaBase.IRequerimiento where Tenum : Enum, IConvertible
	{
		// Token: 0x06000870 RID: 2160 RVA: 0x0003054A File Offset: 0x0002E74A
		public RequerimientoDePersonalidad(string field, params Tenum[] aceptables)
			: base(field, aceptables)
		{
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x00030554 File Offset: 0x0002E754
		protected override string ObtenerLocalizadoDeField(string localizacion)
		{
			return InterpretacionDePersonalidad_DELETE.Localizado(this.m_field, localizacion);
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x00030564 File Offset: 0x0002E764
		public override bool Cumplido(ref IIntrepretacion postulantePersonalidad, ref IIntrepretacion postulanteApariencia)
		{
			int valor = postulanteApariencia.GetValor(this.m_field);
			return this.m_condicionesValores.Contains(valor);
		}
	}
}
