using System;
using System.Collections.Generic;
using System.Text;
using Assets._ReusableScripts.Textos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos
{
	// Token: 0x0200020C RID: 524
	[Serializable]
	public class DialogoInfoGenerico : DialogoInfo
	{
		// Token: 0x06000BF7 RID: 3063 RVA: 0x000356C5 File Offset: 0x000338C5
		protected override DialogoInfo.Seccion InstanciarSeccion(List<char> acumulados, DialogoInfo.Seccion.Tipo tipo, DialogoInfo.Seccion.Condicion condiciones, bool mutable, bool generico)
		{
			if (!generico)
			{
				return base.InstanciarSeccion(acumulados, tipo, condiciones, mutable, generico);
			}
			return new DialogoInfoGenerico.SeccionGenerica(acumulados, tipo, condiciones, mutable);
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x000356E4 File Offset: 0x000338E4
		public override void Init(float provTotal, int index, IList<DialogoInfo> anteriores)
		{
			base.Init(provTotal, index, anteriores);
			for (int i = 0; i < base.secciones.Count; i++)
			{
				DialogoInfoGenerico.SeccionGenerica seccionGenerica = base.secciones[i] as DialogoInfoGenerico.SeccionGenerica;
				if (seccionGenerica != null)
				{
					if (this.m_indexDeTipoDePalabraGenerica.ContainsKey((int)seccionGenerica.tipoGenerico))
					{
						this.m_indexDeTipoDePalabraGenerica[(int)seccionGenerica.tipoGenerico] = i;
					}
					else
					{
						this.m_indexDeTipoDePalabraGenerica.Add((int)seccionGenerica.tipoGenerico, i);
					}
				}
			}
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x0003575E File Offset: 0x0003395E
		public int LastIndexOf(TipoDePalabraGenerica tipoDePalabraGenerica)
		{
			return this.m_indexDeTipoDePalabraGenerica[(int)tipoDePalabraGenerica];
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x0003576C File Offset: 0x0003396C
		public bool Contiene(TipoDePalabraGenerica tipoDePalabraGenerica)
		{
			return this.m_indexDeTipoDePalabraGenerica.ContainsKey((int)tipoDePalabraGenerica);
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x0003577C File Offset: 0x0003397C
		public bool ContieneEnOrden(TipoDePalabraGenerica a, TipoDePalabraGenerica b, TipoDePalabraGenerica c, bool advertirRepedidos = true)
		{
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			for (int i = 0; i < base.secciones.Count; i++)
			{
				DialogoInfoGenerico.SeccionGenerica seccionGenerica = base.secciones[i] as DialogoInfoGenerico.SeccionGenerica;
				if (seccionGenerica != null && seccionGenerica.tipoGenerico != TipoDePalabraGenerica.None)
				{
					if (a == seccionGenerica.tipoGenerico)
					{
						num4++;
						if (num < 0)
						{
							num = i;
						}
					}
					if (b == seccionGenerica.tipoGenerico)
					{
						num5++;
						if (num2 < 0)
						{
							num2 = i;
						}
					}
					if (c == seccionGenerica.tipoGenerico)
					{
						num6++;
						if (num3 < 0)
						{
							num3 = i;
						}
					}
				}
			}
			return num >= 0 && num2 >= 0 && num3 >= 0 && num < num2 && num2 < num3;
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x00035830 File Offset: 0x00033A30
		public bool ContieneEnOrdenLast(TipoDePalabraGenerica a, TipoDePalabraGenerica b, TipoDePalabraGenerica c)
		{
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			for (int i = 0; i < base.secciones.Count; i++)
			{
				DialogoInfoGenerico.SeccionGenerica seccionGenerica = base.secciones[i] as DialogoInfoGenerico.SeccionGenerica;
				if (seccionGenerica != null && seccionGenerica.tipoGenerico != TipoDePalabraGenerica.None)
				{
					if (a == seccionGenerica.tipoGenerico)
					{
						num = i;
					}
					if (b == seccionGenerica.tipoGenerico)
					{
						num2 = i;
					}
					if (c == seccionGenerica.tipoGenerico)
					{
						num3 = i;
					}
				}
			}
			return num >= 0 && num2 >= 0 && num3 >= 0 && num < num2 && num2 < num3;
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x000358B8 File Offset: 0x00033AB8
		public bool ContieneEnOrden(TipoDePalabraGenerica a, TipoDePalabraGenerica b)
		{
			int num = -1;
			int num2 = -1;
			for (int i = 0; i < base.secciones.Count; i++)
			{
				DialogoInfoGenerico.SeccionGenerica seccionGenerica = base.secciones[i] as DialogoInfoGenerico.SeccionGenerica;
				if (seccionGenerica != null && seccionGenerica.tipoGenerico != TipoDePalabraGenerica.None)
				{
					if (num < 0 && a == seccionGenerica.tipoGenerico)
					{
						num = i;
					}
					if (num2 < 0 && b == seccionGenerica.tipoGenerico)
					{
						num2 = i;
					}
				}
			}
			return num >= 0 && num2 >= 0 && num < num2;
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x00035928 File Offset: 0x00033B28
		public DialogoInfoGenerico.SeccionGenerica TryGetLastSeccion(TipoDePalabraGenerica tipoDePalabraGenerica)
		{
			int num;
			if (!this.Contiene(tipoDePalabraGenerica, out num))
			{
				return null;
			}
			return base.secciones[num] as DialogoInfoGenerico.SeccionGenerica;
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x00035953 File Offset: 0x00033B53
		public bool ContieneRefIndex(TipoDePalabraGenerica tipoDePalabraGenerica, ref int index)
		{
			if (this.m_indexDeTipoDePalabraGenerica.ContainsKey((int)tipoDePalabraGenerica))
			{
				index = this.LastIndexOf(tipoDePalabraGenerica);
				return true;
			}
			return false;
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x0003596F File Offset: 0x00033B6F
		public bool Contiene(TipoDePalabraGenerica tipoDePalabraGenerica, out int index)
		{
			index = -1;
			if (this.m_indexDeTipoDePalabraGenerica.ContainsKey((int)tipoDePalabraGenerica))
			{
				index = this.LastIndexOf(tipoDePalabraGenerica);
				return true;
			}
			return false;
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x00035990 File Offset: 0x00033B90
		public bool ContieneTodas(IList<TipoDePalabraGenerica> tiposDePalabrasGenerica)
		{
			bool flag = true;
			for (int i = 0; i < tiposDePalabrasGenerica.Count; i++)
			{
				if (!this.Contiene(tiposDePalabrasGenerica[i]))
				{
					flag = false;
					break;
				}
			}
			return flag;
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x000359C4 File Offset: 0x00033BC4
		public bool ContieneAlguna(IList<TipoDePalabraGenerica> tiposDePalabrasGenerica)
		{
			for (int i = 0; i < tiposDePalabrasGenerica.Count; i++)
			{
				if (this.Contiene(tiposDePalabrasGenerica[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x040009C3 RID: 2499
		private Dictionary<int, int> m_indexDeTipoDePalabraGenerica = new Dictionary<int, int>();

		// Token: 0x0200020D RID: 525
		[Serializable]
		public sealed class SeccionGenerica : DialogoInfo.Seccion
		{
			// Token: 0x06000C04 RID: 3076 RVA: 0x00035A08 File Offset: 0x00033C08
			public SeccionGenerica(List<char> cs, DialogoInfo.Seccion.Tipo tipo, DialogoInfo.Seccion.Condicion condiciones, bool mutable)
				: base(cs, tipo, condiciones, mutable)
			{
				string[] array = this.m_original.Split('=', StringSplitOptions.None);
				if (array.Length == 1)
				{
					this.InitTipoDePalabra(this.m_original);
					this.m_paraLocal = (Localizacion)(-1);
					return;
				}
				this.InitLocal(array[0]);
				this.InitTipoDePalabra(array[1]);
				if (array.Length > 2)
				{
					this.InitPositivoONegatico(array[2]);
				}
			}

			// Token: 0x06000C05 RID: 3077 RVA: 0x00035A75 File Offset: 0x00033C75
			private void InitTipoDePalabra(string enumString)
			{
				if (!Enum.TryParse<TipoDePalabraGenerica>(enumString, out this.m_tipoGenerico))
				{
					Debug.LogError("No se puedo obtener TipoDePalabraGenerica de texto " + this.m_original);
					this.m_tipoGenerico = TipoDePalabraGenerica.None;
				}
			}

			// Token: 0x06000C06 RID: 3078 RVA: 0x00035AA1 File Offset: 0x00033CA1
			private void InitLocal(string enumString)
			{
				if (!Enum.TryParse<Localizacion>(enumString, out this.m_paraLocal))
				{
					Debug.LogError("No se puedo obtener Localizacion de texto " + this.m_original);
					this.m_paraLocal = Localizacion.None;
				}
			}

			// Token: 0x06000C07 RID: 3079 RVA: 0x00035ACD File Offset: 0x00033CCD
			private void InitPositivoONegatico(string enumString)
			{
				if (string.Equals(enumString, "N", StringComparison.InvariantCultureIgnoreCase))
				{
					this.m_paraPositivoONegativo = 1;
					return;
				}
				if (string.Equals(enumString, "P", StringComparison.InvariantCultureIgnoreCase))
				{
					this.m_paraPositivoONegativo = 2;
				}
			}

			// Token: 0x17000295 RID: 661
			// (get) Token: 0x06000C08 RID: 3080 RVA: 0x00035AFA File Offset: 0x00033CFA
			public override int count
			{
				get
				{
					return this.m_nested.Count;
				}
			}

			// Token: 0x17000296 RID: 662
			// (get) Token: 0x06000C09 RID: 3081 RVA: 0x00035B07 File Offset: 0x00033D07
			public TipoDePalabraGenerica tipoGenerico
			{
				get
				{
					return this.m_tipoGenerico;
				}
			}

			// Token: 0x17000297 RID: 663
			// (get) Token: 0x06000C0A RID: 3082 RVA: 0x00035B0F File Offset: 0x00033D0F
			public Localizacion paraLocal
			{
				get
				{
					return this.m_paraLocal;
				}
			}

			// Token: 0x17000298 RID: 664
			// (get) Token: 0x06000C0B RID: 3083 RVA: 0x00035B18 File Offset: 0x00033D18
			public override bool isPalabraEmpty
			{
				get
				{
					if (this.m_nested == null)
					{
						return true;
					}
					for (int i = 0; i < this.m_nested.Count; i++)
					{
						DialogoInfo dialogoInfo = this.m_nested[i];
						if (dialogoInfo != null)
						{
							for (int j = 0; j < dialogoInfo.secciones.Count; j++)
							{
								if (!dialogoInfo.secciones[j].isPalabraEmpty)
								{
									return false;
								}
							}
						}
					}
					return true;
				}
			}

			// Token: 0x06000C0C RID: 3084 RVA: 0x00035B81 File Offset: 0x00033D81
			public bool EsParaLocal(Localizacion localizacion)
			{
				return ((int)this.m_paraLocal).IsAnyFlagSet((int)localizacion);
			}

			// Token: 0x06000C0D RID: 3085 RVA: 0x00035B8F File Offset: 0x00033D8F
			public bool EsParanNegativoOPositivo(bool esNegativo)
			{
				if (this.m_paraPositivoONegativo == 0)
				{
					return true;
				}
				if (esNegativo)
				{
					return this.m_paraPositivoONegativo == 1;
				}
				if (!esNegativo)
				{
					return this.m_paraPositivoONegativo == 2;
				}
				throw new ArgumentOutOfRangeException();
			}

			// Token: 0x06000C0E RID: 3086 RVA: 0x00035BBC File Offset: 0x00033DBC
			[Obsolete("", true)]
			public void ActualizarConString(string palabra)
			{
				if (palabra == null)
				{
					throw new InvalidOperationException();
				}
				if (this.m_builded == null)
				{
					this.m_builded = new StringBuilder();
				}
				this.m_builded.Length = 0;
				this.m_builded.Append(palabra);
				this.m_original = this.m_builded.ToString(0, this.m_builded.Length);
			}

			// Token: 0x06000C0F RID: 3087 RVA: 0x00035C1B File Offset: 0x00033E1B
			public void Actualizar(DialogoInfo nested)
			{
				this.m_nested.Clear();
				if (nested != null && !nested.isInit)
				{
					throw new InvalidOperationException("nested DialogoInfo no esta init");
				}
				if (nested != null)
				{
					this.m_nested.Add(nested);
				}
			}

			// Token: 0x06000C10 RID: 3088 RVA: 0x00035C50 File Offset: 0x00033E50
			public void ActualizarMany(DialogoInfo a, DialogoInfo b)
			{
				this.m_nested.Clear();
				if (a != null && !a.isInit)
				{
					throw new InvalidOperationException("nested DialogoInfo no esta init");
				}
				if (b != null && !b.isInit)
				{
					throw new InvalidOperationException("nested DialogoInfo no esta init");
				}
				if (a != null)
				{
					this.m_nested.Add(a);
				}
				if (a != null)
				{
					this.m_nested.Add(b);
				}
			}

			// Token: 0x06000C11 RID: 3089 RVA: 0x00035CB4 File Offset: 0x00033EB4
			public void ActualizarMany(IList<DialogoInfo> nesteds)
			{
				this.m_nested.Clear();
				for (int i = 0; i < nesteds.Count; i++)
				{
					DialogoInfo dialogoInfo = nesteds[i];
					if (dialogoInfo != null && !dialogoInfo.isInit)
					{
						throw new InvalidOperationException("nested DialogoInfo no esta init");
					}
					if (dialogoInfo != null)
					{
						this.m_nested.Add(dialogoInfo);
					}
				}
			}

			// Token: 0x06000C12 RID: 3090 RVA: 0x00035D0C File Offset: 0x00033F0C
			public override bool EsMutable(EsMutableString delegado)
			{
				if (this.m_nested.Count == 0 || !this.m_mutable)
				{
					return false;
				}
				if (delegado == null)
				{
					throw new ArgumentNullException("delegado", "delegado null reference.");
				}
				for (int i = 0; i < this.m_nested.Count; i++)
				{
					DialogoInfo dialogoInfo = this.m_nested[i];
					if (dialogoInfo != null)
					{
						for (int j = 0; j < dialogoInfo.secciones.Count; j++)
						{
							if (dialogoInfo.secciones[j].EsMutable(delegado))
							{
								return true;
							}
						}
					}
				}
				return false;
			}

			// Token: 0x06000C13 RID: 3091 RVA: 0x00035D98 File Offset: 0x00033F98
			public override void AppendTo(StringBuilder str, DialogoInfo.Seccion previous, Localizacion local, int cantidadDeSeccionesTotal, int myIndex, bool isLastItem, bool isLastPalabra, bool isLastAntesDePuntuacion, int direccion, TryMutarStringHandlerConRestriccion mutador = null, RestriccionDeEdad? restriccion = null, Sexo? sexRestriction = null)
			{
				if (this.m_nested.Count == 0)
				{
					return;
				}
				if (this.EsExcluidaPorCondiciones(str, previous, local, cantidadDeSeccionesTotal, myIndex, isLastItem, isLastPalabra, isLastAntesDePuntuacion, direccion, mutador, restriccion, sexRestriction))
				{
					return;
				}
				DialogoInfo.Seccion seccion = previous;
				int num = myIndex;
				for (int i = 0; i < this.m_nested.Count; i++)
				{
					DialogoInfoGenerico.SeccionGenerica.AppendTo(this.m_nested[i], str, local, ref seccion, cantidadDeSeccionesTotal, ref num, isLastPalabra, isLastAntesDePuntuacion, direccion, mutador, restriccion, sexRestriction);
				}
			}

			// Token: 0x06000C14 RID: 3092 RVA: 0x00035E14 File Offset: 0x00034014
			private static void AppendTo(DialogoInfo nested, StringBuilder str, Localizacion local, ref DialogoInfo.Seccion previous, int cantidadDeSeccionesTotal, ref int myIndex, bool isLastPalabra, bool isLastAntesDePuntuacion, int direccion, TryMutarStringHandlerConRestriccion mutador = null, RestriccionDeEdad? restriccion = null, Sexo? sexRestriction = null)
			{
				if (nested == null)
				{
					return;
				}
				for (int i = 0; i < nested.secciones.Count; i++)
				{
					myIndex += i;
					bool flag = myIndex == cantidadDeSeccionesTotal - 1;
					nested.secciones[i].AppendTo(str, previous, local, cantidadDeSeccionesTotal, myIndex, flag, isLastPalabra, isLastAntesDePuntuacion, direccion, mutador, restriccion, sexRestriction);
					previous = nested.secciones[i];
				}
			}

			// Token: 0x040009C4 RID: 2500
			[ReadOnlyUI]
			[SerializeField]
			private TipoDePalabraGenerica m_tipoGenerico;

			// Token: 0x040009C5 RID: 2501
			[ReadOnlyUI]
			[SerializeField]
			private Localizacion m_paraLocal;

			// Token: 0x040009C6 RID: 2502
			[ReadOnlyUI]
			[SerializeField]
			private int m_paraPositivoONegativo;

			// Token: 0x040009C7 RID: 2503
			[ReadOnlyUI]
			[SerializeField]
			private List<DialogoInfo> m_nested = new List<DialogoInfo>();
		}
	}
}
