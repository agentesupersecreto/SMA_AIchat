using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000037 RID: 55
	[Serializable]
	public struct InterpretacionDeGustos
	{
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00007830 File Offset: 0x00005A30
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x00007838 File Offset: 0x00005A38
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[LabelLocalizado("Initial mouth desire", "US")]
		public Interpretacion.CantidadNoContable facialInitial
		{
			get
			{
				return this.m_facialInitial;
			}
			set
			{
				this.m_facialInitial = value;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00007841 File Offset: 0x00005A41
		// (set) Token: 0x060001BA RID: 442 RVA: 0x00007849 File Offset: 0x00005A49
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[LabelLocalizado("Initial crotch desire", "US")]
		public Interpretacion.CantidadNoContable crotchInitial
		{
			get
			{
				return this.m_crotchInitial;
			}
			set
			{
				this.m_crotchInitial = value;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00007852 File Offset: 0x00005A52
		// (set) Token: 0x060001BC RID: 444 RVA: 0x0000785A File Offset: 0x00005A5A
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[LabelLocalizado("Initial butt desire", "US")]
		public Interpretacion.CantidadNoContable assInitial
		{
			get
			{
				return this.m_assInitial;
			}
			set
			{
				this.m_assInitial = value;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00007863 File Offset: 0x00005A63
		// (set) Token: 0x060001BE RID: 446 RVA: 0x0000786B File Offset: 0x00005A6B
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[LabelLocalizado("mouth desire gain", "US")]
		public Interpretacion.Capacidad facialGain
		{
			get
			{
				return this.m_facialGain;
			}
			set
			{
				this.m_facialGain = value;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00007874 File Offset: 0x00005A74
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x0000787C File Offset: 0x00005A7C
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[LabelLocalizado("Crotch desire gain", "US")]
		public Interpretacion.Capacidad crotchGain
		{
			get
			{
				return this.m_crotchGain;
			}
			set
			{
				this.m_crotchGain = value;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00007885 File Offset: 0x00005A85
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x0000788D File Offset: 0x00005A8D
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[LabelLocalizado("Butt desire gain", "US")]
		public Interpretacion.Capacidad assGain
		{
			get
			{
				return this.m_assGain;
			}
			set
			{
				this.m_assGain = value;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00007896 File Offset: 0x00005A96
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x0000789E File Offset: 0x00005A9E
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[LabelLocalizado("Desire gain when seen", "US")]
		public Interpretacion.Capacidad deseoByVisual
		{
			get
			{
				return this.m_deseoByVisual;
			}
			set
			{
				this.m_deseoByVisual = value;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x000078A7 File Offset: 0x00005AA7
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x000078AF File Offset: 0x00005AAF
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[LabelLocalizado("Desire gain when listening", "US")]
		public Interpretacion.Capacidad deseoByVerbal
		{
			get
			{
				return this.m_deseoByVerbal;
			}
			set
			{
				this.m_deseoByVerbal = value;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x000078B8 File Offset: 0x00005AB8
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x000078C0 File Offset: 0x00005AC0
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[LabelLocalizado("Desire gain when touched", "US")]
		public Interpretacion.Capacidad deseoByTouch
		{
			get
			{
				return this.m_deseoByTouch;
			}
			set
			{
				this.m_deseoByTouch = value;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x000078C9 File Offset: 0x00005AC9
		// (set) Token: 0x060001CA RID: 458 RVA: 0x000078D1 File Offset: 0x00005AD1
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[LabelLocalizado("Desire gain when exposed", "US")]
		public Interpretacion.Capacidad deseoByExposure
		{
			get
			{
				return this.m_deseoByExposure;
			}
			set
			{
				this.m_deseoByExposure = value;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060001CB RID: 459 RVA: 0x000078DA File Offset: 0x00005ADA
		// (set) Token: 0x060001CC RID: 460 RVA: 0x000078E2 File Offset: 0x00005AE2
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[LabelLocalizado("Desire gain when fucked", "US")]
		public Interpretacion.Capacidad deseoByCoital
		{
			get
			{
				return this.m_deseoByCoital;
			}
			set
			{
				this.m_deseoByCoital = value;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060001CD RID: 461 RVA: 0x000078EB File Offset: 0x00005AEB
		// (set) Token: 0x060001CE RID: 462 RVA: 0x000078F3 File Offset: 0x00005AF3
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[DescripcionLocalizado("Desire gain when not directly interacting with the corresponding main body part.", "US")]
		[LabelLocalizado("Indirect desire gain", "US")]
		public Interpretacion.Capacidad deseoGainIndirecto
		{
			get
			{
				return this.m_deseoGainIndirecto;
			}
			set
			{
				this.m_deseoGainIndirecto = value;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060001CF RID: 463 RVA: 0x000078FC File Offset: 0x00005AFC
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x00007904 File Offset: 0x00005B04
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[DescripcionLocalizado("Desire gain on non-consensual interactions.", "US")]
		[LabelLocalizado("corruption by desires (partially implemented)", "US")]
		public Interpretacion.Capacidad corruptionByDesires
		{
			get
			{
				return this.m_corruptionByDesires;
			}
			set
			{
				this.m_corruptionByDesires = value;
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x0000790D File Offset: 0x00005B0D
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x00007915 File Offset: 0x00005B15
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[DescripcionLocalizado("How much desire does she keep after she is satisfied (by orgasms).", "US")]
		[LabelLocalizado("Desire resilience", "US")]
		public Interpretacion.Capacidad deseosResiliance
		{
			get
			{
				return this.m_deseosResiliance;
			}
			set
			{
				this.m_deseosResiliance = value;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x0000791E File Offset: 0x00005B1E
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x00007926 File Offset: 0x00005B26
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[LabelLocalizado("willing to suck", "US")]
		public Interpretacion.Capacidad dispuestaAChupar
		{
			get
			{
				return this.m_dispuestaAChupar;
			}
			set
			{
				this.m_dispuestaAChupar = value;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x0000792F File Offset: 0x00005B2F
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x00007937 File Offset: 0x00005B37
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[DescripcionLocalizado("Willing to do it herself.", "US")]
		[LabelLocalizado("Willing to ride", "US")]
		public Interpretacion.Capacidad dispuestaARiding
		{
			get
			{
				return this.m_dispuestaARiding;
			}
			set
			{
				this.m_dispuestaARiding = value;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00007940 File Offset: 0x00005B40
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x00007948 File Offset: 0x00005B48
		[AplicaAConjuntoDePersonalidad(para = "servicing")]
		[DescripcionLocalizado("willing to do it herself through the other hole", "US")]
		[LabelLocalizado("Willing to ride *", "US")]
		public Interpretacion.Capacidad dispuestaARidingAnal
		{
			get
			{
				return this.m_dispuestaARidingAnal;
			}
			set
			{
				this.m_dispuestaARidingAnal = value;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00007951 File Offset: 0x00005B51
		// (set) Token: 0x060001DA RID: 474 RVA: 0x00007959 File Offset: 0x00005B59
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[LabelLocalizado("Taste for Perverts", "US")]
		public Interpretacion.Capacidad gustoPorPervertidos
		{
			get
			{
				return this.m_gustoPorPervertidos;
			}
			set
			{
				this.m_gustoPorPervertidos = value;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00007962 File Offset: 0x00005B62
		// (set) Token: 0x060001DC RID: 476 RVA: 0x0000796A File Offset: 0x00005B6A
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[LabelLocalizado("Taste for Shy Men", "US")]
		public Interpretacion.Capacidad gustoPorTimidos
		{
			get
			{
				return this.m_gustoPorTimidos;
			}
			set
			{
				this.m_gustoPorTimidos = value;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00007973 File Offset: 0x00005B73
		// (set) Token: 0x060001DE RID: 478 RVA: 0x0000797B File Offset: 0x00005B7B
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[LabelLocalizado("Taste for Assholes", "US")]
		public Interpretacion.Capacidad gustoPorPatanes
		{
			get
			{
				return this.m_gustoPorPatanes;
			}
			set
			{
				this.m_gustoPorPatanes = value;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00007984 File Offset: 0x00005B84
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x0000798C File Offset: 0x00005B8C
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[LabelLocalizado("Taste for Intellectuals", "US")]
		public Interpretacion.Capacidad gustoPorIntelectuales
		{
			get
			{
				return this.m_gustoPorIntelectuales;
			}
			set
			{
				this.m_gustoPorIntelectuales = value;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00007995 File Offset: 0x00005B95
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x0000799D File Offset: 0x00005B9D
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[LabelLocalizado("Taste for Confident Men", "US")]
		public Interpretacion.Capacidad gustoPorConfiados
		{
			get
			{
				return this.m_gustoPorConfiados;
			}
			set
			{
				this.m_gustoPorConfiados = value;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x000079A6 File Offset: 0x00005BA6
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x000079AE File Offset: 0x00005BAE
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[LabelLocalizado("Taste for Weirdos", "US")]
		public Interpretacion.Capacidad gustoPorAutistas
		{
			get
			{
				return this.m_gustoPorAutistas;
			}
			set
			{
				this.m_gustoPorAutistas = value;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x000079B7 File Offset: 0x00005BB7
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x000079BF File Offset: 0x00005BBF
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[LabelLocalizado("Taste for Money", "US")]
		public Interpretacion.Capacidad gustoPorDinero
		{
			get
			{
				return this.m_gustoPorDinero;
			}
			set
			{
				this.m_gustoPorDinero = value;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x000079C8 File Offset: 0x00005BC8
		// (set) Token: 0x060001E8 RID: 488 RVA: 0x000079D0 File Offset: 0x00005BD0
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[LabelLocalizado("Taste for Humility", "US")]
		public Interpretacion.Capacidad gustoPorHumildad
		{
			get
			{
				return this.m_gustoPorHumildad;
			}
			set
			{
				this.m_gustoPorHumildad = value;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x000079D9 File Offset: 0x00005BD9
		// (set) Token: 0x060001EA RID: 490 RVA: 0x000079E1 File Offset: 0x00005BE1
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[LabelLocalizado("Taste for Fat Men", "US")]
		public Interpretacion.Capacidad gustoPorGordos
		{
			get
			{
				return this.m_gustoPorGordos;
			}
			set
			{
				this.m_gustoPorGordos = value;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060001EB RID: 491 RVA: 0x000079EA File Offset: 0x00005BEA
		// (set) Token: 0x060001EC RID: 492 RVA: 0x000079F2 File Offset: 0x00005BF2
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[LabelLocalizado("Taste for Old Men", "US")]
		public Interpretacion.Capacidad gustoPorViejos
		{
			get
			{
				return this.m_gustoPorViejos;
			}
			set
			{
				this.m_gustoPorViejos = value;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060001ED RID: 493 RVA: 0x000079FB File Offset: 0x00005BFB
		// (set) Token: 0x060001EE RID: 494 RVA: 0x00007A03 File Offset: 0x00005C03
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[LabelLocalizado("Taste for Thin Men", "US")]
		public Interpretacion.Capacidad gustoPorDelgados
		{
			get
			{
				return this.m_gustoPorDelgados;
			}
			set
			{
				this.m_gustoPorDelgados = value;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00007A0C File Offset: 0x00005C0C
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x00007A14 File Offset: 0x00005C14
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[LabelLocalizado("Taste for Muscle Men", "US")]
		public Interpretacion.Capacidad gustoPorMusculosos
		{
			get
			{
				return this.m_gustoPorMusculosos;
			}
			set
			{
				this.m_gustoPorMusculosos = value;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x00007A1D File Offset: 0x00005C1D
		// (set) Token: 0x060001F2 RID: 498 RVA: 0x00007A25 File Offset: 0x00005C25
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[LabelLocalizado("Taste for Young Men", "US")]
		public Interpretacion.Capacidad gustoPorJovenes
		{
			get
			{
				return this.m_gustoPorJovenes;
			}
			set
			{
				this.m_gustoPorJovenes = value;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x00007A2E File Offset: 0x00005C2E
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x00007A36 File Offset: 0x00005C36
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[UIElementDisabled]
		[LabelLocalizado("Taste for Tall Men (Not implemented)", "US")]
		public Interpretacion.Capacidad gustoPorAltos { readonly get; set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x00007A3F File Offset: 0x00005C3F
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x00007A47 File Offset: 0x00005C47
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[UIElementDisabled]
		[LabelLocalizado("Taste for Good Looking Men (Not implemented)", "US")]
		public Interpretacion.Capacidad gustoPorBuenaPresencia { readonly get; set; }

		// Token: 0x0400009D RID: 157
		[SerializeField]
		private Interpretacion.CantidadNoContable m_facialInitial;

		// Token: 0x0400009E RID: 158
		[SerializeField]
		private Interpretacion.CantidadNoContable m_crotchInitial;

		// Token: 0x0400009F RID: 159
		[SerializeField]
		private Interpretacion.CantidadNoContable m_assInitial;

		// Token: 0x040000A0 RID: 160
		[SerializeField]
		private Interpretacion.Capacidad m_facialGain;

		// Token: 0x040000A1 RID: 161
		[SerializeField]
		private Interpretacion.Capacidad m_crotchGain;

		// Token: 0x040000A2 RID: 162
		[SerializeField]
		private Interpretacion.Capacidad m_assGain;

		// Token: 0x040000A3 RID: 163
		[SerializeField]
		private Interpretacion.Capacidad m_deseoByVisual;

		// Token: 0x040000A4 RID: 164
		[SerializeField]
		private Interpretacion.Capacidad m_deseoByVerbal;

		// Token: 0x040000A5 RID: 165
		[SerializeField]
		private Interpretacion.Capacidad m_deseoByTouch;

		// Token: 0x040000A6 RID: 166
		[SerializeField]
		private Interpretacion.Capacidad m_deseoByExposure;

		// Token: 0x040000A7 RID: 167
		[SerializeField]
		private Interpretacion.Capacidad m_deseoByCoital;

		// Token: 0x040000A8 RID: 168
		[SerializeField]
		private Interpretacion.Capacidad m_deseoGainIndirecto;

		// Token: 0x040000A9 RID: 169
		[SerializeField]
		private Interpretacion.Capacidad m_corruptionByDesires;

		// Token: 0x040000AA RID: 170
		[SerializeField]
		private Interpretacion.Capacidad m_deseosResiliance;

		// Token: 0x040000AB RID: 171
		[SerializeField]
		private Interpretacion.Capacidad m_dispuestaAChupar;

		// Token: 0x040000AC RID: 172
		[SerializeField]
		private Interpretacion.Capacidad m_dispuestaARiding;

		// Token: 0x040000AD RID: 173
		[SerializeField]
		private Interpretacion.Capacidad m_dispuestaARidingAnal;

		// Token: 0x040000AE RID: 174
		[SerializeField]
		private Interpretacion.Capacidad m_gustoPorPervertidos;

		// Token: 0x040000AF RID: 175
		[SerializeField]
		private Interpretacion.Capacidad m_gustoPorTimidos;

		// Token: 0x040000B0 RID: 176
		[SerializeField]
		private Interpretacion.Capacidad m_gustoPorPatanes;

		// Token: 0x040000B1 RID: 177
		[SerializeField]
		private Interpretacion.Capacidad m_gustoPorIntelectuales;

		// Token: 0x040000B2 RID: 178
		[SerializeField]
		private Interpretacion.Capacidad m_gustoPorConfiados;

		// Token: 0x040000B3 RID: 179
		[SerializeField]
		private Interpretacion.Capacidad m_gustoPorAutistas;

		// Token: 0x040000B4 RID: 180
		[SerializeField]
		private Interpretacion.Capacidad m_gustoPorDinero;

		// Token: 0x040000B5 RID: 181
		[SerializeField]
		private Interpretacion.Capacidad m_gustoPorHumildad;

		// Token: 0x040000B6 RID: 182
		[SerializeField]
		private Interpretacion.Capacidad m_gustoPorGordos;

		// Token: 0x040000B7 RID: 183
		[SerializeField]
		private Interpretacion.Capacidad m_gustoPorViejos;

		// Token: 0x040000B8 RID: 184
		[SerializeField]
		private Interpretacion.Capacidad m_gustoPorDelgados;

		// Token: 0x040000B9 RID: 185
		[SerializeField]
		private Interpretacion.Capacidad m_gustoPorMusculosos;

		// Token: 0x040000BA RID: 186
		[SerializeField]
		private Interpretacion.Capacidad m_gustoPorJovenes;
	}
}
