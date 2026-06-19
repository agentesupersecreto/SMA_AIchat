using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets._ReusableScripts.Textos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos
{
	// Token: 0x020001D5 RID: 469
	[Serializable]
	public class DialogoInfo : IDialogoInfoTextMods, DiccionarioDeSinonimos.IMutable
	{
		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000B35 RID: 2869 RVA: 0x000333BF File Offset: 0x000315BF
		public int cantidadDeCaracteres
		{
			get
			{
				return this.text.Length;
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000B36 RID: 2870 RVA: 0x000333CC File Offset: 0x000315CC
		public string seccionado
		{
			get
			{
				return this.m_textSeccionado;
			}
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x000333D4 File Offset: 0x000315D4
		public T CloneNoInicializado<T>() where T : DialogoInfo, new()
		{
			T t = new T();
			t.text = this.text;
			t.chance = this.chance;
			this.OnCloneNoInicializado<T>(t);
			return t;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void OnCloneNoInicializado<T>(T clonado) where T : DialogoInfo, new()
		{
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000B39 RID: 2873 RVA: 0x00033411 File Offset: 0x00031611
		public int index
		{
			get
			{
				return this.m_index;
			}
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000B3A RID: 2874 RVA: 0x00033419 File Offset: 0x00031619
		public float chanceRangeInferior
		{
			get
			{
				return this.m_chanceRangeInferior;
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000B3B RID: 2875 RVA: 0x00033421 File Offset: 0x00031621
		public float chanceRangeSuperior
		{
			get
			{
				return this.m_chanceRangeInferior + this.m_normalizedChance;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000B3C RID: 2876 RVA: 0x00033430 File Offset: 0x00031630
		public bool isInit
		{
			get
			{
				return this.m_isInit;
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000B3D RID: 2877 RVA: 0x00033438 File Offset: 0x00031638
		// (set) Token: 0x06000B3E RID: 2878 RVA: 0x00033440 File Offset: 0x00031640
		string IDialogoInfoTextMods.text
		{
			get
			{
				return this.text;
			}
			set
			{
				this.text = value;
			}
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000B3F RID: 2879 RVA: 0x00033449 File Offset: 0x00031649
		public IReadOnlyList<DialogoInfo.Seccion> secciones
		{
			get
			{
				return this.m_secciones;
			}
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x00033454 File Offset: 0x00031654
		public virtual void Init(float provTotal, int index, IList<DialogoInfo> anteriores)
		{
			if (this.m_isInit)
			{
				throw new InvalidOperationException();
			}
			this.FixChance();
			if (provTotal <= 0f)
			{
				throw new InvalidOperationException();
			}
			this.m_index = index;
			this.m_normalizedChance = this.chance / provTotal;
			this.m_chanceRangeInferior = 0f;
			if (anteriores != null)
			{
				for (int i = 0; i < anteriores.Count; i++)
				{
					this.m_chanceRangeInferior += anteriores[i].m_normalizedChance;
				}
			}
			if (this.chanceRangeSuperior > 1f)
			{
				this.m_chanceRangeInferior = 1f - this.m_normalizedChance;
			}
			if (this.chanceRangeInferior >= 1f)
			{
				throw new InvalidOperationException();
			}
			this.m_secciones = DialogoInfo.ObtenerSerciones(this.text, new Func<List<char>, DialogoInfo.Seccion.Tipo, DialogoInfo.Seccion.Condicion, bool, bool, DialogoInfo.Seccion>(this.InstanciarSeccion));
			this.m_textSeccionado = string.Empty;
			try
			{
				for (int j = 0; j < this.m_secciones.Count; j++)
				{
					this.m_secciones[j].AppendToOriginal(this.m_tempStringBuilder);
				}
				this.m_textSeccionado = this.m_tempStringBuilder.ToString(0, this.m_tempStringBuilder.Length);
			}
			finally
			{
				this.m_tempStringBuilder.Length = 0;
			}
			this.m_isInit = true;
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0003359C File Offset: 0x0003179C
		public void FixChance()
		{
			if (this.chance < 0.0001f)
			{
				this.chance = 0.0001f;
			}
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x00003B39 File Offset: 0x00001D39
		public void FixText()
		{
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000B43 RID: 2883 RVA: 0x000335B6 File Offset: 0x000317B6
		bool DiccionarioDeSinonimos.IMutable.mutableInit
		{
			get
			{
				return this.m_esMutable != null;
			}
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000B44 RID: 2884 RVA: 0x000335C3 File Offset: 0x000317C3
		bool DiccionarioDeSinonimos.IMutable.esMutable
		{
			get
			{
				return this.m_esMutable.GetValueOrDefault();
			}
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x000335D0 File Offset: 0x000317D0
		void DiccionarioDeSinonimos.IMutable.InitMutable(EsMutableString delegado)
		{
			if (delegado == null)
			{
				throw new ArgumentNullException("delegado", "delegado null reference.");
			}
			for (int i = 0; i < this.m_secciones.Count; i++)
			{
				if (this.m_secciones[i].EsMutable(delegado))
				{
					this.m_esMutable = new bool?(true);
					return;
				}
			}
			this.m_esMutable = new bool?(false);
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x00033634 File Offset: 0x00031834
		public string Mutado(TryMutarStringHandlerConRestriccion mutador, Localizacion local, RestriccionDeEdad restriccion, Sexo sexRestriction, int direccion)
		{
			if (mutador == null)
			{
				throw new ArgumentNullException("mutador", "mutador null reference.");
			}
			string text;
			try
			{
				DialogoInfo.Seccion seccion = this.m_secciones.LastOrDefault((DialogoInfo.Seccion x) => x.tipo == DialogoInfo.Seccion.Tipo.palabra);
				int num = 0;
				for (int i = 0; i < this.m_secciones.Count; i++)
				{
					num += this.m_secciones[i].count;
				}
				for (int j = 0; j < this.m_secciones.Count; j++)
				{
					DialogoInfo.Seccion seccion2;
					if (j > 0)
					{
						seccion2 = this.m_secciones[j - 1];
					}
					else
					{
						seccion2 = null;
					}
					DialogoInfo.Seccion seccion3;
					if (!j.IsLastIndex(this.m_secciones.Count))
					{
						seccion3 = this.m_secciones[j + 1];
					}
					else
					{
						seccion3 = null;
					}
					DialogoInfo.Seccion seccion4 = this.m_secciones[j];
					seccion4.AppendTo(this.m_tempStringBuilder, seccion2, local, num, j, j == this.m_secciones.Count - 1, seccion == seccion4, ((seccion3 != null) ? new DialogoInfo.Seccion.Tipo?(seccion3.tipo) : null).GetValueOrDefault(DialogoInfo.Seccion.Tipo.None) == DialogoInfo.Seccion.Tipo.puntuacion, direccion, mutador, new RestriccionDeEdad?(restriccion), new Sexo?(sexRestriction));
				}
				text = this.m_tempStringBuilder.ToString(0, this.m_tempStringBuilder.Length);
			}
			finally
			{
				this.m_tempStringBuilder.Length = 0;
			}
			return text;
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x000337CC File Offset: 0x000319CC
		public string NoMutado(Localizacion local, int direccion)
		{
			string text;
			try
			{
				DialogoInfo.Seccion seccion = this.m_secciones.LastOrDefault((DialogoInfo.Seccion x) => x.tipo == DialogoInfo.Seccion.Tipo.palabra);
				int num = 0;
				for (int i = 0; i < this.m_secciones.Count; i++)
				{
					num += this.m_secciones[i].count;
				}
				for (int j = 0; j < this.m_secciones.Count; j++)
				{
					DialogoInfo.Seccion seccion2;
					if (j > 0)
					{
						seccion2 = this.m_secciones[j - 1];
					}
					else
					{
						seccion2 = null;
					}
					DialogoInfo.Seccion seccion3;
					if (!j.IsLastIndex(this.m_secciones.Count))
					{
						seccion3 = this.m_secciones[j + 1];
					}
					else
					{
						seccion3 = null;
					}
					DialogoInfo.Seccion seccion4 = this.m_secciones[j];
					seccion4.AppendTo(this.m_tempStringBuilder, seccion2, local, num, j, j == this.m_secciones.Count - 1, seccion == seccion4, ((seccion3 != null) ? new DialogoInfo.Seccion.Tipo?(seccion3.tipo) : null).GetValueOrDefault(DialogoInfo.Seccion.Tipo.None) == DialogoInfo.Seccion.Tipo.puntuacion, direccion, null, null, null);
				}
				text = this.m_tempStringBuilder.ToString(0, this.m_tempStringBuilder.Length);
			}
			finally
			{
				this.m_tempStringBuilder.Length = 0;
			}
			return text;
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x00033954 File Offset: 0x00031B54
		public static List<DialogoInfo.Seccion> ObtenerSerciones(string text, Func<List<char>, DialogoInfo.Seccion.Tipo, DialogoInfo.Seccion.Condicion, bool, bool, DialogoInfo.Seccion> instanciador)
		{
			List<DialogoInfo.Seccion> list = new List<DialogoInfo.Seccion>();
			List<char> list2 = new List<char>();
			List<char> list3 = new List<char>();
			bool flag = true;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			DialogoInfo.Seccion.Condicion condicion = DialogoInfo.Seccion.Condicion.None;
			foreach (char c in text)
			{
				if (flag5)
				{
					if (c == ']')
					{
						flag5 = false;
						DialogoInfo.ProcesarCondiciones(list3, ref condicion);
						list3.Clear();
					}
					else
					{
						list3.Add(c);
					}
				}
				else if (char.IsWhiteSpace(c))
				{
					DialogoInfo.ProcesarAcumulados(list, list2, ref condicion, ref flag, ref flag3, ref flag4, ref flag2, instanciador);
					list.Add(new DialogoInfo.Seccion(c, DialogoInfo.Seccion.Tipo.espacio, condicion));
				}
				else if (c == '[')
				{
					DialogoInfo.ProcesarAcumulados(list, list2, ref condicion, ref flag, ref flag3, ref flag4, ref flag2, instanciador);
					flag5 = true;
				}
				else if (c == '}')
				{
					DialogoInfo.ProcesarAcumulados(list, list2, ref condicion, ref flag, ref flag3, ref flag4, ref flag2, instanciador);
				}
				else if (flag2)
				{
					flag4 = true;
					list2.Add(c);
				}
				else if (c == '{')
				{
					DialogoInfo.ProcesarAcumulados(list, list2, ref condicion, ref flag, ref flag3, ref flag4, ref flag2, instanciador);
					flag2 = true;
				}
				else if (c == '*')
				{
					DialogoInfo.ProcesarAcumulados(list, list2, ref condicion, ref flag, ref flag3, ref flag4, ref flag2, instanciador);
					flag = false;
				}
				else if (c != '-' && char.IsPunctuation(c))
				{
					DialogoInfo.ProcesarAcumulados(list, list2, ref condicion, ref flag, ref flag3, ref flag4, ref flag2, instanciador);
					list.Add(new DialogoInfo.Seccion(c, DialogoInfo.Seccion.Tipo.puntuacion, condicion));
				}
				else if (char.IsDigit(c))
				{
					if (flag4)
					{
						DialogoInfo.ProcesarAcumulados(list, list2, ref condicion, ref flag, ref flag3, ref flag4, ref flag2, instanciador);
					}
					flag3 = true;
					list2.Add(c);
				}
				else if (c == '-' || char.IsLetter(c))
				{
					if (flag3)
					{
						DialogoInfo.ProcesarAcumulados(list, list2, ref condicion, ref flag, ref flag3, ref flag4, ref flag2, instanciador);
					}
					flag4 = true;
					list2.Add(c);
				}
			}
			DialogoInfo.ProcesarAcumulados(list, list2, ref condicion, ref flag, ref flag3, ref flag4, ref flag2, instanciador);
			DialogoInfo.Seccion seccion = ((list.Count > 0) ? list.Last<DialogoInfo.Seccion>() : null);
			while (seccion != null && seccion.tipo == DialogoInfo.Seccion.Tipo.espacio)
			{
				list.Remove(seccion);
				seccion = ((list.Count > 0) ? list.Last<DialogoInfo.Seccion>() : null);
			}
			return list;
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x00033B80 File Offset: 0x00031D80
		public static void ProcesarCondiciones(List<char> condicionesChras, ref DialogoInfo.Seccion.Condicion condiciones)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < condicionesChras.Count; i++)
			{
				stringBuilder.Append(condicionesChras[i]);
			}
			string[] array = stringBuilder.ToString().Split(',', StringSplitOptions.None);
			for (int j = 0; j < array.Length; j++)
			{
				DialogoInfo.Seccion.Condicion condicion;
				if (Enum.TryParse<DialogoInfo.Seccion.Condicion>(array[j], out condicion))
				{
					condiciones |= condicion;
				}
			}
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x00033BE4 File Offset: 0x00031DE4
		public static void ProcesarAcumulados(List<DialogoInfo.Seccion> r, List<char> acumulados, ref DialogoInfo.Seccion.Condicion condiciones, ref bool mutable, ref bool esNumero, ref bool esPalabra, ref bool generic, Func<List<char>, DialogoInfo.Seccion.Tipo, DialogoInfo.Seccion.Condicion, bool, bool, DialogoInfo.Seccion> instanciador)
		{
			if (acumulados.Count == 0)
			{
				return;
			}
			try
			{
				if (esNumero == esPalabra)
				{
					throw new InvalidOperationException();
				}
				DialogoInfo.Seccion.Tipo tipo = DialogoInfo.Seccion.Tipo.None;
				if (esNumero)
				{
					tipo = DialogoInfo.Seccion.Tipo.numero;
				}
				if (esPalabra)
				{
					tipo = DialogoInfo.Seccion.Tipo.palabra;
				}
				if (tipo == DialogoInfo.Seccion.Tipo.None)
				{
					throw new InvalidOperationException();
				}
				DialogoInfo.Seccion seccion = instanciador(acumulados, tipo, condiciones, mutable, generic);
				r.Add(seccion);
			}
			finally
			{
				condiciones = DialogoInfo.Seccion.Condicion.None;
				esPalabra = false;
				esNumero = false;
				acumulados.Clear();
				mutable = true;
				generic = false;
			}
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x00033C68 File Offset: 0x00031E68
		protected virtual DialogoInfo.Seccion InstanciarSeccion(List<char> acumulados, DialogoInfo.Seccion.Tipo tipo, DialogoInfo.Seccion.Condicion condiciones, bool mutable, bool generico)
		{
			return new DialogoInfo.Seccion(acumulados, tipo, condiciones, mutable);
		}

		// Token: 0x04000911 RID: 2321
		private const float minChance = 0.0001f;

		// Token: 0x04000912 RID: 2322
		[SerializeField]
		[TextArea]
		private string text;

		// Token: 0x04000913 RID: 2323
		private string m_textSeccionado;

		// Token: 0x04000914 RID: 2324
		[Range(0.0001f, 100f)]
		public float chance = 50f;

		// Token: 0x04000915 RID: 2325
		[NonSerialized]
		private bool m_isInit;

		// Token: 0x04000916 RID: 2326
		[NonSerialized]
		private float m_normalizedChance;

		// Token: 0x04000917 RID: 2327
		[NonSerialized]
		private int m_index;

		// Token: 0x04000918 RID: 2328
		[NonSerialized]
		private float m_chanceRangeInferior;

		// Token: 0x04000919 RID: 2329
		[NonSerialized]
		private List<DialogoInfo.Seccion> m_secciones;

		// Token: 0x0400091A RID: 2330
		private StringBuilder m_tempStringBuilder = new StringBuilder();

		// Token: 0x0400091B RID: 2331
		[NonSerialized]
		private bool? m_esMutable;

		// Token: 0x020001D6 RID: 470
		[Serializable]
		public class Seccion
		{
			// Token: 0x06000B4D RID: 2893 RVA: 0x00033C92 File Offset: 0x00031E92
			public Seccion(char c, DialogoInfo.Seccion.Tipo tipo, DialogoInfo.Seccion.Condicion condiciones)
			{
				this.m_condiciones = condiciones;
				this.m_char = c;
				this.m_Tipo = tipo;
			}

			// Token: 0x06000B4E RID: 2894 RVA: 0x00033CB0 File Offset: 0x00031EB0
			public Seccion(List<char> cs, DialogoInfo.Seccion.Tipo tipo, DialogoInfo.Seccion.Condicion condiciones, bool mutable)
			{
				this.m_condiciones = condiciones;
				if (cs.Count == 0)
				{
					throw new InvalidOperationException();
				}
				this.m_builded = new StringBuilder();
				for (int i = 0; i < cs.Count; i++)
				{
					char c = cs[i];
					this.m_builded.Append(c);
					if (i == 0)
					{
						this.m_primeraEsMayuscula = char.IsUpper(c);
					}
				}
				this.m_Tipo = tipo;
				this.m_original = this.m_builded.ToString(0, this.m_builded.Length);
				this.m_mutable = mutable;
			}

			// Token: 0x1700026C RID: 620
			// (get) Token: 0x06000B4F RID: 2895 RVA: 0x00033D44 File Offset: 0x00031F44
			public virtual bool isPalabraEmpty
			{
				get
				{
					return this.m_Tipo == DialogoInfo.Seccion.Tipo.palabra && string.IsNullOrEmpty(this.m_original);
				}
			}

			// Token: 0x1700026D RID: 621
			// (get) Token: 0x06000B50 RID: 2896 RVA: 0x00005F51 File Offset: 0x00004151
			public virtual int count
			{
				get
				{
					return 1;
				}
			}

			// Token: 0x1700026E RID: 622
			// (get) Token: 0x06000B51 RID: 2897 RVA: 0x00033D5C File Offset: 0x00031F5C
			public DialogoInfo.Seccion.Condicion condiciones
			{
				get
				{
					return this.m_condiciones;
				}
			}

			// Token: 0x1700026F RID: 623
			// (get) Token: 0x06000B52 RID: 2898 RVA: 0x00033D64 File Offset: 0x00031F64
			public DialogoInfo.Seccion.Tipo tipo
			{
				get
				{
					return this.m_Tipo;
				}
			}

			// Token: 0x17000270 RID: 624
			// (get) Token: 0x06000B53 RID: 2899 RVA: 0x00033D6C File Offset: 0x00031F6C
			public string original
			{
				get
				{
					return this.m_original;
				}
			}

			// Token: 0x06000B54 RID: 2900 RVA: 0x00033D74 File Offset: 0x00031F74
			public virtual bool EsMutable(EsMutableString delegado)
			{
				if (delegado == null)
				{
					throw new ArgumentNullException("delegado", "delegado null reference.");
				}
				return this.m_mutable && this.m_Tipo == DialogoInfo.Seccion.Tipo.palabra && delegado(this.m_original);
			}

			// Token: 0x06000B55 RID: 2901 RVA: 0x00033DA8 File Offset: 0x00031FA8
			public void AppendToOriginal(StringBuilder str)
			{
				if (this.m_builded != null && this.m_original != null)
				{
					str.Append(this.m_builded);
					return;
				}
				str.Append(this.m_char);
			}

			// Token: 0x06000B56 RID: 2902 RVA: 0x00033DD8 File Offset: 0x00031FD8
			protected virtual bool EsExcluidaPorCondiciones(StringBuilder str, DialogoInfo.Seccion previous, Localizacion local, int cantidadDeSeccionesTotal, int myIndex, bool isLastItem, bool isLastPalabra, bool isLastAntesDePunbtuacion, int direccion, TryMutarStringHandlerConRestriccion mutador = null, RestriccionDeEdad? restriccion = null, Sexo? sexRestriction = null)
			{
				if (this.m_condiciones == DialogoInfo.Seccion.Condicion.None)
				{
					return false;
				}
				int condiciones = (int)this.m_condiciones;
				if (isLastItem || isLastPalabra || isLastAntesDePunbtuacion)
				{
					if (condiciones.HasFlag(2))
					{
						return true;
					}
				}
				else if (condiciones.HasFlag(1))
				{
					return true;
				}
				return (condiciones.HasFlag(16) && direccion != 1) || (condiciones.HasFlag(32) && direccion != 2) || (condiciones.HasFlag(4) && local != Localizacion.US) || (condiciones.HasFlag(8) && local != Localizacion.ES);
			}

			// Token: 0x06000B57 RID: 2903 RVA: 0x00033E58 File Offset: 0x00032058
			public virtual void AppendTo(StringBuilder str, DialogoInfo.Seccion previous, Localizacion local, int cantidadDeSeccionesTotal, int myIndex, bool isLastItem, bool isLastPalabra, bool isLastAntesDePunbtuacion, int direccion, TryMutarStringHandlerConRestriccion mutador = null, RestriccionDeEdad? restriccion = null, Sexo? sexRestriction = null)
			{
				if (previous != null && previous.isPalabraEmpty && this.m_Tipo == DialogoInfo.Seccion.Tipo.espacio)
				{
					return;
				}
				if (this.EsExcluidaPorCondiciones(str, previous, local, cantidadDeSeccionesTotal, myIndex, isLastItem, isLastPalabra, isLastAntesDePunbtuacion, direccion, mutador, restriccion, sexRestriction))
				{
					return;
				}
				if (this.m_builded == null || this.m_original == null)
				{
					str.Append(this.m_char);
					return;
				}
				if (this.m_original.Equals("PlayerName", StringComparison.InvariantCultureIgnoreCase))
				{
					MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
					object obj;
					if (current == null)
					{
						obj = null;
					}
					else
					{
						Character character = current.character;
						obj = ((character != null) ? character.apellido : null);
					}
					object obj2;
					if ((obj2 = obj) == null)
					{
						MainChar current2 = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
						if (current2 == null)
						{
							obj2 = null;
						}
						else
						{
							Character character2 = current2.character;
							obj2 = ((character2 != null) ? character2.nombre : null);
						}
					}
					string text = obj2;
					if (!string.IsNullOrWhiteSpace(text))
					{
						str.Append(text);
					}
					return;
				}
				RestriccionDeEdad restriccionDeEdad = ((restriccion == null) ? RestriccionDeEdad.None : restriccion.Value);
				Sexo sexo = ((sexRestriction == null) ? Sexo.noDefinido : sexRestriction.Value);
				string text2;
				if (this.m_mutable && this.m_Tipo == DialogoInfo.Seccion.Tipo.palabra && mutador != null && mutador(this.m_original, this.m_primeraEsMayuscula, restriccionDeEdad, sexo, out text2) && text2 != null && text2 != this.m_original)
				{
					str.Append(text2);
					return;
				}
				this.m_builded.Replace('-', ' ');
				str.Append(this.m_builded.ToString(0, this.m_builded.Length));
			}

			// Token: 0x0400091C RID: 2332
			[ReadOnlyUI]
			[SerializeField]
			protected char m_char;

			// Token: 0x0400091D RID: 2333
			[ReadOnlyUI]
			[SerializeField]
			protected string m_original;

			// Token: 0x0400091E RID: 2334
			[ReadOnlyUI]
			[SerializeField]
			protected bool m_primeraEsMayuscula;

			// Token: 0x0400091F RID: 2335
			[ReadOnlyUI]
			[SerializeField]
			protected bool m_mutable;

			// Token: 0x04000920 RID: 2336
			[ReadOnlyUI]
			[SerializeField]
			protected DialogoInfo.Seccion.Tipo m_Tipo;

			// Token: 0x04000921 RID: 2337
			[ReadOnlyUI]
			[SerializeField]
			protected DialogoInfo.Seccion.Condicion m_condiciones;

			// Token: 0x04000922 RID: 2338
			[SerializeField]
			protected StringBuilder m_builded;

			// Token: 0x020001D7 RID: 471
			public enum Tipo
			{
				// Token: 0x04000924 RID: 2340
				None,
				// Token: 0x04000925 RID: 2341
				palabra,
				// Token: 0x04000926 RID: 2342
				espacio,
				// Token: 0x04000927 RID: 2343
				puntuacion,
				// Token: 0x04000928 RID: 2344
				numero
			}

			// Token: 0x020001D8 RID: 472
			[Flags]
			public enum Condicion
			{
				// Token: 0x0400092A RID: 2346
				None = 0,
				// Token: 0x0400092B RID: 2347
				last = 1,
				// Token: 0x0400092C RID: 2348
				noLast = 2,
				// Token: 0x0400092D RID: 2349
				US = 4,
				// Token: 0x0400092E RID: 2350
				ES = 8,
				// Token: 0x0400092F RID: 2351
				recibida = 16,
				// Token: 0x04000930 RID: 2352
				dada = 32
			}
		}
	}
}
