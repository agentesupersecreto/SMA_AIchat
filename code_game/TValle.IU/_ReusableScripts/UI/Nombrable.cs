using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.UI
{
	// Token: 0x02000010 RID: 16
	public sealed class Nombrable : CustomUpdatedMonobehaviourBase, INombrableLocalizado, INombrable
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002C04 File Offset: 0x00000E04
		public bool esPlural
		{
			get
			{
				Nombrable.Item item = this.ObtenerDeCurrentLocalization();
				return ((item != null) ? new bool?(item.esPlural) : null).GetValueOrDefault(false);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002C3C File Offset: 0x00000E3C
		public bool esFemenino
		{
			get
			{
				Nombrable.Item item = this.ObtenerDeCurrentLocalization();
				return ((item != null) ? new bool?(item.esFemenino) : null).GetValueOrDefault(false);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002C71 File Offset: 0x00000E71
		public string nombre
		{
			get
			{
				return this.ObtenerDeCurrentLocalization().original;
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002C80 File Offset: 0x00000E80
		private void CheckInit()
		{
			if (this.m_iniciadoDicc != null)
			{
				return;
			}
			this.m_iniciadoDicc = new DiccionaryEnum<Localizacion, Nombrable.Item>(this.m_Localizados.Count, (Localizacion x) => (int)x);
			foreach (Nombrable.Item item in this.m_Localizados)
			{
				if (this.m_iniciadoDicc.ContainsKey(item.para))
				{
					Debug.LogError("Localizacion repetida", this);
				}
				else
				{
					this.m_iniciadoDicc.Add(item.para, item);
				}
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002D3C File Offset: 0x00000F3C
		public Nombrable.Item ObtenerDeCurrentLocalization()
		{
			this.CheckInit();
			Localizacion localizacion;
			if (!Singleton<ConfiguracionGeneralDeIdioma>.IsInScene)
			{
				localizacion = Localizacion.US;
			}
			else
			{
				localizacion = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id;
			}
			Nombrable.Item item;
			if (!this.m_iniciadoDicc.TryGetValue(localizacion, out item))
			{
				Debug.LogError("Local " + localizacion.ToString() + " no se encuentra en diccionario de nombres");
				item = this.m_Localizados.FirstOrDefault<Nombrable.Item>();
			}
			return item;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002DA8 File Offset: 0x00000FA8
		public string ObtenerNombreDeCurrentLocalization(NombrableResult resultado)
		{
			Nombrable.Item item = this.ObtenerDeCurrentLocalization();
			if (item == null)
			{
				return "NO NAME";
			}
			return item.Obtener(resultado);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002DCC File Offset: 0x00000FCC
		public void UpdateName()
		{
		}

		// Token: 0x04000029 RID: 41
		[CoolArrayItem]
		[SerializeField]
		private List<Nombrable.Item> m_Localizados = new List<Nombrable.Item>();

		// Token: 0x0400002A RID: 42
		[NonSerialized]
		private DiccionaryEnum<Localizacion, Nombrable.Item> m_iniciadoDicc;

		// Token: 0x02000161 RID: 353
		[Serializable]
		public class Item
		{
			// Token: 0x170002D8 RID: 728
			// (get) Token: 0x06000A69 RID: 2665 RVA: 0x00022943 File Offset: 0x00020B43
			public Localizacion para
			{
				get
				{
					return this.m_para;
				}
			}

			// Token: 0x170002D9 RID: 729
			// (get) Token: 0x06000A6A RID: 2666 RVA: 0x0002294B File Offset: 0x00020B4B
			public string original
			{
				get
				{
					return this.m_text;
				}
			}

			// Token: 0x170002DA RID: 730
			// (get) Token: 0x06000A6B RID: 2667 RVA: 0x00022953 File Offset: 0x00020B53
			public string lower
			{
				get
				{
					if (this.m_lower == null)
					{
						this.m_lower = this.m_text.Trim().ToLowerInvariant();
					}
					return this.m_lower;
				}
			}

			// Token: 0x170002DB RID: 731
			// (get) Token: 0x06000A6C RID: 2668 RVA: 0x00022979 File Offset: 0x00020B79
			public string firstUpper
			{
				get
				{
					if (this.m_firstUpper == null)
					{
						this.m_firstUpper = this.m_text.FirstLetterToUpperCaseOthersToLowerNoOptimizado();
					}
					return this.m_firstUpper;
				}
			}

			// Token: 0x170002DC RID: 732
			// (get) Token: 0x06000A6D RID: 2669 RVA: 0x0002299A File Offset: 0x00020B9A
			public string upper
			{
				get
				{
					if (this.m_upper == null)
					{
						this.m_upper = this.m_text.Trim().ToUpperInvariant();
					}
					return this.m_upper;
				}
			}

			// Token: 0x170002DD RID: 733
			// (get) Token: 0x06000A6E RID: 2670 RVA: 0x000229C0 File Offset: 0x00020BC0
			public bool esPlural
			{
				get
				{
					return this.m_esPlural;
				}
			}

			// Token: 0x170002DE RID: 734
			// (get) Token: 0x06000A6F RID: 2671 RVA: 0x000229C8 File Offset: 0x00020BC8
			public bool esFemenino
			{
				get
				{
					return this.m_esFemenino;
				}
			}

			// Token: 0x06000A70 RID: 2672 RVA: 0x000229D0 File Offset: 0x00020BD0
			public string Obtener(NombrableResult resultado)
			{
				switch (resultado)
				{
				case NombrableResult.original:
					return this.original;
				case NombrableResult.lower:
					return this.lower;
				case NombrableResult.firstUpper:
					return this.firstUpper;
				case NombrableResult.upper:
					return this.upper;
				default:
					throw new ArgumentOutOfRangeException(resultado.ToString());
				}
			}

			// Token: 0x04000458 RID: 1112
			[SerializeField]
			private Localizacion m_para;

			// Token: 0x04000459 RID: 1113
			[SerializeField]
			private string m_text;

			// Token: 0x0400045A RID: 1114
			[SerializeField]
			private bool m_esPlural;

			// Token: 0x0400045B RID: 1115
			[SerializeField]
			private bool m_esFemenino;

			// Token: 0x0400045C RID: 1116
			[NonSerialized]
			private string m_lower;

			// Token: 0x0400045D RID: 1117
			[NonSerialized]
			private string m_firstUpper;

			// Token: 0x0400045E RID: 1118
			[NonSerialized]
			private string m_upper;
		}

		// Token: 0x02000162 RID: 354
		[Serializable]
		public class Class : INombrableLocalizado, INombrable
		{
			// Token: 0x170002DF RID: 735
			// (get) Token: 0x06000A72 RID: 2674 RVA: 0x00022A2C File Offset: 0x00020C2C
			public bool esPlural
			{
				get
				{
					Nombrable.Item item = this.ObtenerDeCurrentLocalization();
					return ((item != null) ? new bool?(item.esPlural) : null).GetValueOrDefault(false);
				}
			}

			// Token: 0x170002E0 RID: 736
			// (get) Token: 0x06000A73 RID: 2675 RVA: 0x00022A64 File Offset: 0x00020C64
			public bool esFemenino
			{
				get
				{
					Nombrable.Item item = this.ObtenerDeCurrentLocalization();
					return ((item != null) ? new bool?(item.esFemenino) : null).GetValueOrDefault(false);
				}
			}

			// Token: 0x170002E1 RID: 737
			// (get) Token: 0x06000A74 RID: 2676 RVA: 0x00022A99 File Offset: 0x00020C99
			public string nombre
			{
				get
				{
					return this.ObtenerDeCurrentLocalization().original;
				}
			}

			// Token: 0x06000A75 RID: 2677 RVA: 0x00022AA8 File Offset: 0x00020CA8
			private void CheckInit()
			{
				if (this.m_iniciadoDicc != null)
				{
					return;
				}
				this.m_iniciadoDicc = new DiccionaryEnum<Localizacion, Nombrable.Item>(this.m_Localizados.Count, (Localizacion x) => (int)x);
				foreach (Nombrable.Item item in this.m_Localizados)
				{
					if (this.m_iniciadoDicc.ContainsKey(item.para))
					{
						Debug.LogError("Localizacion repetida");
					}
					else
					{
						this.m_iniciadoDicc.Add(item.para, item);
					}
				}
			}

			// Token: 0x06000A76 RID: 2678 RVA: 0x00022B64 File Offset: 0x00020D64
			public Nombrable.Item ObtenerDeCurrentLocalization()
			{
				this.CheckInit();
				Localizacion localizacion;
				if (!Singleton<ConfiguracionGeneralDeIdioma>.IsInScene)
				{
					localizacion = Localizacion.US;
				}
				else
				{
					localizacion = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id;
				}
				Nombrable.Item item;
				if (!this.m_iniciadoDicc.TryGetValue(localizacion, out item))
				{
					item = this.m_Localizados.FirstOrDefault<Nombrable.Item>();
				}
				return item;
			}

			// Token: 0x06000A77 RID: 2679 RVA: 0x00022BB0 File Offset: 0x00020DB0
			public string ObtenerNombreDeCurrentLocalization(NombrableResult resultado)
			{
				Nombrable.Item item = this.ObtenerDeCurrentLocalization();
				if (item == null)
				{
					return "NO NAME";
				}
				return item.Obtener(resultado);
			}

			// Token: 0x06000A78 RID: 2680 RVA: 0x00022BD4 File Offset: 0x00020DD4
			public void UpdateName()
			{
			}

			// Token: 0x0400045F RID: 1119
			[SerializeField]
			private List<Nombrable.Item> m_Localizados = new List<Nombrable.Item>();

			// Token: 0x04000460 RID: 1120
			[NonSerialized]
			private DiccionaryEnum<Localizacion, Nombrable.Item> m_iniciadoDicc;
		}
	}
}
