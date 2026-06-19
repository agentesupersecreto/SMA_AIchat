using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.NombresDePartesDelCuerpo;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos
{
	// Token: 0x020001CB RID: 459
	public class NombresLocalizadosDePartes : Singleton<NombresLocalizadosDePartes>
	{
		// Token: 0x06000AE9 RID: 2793 RVA: 0x0003166C File Offset: 0x0002F86C
		public DialogoInfoParteDelCuerpo ObtenerPrimeroPluralDeCurrentLocalization(ParteDelCuerpoHumano parte)
		{
			Localizacion id = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id;
			DiccionaryEnum<ParteDelCuerpoHumano, ListaDeNombresDeParteDelCuerpo> diccionaryEnum;
			if (id > Localizacion.US)
			{
				if (id != Localizacion.ES)
				{
					throw new ArgumentOutOfRangeException(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id.ToString());
				}
				diccionaryEnum = this.m_ES_Cuerpo;
			}
			else
			{
				diccionaryEnum = this.m_US_Cuerpo;
			}
			ListaDeNombresDeParteDelCuerpo listaDeNombresDeParteDelCuerpo;
			if (diccionaryEnum.TryGetValue(parte, out listaDeNombresDeParteDelCuerpo))
			{
				return listaDeNombresDeParteDelCuerpo.ObtenerPluralOrFirst();
			}
			return null;
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x000316D8 File Offset: 0x0002F8D8
		public DialogoInfoParteDelCuerpo ObtenerPrimeroSingularDeCurrentLocalization(ParteDelCuerpoHumano parte)
		{
			Localizacion id = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id;
			DiccionaryEnum<ParteDelCuerpoHumano, ListaDeNombresDeParteDelCuerpo> diccionaryEnum;
			if (id > Localizacion.US)
			{
				if (id != Localizacion.ES)
				{
					throw new ArgumentOutOfRangeException(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id.ToString());
				}
				diccionaryEnum = this.m_ES_Cuerpo;
			}
			else
			{
				diccionaryEnum = this.m_US_Cuerpo;
			}
			ListaDeNombresDeParteDelCuerpo listaDeNombresDeParteDelCuerpo;
			if (diccionaryEnum.TryGetValue(parte, out listaDeNombresDeParteDelCuerpo))
			{
				return listaDeNombresDeParteDelCuerpo.ObtenerSingularOrFirst();
			}
			return null;
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x00031744 File Offset: 0x0002F944
		public DialogoInfoParteDelCuerpo ObtenerPrimeroDeCurrentLocalization(ParteDelCuerpoHumano parte)
		{
			Localizacion id = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id;
			DiccionaryEnum<ParteDelCuerpoHumano, ListaDeNombresDeParteDelCuerpo> diccionaryEnum;
			if (id > Localizacion.US)
			{
				if (id != Localizacion.ES)
				{
					throw new ArgumentOutOfRangeException(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id.ToString());
				}
				diccionaryEnum = this.m_ES_Cuerpo;
			}
			else
			{
				diccionaryEnum = this.m_US_Cuerpo;
			}
			ListaDeNombresDeParteDelCuerpo listaDeNombresDeParteDelCuerpo;
			if (diccionaryEnum.TryGetValue(parte, out listaDeNombresDeParteDelCuerpo))
			{
				return listaDeNombresDeParteDelCuerpo.ObtenerPrimero();
			}
			return null;
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x000317B0 File Offset: 0x0002F9B0
		public DialogoInfoParteDelCuerpo ObtenerRealDeCurrentLocalization(ParteDelCuerpoHumano parte)
		{
			Localizacion id = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id;
			DiccionaryEnum<ParteDelCuerpoHumano, ListaDeNombresDeParteDelCuerpo> diccionaryEnum;
			if (id > Localizacion.US)
			{
				if (id != Localizacion.ES)
				{
					throw new ArgumentOutOfRangeException(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id.ToString());
				}
				diccionaryEnum = this.m_ES_Cuerpo;
			}
			else
			{
				diccionaryEnum = this.m_US_Cuerpo;
			}
			ListaDeNombresDeParteDelCuerpo listaDeNombresDeParteDelCuerpo;
			if (diccionaryEnum.TryGetValue(parte, out listaDeNombresDeParteDelCuerpo))
			{
				return listaDeNombresDeParteDelCuerpo.ObtenerReal();
			}
			return null;
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x0003181C File Offset: 0x0002FA1C
		public DialogoInfoParteDelCuerpo ObtenerDeCurrentLocalization(ParteDelCuerpoHumano parte)
		{
			Localizacion id = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id;
			DiccionaryEnum<ParteDelCuerpoHumano, ListaDeNombresDeParteDelCuerpo> diccionaryEnum;
			if (id > Localizacion.US)
			{
				if (id != Localizacion.ES)
				{
					throw new ArgumentOutOfRangeException(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id.ToString());
				}
				diccionaryEnum = this.m_ES_Cuerpo;
			}
			else
			{
				diccionaryEnum = this.m_US_Cuerpo;
			}
			ListaDeNombresDeParteDelCuerpo listaDeNombresDeParteDelCuerpo;
			if (diccionaryEnum.TryGetValue(parte, out listaDeNombresDeParteDelCuerpo))
			{
				return listaDeNombresDeParteDelCuerpo.Obtener(null);
			}
			return null;
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x0003188C File Offset: 0x0002FA8C
		public DialogoInfoParteDelCuerpo ObtenerDeCurrentLocalization(ParteQuePuedeEstimular parte, TipoDeEstimulo contexto)
		{
			Localizacion id = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id;
			DiccionaryEnum<ParteQuePuedeEstimular, ListaDeNombresDeParteQueEstimula> diccionaryEnum;
			if (id > Localizacion.US)
			{
				if (id != Localizacion.ES)
				{
					goto IL_00A2;
				}
			}
			else
			{
				try
				{
					diccionaryEnum = this.m_US_QueEstimulan[contexto];
					goto IL_00C2;
				}
				catch (Exception)
				{
					Debug.LogError("No se encontro nombre para parte: " + parte.ToString() + " con contexto: " + contexto.ToString());
					throw;
				}
			}
			try
			{
				diccionaryEnum = this.m_ES_QueEstimulan[contexto];
				goto IL_00C2;
			}
			catch (Exception)
			{
				Debug.LogError("No se encontro nombre para parte: " + parte.ToString() + " con contexto: " + contexto.ToString());
				throw;
			}
			IL_00A2:
			throw new ArgumentOutOfRangeException(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id.ToString());
			IL_00C2:
			ListaDeNombresDeParteQueEstimula listaDeNombresDeParteQueEstimula;
			if (diccionaryEnum.TryGetValue(parte, out listaDeNombresDeParteQueEstimula))
			{
				return listaDeNombresDeParteQueEstimula.Obtener(null);
			}
			return null;
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x0003198C File Offset: 0x0002FB8C
		public DialogoInfoParteDelCuerpo ObtenerDeCurrentLocalization(SemenParticulaQuePuedeEstimular parte, TipoDeEstimulo contexto)
		{
			Localizacion id = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id;
			DiccionaryEnum<SemenParticulaQuePuedeEstimular, ListaDeNombresDeSemenParticulasQueEstimula> diccionaryEnum;
			if (id > Localizacion.US)
			{
				if (id != Localizacion.ES)
				{
					goto IL_00A2;
				}
			}
			else
			{
				try
				{
					diccionaryEnum = this.m_US_SemenParticulasQueEstimulan[contexto];
					goto IL_00C2;
				}
				catch (Exception)
				{
					Debug.LogError("No se encontro nombre para parte: " + parte.ToString() + " con contexto: " + contexto.ToString());
					throw;
				}
			}
			try
			{
				diccionaryEnum = this.m_ES_SemenParticulasQueEstimulan[contexto];
				goto IL_00C2;
			}
			catch (Exception)
			{
				Debug.LogError("No se encontro nombre para parte: " + parte.ToString() + " con contexto: " + contexto.ToString());
				throw;
			}
			IL_00A2:
			throw new ArgumentOutOfRangeException(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id.ToString());
			IL_00C2:
			ListaDeNombresDeSemenParticulasQueEstimula listaDeNombresDeSemenParticulasQueEstimula;
			if (diccionaryEnum.TryGetValue(parte, out listaDeNombresDeSemenParticulasQueEstimula))
			{
				return listaDeNombresDeSemenParticulasQueEstimula.Obtener(null);
			}
			return null;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x00031A8C File Offset: 0x0002FC8C
		public DialogoInfoParteDelCuerpo ObtenerDeCurrentLocalization(TipoDeProp prop, TipoDeEstimulo contexto)
		{
			Localizacion id = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id;
			DiccionaryEnum<TipoDeProp, ListaDeNombresDePropsQueEstimula> diccionaryEnum;
			if (id > Localizacion.US)
			{
				if (id != Localizacion.ES)
				{
					goto IL_00A2;
				}
			}
			else
			{
				try
				{
					diccionaryEnum = this.m_US_PropsQueEstimulan[contexto];
					goto IL_00C2;
				}
				catch (Exception)
				{
					Debug.LogError("No se encontro nombre para prop: " + prop.ToString() + " con contexto: " + contexto.ToString());
					throw;
				}
			}
			try
			{
				diccionaryEnum = this.m_ES_PropsQueEstimulan[contexto];
				goto IL_00C2;
			}
			catch (Exception)
			{
				Debug.LogError("No se encontro nombre para prop: " + prop.ToString() + " con contexto: " + contexto.ToString());
				throw;
			}
			IL_00A2:
			throw new ArgumentOutOfRangeException(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id.ToString());
			IL_00C2:
			ListaDeNombresDePropsQueEstimula listaDeNombresDePropsQueEstimula;
			if (diccionaryEnum.TryGetValue(prop, out listaDeNombresDePropsQueEstimula))
			{
				return listaDeNombresDePropsQueEstimula.Obtener(null);
			}
			return null;
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x00031B8C File Offset: 0x0002FD8C
		protected override void InitData(bool esEditorTime)
		{
			this.m_ES_Cuerpo = new DiccionaryEnum<ParteDelCuerpoHumano, ListaDeNombresDeParteDelCuerpo>((ParteDelCuerpoHumano x) => (int)x);
			this.m_US_Cuerpo = new DiccionaryEnum<ParteDelCuerpoHumano, ListaDeNombresDeParteDelCuerpo>((ParteDelCuerpoHumano x) => (int)x);
			foreach (ListaDeNombresDeParteDelCuerpo listaDeNombresDeParteDelCuerpo in this.m_nombresDePartesDelCuerpo)
			{
				DiccionaryEnum<ParteDelCuerpoHumano, ListaDeNombresDeParteDelCuerpo> diccionaryEnum;
				if (listaDeNombresDeParteDelCuerpo.ParaCultura(Localizacion.ES))
				{
					diccionaryEnum = this.m_ES_Cuerpo;
				}
				else
				{
					if (!listaDeNombresDeParteDelCuerpo.ParaCultura(Localizacion.US))
					{
						Debug.LogError("mapa no es mapa culturas establecidas: " + listaDeNombresDeParteDelCuerpo.paraCulturas.ToString(), listaDeNombresDeParteDelCuerpo);
						continue;
					}
					diccionaryEnum = this.m_US_Cuerpo;
				}
				ListaDeNombresDeParteDelCuerpo listaDeNombresDeParteDelCuerpo2;
				if (!diccionaryEnum.TryGetValue(listaDeNombresDeParteDelCuerpo.parte, out listaDeNombresDeParteDelCuerpo2))
				{
					listaDeNombresDeParteDelCuerpo2 = ScriptableObject.CreateInstance<ListaDeNombresDeParteDelCuerpo>();
					listaDeNombresDeParteDelCuerpo2.CopiarDe(listaDeNombresDeParteDelCuerpo);
					diccionaryEnum.Add(listaDeNombresDeParteDelCuerpo.parte, listaDeNombresDeParteDelCuerpo2);
				}
				listaDeNombresDeParteDelCuerpo2.Add(listaDeNombresDeParteDelCuerpo, false);
			}
			this.m_ES_QueEstimulan = new DiccionaryEnum<TipoDeEstimulo, DiccionaryEnum<ParteQuePuedeEstimular, ListaDeNombresDeParteQueEstimula>>((TipoDeEstimulo x) => (int)x);
			this.m_US_QueEstimulan = new DiccionaryEnum<TipoDeEstimulo, DiccionaryEnum<ParteQuePuedeEstimular, ListaDeNombresDeParteQueEstimula>>((TipoDeEstimulo x) => (int)x);
			foreach (ListaDeNombresDeParteQueEstimula listaDeNombresDeParteQueEstimula in this.m_nombresDePartesQueEstimulan)
			{
				foreach (object obj in typeof(TipoDeEstimulo).GetEnumValoresObject())
				{
					TipoDeEstimulo tipoDeEstimulo = (TipoDeEstimulo)obj;
					if (tipoDeEstimulo != TipoDeEstimulo.None)
					{
						TipoDeEstimuloFlags tipoDeEstimuloFlags = tipoDeEstimulo.ParceAFlags();
						if (((int)listaDeNombresDeParteQueEstimula.contexto).HasFlag((int)tipoDeEstimuloFlags))
						{
							DiccionaryEnum<ParteQuePuedeEstimular, ListaDeNombresDeParteQueEstimula> diccionaryEnum2;
							if (listaDeNombresDeParteQueEstimula.ParaCultura(Localizacion.US))
							{
								if (!this.m_US_QueEstimulan.TryGetValue(tipoDeEstimulo, out diccionaryEnum2))
								{
									diccionaryEnum2 = new DiccionaryEnum<ParteQuePuedeEstimular, ListaDeNombresDeParteQueEstimula>((ParteQuePuedeEstimular x) => (int)x);
									this.m_US_QueEstimulan.Add(tipoDeEstimulo, diccionaryEnum2);
								}
							}
							else
							{
								if (!listaDeNombresDeParteQueEstimula.ParaCultura(Localizacion.ES))
								{
									Debug.LogError("mapa no es mapa culturas establecidas: " + listaDeNombresDeParteQueEstimula.paraCulturas.ToString(), listaDeNombresDeParteQueEstimula);
									continue;
								}
								if (!this.m_ES_QueEstimulan.TryGetValue(tipoDeEstimulo, out diccionaryEnum2))
								{
									diccionaryEnum2 = new DiccionaryEnum<ParteQuePuedeEstimular, ListaDeNombresDeParteQueEstimula>((ParteQuePuedeEstimular x) => (int)x);
									this.m_ES_QueEstimulan.Add(tipoDeEstimulo, diccionaryEnum2);
								}
							}
							ListaDeNombresDeParteQueEstimula listaDeNombresDeParteQueEstimula2;
							if (!diccionaryEnum2.TryGetValue(listaDeNombresDeParteQueEstimula.parte, out listaDeNombresDeParteQueEstimula2))
							{
								listaDeNombresDeParteQueEstimula2 = ScriptableObject.CreateInstance<ListaDeNombresDeParteQueEstimula>();
								listaDeNombresDeParteQueEstimula2.CopiarDe(listaDeNombresDeParteQueEstimula);
								diccionaryEnum2.Add(listaDeNombresDeParteQueEstimula.parte, listaDeNombresDeParteQueEstimula2);
							}
							listaDeNombresDeParteQueEstimula2.Add(listaDeNombresDeParteQueEstimula, false);
						}
					}
				}
			}
			this.m_ES_SemenParticulasQueEstimulan = new DiccionaryEnum<TipoDeEstimulo, DiccionaryEnum<SemenParticulaQuePuedeEstimular, ListaDeNombresDeSemenParticulasQueEstimula>>((TipoDeEstimulo x) => (int)x);
			this.m_US_SemenParticulasQueEstimulan = new DiccionaryEnum<TipoDeEstimulo, DiccionaryEnum<SemenParticulaQuePuedeEstimular, ListaDeNombresDeSemenParticulasQueEstimula>>((TipoDeEstimulo x) => (int)x);
			foreach (ListaDeNombresDeSemenParticulasQueEstimula listaDeNombresDeSemenParticulasQueEstimula in this.m_nombresDeSemenParticulasQueEstimulan)
			{
				foreach (object obj2 in typeof(TipoDeEstimulo).GetEnumValoresObject())
				{
					TipoDeEstimulo tipoDeEstimulo2 = (TipoDeEstimulo)obj2;
					if (tipoDeEstimulo2 != TipoDeEstimulo.None)
					{
						TipoDeEstimuloFlags tipoDeEstimuloFlags2 = tipoDeEstimulo2.ParceAFlags();
						if (((int)listaDeNombresDeSemenParticulasQueEstimula.contexto).HasFlag((int)tipoDeEstimuloFlags2))
						{
							DiccionaryEnum<SemenParticulaQuePuedeEstimular, ListaDeNombresDeSemenParticulasQueEstimula> diccionaryEnum3;
							if (listaDeNombresDeSemenParticulasQueEstimula.ParaCultura(Localizacion.US))
							{
								if (!this.m_US_SemenParticulasQueEstimulan.TryGetValue(tipoDeEstimulo2, out diccionaryEnum3))
								{
									diccionaryEnum3 = new DiccionaryEnum<SemenParticulaQuePuedeEstimular, ListaDeNombresDeSemenParticulasQueEstimula>((SemenParticulaQuePuedeEstimular x) => (int)x);
									this.m_US_SemenParticulasQueEstimulan.Add(tipoDeEstimulo2, diccionaryEnum3);
								}
							}
							else
							{
								if (!listaDeNombresDeSemenParticulasQueEstimula.ParaCultura(Localizacion.ES))
								{
									Debug.LogError("mapa no es mapa culturas establecidas: " + listaDeNombresDeSemenParticulasQueEstimula.paraCulturas.ToString(), listaDeNombresDeSemenParticulasQueEstimula);
									continue;
								}
								if (!this.m_ES_SemenParticulasQueEstimulan.TryGetValue(tipoDeEstimulo2, out diccionaryEnum3))
								{
									diccionaryEnum3 = new DiccionaryEnum<SemenParticulaQuePuedeEstimular, ListaDeNombresDeSemenParticulasQueEstimula>((SemenParticulaQuePuedeEstimular x) => (int)x);
									this.m_ES_SemenParticulasQueEstimulan.Add(tipoDeEstimulo2, diccionaryEnum3);
								}
							}
							ListaDeNombresDeSemenParticulasQueEstimula listaDeNombresDeSemenParticulasQueEstimula2;
							if (!diccionaryEnum3.TryGetValue(listaDeNombresDeSemenParticulasQueEstimula.parte, out listaDeNombresDeSemenParticulasQueEstimula2))
							{
								listaDeNombresDeSemenParticulasQueEstimula2 = ScriptableObject.CreateInstance<ListaDeNombresDeSemenParticulasQueEstimula>();
								listaDeNombresDeSemenParticulasQueEstimula2.CopiarDe(listaDeNombresDeSemenParticulasQueEstimula);
								diccionaryEnum3.Add(listaDeNombresDeSemenParticulasQueEstimula.parte, listaDeNombresDeSemenParticulasQueEstimula2);
							}
							listaDeNombresDeSemenParticulasQueEstimula2.Add(listaDeNombresDeSemenParticulasQueEstimula, false);
						}
					}
				}
			}
			this.m_ES_PropsQueEstimulan = new DiccionaryEnum<TipoDeEstimulo, DiccionaryEnum<TipoDeProp, ListaDeNombresDePropsQueEstimula>>((TipoDeEstimulo x) => (int)x);
			this.m_US_PropsQueEstimulan = new DiccionaryEnum<TipoDeEstimulo, DiccionaryEnum<TipoDeProp, ListaDeNombresDePropsQueEstimula>>((TipoDeEstimulo x) => (int)x);
			foreach (ListaDeNombresDePropsQueEstimula listaDeNombresDePropsQueEstimula in this.m_nombresDePropsQueEstimulan)
			{
				foreach (object obj3 in typeof(TipoDeEstimulo).GetEnumValoresObject())
				{
					TipoDeEstimulo tipoDeEstimulo3 = (TipoDeEstimulo)obj3;
					if (tipoDeEstimulo3 != TipoDeEstimulo.None)
					{
						TipoDeEstimuloFlags tipoDeEstimuloFlags3 = tipoDeEstimulo3.ParceAFlags();
						if (((int)listaDeNombresDePropsQueEstimula.contexto).HasFlag((int)tipoDeEstimuloFlags3))
						{
							DiccionaryEnum<TipoDeProp, ListaDeNombresDePropsQueEstimula> diccionaryEnum4;
							if (listaDeNombresDePropsQueEstimula.ParaCultura(Localizacion.US))
							{
								if (!this.m_US_PropsQueEstimulan.TryGetValue(tipoDeEstimulo3, out diccionaryEnum4))
								{
									diccionaryEnum4 = new DiccionaryEnum<TipoDeProp, ListaDeNombresDePropsQueEstimula>((TipoDeProp x) => (int)x);
									this.m_US_PropsQueEstimulan.Add(tipoDeEstimulo3, diccionaryEnum4);
								}
							}
							else
							{
								if (!listaDeNombresDePropsQueEstimula.ParaCultura(Localizacion.ES))
								{
									Debug.LogError("mapa no es mapa culturas establecidas: " + listaDeNombresDePropsQueEstimula.paraCulturas.ToString(), listaDeNombresDePropsQueEstimula);
									continue;
								}
								if (!this.m_ES_PropsQueEstimulan.TryGetValue(tipoDeEstimulo3, out diccionaryEnum4))
								{
									diccionaryEnum4 = new DiccionaryEnum<TipoDeProp, ListaDeNombresDePropsQueEstimula>((TipoDeProp x) => (int)x);
									this.m_ES_PropsQueEstimulan.Add(tipoDeEstimulo3, diccionaryEnum4);
								}
							}
							ListaDeNombresDePropsQueEstimula listaDeNombresDePropsQueEstimula2;
							if (!diccionaryEnum4.TryGetValue(listaDeNombresDePropsQueEstimula.parte, out listaDeNombresDePropsQueEstimula2))
							{
								listaDeNombresDePropsQueEstimula2 = ScriptableObject.CreateInstance<ListaDeNombresDePropsQueEstimula>();
								listaDeNombresDePropsQueEstimula2.CopiarDe(listaDeNombresDePropsQueEstimula);
								diccionaryEnum4.Add(listaDeNombresDePropsQueEstimula.parte, listaDeNombresDePropsQueEstimula2);
							}
							listaDeNombresDePropsQueEstimula2.Add(listaDeNombresDePropsQueEstimula, false);
						}
					}
				}
			}
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x00032360 File Offset: 0x00030560
		protected override void OnDestroyed(bool wasInitiated)
		{
			base.OnDestroyed(wasInitiated);
			if (wasInitiated)
			{
				foreach (KeyValuePair<int, ListaDeNombresDeParteDelCuerpo> keyValuePair in this.m_ES_Cuerpo)
				{
					if (keyValuePair.Value != null)
					{
						Object.Destroy(keyValuePair.Value);
					}
				}
				foreach (KeyValuePair<int, ListaDeNombresDeParteDelCuerpo> keyValuePair2 in this.m_US_Cuerpo)
				{
					if (keyValuePair2.Value != null)
					{
						Object.Destroy(keyValuePair2.Value);
					}
				}
				foreach (KeyValuePair<int, DiccionaryEnum<ParteQuePuedeEstimular, ListaDeNombresDeParteQueEstimula>> keyValuePair3 in this.m_ES_QueEstimulan)
				{
					if (keyValuePair3.Value != null)
					{
						foreach (KeyValuePair<int, ListaDeNombresDeParteQueEstimula> keyValuePair4 in keyValuePair3.Value)
						{
							Object.Destroy(keyValuePair4.Value);
						}
					}
				}
				foreach (KeyValuePair<int, DiccionaryEnum<ParteQuePuedeEstimular, ListaDeNombresDeParteQueEstimula>> keyValuePair5 in this.m_US_QueEstimulan)
				{
					if (keyValuePair5.Value != null)
					{
						foreach (KeyValuePair<int, ListaDeNombresDeParteQueEstimula> keyValuePair6 in keyValuePair5.Value)
						{
							Object.Destroy(keyValuePair6.Value);
						}
					}
				}
				foreach (KeyValuePair<int, DiccionaryEnum<SemenParticulaQuePuedeEstimular, ListaDeNombresDeSemenParticulasQueEstimula>> keyValuePair7 in this.m_ES_SemenParticulasQueEstimulan)
				{
					if (keyValuePair7.Value != null)
					{
						foreach (KeyValuePair<int, ListaDeNombresDeSemenParticulasQueEstimula> keyValuePair8 in keyValuePair7.Value)
						{
							Object.Destroy(keyValuePair8.Value);
						}
					}
				}
				foreach (KeyValuePair<int, DiccionaryEnum<SemenParticulaQuePuedeEstimular, ListaDeNombresDeSemenParticulasQueEstimula>> keyValuePair9 in this.m_US_SemenParticulasQueEstimulan)
				{
					if (keyValuePair9.Value != null)
					{
						foreach (KeyValuePair<int, ListaDeNombresDeSemenParticulasQueEstimula> keyValuePair10 in keyValuePair9.Value)
						{
							Object.Destroy(keyValuePair10.Value);
						}
					}
				}
				foreach (KeyValuePair<int, DiccionaryEnum<TipoDeProp, ListaDeNombresDePropsQueEstimula>> keyValuePair11 in this.m_ES_PropsQueEstimulan)
				{
					if (keyValuePair11.Value != null)
					{
						foreach (KeyValuePair<int, ListaDeNombresDePropsQueEstimula> keyValuePair12 in keyValuePair11.Value)
						{
							Object.Destroy(keyValuePair12.Value);
						}
					}
				}
				foreach (KeyValuePair<int, DiccionaryEnum<TipoDeProp, ListaDeNombresDePropsQueEstimula>> keyValuePair13 in this.m_US_PropsQueEstimulan)
				{
					if (keyValuePair13.Value != null)
					{
						foreach (KeyValuePair<int, ListaDeNombresDePropsQueEstimula> keyValuePair14 in keyValuePair13.Value)
						{
							Object.Destroy(keyValuePair14.Value);
						}
					}
				}
			}
			this.m_ES_Cuerpo = null;
			this.m_US_Cuerpo = null;
			this.m_ES_QueEstimulan = null;
			this.m_US_QueEstimulan = null;
			this.m_ES_SemenParticulasQueEstimulan = null;
			this.m_US_SemenParticulasQueEstimulan = null;
			this.m_ES_PropsQueEstimulan = null;
			this.m_US_PropsQueEstimulan = null;
		}

		// Token: 0x040008EA RID: 2282
		[SerializeField]
		private List<ListaDeNombresDeParteDelCuerpo> m_nombresDePartesDelCuerpo;

		// Token: 0x040008EB RID: 2283
		[SerializeField]
		private List<ListaDeNombresDeParteQueEstimula> m_nombresDePartesQueEstimulan;

		// Token: 0x040008EC RID: 2284
		[SerializeField]
		private List<ListaDeNombresDeSemenParticulasQueEstimula> m_nombresDeSemenParticulasQueEstimulan;

		// Token: 0x040008ED RID: 2285
		[SerializeField]
		private List<ListaDeNombresDePropsQueEstimula> m_nombresDePropsQueEstimulan;

		// Token: 0x040008EE RID: 2286
		private DiccionaryEnum<ParteDelCuerpoHumano, ListaDeNombresDeParteDelCuerpo> m_ES_Cuerpo;

		// Token: 0x040008EF RID: 2287
		private DiccionaryEnum<ParteDelCuerpoHumano, ListaDeNombresDeParteDelCuerpo> m_US_Cuerpo;

		// Token: 0x040008F0 RID: 2288
		private DiccionaryEnum<TipoDeEstimulo, DiccionaryEnum<ParteQuePuedeEstimular, ListaDeNombresDeParteQueEstimula>> m_ES_QueEstimulan;

		// Token: 0x040008F1 RID: 2289
		private DiccionaryEnum<TipoDeEstimulo, DiccionaryEnum<ParteQuePuedeEstimular, ListaDeNombresDeParteQueEstimula>> m_US_QueEstimulan;

		// Token: 0x040008F2 RID: 2290
		private DiccionaryEnum<TipoDeEstimulo, DiccionaryEnum<SemenParticulaQuePuedeEstimular, ListaDeNombresDeSemenParticulasQueEstimula>> m_ES_SemenParticulasQueEstimulan;

		// Token: 0x040008F3 RID: 2291
		private DiccionaryEnum<TipoDeEstimulo, DiccionaryEnum<SemenParticulaQuePuedeEstimular, ListaDeNombresDeSemenParticulasQueEstimula>> m_US_SemenParticulasQueEstimulan;

		// Token: 0x040008F4 RID: 2292
		private DiccionaryEnum<TipoDeEstimulo, DiccionaryEnum<TipoDeProp, ListaDeNombresDePropsQueEstimula>> m_ES_PropsQueEstimulan;

		// Token: 0x040008F5 RID: 2293
		private DiccionaryEnum<TipoDeEstimulo, DiccionaryEnum<TipoDeProp, ListaDeNombresDePropsQueEstimula>> m_US_PropsQueEstimulan;
	}
}
