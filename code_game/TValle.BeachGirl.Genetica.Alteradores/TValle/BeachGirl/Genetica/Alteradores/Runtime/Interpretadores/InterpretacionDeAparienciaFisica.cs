using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000052 RID: 82
	[Serializable]
	public struct InterpretacionDeAparienciaFisica : IIntrepretacion
	{
		// Token: 0x060003F6 RID: 1014 RVA: 0x0000EF97 File Offset: 0x0000D197
		private static void InitProperties()
		{
			if (InterpretacionDeAparienciaFisica.m_initProperties)
			{
				return;
			}
			InterpretacionHelper.InitProperties<InterpretacionDeAparienciaFisica>(InterpretacionDeAparienciaFisica.m_getters, InterpretacionDeAparienciaFisica.m_setters, "Valor");
			InterpretacionDeAparienciaFisica.m_initProperties = true;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000EFBB File Offset: 0x0000D1BB
		private static void InitDisplays()
		{
			if (InterpretacionDeAparienciaFisica.m_initDisplays)
			{
				return;
			}
			InterpretacionHelper.InitDisplays<InterpretacionDeAparienciaFisica>(InterpretacionDeAparienciaFisica.m_displays);
			InterpretacionDeAparienciaFisica.m_initDisplays = true;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0000EFD8 File Offset: 0x0000D1D8
		public static string Localizado(string field, string localizacion)
		{
			InterpretacionDeAparienciaFisica.InitDisplays();
			string text2;
			try
			{
				Dictionary<string, string> dictionary = InterpretacionDeAparienciaFisica.m_displays[field];
				string text;
				if (dictionary.TryGetValue(localizacion, out text))
				{
					text2 = text;
				}
				else
				{
					text2 = dictionary[Localizacion.US.ToString()];
				}
			}
			catch (Exception)
			{
				throw;
			}
			return text2;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0000F034 File Offset: 0x0000D234
		public int GetValor(string field)
		{
			InterpretacionDeAparienciaFisica.InitProperties();
			int num;
			try
			{
				num = InterpretacionDeAparienciaFisica.m_getters[field].Item2(ref this);
			}
			catch (Exception)
			{
				throw;
			}
			return num;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0000F074 File Offset: 0x0000D274
		public void SetValor(string field, int valor)
		{
			InterpretacionDeAparienciaFisica.InitProperties();
			try
			{
				InterpretacionDeAparienciaFisica.m_setters[field].Item2(ref this, valor);
			}
			catch (Exception)
			{
				throw;
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x0000F0B4 File Offset: 0x0000D2B4
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x0000F0BC File Offset: 0x0000D2BC
		[LabelLocalizado("Butt size", "US")]
		public Interpretacion.Size culo
		{
			get
			{
				return this.m_culo;
			}
			set
			{
				this.m_culo = value;
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x0000F0C5 File Offset: 0x0000D2C5
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x0000F0CD File Offset: 0x0000D2CD
		[LabelLocalizado("Breast size", "US")]
		public Interpretacion.Size tetas
		{
			get
			{
				return this.m_tetas;
			}
			set
			{
				this.m_tetas = value;
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x0000F0D6 File Offset: 0x0000D2D6
		// (set) Token: 0x06000400 RID: 1024 RVA: 0x0000F0DE File Offset: 0x0000D2DE
		[LabelLocalizado("Height size", "US")]
		public Interpretacion.Size estatura
		{
			get
			{
				return this.m_estatura;
			}
			set
			{
				this.m_estatura = value;
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000401 RID: 1025 RVA: 0x0000F0E7 File Offset: 0x0000D2E7
		// (set) Token: 0x06000402 RID: 1026 RVA: 0x0000F0EF File Offset: 0x0000D2EF
		[LabelLocalizado("Body fat", "US")]
		public Interpretacion.Capacidad bodyFat
		{
			get
			{
				return this.m_bodyFat;
			}
			set
			{
				this.m_bodyFat = value;
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000403 RID: 1027 RVA: 0x0000F0F8 File Offset: 0x0000D2F8
		// (set) Token: 0x06000404 RID: 1028 RVA: 0x0000F100 File Offset: 0x0000D300
		[LabelLocalizado("Thickness", "US")]
		public Interpretacion.Capacidad thickness
		{
			get
			{
				return this.m_thickness;
			}
			set
			{
				this.m_thickness = value;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x0000F109 File Offset: 0x0000D309
		// (set) Token: 0x06000406 RID: 1030 RVA: 0x0000F111 File Offset: 0x0000D311
		[LabelLocalizado("Skin tone", "US")]
		public Interpretacion.Tono tonoPiel
		{
			get
			{
				return this.m_tonoPiel;
			}
			set
			{
				this.m_tonoPiel = value;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x0000F11A File Offset: 0x0000D31A
		// (set) Token: 0x06000408 RID: 1032 RVA: 0x0000F122 File Offset: 0x0000D322
		[LabelLocalizado("Brown Skin", "US")]
		public Interpretacion.Capacidad pielTrigena
		{
			get
			{
				return this.m_pielTrigena;
			}
			set
			{
				this.m_pielTrigena = value;
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000409 RID: 1033 RVA: 0x0000F12B File Offset: 0x0000D32B
		// (set) Token: 0x0600040A RID: 1034 RVA: 0x0000F133 File Offset: 0x0000D333
		[LabelLocalizado("Hair tone", "US")]
		public Interpretacion.Tono tonoCabello
		{
			get
			{
				return this.m_tonoCabello;
			}
			set
			{
				this.m_tonoCabello = value;
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x0600040B RID: 1035 RVA: 0x0000F13C File Offset: 0x0000D33C
		// (set) Token: 0x0600040C RID: 1036 RVA: 0x0000F144 File Offset: 0x0000D344
		[LabelLocalizado("Eyes tone", "US")]
		public Interpretacion.Tono tonoOjos
		{
			get
			{
				return this.m_tonoOjos;
			}
			set
			{
				this.m_tonoOjos = value;
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x0000F14D File Offset: 0x0000D34D
		// (set) Token: 0x0600040E RID: 1038 RVA: 0x0000F155 File Offset: 0x0000D355
		public int culoValor
		{
			get
			{
				return (int)this.m_culo;
			}
			set
			{
				this.m_culo = (Interpretacion.Size)value;
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x0600040F RID: 1039 RVA: 0x0000F15E File Offset: 0x0000D35E
		// (set) Token: 0x06000410 RID: 1040 RVA: 0x0000F166 File Offset: 0x0000D366
		public int tetasValor
		{
			get
			{
				return (int)this.m_tetas;
			}
			set
			{
				this.m_tetas = (Interpretacion.Size)value;
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x0000F16F File Offset: 0x0000D36F
		// (set) Token: 0x06000412 RID: 1042 RVA: 0x0000F177 File Offset: 0x0000D377
		public int estaturaValor
		{
			get
			{
				return (int)this.m_estatura;
			}
			set
			{
				this.m_estatura = (Interpretacion.Size)value;
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x0000F180 File Offset: 0x0000D380
		// (set) Token: 0x06000414 RID: 1044 RVA: 0x0000F188 File Offset: 0x0000D388
		public int bodyFatValor
		{
			get
			{
				return (int)this.m_bodyFat;
			}
			set
			{
				this.m_bodyFat = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x0000F191 File Offset: 0x0000D391
		// (set) Token: 0x06000416 RID: 1046 RVA: 0x0000F199 File Offset: 0x0000D399
		public int thicknessValor
		{
			get
			{
				return (int)this.m_thickness;
			}
			set
			{
				this.m_thickness = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x0000F1A2 File Offset: 0x0000D3A2
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x0000F1AA File Offset: 0x0000D3AA
		public int tonoPielValor
		{
			get
			{
				return (int)this.m_tonoPiel;
			}
			set
			{
				this.m_tonoPiel = (Interpretacion.Tono)value;
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x0000F1B3 File Offset: 0x0000D3B3
		// (set) Token: 0x0600041A RID: 1050 RVA: 0x0000F1BB File Offset: 0x0000D3BB
		public int pielTrigenaValor
		{
			get
			{
				return (int)this.m_pielTrigena;
			}
			set
			{
				this.m_pielTrigena = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x0000F1C4 File Offset: 0x0000D3C4
		// (set) Token: 0x0600041C RID: 1052 RVA: 0x0000F1CC File Offset: 0x0000D3CC
		public int tonoCabelloValor
		{
			get
			{
				return (int)this.m_tonoCabello;
			}
			set
			{
				this.m_tonoCabello = (Interpretacion.Tono)value;
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x0000F1D5 File Offset: 0x0000D3D5
		// (set) Token: 0x0600041E RID: 1054 RVA: 0x0000F1DD File Offset: 0x0000D3DD
		public int tonoOjosValor
		{
			get
			{
				return (int)this.m_tonoOjos;
			}
			set
			{
				this.m_tonoOjos = (Interpretacion.Tono)value;
			}
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0000F1E8 File Offset: 0x0000D3E8
		[Obsolete("", true)]
		public bool Cumple(IInterpretacionDeAparienciaFisica condiciones)
		{
			return condiciones.culo.Contains(this.m_culo) && condiciones.tetas.Contains(this.m_tetas) && condiciones.estatura.Contains(this.m_estatura) && condiciones.bodyFat.Contains(this.m_bodyFat) && condiciones.thickness.Contains(this.m_thickness) && condiciones.tonoPiel.Contains(this.m_tonoPiel) && condiciones.pielTrigena.Contains(this.m_pielTrigena) && condiciones.tonoCabello.Contains(this.m_tonoCabello) && condiciones.tonoOjos.Contains(this.m_tonoOjos);
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0000F2B3 File Offset: 0x0000D4B3
		public int GetValor(string subInterpretacion, string field)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0000F2BA File Offset: 0x0000D4BA
		public void SetValor(string subInterpretacion, string field, int valor)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0400016A RID: 362
		[NonSerialized]
		private static bool m_initProperties;

		// Token: 0x0400016B RID: 363
		[NonSerialized]
		private static bool m_initDisplays;

		// Token: 0x0400016C RID: 364
		private static readonly Dictionary<string, ValueTuple<PropertyInfo, InterpretacionHelper.PropGetter<InterpretacionDeAparienciaFisica>>> m_getters = new Dictionary<string, ValueTuple<PropertyInfo, InterpretacionHelper.PropGetter<InterpretacionDeAparienciaFisica>>>();

		// Token: 0x0400016D RID: 365
		private static readonly Dictionary<string, ValueTuple<PropertyInfo, InterpretacionHelper.PropSetter<InterpretacionDeAparienciaFisica>>> m_setters = new Dictionary<string, ValueTuple<PropertyInfo, InterpretacionHelper.PropSetter<InterpretacionDeAparienciaFisica>>>();

		// Token: 0x0400016E RID: 366
		private static readonly Dictionary<string, Dictionary<string, string>> m_displays = new Dictionary<string, Dictionary<string, string>>();

		// Token: 0x0400016F RID: 367
		[SerializeField]
		private Interpretacion.Size m_culo;

		// Token: 0x04000170 RID: 368
		[SerializeField]
		private Interpretacion.Size m_tetas;

		// Token: 0x04000171 RID: 369
		[SerializeField]
		private Interpretacion.Size m_estatura;

		// Token: 0x04000172 RID: 370
		[SerializeField]
		private Interpretacion.Capacidad m_bodyFat;

		// Token: 0x04000173 RID: 371
		[SerializeField]
		private Interpretacion.Capacidad m_thickness;

		// Token: 0x04000174 RID: 372
		[SerializeField]
		private Interpretacion.Tono m_tonoPiel;

		// Token: 0x04000175 RID: 373
		[SerializeField]
		private Interpretacion.Capacidad m_pielTrigena;

		// Token: 0x04000176 RID: 374
		[SerializeField]
		private Interpretacion.Tono m_tonoCabello;

		// Token: 0x04000177 RID: 375
		[SerializeField]
		private Interpretacion.Tono m_tonoOjos;
	}
}
