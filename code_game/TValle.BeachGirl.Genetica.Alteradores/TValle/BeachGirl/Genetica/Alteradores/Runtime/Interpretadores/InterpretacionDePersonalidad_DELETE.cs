using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000051 RID: 81
	[Obsolete("dividir En Varios")]
	[Serializable]
	public struct InterpretacionDePersonalidad_DELETE : IIntrepretacion
	{
		// Token: 0x060003B1 RID: 945 RVA: 0x0000EB24 File Offset: 0x0000CD24
		private static void InitProperties()
		{
			if (InterpretacionDePersonalidad_DELETE.m_initProperties)
			{
				return;
			}
			InterpretacionHelper.InitProperties<InterpretacionDePersonalidad_DELETE>(InterpretacionDePersonalidad_DELETE.m_getters, InterpretacionDePersonalidad_DELETE.m_setters, "Valor");
			InterpretacionDePersonalidad_DELETE.m_initProperties = true;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0000EB48 File Offset: 0x0000CD48
		private static void InitDisplays()
		{
			if (InterpretacionDePersonalidad_DELETE.m_initDisplays)
			{
				return;
			}
			InterpretacionHelper.InitDisplays<InterpretacionDePersonalidad_DELETE>(InterpretacionDePersonalidad_DELETE.m_displays);
			InterpretacionDePersonalidad_DELETE.m_initDisplays = true;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000EB64 File Offset: 0x0000CD64
		public static string Localizado(string field, string localizacion)
		{
			InterpretacionDePersonalidad_DELETE.InitDisplays();
			string text;
			try
			{
				text = InterpretacionDePersonalidad_DELETE.m_displays[field][localizacion];
			}
			catch (Exception)
			{
				throw;
			}
			return text;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000EBA0 File Offset: 0x0000CDA0
		public int GetValor(string field)
		{
			InterpretacionDePersonalidad_DELETE.InitProperties();
			int num;
			try
			{
				num = InterpretacionDePersonalidad_DELETE.m_getters[field].Item2(ref this);
			}
			catch (Exception)
			{
				throw;
			}
			return num;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0000EBE0 File Offset: 0x0000CDE0
		public void SetValor(string field, int valor)
		{
			InterpretacionDePersonalidad_DELETE.InitProperties();
			try
			{
				InterpretacionDePersonalidad_DELETE.m_setters[field].Item2(ref this, valor);
			}
			catch (Exception)
			{
				throw;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x0000EC20 File Offset: 0x0000CE20
		// (set) Token: 0x060003B7 RID: 951 RVA: 0x0000EC28 File Offset: 0x0000CE28
		[LabelLocalizado("Vaginal capacity –deepness", "US")]
		public Interpretacion.Size vaginalProfundidadQueen
		{
			get
			{
				return this.m_vaginalProfundidadQueen;
			}
			set
			{
				this.m_vaginalProfundidadQueen = value;
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x0000EC31 File Offset: 0x0000CE31
		// (set) Token: 0x060003B9 RID: 953 RVA: 0x0000EC39 File Offset: 0x0000CE39
		[LabelLocalizado("Anal capacity –deepness", "US")]
		public Interpretacion.Size analProfundidadQueen
		{
			get
			{
				return this.m_analProfundidadQueen;
			}
			set
			{
				this.m_analProfundidadQueen = value;
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x060003BA RID: 954 RVA: 0x0000EC42 File Offset: 0x0000CE42
		// (set) Token: 0x060003BB RID: 955 RVA: 0x0000EC4A File Offset: 0x0000CE4A
		[LabelLocalizado("Oral capacity –deepness", "US")]
		public Interpretacion.Size oralProfundidadQueen
		{
			get
			{
				return this.m_oralProfundidadQueen;
			}
			set
			{
				this.m_oralProfundidadQueen = value;
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x060003BC RID: 956 RVA: 0x0000EC53 File Offset: 0x0000CE53
		// (set) Token: 0x060003BD RID: 957 RVA: 0x0000EC5B File Offset: 0x0000CE5B
		[LabelLocalizado("Vaginal capacity –wideness", "US")]
		public Interpretacion.Size vaginalAnchuraQueen
		{
			get
			{
				return this.m_vaginalAnchuraQueen;
			}
			set
			{
				this.m_vaginalAnchuraQueen = value;
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x060003BE RID: 958 RVA: 0x0000EC64 File Offset: 0x0000CE64
		// (set) Token: 0x060003BF RID: 959 RVA: 0x0000EC6C File Offset: 0x0000CE6C
		[LabelLocalizado("Anal capacity –wideness", "US")]
		public Interpretacion.Size analAnchuraQueen
		{
			get
			{
				return this.m_analAnchuraQueen;
			}
			set
			{
				this.m_analAnchuraQueen = value;
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x0000EC75 File Offset: 0x0000CE75
		// (set) Token: 0x060003C1 RID: 961 RVA: 0x0000EC7D File Offset: 0x0000CE7D
		[LabelLocalizado("Oral capacity –wideness", "US")]
		public Interpretacion.Size oralAnchuraQueen
		{
			get
			{
				return this.m_oralAnchuraQueen;
			}
			set
			{
				this.m_oralAnchuraQueen = value;
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x0000EC86 File Offset: 0x0000CE86
		// (set) Token: 0x060003C3 RID: 963 RVA: 0x0000EC8E File Offset: 0x0000CE8E
		[LabelLocalizado("Vaginal sex permission", "US")]
		public Interpretacion.Capacidad vaginalConsent
		{
			get
			{
				return this.m_vaginalConsent;
			}
			set
			{
				this.m_vaginalConsent = value;
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x0000EC97 File Offset: 0x0000CE97
		// (set) Token: 0x060003C5 RID: 965 RVA: 0x0000EC9F File Offset: 0x0000CE9F
		[LabelLocalizado("Anal sex permission", "US")]
		public Interpretacion.Capacidad analConsent
		{
			get
			{
				return this.m_analConsent;
			}
			set
			{
				this.m_analConsent = value;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x0000ECA8 File Offset: 0x0000CEA8
		// (set) Token: 0x060003C7 RID: 967 RVA: 0x0000ECB0 File Offset: 0x0000CEB0
		[LabelLocalizado("Oral sex permission", "US")]
		public Interpretacion.Capacidad oralConsent
		{
			get
			{
				return this.m_oralConsent;
			}
			set
			{
				this.m_oralConsent = value;
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x0000ECB9 File Offset: 0x0000CEB9
		// (set) Token: 0x060003C9 RID: 969 RVA: 0x0000ECC1 File Offset: 0x0000CEC1
		[LabelLocalizado("Photoshooting permission", "US")]
		public Interpretacion.Capacidad watchedConsent
		{
			get
			{
				return this.m_watchedConsent;
			}
			set
			{
				this.m_watchedConsent = value;
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x060003CA RID: 970 RVA: 0x0000ECCA File Offset: 0x0000CECA
		// (set) Token: 0x060003CB RID: 971 RVA: 0x0000ECD2 File Offset: 0x0000CED2
		[LabelLocalizado("Photoshooting privates permission", "US")]
		public Interpretacion.Capacidad watchedPrivatesConsent
		{
			get
			{
				return this.m_watchedPrivatesConsent;
			}
			set
			{
				this.m_watchedPrivatesConsent = value;
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x060003CC RID: 972 RVA: 0x0000ECDB File Offset: 0x0000CEDB
		// (set) Token: 0x060003CD RID: 973 RVA: 0x0000ECE3 File Offset: 0x0000CEE3
		[LabelLocalizado("Cuddling permission", "US")]
		public Interpretacion.Capacidad touchedConsent
		{
			get
			{
				return this.m_touchedConsent;
			}
			set
			{
				this.m_touchedConsent = value;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x060003CE RID: 974 RVA: 0x0000ECEC File Offset: 0x0000CEEC
		// (set) Token: 0x060003CF RID: 975 RVA: 0x0000ECF4 File Offset: 0x0000CEF4
		[LabelLocalizado("Fondling permission", "US")]
		public Interpretacion.Capacidad touchedPrivatesConsent
		{
			get
			{
				return this.m_touchedPrivatesConsent;
			}
			set
			{
				this.m_touchedPrivatesConsent = value;
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x0000ECFD File Offset: 0x0000CEFD
		// (set) Token: 0x060003D1 RID: 977 RVA: 0x0000ED05 File Offset: 0x0000CF05
		[LabelLocalizado("Wearing swimsuit / just–underwar permission", "US")]
		public Interpretacion.Capacidad undressedConsent
		{
			get
			{
				return this.m_undressedConsent;
			}
			set
			{
				this.m_undressedConsent = value;
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x060003D2 RID: 978 RVA: 0x0000ED0E File Offset: 0x0000CF0E
		// (set) Token: 0x060003D3 RID: 979 RVA: 0x0000ED16 File Offset: 0x0000CF16
		[LabelLocalizado("Stripping permission", "US")]
		public Interpretacion.Capacidad undressedPrivatesConsent
		{
			get
			{
				return this.m_undressedPrivatesConsent;
			}
			set
			{
				this.m_undressedPrivatesConsent = value;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x060003D4 RID: 980 RVA: 0x0000ED1F File Offset: 0x0000CF1F
		// (set) Token: 0x060003D5 RID: 981 RVA: 0x0000ED27 File Offset: 0x0000CF27
		public int vaginalProfundidadQueenValor
		{
			get
			{
				return (int)this.m_vaginalProfundidadQueen;
			}
			set
			{
				this.m_vaginalProfundidadQueen = (Interpretacion.Size)value;
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x0000ED30 File Offset: 0x0000CF30
		// (set) Token: 0x060003D7 RID: 983 RVA: 0x0000ED38 File Offset: 0x0000CF38
		public int analProfundidadQueenValor
		{
			get
			{
				return (int)this.m_analProfundidadQueen;
			}
			set
			{
				this.m_analProfundidadQueen = (Interpretacion.Size)value;
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x0000ED41 File Offset: 0x0000CF41
		// (set) Token: 0x060003D9 RID: 985 RVA: 0x0000ED49 File Offset: 0x0000CF49
		public int oralProfundidadQueenValor
		{
			get
			{
				return (int)this.m_oralProfundidadQueen;
			}
			set
			{
				this.m_oralProfundidadQueen = (Interpretacion.Size)value;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x060003DA RID: 986 RVA: 0x0000ED52 File Offset: 0x0000CF52
		// (set) Token: 0x060003DB RID: 987 RVA: 0x0000ED5A File Offset: 0x0000CF5A
		public int vaginalAnchuraQueenValor
		{
			get
			{
				return (int)this.m_vaginalAnchuraQueen;
			}
			set
			{
				this.m_vaginalAnchuraQueen = (Interpretacion.Size)value;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060003DC RID: 988 RVA: 0x0000ED63 File Offset: 0x0000CF63
		// (set) Token: 0x060003DD RID: 989 RVA: 0x0000ED6B File Offset: 0x0000CF6B
		public int analAnchuraQueenValor
		{
			get
			{
				return (int)this.m_analAnchuraQueen;
			}
			set
			{
				this.m_analAnchuraQueen = (Interpretacion.Size)value;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060003DE RID: 990 RVA: 0x0000ED74 File Offset: 0x0000CF74
		// (set) Token: 0x060003DF RID: 991 RVA: 0x0000ED7C File Offset: 0x0000CF7C
		public int oralAnchuraQueenValor
		{
			get
			{
				return (int)this.m_oralAnchuraQueen;
			}
			set
			{
				this.m_oralAnchuraQueen = (Interpretacion.Size)value;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x0000ED85 File Offset: 0x0000CF85
		// (set) Token: 0x060003E1 RID: 993 RVA: 0x0000ED8D File Offset: 0x0000CF8D
		public int vaginalConsentValor
		{
			get
			{
				return (int)this.m_vaginalConsent;
			}
			set
			{
				this.m_vaginalConsent = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x0000ED96 File Offset: 0x0000CF96
		// (set) Token: 0x060003E3 RID: 995 RVA: 0x0000ED9E File Offset: 0x0000CF9E
		public int analConsentValor
		{
			get
			{
				return (int)this.m_analConsent;
			}
			set
			{
				this.m_analConsent = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x0000EDA7 File Offset: 0x0000CFA7
		// (set) Token: 0x060003E5 RID: 997 RVA: 0x0000EDAF File Offset: 0x0000CFAF
		public int oralConsentValor
		{
			get
			{
				return (int)this.m_oralConsent;
			}
			set
			{
				this.m_oralConsent = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x0000EDB8 File Offset: 0x0000CFB8
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x0000EDC0 File Offset: 0x0000CFC0
		public int watchedConsentValor
		{
			get
			{
				return (int)this.m_watchedConsent;
			}
			set
			{
				this.m_watchedConsent = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x0000EDC9 File Offset: 0x0000CFC9
		// (set) Token: 0x060003E9 RID: 1001 RVA: 0x0000EDD1 File Offset: 0x0000CFD1
		public int watchedPrivatesConsentValor
		{
			get
			{
				return (int)this.m_watchedPrivatesConsent;
			}
			set
			{
				this.m_watchedPrivatesConsent = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x0000EDDA File Offset: 0x0000CFDA
		// (set) Token: 0x060003EB RID: 1003 RVA: 0x0000EDE2 File Offset: 0x0000CFE2
		public int touchedConsentValor
		{
			get
			{
				return (int)this.m_touchedConsent;
			}
			set
			{
				this.m_touchedConsent = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x0000EDEB File Offset: 0x0000CFEB
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x0000EDF3 File Offset: 0x0000CFF3
		public int touchedPrivatesConsentValor
		{
			get
			{
				return (int)this.m_touchedPrivatesConsent;
			}
			set
			{
				this.m_touchedPrivatesConsent = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x0000EDFC File Offset: 0x0000CFFC
		// (set) Token: 0x060003EF RID: 1007 RVA: 0x0000EE04 File Offset: 0x0000D004
		public int undressedConsentValor
		{
			get
			{
				return (int)this.m_undressedConsent;
			}
			set
			{
				this.m_undressedConsent = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x060003F0 RID: 1008 RVA: 0x0000EE0D File Offset: 0x0000D00D
		// (set) Token: 0x060003F1 RID: 1009 RVA: 0x0000EE15 File Offset: 0x0000D015
		public int undressedPrivatesConsentValor
		{
			get
			{
				return (int)this.m_undressedPrivatesConsent;
			}
			set
			{
				this.m_undressedPrivatesConsent = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0000EE20 File Offset: 0x0000D020
		[Obsolete("", true)]
		public bool Cumple(IInterpretacionDePersonalidadCondiciones condiciones)
		{
			return condiciones.vaginalProfundidadQueen.Contains(this.m_vaginalProfundidadQueen) && condiciones.analProfundidadQueen.Contains(this.m_analProfundidadQueen) && condiciones.oralProfundidadQueen.Contains(this.m_oralProfundidadQueen) && condiciones.vaginalAnchuraQueen.Contains(this.m_vaginalAnchuraQueen) && condiciones.analAnchuraQueen.Contains(this.m_analAnchuraQueen) && condiciones.oralAnchuraQueen.Contains(this.m_oralAnchuraQueen) && condiciones.vaginalConsent.Contains(this.m_vaginalConsent) && condiciones.analConsent.Contains(this.m_analConsent) && condiciones.oralConsent.Contains(this.m_oralConsent) && condiciones.watchedConsent.Contains(this.m_watchedConsent) && condiciones.watchedPrivatesConsent.Contains(this.m_watchedPrivatesConsent) && condiciones.touchedConsent.Contains(this.m_touchedConsent) && condiciones.touchedPrivatesConsent.Contains(this.m_touchedPrivatesConsent) && condiciones.undressedConsent.Contains(this.m_undressedConsent) && condiciones.undressedPrivatesConsent.Contains(this.m_undressedPrivatesConsent);
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0000EF69 File Offset: 0x0000D169
		public int GetValor(string subInterpretacion, string field)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0000EF70 File Offset: 0x0000D170
		public void SetValor(string subInterpretacion, string field, int valor)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000156 RID: 342
		[NonSerialized]
		private static bool m_initProperties;

		// Token: 0x04000157 RID: 343
		[NonSerialized]
		private static bool m_initDisplays;

		// Token: 0x04000158 RID: 344
		private static readonly Dictionary<string, ValueTuple<PropertyInfo, InterpretacionHelper.PropGetter<InterpretacionDePersonalidad_DELETE>>> m_getters = new Dictionary<string, ValueTuple<PropertyInfo, InterpretacionHelper.PropGetter<InterpretacionDePersonalidad_DELETE>>>();

		// Token: 0x04000159 RID: 345
		private static readonly Dictionary<string, ValueTuple<PropertyInfo, InterpretacionHelper.PropSetter<InterpretacionDePersonalidad_DELETE>>> m_setters = new Dictionary<string, ValueTuple<PropertyInfo, InterpretacionHelper.PropSetter<InterpretacionDePersonalidad_DELETE>>>();

		// Token: 0x0400015A RID: 346
		private static readonly Dictionary<string, Dictionary<string, string>> m_displays = new Dictionary<string, Dictionary<string, string>>();

		// Token: 0x0400015B RID: 347
		[SerializeField]
		private Interpretacion.Size m_vaginalProfundidadQueen;

		// Token: 0x0400015C RID: 348
		[SerializeField]
		private Interpretacion.Size m_analProfundidadQueen;

		// Token: 0x0400015D RID: 349
		[SerializeField]
		private Interpretacion.Size m_oralProfundidadQueen;

		// Token: 0x0400015E RID: 350
		[SerializeField]
		private Interpretacion.Size m_vaginalAnchuraQueen;

		// Token: 0x0400015F RID: 351
		[SerializeField]
		private Interpretacion.Size m_analAnchuraQueen;

		// Token: 0x04000160 RID: 352
		[SerializeField]
		private Interpretacion.Size m_oralAnchuraQueen;

		// Token: 0x04000161 RID: 353
		[SerializeField]
		private Interpretacion.Capacidad m_vaginalConsent;

		// Token: 0x04000162 RID: 354
		[SerializeField]
		private Interpretacion.Capacidad m_analConsent;

		// Token: 0x04000163 RID: 355
		[SerializeField]
		private Interpretacion.Capacidad m_oralConsent;

		// Token: 0x04000164 RID: 356
		[SerializeField]
		private Interpretacion.Capacidad m_watchedConsent;

		// Token: 0x04000165 RID: 357
		[SerializeField]
		private Interpretacion.Capacidad m_watchedPrivatesConsent;

		// Token: 0x04000166 RID: 358
		[SerializeField]
		private Interpretacion.Capacidad m_touchedConsent;

		// Token: 0x04000167 RID: 359
		[SerializeField]
		private Interpretacion.Capacidad m_touchedPrivatesConsent;

		// Token: 0x04000168 RID: 360
		[SerializeField]
		private Interpretacion.Capacidad m_undressedConsent;

		// Token: 0x04000169 RID: 361
		[SerializeField]
		private Interpretacion.Capacidad m_undressedPrivatesConsent;
	}
}
