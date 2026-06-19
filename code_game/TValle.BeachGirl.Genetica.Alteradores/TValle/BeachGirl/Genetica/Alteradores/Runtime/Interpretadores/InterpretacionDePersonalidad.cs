using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200003C RID: 60
	[AplicaAConjuntoDePersonalidad(para = "summarizing")]
	[Serializable]
	public struct InterpretacionDePersonalidad
	{
		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600029D RID: 669 RVA: 0x00007FD3 File Offset: 0x000061D3
		// (set) Token: 0x0600029E RID: 670 RVA: 0x00007FDB File Offset: 0x000061DB
		[DescripcionLocalizado("Less likely to leave.", "US")]
		[LabelLocalizado("Patience", "US")]
		public Interpretacion.Capacidad patience
		{
			get
			{
				return this.m_patience;
			}
			set
			{
				this.m_patience = value;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600029F RID: 671 RVA: 0x00007FE4 File Offset: 0x000061E4
		// (set) Token: 0x060002A0 RID: 672 RVA: 0x00007FEC File Offset: 0x000061EC
		[Ignore]
		[DescripcionLocalizado("Boredom gain. (obsolete)", "US")]
		[LabelLocalizado("High standards (obsolete)", "US")]
		public Interpretacion.Capacidad estandaresAltos
		{
			get
			{
				return this.m_estandaresAltos;
			}
			set
			{
				this.m_estandaresAltos = value;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x00007FF5 File Offset: 0x000061F5
		// (set) Token: 0x060002A2 RID: 674 RVA: 0x00007FFD File Offset: 0x000061FD
		[DescripcionLocalizado("Wil reacts more frequently to interactions.", "US")]
		[LabelLocalizado("Responsiveness", "US")]
		public Interpretacion.Capacidad responsiveness
		{
			get
			{
				return this.m_responsiveness;
			}
			set
			{
				this.m_responsiveness = value;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x00008006 File Offset: 0x00006206
		// (set) Token: 0x060002A4 RID: 676 RVA: 0x0000800E File Offset: 0x0000620E
		[DescripcionLocalizado("Will have more facial expressions .", "US")]
		[LabelLocalizado("Expressiveness", "US")]
		public Interpretacion.Capacidad expressiveness
		{
			get
			{
				return this.m_expressiveness;
			}
			set
			{
				this.m_expressiveness = value;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x00008017 File Offset: 0x00006217
		// (set) Token: 0x060002A6 RID: 678 RVA: 0x0000801F File Offset: 0x0000621F
		[UIElementDisabled]
		[AplicaAConjuntoDePersonalidad(para = "slutness")]
		[LabelLocalizado("Consent Consistency (Not implemented)", "US")]
		public Interpretacion.Capacidad consentConsistency { readonly get; set; }

		// Token: 0x040000FC RID: 252
		[SerializeField]
		private Interpretacion.Capacidad m_patience;

		// Token: 0x040000FD RID: 253
		[SerializeField]
		private Interpretacion.Capacidad m_estandaresAltos;

		// Token: 0x040000FE RID: 254
		[SerializeField]
		private Interpretacion.Capacidad m_responsiveness;

		// Token: 0x040000FF RID: 255
		[SerializeField]
		private Interpretacion.Capacidad m_expressiveness;

		// Token: 0x04000100 RID: 256
		[DescripcionLocalizado("It is not recommended to have them all on high or all on low. Select some to be high, and some others to be lower.", "US")]
		[LabelLocalizado("Traits", "US")]
		public PersonalidadTraits traits;
	}
}
