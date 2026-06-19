using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync
{
	// Token: 0x02000274 RID: 628
	public static class DecoDeTexto
	{
		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06000DE4 RID: 3556 RVA: 0x00040F66 File Offset: 0x0003F166
		public static DecoDeCharacters decoDeCharacters
		{
			get
			{
				if (DecoDeTexto.m_decoDeCharacters == null)
				{
					DecoDeTexto.m_decoDeCharacters = new DecoDeCharacters();
				}
				return DecoDeTexto.m_decoDeCharacters;
			}
		}

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06000DE5 RID: 3557 RVA: 0x00040F7E File Offset: 0x0003F17E
		public static DecoDeCasilla decoDeCasilla
		{
			get
			{
				if (DecoDeTexto.m_DecoDeCasilla == null)
				{
					DecoDeTexto.m_DecoDeCasilla = new DecoDeCasilla();
				}
				return DecoDeTexto.m_DecoDeCasilla;
			}
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x00040F98 File Offset: 0x0003F198
		public static TextoPronunciable Decodificar(string texto, SimplePoolDeClearables<TextoPronunciable> pool)
		{
			TextoPronunciable textoPronunciable2;
			try
			{
				if (string.IsNullOrEmpty(texto))
				{
					throw new InvalidOperationException(texto);
				}
				DecoDeTexto.LoadCasillasUnChar(texto);
				DecoDeTexto.LoadCasillas();
				DecoDeTexto.LoadSilabas();
				DecoDeTexto.LoadSilabasPronunciables();
				TextoPronunciable textoPronunciable;
				if (pool == null)
				{
					if (Application.isPlaying)
					{
						throw new NullReferenceException();
					}
					textoPronunciable = new TextoPronunciable();
				}
				else
				{
					textoPronunciable = pool.GetItem();
				}
				textoPronunciable.Init(DecoDeTexto.m_SilabasPronunciables);
				textoPronunciable2 = textoPronunciable;
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Texto fallo: " + texto);
				Debug.LogException(ex);
				textoPronunciable2 = null;
			}
			finally
			{
				DecoDeTexto.m_TempAcumulados.Clear();
				DecoDeTexto.m_TempAcumulados2.Clear();
				DecoDeTexto.m_SilabasPronunciables.Clear();
				DecoDeTexto.m_CasillasDeUnSoloChar.Clear();
				DecoDeTexto.m_Casillas.Clear();
				DecoDeTexto.m_Silabas.Clear();
			}
			return textoPronunciable2;
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x0004106C File Offset: 0x0003F26C
		private static void LoadCasillas()
		{
			if (DecoDeTexto.m_CasillasDeUnSoloChar.Count == 1)
			{
				DecoDeTexto.m_Casillas.Add(new Casilla(DecoDeTexto.m_CasillasDeUnSoloChar[0]));
				return;
			}
			for (int i = 0; i < DecoDeTexto.m_CasillasDeUnSoloChar.Count; i++)
			{
				CasillaDeCharacters casillaDeCharacters = DecoDeTexto.m_CasillasDeUnSoloChar[i];
				if (i == 0)
				{
					DecoDeTexto.m_TempAcumulados.Add(casillaDeCharacters);
				}
				else
				{
					CasillaDeCharacters casillaDeCharacters2 = DecoDeTexto.m_CasillasDeUnSoloChar[i - 1];
					bool flag = DecoDeTexto.m_CasillasDeUnSoloChar.Count - 1 == i;
					if (!flag)
					{
						if (casillaDeCharacters2.@char == casillaDeCharacters.@char)
						{
							throw new NotSupportedException();
						}
						if (DecoDeTexto.AcumuladosCasillasPorLenguaje(DecoDeTexto.m_TempAcumulados, casillaDeCharacters))
						{
							DecoDeTexto.m_TempAcumulados.Add(casillaDeCharacters);
							goto IL_00B2;
						}
					}
					DecoDeTexto.VaciarCasillasAcumulados();
					DecoDeTexto.m_TempAcumulados.Add(casillaDeCharacters);
					if (flag)
					{
						DecoDeTexto.VaciarCasillasAcumulados();
					}
				}
				IL_00B2:;
			}
			if (DecoDeTexto.m_TempAcumulados.Count > 0)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x00041154 File Offset: 0x0003F354
		private static void VaciarCasillasAcumulados()
		{
			try
			{
				if (DecoDeTexto.m_TempAcumulados.Count != 0)
				{
					Casilla casilla;
					if (DecoDeTexto.m_TempAcumulados.Count == 1)
					{
						casilla = new Casilla(DecoDeTexto.m_TempAcumulados[0]);
					}
					else
					{
						if (DecoDeTexto.m_TempAcumulados.Count != 2)
						{
							throw new NotSupportedException();
						}
						casilla = new Casilla(DecoDeTexto.m_TempAcumulados[0], DecoDeTexto.m_TempAcumulados[1]);
					}
					DecoDeTexto.m_Casillas.Add(casilla);
				}
			}
			finally
			{
				DecoDeTexto.m_TempAcumulados.Clear();
			}
		}

		// Token: 0x06000DE9 RID: 3561 RVA: 0x000411EC File Offset: 0x0003F3EC
		private static void LoadCasillasUnChar(string texto)
		{
			CasillaDeCharacters casillaDeCharacters = default(CasillaDeCharacters);
			int num = -1;
			for (int i = 0; i < texto.Length; i++)
			{
				char c = texto[i];
				if (i > 0 && c == casillaDeCharacters.@char)
				{
					casillaDeCharacters = DecoDeTexto.m_CasillasDeUnSoloChar[num];
					casillaDeCharacters.largo++;
					DecoDeTexto.m_CasillasDeUnSoloChar[num] = casillaDeCharacters;
				}
				else
				{
					casillaDeCharacters = new CasillaDeCharacters(DecoDeTexto.decoDeCharacters.Decodificar(c), c);
					num = DecoDeTexto.m_CasillasDeUnSoloChar.Count;
					DecoDeTexto.m_CasillasDeUnSoloChar.Add(casillaDeCharacters);
				}
			}
		}

		// Token: 0x06000DEA RID: 3562 RVA: 0x0004127C File Offset: 0x0003F47C
		private static void LoadSilabasPronunciables()
		{
			for (int i = 0; i < DecoDeTexto.m_Silabas.Count; i++)
			{
				DecoDeTexto.m_SilabasPronunciables.Add(new SilabaPronunciable(DecoDeTexto.m_Silabas[i], DecoDeTexto.decoDeCasilla));
			}
		}

		// Token: 0x06000DEB RID: 3563 RVA: 0x000412C0 File Offset: 0x0003F4C0
		private static void LoadSilabas()
		{
			if (DecoDeTexto.m_Casillas.Count == 1)
			{
				Casilla casilla = DecoDeTexto.m_Casillas[0];
				DecoDeTexto.m_Silabas.Add(new Silaba(casilla));
				return;
			}
			for (int i = 0; i < DecoDeTexto.m_Casillas.Count; i++)
			{
				Casilla casilla2 = DecoDeTexto.m_Casillas[i];
				if (i == 0)
				{
					DecoDeTexto.m_TempAcumulados2.Add(casilla2);
				}
				else
				{
					Casilla casilla3 = DecoDeTexto.m_Casillas[i - 1];
					bool flag = DecoDeTexto.m_Casillas.Count - 1 == i;
					if (DecoDeTexto.AcumuladosSilabasPorLenguaje(DecoDeTexto.m_TempAcumulados2, casilla2))
					{
						DecoDeTexto.m_TempAcumulados2.Add(casilla2);
						if (flag)
						{
							DecoDeTexto.VaciarSilabasAcumulados();
						}
					}
					else
					{
						DecoDeTexto.VaciarSilabasAcumulados();
						DecoDeTexto.m_TempAcumulados2.Add(casilla2);
						if (flag)
						{
							DecoDeTexto.VaciarSilabasAcumulados();
						}
					}
				}
			}
			if (DecoDeTexto.m_TempAcumulados.Count > 0)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x06000DEC RID: 3564 RVA: 0x00041398 File Offset: 0x0003F598
		private static void VaciarSilabasAcumulados()
		{
			try
			{
				if (DecoDeTexto.m_TempAcumulados2.Count != 0)
				{
					Silaba silaba;
					if (DecoDeTexto.m_TempAcumulados2.Count == 1)
					{
						silaba = new Silaba(DecoDeTexto.m_TempAcumulados2[0]);
					}
					else if (DecoDeTexto.m_TempAcumulados2.Count == 2)
					{
						silaba = new Silaba(DecoDeTexto.m_TempAcumulados2[0], DecoDeTexto.m_TempAcumulados2[1]);
					}
					else if (DecoDeTexto.m_TempAcumulados2.Count == 3)
					{
						silaba = new Silaba(DecoDeTexto.m_TempAcumulados2[0], DecoDeTexto.m_TempAcumulados2[1]);
					}
					else
					{
						silaba = new Silaba(DecoDeTexto.m_TempAcumulados2[0], DecoDeTexto.m_TempAcumulados2[1]);
						Debug.LogException(new NotSupportedException("mas de tres silabas acumuladas: " + string.Join("+", DecoDeTexto.m_TempAcumulados2.Select((Casilla ac) => ac.ToString()))));
					}
					DecoDeTexto.m_Silabas.Add(silaba);
				}
			}
			finally
			{
				DecoDeTexto.m_TempAcumulados2.Clear();
			}
		}

		// Token: 0x06000DED RID: 3565 RVA: 0x000414D0 File Offset: 0x0003F6D0
		private static bool AcumuladosCasillasPorLenguaje(List<CasillaDeCharacters> acumulados, CasillaDeCharacters current)
		{
			if (acumulados.Count > 0 && current.esLetra)
			{
				if (current.upper.Value == 'H')
				{
					CasillaDeCharacters casillaDeCharacters = acumulados[acumulados.Count - 1];
					if (casillaDeCharacters.esLetra)
					{
						if (casillaDeCharacters.upper.Value == 'T')
						{
							return true;
						}
						if (casillaDeCharacters.upper.Value == 'S')
						{
							return true;
						}
						if (casillaDeCharacters.upper.Value == 'C')
						{
							return true;
						}
						if (casillaDeCharacters.upper.Value == 'P')
						{
							return true;
						}
					}
				}
				if (current.upper.Value == 'C')
				{
					CasillaDeCharacters casillaDeCharacters2 = acumulados[acumulados.Count - 1];
					if (casillaDeCharacters2.esLetra && casillaDeCharacters2.upper.Value == 'K')
					{
						return true;
					}
				}
				if (Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id == Localizacion.ES)
				{
					if (current.upper.Value == 'U')
					{
						CasillaDeCharacters casillaDeCharacters3 = acumulados[acumulados.Count - 1];
						if (casillaDeCharacters3.esLetra && casillaDeCharacters3.upper.Value == 'Q')
						{
							return true;
						}
					}
					if (current.upper.Value == 'U')
					{
						CasillaDeCharacters casillaDeCharacters4 = acumulados[acumulados.Count - 1];
						if (casillaDeCharacters4.esLetra && casillaDeCharacters4.upper.Value == 'Q')
						{
							return true;
						}
						if (casillaDeCharacters4.esLetra && casillaDeCharacters4.upper.Value == 'G')
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000DEE RID: 3566 RVA: 0x00041644 File Offset: 0x0003F844
		private static bool AcumuladosSilabasPorLenguaje(List<Casilla> acumulados, Casilla current)
		{
			if (acumulados.Count > 0 && current.tipo == TipoDeCasilla.simple)
			{
				if (current.primer.tipo == TipoDeCharacter.vocal)
				{
					Casilla casilla = acumulados[acumulados.Count - 1];
					return casilla.tipo == TipoDeCasilla.consonanteCompuesta || casilla.primer.tipo == TipoDeCharacter.consonante;
				}
				if (current.primer.tipo == TipoDeCharacter.consonante)
				{
					char value = current.primer.upper.Value;
					if (value == 'H')
					{
						Casilla casilla2 = acumulados[acumulados.Count - 1];
						if (casilla2.tipo == TipoDeCasilla.simple && casilla2.primer.tipo == TipoDeCharacter.vocal)
						{
							if (acumulados.Count <= 1)
							{
								return true;
							}
							Casilla casilla3 = acumulados[acumulados.Count - 2];
							if (casilla3.tipo == TipoDeCasilla.simple && casilla3.primer.tipo == TipoDeCharacter.vocal)
							{
								return true;
							}
						}
						return false;
					}
					if (value == 'Y')
					{
						Casilla casilla4 = acumulados[acumulados.Count - 1];
						return casilla4.tipo == TipoDeCasilla.consonanteCompuesta || casilla4.primer.tipo == TipoDeCharacter.consonante;
					}
					return false;
				}
			}
			return false;
		}

		// Token: 0x04000BFE RID: 3070
		private static DecoDeCharacters m_decoDeCharacters;

		// Token: 0x04000BFF RID: 3071
		private static DecoDeCasilla m_DecoDeCasilla;

		// Token: 0x04000C00 RID: 3072
		private static List<Casilla> m_Casillas = new List<Casilla>();

		// Token: 0x04000C01 RID: 3073
		private static List<CasillaDeCharacters> m_CasillasDeUnSoloChar = new List<CasillaDeCharacters>();

		// Token: 0x04000C02 RID: 3074
		private static List<Silaba> m_Silabas = new List<Silaba>();

		// Token: 0x04000C03 RID: 3075
		private static List<SilabaPronunciable> m_SilabasPronunciables = new List<SilabaPronunciable>();

		// Token: 0x04000C04 RID: 3076
		private static List<CasillaDeCharacters> m_TempAcumulados = new List<CasillaDeCharacters>();

		// Token: 0x04000C05 RID: 3077
		private static List<Casilla> m_TempAcumulados2 = new List<Casilla>();
	}
}
