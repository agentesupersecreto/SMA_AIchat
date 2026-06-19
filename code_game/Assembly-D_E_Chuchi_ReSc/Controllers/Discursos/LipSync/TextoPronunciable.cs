using System;
using System.Collections.Generic;
using System.Text;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync
{
	// Token: 0x02000279 RID: 633
	[Serializable]
	public class TextoPronunciable : IClearable
	{
		// Token: 0x06000E06 RID: 3590 RVA: 0x00041DE6 File Offset: 0x0003FFE6
		private static void CheckCurrentPalabra(ref TextoPronunciable.Palabra currentPlabra, SimplePoolDeClearables<TextoPronunciable.Palabra> pool)
		{
			if (currentPlabra == null)
			{
				currentPlabra = pool.GetItem();
			}
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x00041DF4 File Offset: 0x0003FFF4
		private static void AcumularSilaba(ref TextoPronunciable.Palabra currentPlabra, SilabaPronunciableEnTiempo silaba)
		{
			currentPlabra.Add(silaba);
		}

		// Token: 0x06000E08 RID: 3592 RVA: 0x00041DFE File Offset: 0x0003FFFE
		private static TextoPronunciable.Palabra FinalizarPalabra(ref TextoPronunciable.Palabra currentPlabra, IList<TextoPronunciable.Palabra> target)
		{
			if (currentPlabra == null)
			{
				throw new ArgumentNullException("currentPlabra", "currentPlabra null reference.");
			}
			if (currentPlabra.silabas.Count > 0)
			{
				target.Add(currentPlabra);
				TextoPronunciable.Palabra palabra = currentPlabra;
				currentPlabra = null;
				return palabra;
			}
			return null;
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x00041E34 File Offset: 0x00040034
		[Obsolete]
		private static void VaciarSilabasAcumuladas(ref TextoPronunciable.Palabra currentPlabra, List<SilabaPronunciableEnTiempo> acumuladas, List<TextoPronunciable.Palabra> target, SimplePoolDeClearables<TextoPronunciable.Palabra> pool)
		{
			if (acumuladas.Count == 0)
			{
				return;
			}
			TextoPronunciable.Palabra item = pool.GetItem();
			item.AddRange(acumuladas);
			target.Add(item);
			acumuladas.Clear();
			currentPlabra = item;
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x00041E88 File Offset: 0x00040088
		public void Init(List<SilabaPronunciable> silabas)
		{
			if (this.m_initiated)
			{
				throw new InvalidOperationException();
			}
			this.duracionTotal = 0f;
			this.queue = new Queue<ValueTuple<SilabaPronunciableEnTiempo, TextoPronunciable.Palabra>>(silabas.Count);
			this.m_poolDePalabras = new SimplePoolDeClearables<TextoPronunciable.Palabra>();
			TextoPronunciable.Palabra palabra = null;
			for (int i = 0; i < silabas.Count; i++)
			{
				SilabaPronunciable silabaPronunciable = silabas[i];
				float duration = silabaPronunciable.duration;
				SilabaPronunciableEnTiempo silabaPronunciableEnTiempo = new SilabaPronunciableEnTiempo(silabaPronunciable, this.duracionTotal);
				TextoPronunciable.CheckCurrentPalabra(ref palabra, this.m_poolDePalabras);
				TipoDeSilaba tipo = silabaPronunciable.silaba.tipo;
				TextoPronunciable.Palabra palabra2;
				if (tipo > TipoDeSilaba.espacio)
				{
					if (tipo - TipoDeSilaba.unaVocal > 6)
					{
						throw new ArgumentOutOfRangeException(silabaPronunciable.silaba.tipo.ToString());
					}
					TextoPronunciable.AcumularSilaba(ref palabra, silabaPronunciableEnTiempo);
					palabra2 = palabra;
					if (silabas.Count - 1 == i)
					{
						palabra2 = TextoPronunciable.FinalizarPalabra(ref palabra, this.m_listaDePalabras);
					}
				}
				else
				{
					palabra2 = TextoPronunciable.FinalizarPalabra(ref palabra, this.m_listaDePalabras);
					TextoPronunciable.CheckCurrentPalabra(ref palabra, this.m_poolDePalabras);
					TextoPronunciable.AcumularSilaba(ref palabra, silabaPronunciableEnTiempo);
					palabra2 = TextoPronunciable.FinalizarPalabra(ref palabra, this.m_listaDePalabras);
				}
				if (palabra2 == null || palabra2.silabas.Count == 0)
				{
					throw new ArgumentNullException("current", "current null reference.");
				}
				if (Application.isEditor)
				{
					if (this.m_casillasDebug == null)
					{
						this.m_casillasDebug = new List<SilabaPronunciableEnTiempo>(silabas.Count);
					}
					this.m_casillasDebug.Add(silabaPronunciableEnTiempo);
				}
				this.queue.Enqueue(new ValueTuple<SilabaPronunciableEnTiempo, TextoPronunciable.Palabra>(silabaPronunciableEnTiempo, palabra2));
				this.duracionTotal += duration;
			}
			if (this.m_listaDePalabras.Count == 0)
			{
				throw new InvalidOperationException();
			}
			this.m_initiated = true;
		}

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000E0C RID: 3596 RVA: 0x0004202F File Offset: 0x0004022F
		public IReadOnlyList<TextoPronunciable.Palabra> palabras
		{
			get
			{
				return this.m_listaDePalabras;
			}
		}

		// Token: 0x06000E0D RID: 3597 RVA: 0x00042038 File Offset: 0x00040238
		public void Clear()
		{
			List<SilabaPronunciableEnTiempo> casillasDebug = this.m_casillasDebug;
			if (casillasDebug != null)
			{
				casillasDebug.Clear();
			}
			Queue<ValueTuple<SilabaPronunciableEnTiempo, TextoPronunciable.Palabra>> queue = this.queue;
			if (queue != null)
			{
				queue.Clear();
			}
			this.duracionTotal = 0f;
			this.m_StringBuilder.Clear();
			for (int i = 0; i < this.m_listaDePalabras.Count; i++)
			{
				this.m_poolDePalabras.ReturnItem(this.m_listaDePalabras[i]);
			}
			this.m_listaDePalabras.Clear();
			this.m_initiated = false;
		}

		// Token: 0x06000E0E RID: 3598 RVA: 0x000420C0 File Offset: 0x000402C0
		public void ObtenerTextoAlterado(StringBuilder result, CharacterEstadoDeBoca uso)
		{
			if (uso == CharacterEstadoDeBoca.None)
			{
				this.ObtenerTexto(result);
				return;
			}
			for (int i = 0; i < this.m_listaDePalabras.Count; i++)
			{
				this.m_listaDePalabras[i].ObtenerTextoAlterado(result, uso);
			}
		}

		// Token: 0x06000E0F RID: 3599 RVA: 0x00042104 File Offset: 0x00040304
		private static bool SilabaEsLetras(ref Silaba silaba)
		{
			switch (silaba.tipo)
			{
			case TipoDeSilaba.simbolo:
				return false;
			case TipoDeSilaba.espacio:
				return false;
			case TipoDeSilaba.unaVocal:
			case TipoDeSilaba.unaConsonante:
			case TipoDeSilaba.consonanteCompuesta:
			case TipoDeSilaba.unaConsonanteConUnaVocal:
			case TipoDeSilaba.consonanteCompuestaConUnaVocal:
				return true;
			default:
				throw new ArgumentOutOfRangeException(silaba.tipo.ToString());
			}
		}

		// Token: 0x06000E10 RID: 3600 RVA: 0x00042158 File Offset: 0x00040358
		public float TimepotranscurridoModABuscandoTime(float timepotranscurridoMod)
		{
			timepotranscurridoMod = Mathf.Clamp01(timepotranscurridoMod);
			return timepotranscurridoMod * this.duracionTotal;
		}

		// Token: 0x06000E11 RID: 3601 RVA: 0x0004216C File Offset: 0x0004036C
		public void ObtenerTexto(StringBuilder texto)
		{
			for (int i = 0; i < this.m_listaDePalabras.Count; i++)
			{
				this.m_listaDePalabras[i].ObtenerTexto(texto);
			}
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x000421A4 File Offset: 0x000403A4
		public string ObtenerTexto()
		{
			string text;
			try
			{
				for (int i = 0; i < this.m_listaDePalabras.Count; i++)
				{
					this.m_listaDePalabras[i].ObtenerTexto(this.m_StringBuilder);
				}
				text = this.m_StringBuilder.ToString();
			}
			finally
			{
				this.m_StringBuilder.Clear();
			}
			return text;
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x0004220C File Offset: 0x0004040C
		public string ObtenerPronunciacion(bool isDebug)
		{
			string text;
			try
			{
				foreach (ValueTuple<SilabaPronunciableEnTiempo, TextoPronunciable.Palabra> valueTuple in this.queue)
				{
					SilabaPronunciableEnTiempo item = valueTuple.Item1;
					foreach (CasillaPronunciable casillaPronunciable in item.silabaPronunciable)
					{
						Casilla casilla = casillaPronunciable.casilla;
						foreach (CasillaDeCharacters casillaDeCharacters in casilla)
						{
							char @char = casillaDeCharacters.@char;
							int largo = casillaDeCharacters.largo;
							for (int i = 0; i < largo; i++)
							{
								this.m_StringBuilder.Append(@char);
							}
						}
						if (isDebug && casillaPronunciable.tipo != TipoDeCasillaPronunciable.None)
						{
							this.m_StringBuilder.Append('`');
							this.m_StringBuilder.Append(casillaPronunciable.duration.ToString("F1"));
							this.m_StringBuilder.Append('`');
						}
					}
					if (isDebug)
					{
						this.m_StringBuilder.Append('|');
					}
				}
				text = this.m_StringBuilder.ToString();
			}
			finally
			{
				this.m_StringBuilder.Clear();
			}
			return text;
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x000423C0 File Offset: 0x000405C0
		public bool Dequeue(float timepotranscurridoMod, out TextoPronunciable.Palabra palabra, out SilabaPronunciableEnTiempo silaba, out CasillaPronunciable casilla, out RangeValueV2 casillaRange, out bool PronunciandoSegunda, out CasillaPronunciable segundaCasilla, out RangeValueV2 segundoRange, out bool primeraEsVocal, out bool segundaEsVocal)
		{
			float num = this.TimepotranscurridoModABuscandoTime(timepotranscurridoMod);
			while (this.queue.Count > 0)
			{
				ValueTuple<SilabaPronunciableEnTiempo, TextoPronunciable.Palabra> valueTuple = this.queue.Peek();
				SilabaPronunciableEnTiempo item = valueTuple.Item1;
				float tiempo = item.tiempo;
				float num2 = tiempo + item.duration;
				if (num >= num2)
				{
					this.queue.Dequeue();
				}
				else
				{
					switch (item.silabaPronunciable.silaba.tipo)
					{
					case TipoDeSilaba.simbolo:
					case TipoDeSilaba.espacio:
						segundaEsVocal = (primeraEsVocal = false);
						break;
					case TipoDeSilaba.unaVocal:
						primeraEsVocal = true;
						segundaEsVocal = false;
						break;
					case TipoDeSilaba.unaConsonante:
					case TipoDeSilaba.consonanteCompuesta:
						primeraEsVocal = false;
						segundaEsVocal = false;
						break;
					case TipoDeSilaba.unaConsonanteConUnaVocal:
					case TipoDeSilaba.consonanteCompuestaConUnaVocal:
						primeraEsVocal = false;
						segundaEsVocal = true;
						break;
					case TipoDeSilaba.unaVocalConUnaConsonante:
					case TipoDeSilaba.unaVocalConConsonanteCompuesta:
						primeraEsVocal = true;
						segundaEsVocal = false;
						break;
					default:
						throw new ArgumentOutOfRangeException(item.silabaPronunciable.silaba.tipo.ToString());
					}
					TipoDeSilaba tipo = item.silabaPronunciable.silaba.tipo;
					if (tipo <= TipoDeSilaba.consonanteCompuesta)
					{
						palabra = valueTuple.Item2;
						silaba = item;
						casilla = silaba.silabaPronunciable.primera;
						casillaRange = new RangeValueV2(tiempo, num2);
						PronunciandoSegunda = false;
						segundaCasilla = default(CasillaPronunciable);
						segundoRange = default(RangeValueV2);
						return true;
					}
					if (tipo - TipoDeSilaba.unaConsonanteConUnaVocal > 3)
					{
						throw new ArgumentOutOfRangeException(item.silabaPronunciable.silaba.tipo.ToString());
					}
					palabra = valueTuple.Item2;
					silaba = item;
					float num3 = item.tiempo + silaba.silabaPronunciable.primera.duration;
					casilla = silaba.silabaPronunciable.primera;
					casillaRange = new RangeValueV2(tiempo, num2);
					if (num > num3)
					{
						PronunciandoSegunda = true;
						segundaCasilla = silaba.silabaPronunciable.segunda;
						segundoRange = new RangeValueV2(num3, num2);
					}
					else
					{
						PronunciandoSegunda = false;
						segundaCasilla = default(CasillaPronunciable);
						segundoRange = default(RangeValueV2);
					}
					return true;
				}
			}
			palabra = null;
			casilla = default(CasillaPronunciable);
			silaba = default(SilabaPronunciableEnTiempo);
			casillaRange = default(RangeValueV2);
			PronunciandoSegunda = false;
			segundaCasilla = default(CasillaPronunciable);
			segundoRange = default(RangeValueV2);
			segundaEsVocal = (primeraEsVocal = false);
			return false;
		}

		// Token: 0x04000C0A RID: 3082
		[SerializeField]
		[ReadOnlyUI]
		private bool m_initiated;

		// Token: 0x04000C0B RID: 3083
		private SimplePoolDeClearables<TextoPronunciable.Palabra> m_poolDePalabras;

		// Token: 0x04000C0C RID: 3084
		[SerializeField]
		private List<SilabaPronunciableEnTiempo> m_casillasDebug;

		// Token: 0x04000C0D RID: 3085
		[SerializeField]
		private List<TextoPronunciable.Palabra> m_listaDePalabras = new List<TextoPronunciable.Palabra>();

		// Token: 0x04000C0E RID: 3086
		public Queue<ValueTuple<SilabaPronunciableEnTiempo, TextoPronunciable.Palabra>> queue;

		// Token: 0x04000C0F RID: 3087
		public float duracionTotal;

		// Token: 0x04000C10 RID: 3088
		private StringBuilder m_StringBuilder = new StringBuilder();

		// Token: 0x0200027A RID: 634
		[Serializable]
		public class Palabra : IClearable
		{
			// Token: 0x1700030B RID: 779
			// (get) Token: 0x06000E15 RID: 3605 RVA: 0x00042610 File Offset: 0x00040810
			public string texto
			{
				get
				{
					string text = string.Empty;
					foreach (SilabaPronunciableEnTiempo silabaPronunciableEnTiempo in this.m_silabas)
					{
						Silaba silaba = silabaPronunciableEnTiempo.silabaPronunciable.silaba;
						foreach (Casilla casilla in silaba)
						{
							foreach (CasillaDeCharacters casillaDeCharacters in casilla)
							{
								char @char = casillaDeCharacters.@char;
								int largo = casillaDeCharacters.largo;
								for (int i = 0; i < largo; i++)
								{
									text += @char.ToString();
								}
							}
						}
					}
					return text;
				}
			}

			// Token: 0x1700030C RID: 780
			// (get) Token: 0x06000E16 RID: 3606 RVA: 0x0004270C File Offset: 0x0004090C
			public IReadOnlyList<SilabaPronunciableEnTiempo> silabas
			{
				get
				{
					return this.m_silabas;
				}
			}

			// Token: 0x06000E17 RID: 3607 RVA: 0x00042714 File Offset: 0x00040914
			public float ObtenerDuracion()
			{
				float num = 0f;
				for (int i = 0; i < this.m_silabas.Count; i++)
				{
					num += this.m_silabas[i].duration;
				}
				return num;
			}

			// Token: 0x06000E18 RID: 3608 RVA: 0x00042758 File Offset: 0x00040958
			public void ObtenerTexto(StringBuilder result)
			{
				for (int i = 0; i < this.m_silabas.Count; i++)
				{
					foreach (Casilla casilla in this.m_silabas[i].silabaPronunciable.silaba)
					{
						foreach (CasillaDeCharacters casillaDeCharacters in casilla)
						{
							char @char = casillaDeCharacters.@char;
							int largo = casillaDeCharacters.largo;
							for (int j = 0; j < largo; j++)
							{
								result.Append(@char);
							}
						}
					}
				}
			}

			// Token: 0x06000E19 RID: 3609 RVA: 0x0004282C File Offset: 0x00040A2C
			public void ObtenerTextoAlterado(StringBuilder result, CharacterEstadoDeBoca usoDeBoca)
			{
				if (usoDeBoca == CharacterEstadoDeBoca.None)
				{
					this.ObtenerTexto(result);
					return;
				}
				for (int i = 0; i < this.m_silabas.Count; i++)
				{
					foreach (Casilla casilla in this.m_silabas[i].silabaPronunciable.silaba)
					{
						foreach (CasillaDeCharacters casillaDeCharacters in casilla)
						{
							char c;
							switch (casillaDeCharacters.tipo)
							{
							case TipoDeCharacter.espacio:
							case TipoDeCharacter.coma:
							case TipoDeCharacter.punto:
							case TipoDeCharacter.dosPuntos:
							case TipoDeCharacter.puntoYComa:
							case TipoDeCharacter.simbolo:
								c = casillaDeCharacters.@char;
								break;
							case TipoDeCharacter.consonante:
								c = this.ObtenerConsonanteDeCasilla(casillaDeCharacters, usoDeBoca);
								break;
							case TipoDeCharacter.vocal:
								c = this.ObtenerVocalDeCasilla(casillaDeCharacters, usoDeBoca);
								break;
							default:
								throw new ArgumentOutOfRangeException(casillaDeCharacters.tipo.ToString());
							}
							int largo = casillaDeCharacters.largo;
							for (int j = 0; j < largo; j++)
							{
								result.Append(c);
							}
						}
					}
				}
			}

			// Token: 0x06000E1A RID: 3610 RVA: 0x00042984 File Offset: 0x00040B84
			private char ObtenerVocalDeCasilla(CasillaDeCharacters casillaDeCharacters, CharacterEstadoDeBoca usoDeBoca)
			{
				switch (usoDeBoca)
				{
				case CharacterEstadoDeBoca.None:
					return casillaDeCharacters.@char;
				case CharacterEstadoDeBoca.sellada:
					return 'M';
				case CharacterEstadoDeBoca.abierta:
				{
					char? c = casillaDeCharacters.upper;
					if (c != null)
					{
						char c2 = c.GetValueOrDefault();
						if (c2 == 'I' || c2 == 'O' || c2 == 'U')
						{
							return 'a';
						}
					}
					return casillaDeCharacters.lower.Value;
				}
				case CharacterEstadoDeBoca.abiertaSinEnergia:
				{
					char? c = casillaDeCharacters.upper;
					if (c != null)
					{
						char c2 = c.GetValueOrDefault();
						if (c2 == 'I')
						{
							return 'e';
						}
						if (c2 == 'O' || c2 == 'U')
						{
							return 'a';
						}
					}
					return casillaDeCharacters.@char;
				}
				default:
					throw new ArgumentOutOfRangeException(usoDeBoca.ToString());
				}
			}

			// Token: 0x06000E1B RID: 3611 RVA: 0x00042A30 File Offset: 0x00040C30
			private char ObtenerConsonanteDeCasilla(CasillaDeCharacters casillaDeCharacters, CharacterEstadoDeBoca usoDeBoca)
			{
				switch (usoDeBoca)
				{
				case CharacterEstadoDeBoca.None:
					return casillaDeCharacters.@char;
				case CharacterEstadoDeBoca.sellada:
					return 'm';
				case CharacterEstadoDeBoca.abierta:
				{
					char? upper = casillaDeCharacters.upper;
					if (upper != null)
					{
						char valueOrDefault = upper.GetValueOrDefault();
						switch (valueOrDefault)
						{
						case 'G':
						case 'H':
						case 'J':
						case 'K':
							break;
						case 'I':
							goto IL_007E;
						default:
							if (valueOrDefault != 'Q')
							{
								goto IL_007E;
							}
							break;
						}
						return casillaDeCharacters.lower.Value;
					}
					IL_007E:
					switch (Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id)
					{
					case Localizacion.US:
						if (Random.value <= 0.75f)
						{
							return 'a';
						}
						return 'h';
					case Localizacion.ES:
						if (Random.value <= 0.75f)
						{
							return 'a';
						}
						return 'j';
					}
					throw new ArgumentOutOfRangeException(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id.ToString());
				}
				case CharacterEstadoDeBoca.abiertaSinEnergia:
					if (Random.value <= 0.85f)
					{
						return 'h';
					}
					return ' ';
				default:
					throw new ArgumentOutOfRangeException(usoDeBoca.ToString());
				}
			}

			// Token: 0x06000E1C RID: 3612 RVA: 0x00042B35 File Offset: 0x00040D35
			public void Add(SilabaPronunciableEnTiempo silaba)
			{
				this.m_silabas.Add(silaba);
			}

			// Token: 0x06000E1D RID: 3613 RVA: 0x00042B43 File Offset: 0x00040D43
			public void AddRange(IEnumerable<SilabaPronunciableEnTiempo> silabas)
			{
				this.m_silabas.AddRange(silabas);
			}

			// Token: 0x06000E1E RID: 3614 RVA: 0x00042B51 File Offset: 0x00040D51
			public void Clear()
			{
				this.m_silabas.Clear();
			}

			// Token: 0x04000C11 RID: 3089
			[SerializeField]
			private List<SilabaPronunciableEnTiempo> m_silabas = new List<SilabaPronunciableEnTiempo>();
		}
	}
}
