using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000047 RID: 71
	[AplicaAConjuntoDePersonalidad(para = "summarizing")]
	[PanelLayout(alturaMinima = 360f, alturaPreferida = 360f)]
	[FontProConfigUI(alignmentUnity = TextAnchor.MiddleLeft, fontSize = 15)]
	[LayoutConfigUI(height = 20)]
	[Modelo]
	[Serializable]
	public struct PersonalidadTraits
	{
		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000322 RID: 802 RVA: 0x0000847C File Offset: 0x0000667C
		// (set) Token: 0x06000323 RID: 803 RVA: 0x00008484 File Offset: 0x00006684
		[AplicaAConjuntoDePersonalidad(para = "summarizing", weigth = 5)]
		[DescripcionLocalizado("More willing to undress, to change poses, to talk dirty.", "US")]
		[LabelLocalizado("Perverted", "US")]
		public Interpretacion.Capacidad perverted
		{
			get
			{
				return this.m_perverted;
			}
			set
			{
				this.m_perverted = value;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000324 RID: 804 RVA: 0x0000848D File Offset: 0x0000668D
		// (set) Token: 0x06000325 RID: 805 RVA: 0x00008495 File Offset: 0x00006695
		[DescripcionLocalizado("Less willing to tell lies.", "US")]
		[LabelLocalizado("Honest", "US")]
		public Interpretacion.Capacidad honest
		{
			get
			{
				return this.m_honest;
			}
			set
			{
				this.m_honest = value;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000326 RID: 806 RVA: 0x0000849E File Offset: 0x0000669E
		// (set) Token: 0x06000327 RID: 807 RVA: 0x000084A6 File Offset: 0x000066A6
		[AplicaAConjuntoDePersonalidad(para = "summarizing", weigth = 5)]
		[DescripcionLocalizado("Much more willing to undress.", "US")]
		[LabelLocalizado("Exhibitionist", "US")]
		public Interpretacion.Capacidad exhibitionist
		{
			get
			{
				return this.m_exhibitionist;
			}
			set
			{
				this.m_exhibitionist = value;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000328 RID: 808 RVA: 0x000084AF File Offset: 0x000066AF
		// (set) Token: 0x06000329 RID: 809 RVA: 0x000084B7 File Offset: 0x000066B7
		[DescripcionLocalizado("She will talk much more.", "US")]
		[LabelLocalizado("Extroverted", "US")]
		public Interpretacion.Capacidad extroverted
		{
			get
			{
				return this.m_extroverted;
			}
			set
			{
				this.m_extroverted = value;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600032A RID: 810 RVA: 0x000084C0 File Offset: 0x000066C0
		// (set) Token: 0x0600032B RID: 811 RVA: 0x000084C8 File Offset: 0x000066C8
		[DescripcionLocalizado("Less likely to have negative responses. Negative interactions have a longer buffer time before taking effect on her.", "US")]
		[LabelLocalizado("Optimistic", "US")]
		public Interpretacion.Capacidad optimistic
		{
			get
			{
				return this.m_optimistic;
			}
			set
			{
				this.m_optimistic = value;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x0600032C RID: 812 RVA: 0x000084D1 File Offset: 0x000066D1
		// (set) Token: 0x0600032D RID: 813 RVA: 0x000084D9 File Offset: 0x000066D9
		[DescripcionLocalizado("Less willing to talk about private things.", "US")]
		[LabelLocalizado("Respectful", "US")]
		public Interpretacion.Capacidad respectful
		{
			get
			{
				return this.m_respectful;
			}
			set
			{
				this.m_respectful = value;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x0600032E RID: 814 RVA: 0x000084E2 File Offset: 0x000066E2
		// (set) Token: 0x0600032F RID: 815 RVA: 0x000084EA File Offset: 0x000066EA
		[AplicaAConjuntoDePersonalidad(para = "summarizing", weigth = 5)]
		[DescripcionLocalizado("More willing to cover herself when exposed, when caressed, when observed.", "US")]
		[LabelLocalizado("Shy", "US")]
		public Interpretacion.Capacidad shy
		{
			get
			{
				return this.m_shy;
			}
			set
			{
				this.m_shy = value;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000330 RID: 816 RVA: 0x000084F3 File Offset: 0x000066F3
		// (set) Token: 0x06000331 RID: 817 RVA: 0x000084FB File Offset: 0x000066FB
		[AplicaAConjuntoDePersonalidad(para = "summarizing", weigth = 10)]
		[DescripcionLocalizado("Conflict excites her.", "US")]
		[LabelLocalizado("Dominant", "US")]
		public Interpretacion.Capacidad rude
		{
			get
			{
				return this.m_rude;
			}
			set
			{
				this.m_rude = value;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000332 RID: 818 RVA: 0x00008504 File Offset: 0x00006704
		// (set) Token: 0x06000333 RID: 819 RVA: 0x0000850C File Offset: 0x0000670C
		[AplicaAConjuntoDePersonalidad(para = "summarizing", weigth = 10)]
		[DescripcionLocalizado("Rough treatment excites her.", "US")]
		[LabelLocalizado("Masochist", "US")]
		public Interpretacion.Capacidad masochist
		{
			get
			{
				return this.m_masochist;
			}
			set
			{
				this.m_masochist = value;
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000334 RID: 820 RVA: 0x00008515 File Offset: 0x00006715
		// (set) Token: 0x06000335 RID: 821 RVA: 0x0000851D File Offset: 0x0000671D
		[AplicaAConjuntoDePersonalidad(para = "summarizing", weigth = 10)]
		[DescripcionLocalizado("Bad boys have a pull on her.", "US")]
		[LabelLocalizado("Hybristophilia", "US")]
		public Interpretacion.Capacidad passive
		{
			get
			{
				return this.m_passive;
			}
			set
			{
				this.m_passive = value;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000336 RID: 822 RVA: 0x00008526 File Offset: 0x00006726
		// (set) Token: 0x06000337 RID: 823 RVA: 0x0000852E File Offset: 0x0000672E
		[AplicaAConjuntoDePersonalidad(para = "summarizing", weigth = 10)]
		[DescripcionLocalizado("She enjoys surrendering to a stronger will.", "US")]
		[LabelLocalizado("Submissive", "US")]
		public Interpretacion.Capacidad submissive
		{
			get
			{
				return this.m_submissive;
			}
			set
			{
				this.m_submissive = value;
			}
		}

		// Token: 0x04000133 RID: 307
		[SerializeField]
		private Interpretacion.Capacidad m_perverted;

		// Token: 0x04000134 RID: 308
		[SerializeField]
		private Interpretacion.Capacidad m_honest;

		// Token: 0x04000135 RID: 309
		[SerializeField]
		private Interpretacion.Capacidad m_exhibitionist;

		// Token: 0x04000136 RID: 310
		[SerializeField]
		private Interpretacion.Capacidad m_extroverted;

		// Token: 0x04000137 RID: 311
		[SerializeField]
		private Interpretacion.Capacidad m_optimistic;

		// Token: 0x04000138 RID: 312
		[SerializeField]
		private Interpretacion.Capacidad m_respectful;

		// Token: 0x04000139 RID: 313
		[SerializeField]
		private Interpretacion.Capacidad m_shy;

		// Token: 0x0400013A RID: 314
		[SerializeField]
		private Interpretacion.Capacidad m_rude;

		// Token: 0x0400013B RID: 315
		[SerializeField]
		private Interpretacion.Capacidad m_masochist;

		// Token: 0x0400013C RID: 316
		[SerializeField]
		private Interpretacion.Capacidad m_passive;

		// Token: 0x0400013D RID: 317
		[SerializeField]
		private Interpretacion.Capacidad m_submissive;
	}
}
