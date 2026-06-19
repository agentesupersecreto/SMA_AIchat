using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.NombresDePartesDelCuerpo;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Objetos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos
{
	// Token: 0x0200032B RID: 811
	[Serializable]
	public sealed class ObtenerDialogosUtil
	{
		// Token: 0x0600146B RID: 5227 RVA: 0x0005FB45 File Offset: 0x0005DD45
		public ObtenerDialogosUtil()
		{
		}

		// Token: 0x0600146C RID: 5228 RVA: 0x0005FB63 File Offset: 0x0005DD63
		public ObtenerDialogosUtil(ICharacter owner)
		{
			this.m_IFemaleCharacterIdleable = owner.GetComponentEnRoot<IFemaleCharacterIdleable>();
		}

		// Token: 0x0600146D RID: 5229 RVA: 0x0005FB8D File Offset: 0x0005DD8D
		public ObtenerDialogosUtil(ICharacter owner, Object contexto)
		{
			this.ReInit(owner, contexto);
		}

		// Token: 0x0600146E RID: 5230 RVA: 0x0005FBB3 File Offset: 0x0005DDB3
		public void ReInit(ICharacter owner, Object contexto)
		{
			this.contexto = contexto;
			this.m_IFemaleCharacterIdleable = ((owner != null) ? owner.GetComponentEnRoot<IFemaleCharacterIdleable>() : null);
		}

		// Token: 0x0600146F RID: 5231 RVA: 0x0005FBD0 File Offset: 0x0005DDD0
		public void AddIgnoracionDeProducor(object productorDelDialogo, TipoDePalabraGenerica palabra)
		{
			if (productorDelDialogo == null)
			{
				throw new ArgumentNullException("productorDelDialogo", "productorDelDialogo null reference.");
			}
			ListaDeTipoDePalabraGenerica valueNotNull = this.m_ignorarPalabraGenericasDeProductor.GetValueNotNull(productorDelDialogo);
			if (!valueNotNull.Contains(palabra))
			{
				valueNotNull.Add(palabra);
			}
		}

		// Token: 0x06001470 RID: 5232 RVA: 0x0005FC10 File Offset: 0x0005DE10
		public bool DialogoGenericoSePuedeActualizar(object productorDelDialogo, DialogoInfoGenerico dialogoInfo, ICalculoDeEstimulo calculo, bool ignorarRedundancia, bool ignorarContextoErrado)
		{
			ObtenerDialogosUtil.Resultado resultado = ObtenerDialogosUtil.Resultado.exito;
			return this.DialogoGenericoSePuedeActualizar(ref resultado, productorDelDialogo, dialogoInfo, calculo, ignorarRedundancia, ignorarContextoErrado);
		}

		// Token: 0x06001471 RID: 5233 RVA: 0x0005FC30 File Offset: 0x0005DE30
		private bool DialogoGenericoSePuedeActualizar(ref ObtenerDialogosUtil.Resultado resultado, object productorDelDialogo, DialogoInfoGenerico dialogoInfo, ICalculoDeEstimulo calculo, bool ignorarRedundancia, bool ignorarContextoErrado)
		{
			if (this.flagClearIgnoreList)
			{
				this.m_ignorarPalabraGenericasDeProductor.Clear();
				this.flagClearIgnoreList = false;
			}
			if (calculo == null)
			{
				return false;
			}
			if (dialogoInfo == null)
			{
				return false;
			}
			bool flag = this.forcedEnAutoInteraccion || (this.m_IFemaleCharacterIdleable != null && this.m_IFemaleCharacterIdleable.enAutoInteraccion);
			if (flag && !(calculo as ICalculoDeInteracionEstimulante).EstimuloInvertidoEsValido())
			{
				return false;
			}
			if (!ignorarRedundancia && this.EsRedundante(calculo, dialogoInfo, flag))
			{
				resultado = ObtenerDialogosUtil.Resultado.redundante;
				return false;
			}
			if (!ignorarContextoErrado && this.EsContextoErrado(calculo, dialogoInfo, flag))
			{
				resultado = ObtenerDialogosUtil.Resultado.contextoErrado;
				return false;
			}
			ListaDeTipoDePalabraGenerica listaDeTipoDePalabraGenerica;
			return (this.ignorarPalabraGenericas.Count <= 0 || !dialogoInfo.ContieneAlguna(this.ignorarPalabraGenericas)) && (this.m_ignorarPalabraGenericasDeProductor.Count <= 0 || productorDelDialogo == null || !this.m_ignorarPalabraGenericasDeProductor.TryGetValue(productorDelDialogo, out listaDeTipoDePalabraGenerica) || listaDeTipoDePalabraGenerica.Count <= 0 || !dialogoInfo.ContieneAlguna(listaDeTipoDePalabraGenerica)) && Singleton<PalabrasDeDialogosGenericos>.IsInScene;
		}

		// Token: 0x06001472 RID: 5234 RVA: 0x0005FD1C File Offset: 0x0005DF1C
		public ValueTuple<ObtenerDialogosUtil.Resultado, TipoDePalabraGenerica> ActualizarDialogoGenerico(object productor, DialogoInfoGenerico dialogoInfo, ICalculoDeEstimulo calculo, DialogoInfo anteriorUsado, int? intensidad, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta)
		{
			bool flag = this.forcedEnAutoInteraccion || (this.m_IFemaleCharacterIdleable != null && this.m_IFemaleCharacterIdleable.enAutoInteraccion);
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			bool flag2 = !calculo.emocion.reaccion.EsPositiva();
			PalabrasDeDialogosGenericos.CompatibilidadConPartes compatibilidad = PalabrasDeDialogosGenericos.GetCompatibilidad(dialogoInfo);
			PalabrasDeDialogosGenericos.DialogosDeLocal dialogosDeLocal = Singleton<PalabrasDeDialogosGenericos>.instance.DialogosDeCurrentLocal();
			Localizacion id = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id;
			int num = 0;
			ICalculoDeInteracionEstimulanteDeParteEstimulante calculoDeInteracionEstimulanteDeParteEstimulante = calculo as ICalculoDeInteracionEstimulanteDeParteEstimulante;
			ICalculoDeEstimuloTactil calculoDeEstimuloTactil = calculo as ICalculoDeEstimuloTactil;
			if (calculoDeEstimuloTactil != null)
			{
				if (!flag || !calculoDeEstimuloTactil.estimulo.tieneCopiaInvertida || calculoDeEstimuloTactil.estimuloInvertido.tipoDeEstimuloTactilInvertido == TipoDeEstimuloTactilInvertido.None)
				{
					TipoDeEstimuloTactil tipoDeEstimuloTactil = calculoDeEstimuloTactil.estimulo.tipoDeEstimuloTactil;
					if ((tipoDeEstimuloTactil == TipoDeEstimuloTactil.derramamientoDentro || tipoDeEstimuloTactil == TipoDeEstimuloTactil.derramamientoSobre) && calculoDeEstimuloTactil.estimulo is EstimuloTactilDeSemen)
					{
						num = (int)((EstimuloTactilDeSemen)calculoDeEstimuloTactil.estimulo).tipoDeEstimuloTactilDerramante;
					}
					else
					{
						num = (int)tipoDeEstimuloTactil;
					}
				}
				else
				{
					num = (int)calculoDeEstimuloTactil.estimuloInvertido.tipoDeEstimuloTactilInvertido;
				}
			}
			ICalculoDeEstimuloCoitalHole calculoDeEstimuloCoitalHole = calculo as ICalculoDeEstimuloCoitalHole;
			if (calculoDeEstimuloCoitalHole != null)
			{
				num = 0;
				if (!flag || !calculoDeEstimuloCoitalHole.estimulo.tieneCopiaInvertida)
				{
					if (calculoDeEstimuloCoitalHole.estimulo.tipoDeEstimuloCoital == TipoDeEstimuloCoital.conDedo)
					{
						num = (int)calculoDeEstimuloCoitalHole.estimulo.tipoDeEstimuloCoital;
					}
					else if (calculoDeEstimuloCoitalHole.estimulo.tipoDeEstimuloCoital == TipoDeEstimuloCoital.otros)
					{
						TipoDeEstimuloCoitalConPenes tipoDeEstimuloCoitalConPenes = calculoDeEstimuloCoitalHole.estimulo.tipoDeEstimuloCoitalConPenes;
						if (tipoDeEstimuloCoitalConPenes == TipoDeEstimuloCoitalConPenes.explorar || tipoDeEstimuloCoitalConPenes == TipoDeEstimuloCoitalConPenes.aplicar)
						{
							num = (int)calculoDeEstimuloCoitalHole.estimulo.tipoDeEstimuloCoitalConPenes;
						}
						else
						{
							num = 0;
						}
					}
				}
			}
			ICalculoDeEstimuloVisual calculoDeEstimuloVisual = calculo as ICalculoDeEstimuloVisual;
			if (calculoDeEstimuloVisual != null)
			{
				num = (int)calculoDeEstimuloVisual.estimulo.tipoDeEstimuloVisual;
			}
			InteracionEstimulanteBasica interacionEstimulanteBasica = ((calculoDeInteracionEstimulante != null) ? calculoDeInteracionEstimulante.estimuloBasico : null);
			InteracionEstimulanteBasica interacionEstimulanteBasica2 = ((flag && interacionEstimulanteBasica != null && interacionEstimulanteBasica.tieneCopiaInvertida) ? ((calculoDeInteracionEstimulante != null) ? calculoDeInteracionEstimulante.estimuloInvertidoBasico : null) : interacionEstimulanteBasica);
			DialogoInfoGenerico.SeccionGenerica seccionGenerica = null;
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo = null;
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo2 = null;
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo3 = null;
			DialogoInfoGenerico.SeccionGenerica seccionGenerica2 = null;
			dialogoInfoParteDelCuerpo2 = (dialogoInfo.Contiene(TipoDePalabraGenerica.cosaOther) ? this.ObtenerDialogosDeParteEstimulante(calculo, flag) : null);
			dialogoInfoParteDelCuerpo3 = (dialogoInfo.Contiene(TipoDePalabraGenerica.cosaPropia) ? this.ObtenerDialogosDeParteEstumulada(calculo, flag) : null);
			for (int i = 0; i < dialogoInfo.secciones.Count; i++)
			{
				DialogoInfoGenerico.SeccionGenerica seccionGenerica3 = dialogoInfo.secciones[i] as DialogoInfoGenerico.SeccionGenerica;
				if (seccionGenerica3 != null)
				{
					if (seccionGenerica3.EsParaLocal(id) && seccionGenerica3.EsParanNegativoOPositivo(flag2))
					{
						DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> diccionaryEnum = null;
						ListaDeDialogos listaDeDialogos = null;
						DialogoInfo dialogoInfo2 = null;
						DialogoInfo dialogoInfo3 = null;
						try
						{
							switch (seccionGenerica3.tipoGenerico)
							{
							case TipoDePalabraGenerica.None:
								goto IL_0FC3;
							case TipoDePalabraGenerica.prefijo:
							case TipoDePalabraGenerica.sufijo:
								if (!dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras.ContainsKey(seccionGenerica3.tipoGenerico))
								{
									goto IL_0D7C;
								}
								diccionaryEnum = dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras[seccionGenerica3.tipoGenerico];
								if (diccionaryEnum != null)
								{
									diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
								}
								goto IL_0D7C;
							case TipoDePalabraGenerica.peticionPersonal:
								if (flag2)
								{
									diccionaryEnum = dialogosDeLocal.peticionesPersonalesNegativasDeTipoDeRespuesta;
									if (diccionaryEnum != null)
									{
										diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
									}
									goto IL_0D7C;
								}
								else
								{
									diccionaryEnum = dialogosDeLocal.peticionesPersonalesPositivasDeTipoDeRespuesta;
									if (diccionaryEnum != null)
									{
										diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
									}
									goto IL_0D7C;
								}
								break;
							case TipoDePalabraGenerica.peticionPresente:
								if (flag2)
								{
									diccionaryEnum = dialogosDeLocal.peticionesPresentesNegativasDeTipoDeRespuesta;
									if (diccionaryEnum != null)
									{
										diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
									}
									goto IL_0D7C;
								}
								else
								{
									diccionaryEnum = dialogosDeLocal.peticionesPresentesPositivasDeTipoDeRespuesta;
									if (diccionaryEnum != null)
									{
										diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
									}
									goto IL_0D7C;
								}
								break;
							case TipoDePalabraGenerica.accion3Persona:
								goto IL_07D7;
							case TipoDePalabraGenerica.accion3PersonaPlural:
								break;
							case TipoDePalabraGenerica.accionConjugada:
								if (calculoDeInteracionEstimulante != null)
								{
									ValueTuple<int, int, int, int> valueTuple = new ValueTuple<int, int, int, int>((int)interacionEstimulanteBasica2.tipoDeEstimulo, (int)interacionEstimulanteBasica2.tipo, num, (int)compatibilidad);
									if (dialogosDeLocal.accionesConjugadasDeTipoDeRespuesta.ContainsKey(valueTuple))
									{
										diccionaryEnum = dialogosDeLocal.accionesConjugadasDeTipoDeRespuesta[valueTuple];
										if (diccionaryEnum != null)
										{
											diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
										}
									}
								}
								seccionGenerica2 = seccionGenerica3;
								goto IL_0D7C;
							case TipoDePalabraGenerica.accionPlural:
								if (calculoDeInteracionEstimulante != null)
								{
									ValueTuple<int, int, int, int> valueTuple2 = new ValueTuple<int, int, int, int>((int)interacionEstimulanteBasica2.tipoDeEstimulo, (int)interacionEstimulanteBasica2.tipo, num, (int)compatibilidad);
									if (dialogosDeLocal.accionesPluralesDeTipoDeRespuesta.ContainsKey(valueTuple2))
									{
										diccionaryEnum = dialogosDeLocal.accionesPluralesDeTipoDeRespuesta[valueTuple2];
										if (diccionaryEnum != null)
										{
											diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
										}
									}
								}
								seccionGenerica2 = seccionGenerica3;
								goto IL_0D7C;
							case TipoDePalabraGenerica.accionPresente:
								if (calculoDeInteracionEstimulante != null)
								{
									ValueTuple<int, int, int, int> valueTuple3 = new ValueTuple<int, int, int, int>((int)interacionEstimulanteBasica2.tipoDeEstimulo, (int)interacionEstimulanteBasica2.tipo, num, (int)compatibilidad);
									if (dialogosDeLocal.accionesPresentesDeTipoDeRespuesta.ContainsKey(valueTuple3))
									{
										diccionaryEnum = dialogosDeLocal.accionesPresentesDeTipoDeRespuesta[valueTuple3];
										if (diccionaryEnum != null)
										{
											diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
										}
									}
								}
								seccionGenerica2 = seccionGenerica3;
								goto IL_0D7C;
							case TipoDePalabraGenerica.emocionPersonal:
								goto IL_098B;
							case TipoDePalabraGenerica.emocionPresente:
								if (!dialogosDeLocal.emocionesPresentesDeTipoDeRespuesta.ContainsKey(calculo.emocion.reaccion))
								{
									goto IL_0D7C;
								}
								diccionaryEnum = dialogosDeLocal.emocionesPresentesDeTipoDeRespuesta[calculo.emocion.reaccion];
								if (diccionaryEnum != null)
								{
									diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
								}
								goto IL_0D7C;
							case TipoDePalabraGenerica.mi:
							case TipoDePalabraGenerica.miPlural:
							{
								TipoDePalabraGenerica tipoGenerico = seccionGenerica3.tipoGenerico;
								ListaDeDialogos listaDeDialogos2 = null;
								seccionGenerica = seccionGenerica3;
								if (dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras.ContainsKey(tipoGenerico))
								{
									diccionaryEnum = dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras[tipoGenerico];
									if (diccionaryEnum != null)
									{
										diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos2);
									}
								}
								if (listaDeDialogos2 != null)
								{
									dialogoInfo2 = listaDeDialogos2.Obtener(null);
								}
								if (dialogoInfo3 != null)
								{
									DialogoInfo dialogoInfo4 = dialogoInfo3;
									dialogoInfo3 = dialogoInfo2;
									dialogoInfo2 = dialogoInfo4;
								}
								goto IL_0D7C;
							}
							case TipoDePalabraGenerica.eso:
							case TipoDePalabraGenerica.esoEsta:
							case TipoDePalabraGenerica.esoEs:
							case TipoDePalabraGenerica.estas:
							case TipoDePalabraGenerica.con:
							case TipoDePalabraGenerica.hacerConjugado:
							case TipoDePalabraGenerica.haciendo:
							case TipoDePalabraGenerica.deEstar:
							case TipoDePalabraGenerica.queEstes:
							case TipoDePalabraGenerica.esoCosa:
							case TipoDePalabraGenerica.cuando:
							case TipoDePalabraGenerica.ponerPerfecto:
							case TipoDePalabraGenerica.tomarPerfecto:
							case TipoDePalabraGenerica.voltearPerfecto:
							case TipoDePalabraGenerica.lejos:
							case TipoDePalabraGenerica.desde:
							case TipoDePalabraGenerica.de:
							case TipoDePalabraGenerica.off:
							case TipoDePalabraGenerica.why:
							case TipoDePalabraGenerica.stop:
							case TipoDePalabraGenerica.hacerPasado:
							case TipoDePalabraGenerica.again:
							case TipoDePalabraGenerica.hacerPlural:
							case TipoDePalabraGenerica.just:
							case TipoDePalabraGenerica.muy:
							case TipoDePalabraGenerica.el:
							case TipoDePalabraGenerica.la:
							case TipoDePalabraGenerica.los:
							case TipoDePalabraGenerica.las:
							case TipoDePalabraGenerica.muymuy:
							case TipoDePalabraGenerica.exclamacionPlacer:
							case TipoDePalabraGenerica.enDentro:
							case TipoDePalabraGenerica.enSobre:
							case TipoDePalabraGenerica.enUbicacion:
							case TipoDePalabraGenerica.esoCosaPlural:
							case TipoDePalabraGenerica.esta:
							case TipoDePalabraGenerica.esto:
							case TipoDePalabraGenerica.a:
								if (!dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras.ContainsKey(seccionGenerica3.tipoGenerico))
								{
									goto IL_0D7C;
								}
								diccionaryEnum = dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras[seccionGenerica3.tipoGenerico];
								if (diccionaryEnum != null)
								{
									diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
								}
								goto IL_0D7C;
							case TipoDePalabraGenerica.me:
								if (seccionGenerica2 != null && interacionEstimulanteBasica != null && interacionEstimulanteBasica.tipoDeEstimulo.TipoDeAccionProvenienteDeTipoDeEstimuloEsAutoEjecutadaPorDefecto())
								{
									if (interacionEstimulanteBasica.tipoDeEstimulo.TipoDeAccionProvenienteDeTipoDeEstimuloEsAutoEjecutadaPorDefectoVar2())
									{
										if (!dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras.ContainsKey(TipoDePalabraGenerica.porYoMismo))
										{
											goto IL_0D7C;
										}
										diccionaryEnum = dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras[TipoDePalabraGenerica.porYoMismo];
										if (diccionaryEnum != null)
										{
											diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
										}
										goto IL_0D7C;
									}
									else
									{
										if (!dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras.ContainsKey(TipoDePalabraGenerica.yoMismo))
										{
											goto IL_0D7C;
										}
										diccionaryEnum = dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras[TipoDePalabraGenerica.yoMismo];
										if (diccionaryEnum != null)
										{
											diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
										}
										goto IL_0D7C;
									}
								}
								else
								{
									if (!dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras.ContainsKey(TipoDePalabraGenerica.me))
									{
										goto IL_0D7C;
									}
									diccionaryEnum = dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras[TipoDePalabraGenerica.me];
									if (diccionaryEnum != null)
									{
										diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
									}
									goto IL_0D7C;
								}
								break;
							case TipoDePalabraGenerica.tuyo:
							case TipoDePalabraGenerica.tuyoPlural:
							{
								TipoDePalabraGenerica tipoGenerico2 = seccionGenerica3.tipoGenerico;
								ListaDeDialogos listaDeDialogos3 = null;
								seccionGenerica = seccionGenerica3;
								if (dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras.ContainsKey(tipoGenerico2))
								{
									diccionaryEnum = dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras[tipoGenerico2];
									if (diccionaryEnum != null)
									{
										diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos3);
									}
								}
								if (listaDeDialogos3 != null)
								{
									dialogoInfo2 = listaDeDialogos3.Obtener(null);
								}
								goto IL_0D7C;
							}
							case TipoDePalabraGenerica.cosaPropia:
							{
								DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo4 = dialogoInfoParteDelCuerpo3 ?? this.ObtenerDialogosDeParteEstumulada(calculo, flag);
								dialogoInfo2 = dialogoInfoParteDelCuerpo4;
								this.ActualizarPronombre(seccionGenerica, dialogoInfoParteDelCuerpo4, dialogosDeLocal, tipoDeRespuesta);
								dialogoInfoParteDelCuerpo = dialogoInfoParteDelCuerpo4;
								goto IL_0D7C;
							}
							case TipoDePalabraGenerica.cosaOther:
							{
								DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo5 = dialogoInfoParteDelCuerpo2 ?? this.ObtenerDialogosDeParteEstimulante(calculo, flag);
								dialogoInfo2 = dialogoInfoParteDelCuerpo5;
								this.ActualizarPronombre(seccionGenerica, dialogoInfoParteDelCuerpo5, dialogosDeLocal, tipoDeRespuesta);
								dialogoInfoParteDelCuerpo = dialogoInfoParteDelCuerpo5;
								goto IL_0D7C;
							}
							case TipoDePalabraGenerica.sentimientoPerfecto:
								if (!dialogosDeLocal.sentimientoPerfectoDeTipoDeRespuesta.ContainsKey(calculo.emocion.reaccion))
								{
									goto IL_0D7C;
								}
								diccionaryEnum = dialogosDeLocal.sentimientoPerfectoDeTipoDeRespuesta[calculo.emocion.reaccion];
								if (diccionaryEnum != null)
								{
									diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
								}
								goto IL_0D7C;
							case TipoDePalabraGenerica.tu:
							case TipoDePalabraGenerica.yo:
							case TipoDePalabraGenerica.yoEstoy:
							case TipoDePalabraGenerica.yoMismo:
							case TipoDePalabraGenerica.porYoMismo:
								seccionGenerica = seccionGenerica3;
								if (!dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras.ContainsKey(seccionGenerica3.tipoGenerico))
								{
									goto IL_0D7C;
								}
								diccionaryEnum = dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras[seccionGenerica3.tipoGenerico];
								if (diccionaryEnum != null)
								{
									diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
								}
								goto IL_0D7C;
							case TipoDePalabraGenerica.peticionSerConjugado:
								if (!dialogosDeLocal.peticionesSerConjugadoDeTipoDeRespuesta.ContainsKey(calculo.emocion.reaccion))
								{
									goto IL_0D7C;
								}
								diccionaryEnum = dialogosDeLocal.peticionesSerConjugadoDeTipoDeRespuesta[calculo.emocion.reaccion];
								if (diccionaryEnum != null)
								{
									diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
								}
								goto IL_0D7C;
							case TipoDePalabraGenerica.intensidadAdverbio:
								if (intensidad == null || !dialogosDeLocal.intensidadAdverbio.ContainsKey(intensidad.Value))
								{
									goto IL_0D7C;
								}
								diccionaryEnum = dialogosDeLocal.intensidadAdverbio[intensidad.Value];
								if (diccionaryEnum != null)
								{
									diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
								}
								goto IL_0D7C;
							case TipoDePalabraGenerica.intensidadAdjetivo:
								if (intensidad == null || !dialogosDeLocal.intensidadAdjetivo.ContainsKey(intensidad.Value))
								{
									goto IL_0D7C;
								}
								diccionaryEnum = dialogosDeLocal.intensidadAdjetivo[intensidad.Value];
								if (diccionaryEnum != null)
								{
									diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
								}
								goto IL_0D7C;
							case TipoDePalabraGenerica.accionPasado:
								if (calculoDeInteracionEstimulante != null)
								{
									ValueTuple<int, int, int, int> valueTuple4 = new ValueTuple<int, int, int, int>((int)interacionEstimulanteBasica2.tipoDeEstimulo, (int)interacionEstimulanteBasica2.tipo, num, (int)compatibilidad);
									if (dialogosDeLocal.accionesPasadoDeTipoDeRespuesta.ContainsKey(valueTuple4))
									{
										diccionaryEnum = dialogosDeLocal.accionesPasadoDeTipoDeRespuesta[valueTuple4];
										if (diccionaryEnum != null)
										{
											diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
										}
									}
								}
								seccionGenerica2 = seccionGenerica3;
								goto IL_0D7C;
							case TipoDePalabraGenerica.enAccionAuto:
							{
								TipoDePalabraGenerica tipoDePalabraGenerica = this.ObtenerEnAccionAuto(calculoDeInteracionEstimulanteDeParteEstimulante);
								if (tipoDePalabraGenerica <= TipoDePalabraGenerica.None || !dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras.ContainsKey(tipoDePalabraGenerica))
								{
									goto IL_0D7C;
								}
								diccionaryEnum = dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras[tipoDePalabraGenerica];
								if (diccionaryEnum != null)
								{
									diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
								}
								goto IL_0D7C;
							}
							case TipoDePalabraGenerica.enCosaPropiaAuto:
							{
								TipoDePalabraGenerica tipoDePalabraGenerica2 = this.ObtenerEnCosaPropiaAuto(calculoDeInteracionEstimulanteDeParteEstimulante);
								if (tipoDePalabraGenerica2 <= TipoDePalabraGenerica.None || !dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras.ContainsKey(tipoDePalabraGenerica2))
								{
									goto IL_0D7C;
								}
								diccionaryEnum = dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras[tipoDePalabraGenerica2];
								if (diccionaryEnum != null)
								{
									diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
								}
								goto IL_0D7C;
							}
							case TipoDePalabraGenerica.empty:
								goto IL_0D60;
							case TipoDePalabraGenerica.accion:
							{
								if (calculoDeInteracionEstimulante == null)
								{
									goto IL_0D7C;
								}
								ValueTuple<int, int, int, int> valueTuple5 = new ValueTuple<int, int, int, int>((int)interacionEstimulanteBasica2.tipoDeEstimulo, (int)interacionEstimulanteBasica2.tipo, num, (int)compatibilidad);
								if (!dialogosDeLocal.accionesDeTipoDeRespuesta.ContainsKey(valueTuple5))
								{
									goto IL_0D7C;
								}
								diccionaryEnum = dialogosDeLocal.accionesDeTipoDeRespuesta[valueTuple5];
								if (diccionaryEnum != null)
								{
									diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
								}
								goto IL_0D7C;
							}
							case TipoDePalabraGenerica.emocionTerceraPersona:
								goto IL_0AD9;
							case TipoDePalabraGenerica.emocionPersonalPlural:
								goto IL_0A07;
							case TipoDePalabraGenerica.emocionTerceraPersonaPlural:
								goto IL_0B55;
							default:
								goto IL_0D60;
							}
							IL_071A:
							if (dialogoInfoParteDelCuerpo == null || dialogoInfoParteDelCuerpo.plural)
							{
								if (calculoDeInteracionEstimulante != null)
								{
									ValueTuple<int, int, int, int> valueTuple6 = new ValueTuple<int, int, int, int>((int)interacionEstimulanteBasica2.tipoDeEstimulo, (int)interacionEstimulanteBasica2.tipo, num, (int)compatibilidad);
									if (dialogosDeLocal.acciones3PersonaPluralDeTipoDeRespuesta.ContainsKey(valueTuple6))
									{
										diccionaryEnum = dialogosDeLocal.acciones3PersonaPluralDeTipoDeRespuesta[valueTuple6];
										if (diccionaryEnum != null)
										{
											diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
										}
									}
								}
								seccionGenerica2 = seccionGenerica3;
								goto IL_0D7C;
							}
							IL_07D7:
							if (dialogoInfoParteDelCuerpo == null || dialogoInfoParteDelCuerpo.singular)
							{
								if (calculoDeInteracionEstimulante != null)
								{
									ValueTuple<int, int, int, int> valueTuple7 = new ValueTuple<int, int, int, int>((int)interacionEstimulanteBasica2.tipoDeEstimulo, (int)interacionEstimulanteBasica2.tipo, num, (int)compatibilidad);
									if (dialogosDeLocal.acciones3PersonaDeTipoDeRespuesta.ContainsKey(valueTuple7))
									{
										diccionaryEnum = dialogosDeLocal.acciones3PersonaDeTipoDeRespuesta[valueTuple7];
										if (diccionaryEnum != null)
										{
											diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
										}
									}
								}
								seccionGenerica2 = seccionGenerica3;
								goto IL_0D7C;
							}
							goto IL_071A;
							IL_098B:
							if (dialogoInfoParteDelCuerpo2 != null && dialogoInfoParteDelCuerpo3 != null)
							{
								if (!dialogoInfoParteDelCuerpo2.plural)
								{
									goto IL_0A07;
								}
							}
							else if (dialogoInfoParteDelCuerpo2 != null)
							{
								if (!dialogoInfoParteDelCuerpo2.plural)
								{
									goto IL_0A07;
								}
							}
							else if (dialogoInfoParteDelCuerpo3 != null && !dialogoInfoParteDelCuerpo3.plural)
							{
								goto IL_0A07;
							}
							if (!dialogosDeLocal.emocionesPersonalesDeTipoDeRespuesta.ContainsKey(calculo.emocion.reaccion))
							{
								goto IL_0D7C;
							}
							diccionaryEnum = dialogosDeLocal.emocionesPersonalesDeTipoDeRespuesta[calculo.emocion.reaccion];
							if (diccionaryEnum != null)
							{
								diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
							}
							goto IL_0D7C;
							IL_0A07:
							if (dialogoInfoParteDelCuerpo2 != null && dialogoInfoParteDelCuerpo3 != null)
							{
								if (!dialogoInfoParteDelCuerpo2.singular)
								{
									goto IL_098B;
								}
							}
							else if (dialogoInfoParteDelCuerpo2 != null)
							{
								if (!dialogoInfoParteDelCuerpo2.singular)
								{
									goto IL_098B;
								}
							}
							else if (dialogoInfoParteDelCuerpo3 != null && !dialogoInfoParteDelCuerpo3.singular)
							{
								goto IL_098B;
							}
							if (!dialogosDeLocal.emocionesPersonalesPluralesDeTipoDeRespuesta.ContainsKey(calculo.emocion.reaccion))
							{
								goto IL_0D7C;
							}
							diccionaryEnum = dialogosDeLocal.emocionesPersonalesPluralesDeTipoDeRespuesta[calculo.emocion.reaccion];
							if (diccionaryEnum != null)
							{
								diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
							}
							goto IL_0D7C;
							IL_0AD9:
							if (dialogoInfoParteDelCuerpo2 != null && dialogoInfoParteDelCuerpo3 != null)
							{
								if (!dialogoInfoParteDelCuerpo2.plural)
								{
									goto IL_0B55;
								}
							}
							else if (dialogoInfoParteDelCuerpo2 != null)
							{
								if (!dialogoInfoParteDelCuerpo2.plural)
								{
									goto IL_0B55;
								}
							}
							else if (dialogoInfoParteDelCuerpo3 != null && !dialogoInfoParteDelCuerpo3.plural)
							{
								goto IL_0B55;
							}
							if (!dialogosDeLocal.emocionesTerceraPersonaDeTipoDeRespuesta.ContainsKey(calculo.emocion.reaccion))
							{
								goto IL_0D7C;
							}
							diccionaryEnum = dialogosDeLocal.emocionesTerceraPersonaDeTipoDeRespuesta[calculo.emocion.reaccion];
							if (diccionaryEnum != null)
							{
								diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
							}
							goto IL_0D7C;
							IL_0B55:
							if (dialogoInfoParteDelCuerpo2 != null && dialogoInfoParteDelCuerpo3 != null)
							{
								if (!dialogoInfoParteDelCuerpo2.singular)
								{
									goto IL_0AD9;
								}
							}
							else if (dialogoInfoParteDelCuerpo2 != null)
							{
								if (!dialogoInfoParteDelCuerpo2.singular)
								{
									goto IL_0AD9;
								}
							}
							else if (dialogoInfoParteDelCuerpo3 != null && !dialogoInfoParteDelCuerpo3.singular)
							{
								goto IL_0AD9;
							}
							if (!dialogosDeLocal.emocionesTerceraPersonaPluralesDeTipoDeRespuesta.ContainsKey(calculo.emocion.reaccion))
							{
								goto IL_0D7C;
							}
							diccionaryEnum = dialogosDeLocal.emocionesTerceraPersonaPluralesDeTipoDeRespuesta[calculo.emocion.reaccion];
							if (diccionaryEnum != null)
							{
								diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
							}
							goto IL_0D7C;
							IL_0D60:
							throw new ArgumentOutOfRangeException(seccionGenerica3.tipoGenerico.ToString());
							IL_0D7C:;
						}
						catch (KeyNotFoundException ex)
						{
							Debug.LogWarning(string.Concat(new string[]
							{
								"error ahead: lo mas probalble es que tipo de palabra: ",
								seccionGenerica3.tipoGenerico.ToString(),
								", o tipo de respuesta: ",
								tipoDeRespuesta.ToString(),
								", o tipo de estimulo: ",
								(calculoDeInteracionEstimulante != null) ? interacionEstimulanteBasica2.tipoDeEstimulo.ToString() : "null",
								" no este en dicconarios."
							}), this.contexto);
							Debug.LogException(ex, this.contexto);
							return new ValueTuple<ObtenerDialogosUtil.Resultado, TipoDePalabraGenerica>(ObtenerDialogosUtil.Resultado.error, seccionGenerica3.tipoGenerico);
						}
						catch (ArgumentNullException ex2)
						{
							Debug.LogWarning("error ahead: referencia es nula:" + ex2.ParamName, this.contexto);
							Debug.LogException(ex2, this.contexto);
							return new ValueTuple<ObtenerDialogosUtil.Resultado, TipoDePalabraGenerica>(ObtenerDialogosUtil.Resultado.error, seccionGenerica3.tipoGenerico);
						}
						catch (Exception ex3)
						{
							Debug.LogWarning("error ahead: " + ex3.Message, this.contexto);
							Debug.LogException(ex3, this.contexto);
							return new ValueTuple<ObtenerDialogosUtil.Resultado, TipoDePalabraGenerica>(ObtenerDialogosUtil.Resultado.error, seccionGenerica3.tipoGenerico);
						}
						if (listaDeDialogos != null)
						{
							dialogoInfo2 = listaDeDialogos.Obtener(null);
						}
						if (dialogoInfo2 != null && dialogoInfo3 != null)
						{
							seccionGenerica3.ActualizarMany(dialogoInfo2, dialogoInfo3);
							goto IL_0FC3;
						}
						if (dialogoInfo2 != null)
						{
							seccionGenerica3.Actualizar(dialogoInfo2);
							goto IL_0FC3;
						}
						if (dialogoInfo3 != null)
						{
							seccionGenerica3.Actualizar(dialogoInfo3);
							goto IL_0FC3;
						}
						if (Application.isEditor)
						{
							string[] array = new string[8];
							array[0] = "Dialogo generico Fallo: ";
							array[1] = string.Join(" ", dialogoInfo.secciones.Select((DialogoInfo.Seccion d) => d.original));
							array[2] = " SECTION: ";
							array[3] = seccionGenerica3.tipoGenerico.ToString();
							array[4] = " TIPODERESPUESTA: ";
							array[5] = tipoDeRespuesta.ToString();
							array[6] = " PRODUCTOR es: ";
							int num2 = 7;
							Object @object = productor as Object;
							array[num2] = ((@object != null) ? @object.name : null);
							Debug.Log(string.Concat(array));
						}
						if (diccionaryEnum == null)
						{
							return new ValueTuple<ObtenerDialogosUtil.Resultado, TipoDePalabraGenerica>(ObtenerDialogosUtil.Resultado.noExisteDialogo, seccionGenerica3.tipoGenerico);
						}
						return new ValueTuple<ObtenerDialogosUtil.Resultado, TipoDePalabraGenerica>(ObtenerDialogosUtil.Resultado.noExisteDialogoTipoDeRespuesta, seccionGenerica3.tipoGenerico);
					}
					seccionGenerica3.Actualizar(null);
				}
				IL_0FC3:;
			}
			return new ValueTuple<ObtenerDialogosUtil.Resultado, TipoDePalabraGenerica>(ObtenerDialogosUtil.Resultado.exito, TipoDePalabraGenerica.None);
		}

		// Token: 0x06001473 RID: 5235 RVA: 0x00060D5C File Offset: 0x0005EF5C
		public bool TryActualizarDialogoGenerico(out ObtenerDialogosUtil.Resultado resultado, out TipoDePalabraGenerica resultado2, object productorDelDialogo, DialogoInfoGenerico dialogoInfo, ICalculoDeEstimulo calculo, DialogoInfo anteriorUsado, int? intensidad, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, bool ignorarRedundancia = false, bool ignorarContextoErrado = false)
		{
			resultado = ObtenerDialogosUtil.Resultado.error;
			resultado2 = TipoDePalabraGenerica.None;
			if (!this.DialogoGenericoSePuedeActualizar(ref resultado, productorDelDialogo, dialogoInfo, calculo, ignorarRedundancia, ignorarContextoErrado))
			{
				return false;
			}
			ValueTuple<ObtenerDialogosUtil.Resultado, TipoDePalabraGenerica> valueTuple = this.ActualizarDialogoGenerico(productorDelDialogo, dialogoInfo, calculo, anteriorUsado, intensidad, tipoDeRespuesta);
			resultado = valueTuple.Item1;
			resultado2 = valueTuple.Item2;
			return valueTuple.Item1 == ObtenerDialogosUtil.Resultado.exito;
		}

		// Token: 0x06001474 RID: 5236 RVA: 0x00060DAE File Offset: 0x0005EFAE
		private TipoDePalabraGenerica ObtenerEnCosaPropiaAuto(ICalculoDeInteracionEstimulanteDeParteEstimulante calculo)
		{
			return this.ObtenerEnCosaPropiaAuto(calculo.estimuloBasico.tipoDeEstimulo);
		}

		// Token: 0x06001475 RID: 5237 RVA: 0x00060DC4 File Offset: 0x0005EFC4
		private TipoDePalabraGenerica ObtenerEnCosaPropiaAuto(TipoDeEstimulo tipoDeEstimulo)
		{
			switch (tipoDeEstimulo)
			{
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.visual:
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
			case TipoDeEstimulo.manipulandoBone:
				return TipoDePalabraGenerica.enSobre;
			case TipoDeEstimulo.coital:
				return TipoDePalabraGenerica.enDentro;
			}
			throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
		}

		// Token: 0x06001476 RID: 5238 RVA: 0x00060E38 File Offset: 0x0005F038
		private TipoDePalabraGenerica ObtenerEnAccionAuto(ICalculoDeInteracionEstimulanteDeParteEstimulante calculo)
		{
			TipoDePalabraGenerica tipoDePalabraGenerica = (TipoDePalabraGenerica)(-1);
			if (calculo == null)
			{
				return tipoDePalabraGenerica;
			}
			TipoDeEstimulo tipoDeEstimulo = calculo.estimuloBasico.tipoDeEstimulo;
			if (tipoDeEstimulo != TipoDeEstimulo.None)
			{
				if (tipoDeEstimulo != TipoDeEstimulo.tactil)
				{
					if (tipoDeEstimulo == TipoDeEstimulo.coital)
					{
						tipoDePalabraGenerica = TipoDePalabraGenerica.enDentro;
					}
				}
				else
				{
					switch (calculo.estimuloBasico.ObtenerTipoDeEstimuloTactil(ReactorSegundario.PrioridadContexto(calculo), calculo.estimulanteParte, calculo.tag == "golpe"))
					{
					case TipoDeEstimuloTactil.caricia:
					case TipoDeEstimuloTactil.golpe:
					case TipoDeEstimuloTactil.beso:
					case TipoDeEstimuloTactil.lambida:
					case TipoDeEstimuloTactil.slapping:
					case TipoDeEstimuloTactil.humping:
					case TipoDeEstimuloTactil.dryHump:
						tipoDePalabraGenerica = TipoDePalabraGenerica.enSobre;
						break;
					case TipoDeEstimuloTactil.derramamientoSobre:
					case TipoDeEstimuloTactil.derramamientoDentro:
						tipoDePalabraGenerica = TipoDePalabraGenerica.empty;
						break;
					case TipoDeEstimuloTactil.poking:
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano = ReactorSegundario.PartePrincipalEstimulada(calculo, false);
						if (parteDelCuerpoHumano - ParteDelCuerpoHumano.bocaInterno <= 1 || parteDelCuerpoHumano == ParteDelCuerpoHumano.globosOculares || parteDelCuerpoHumano - ParteDelCuerpoHumano.ano <= 1)
						{
							tipoDePalabraGenerica = TipoDePalabraGenerica.enDentro;
						}
						else
						{
							tipoDePalabraGenerica = TipoDePalabraGenerica.enSobre;
						}
						break;
					}
					}
				}
			}
			return tipoDePalabraGenerica;
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x00060EFC File Offset: 0x0005F0FC
		private TipoDePalabraGenerica ObtenerEnAccionAuto(TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, string tag)
		{
			TipoDePalabraGenerica tipoDePalabraGenerica = (TipoDePalabraGenerica)(-1);
			if (tipoDeEstimulo != TipoDeEstimulo.None)
			{
				if (tipoDeEstimulo != TipoDeEstimulo.tactil)
				{
					if (tipoDeEstimulo == TipoDeEstimulo.coital)
					{
						tipoDePalabraGenerica = TipoDePalabraGenerica.enDentro;
					}
				}
				else
				{
					switch (estimulante.ObtenerTipoDeEstimuloTactil(tag == "golpe", estimulada))
					{
					case TipoDeEstimuloTactil.caricia:
					case TipoDeEstimuloTactil.golpe:
					case TipoDeEstimuloTactil.beso:
					case TipoDeEstimuloTactil.lambida:
					case TipoDeEstimuloTactil.slapping:
					case TipoDeEstimuloTactil.humping:
					case TipoDeEstimuloTactil.dryHump:
						tipoDePalabraGenerica = TipoDePalabraGenerica.enSobre;
						break;
					case TipoDeEstimuloTactil.derramamientoSobre:
					case TipoDeEstimuloTactil.derramamientoDentro:
						tipoDePalabraGenerica = TipoDePalabraGenerica.empty;
						break;
					case TipoDeEstimuloTactil.poking:
						if (estimulada - ParteDelCuerpoHumano.bocaInterno <= 1 || estimulada == ParteDelCuerpoHumano.globosOculares || estimulada - ParteDelCuerpoHumano.ano <= 1)
						{
							tipoDePalabraGenerica = TipoDePalabraGenerica.enDentro;
						}
						else
						{
							tipoDePalabraGenerica = TipoDePalabraGenerica.enSobre;
						}
						break;
					}
				}
			}
			return tipoDePalabraGenerica;
		}

		// Token: 0x06001478 RID: 5240 RVA: 0x00060F8C File Offset: 0x0005F18C
		private bool EsContextoErradoHaciendoloEllaMisma(ICalculoDeEstimulo calculo, DialogoInfoGenerico dialogo)
		{
			if (dialogo.Contiene(TipoDePalabraGenerica.yoMismo) && !(calculo is ICalculoDeEstimuloCoitalHole))
			{
				return true;
			}
			if (dialogo.Contiene(TipoDePalabraGenerica.intensidadAdverbio))
			{
				return true;
			}
			bool flag = dialogo.ContieneEnOrden(TipoDePalabraGenerica.mi, TipoDePalabraGenerica.cosaPropia, TipoDePalabraGenerica.esta, true);
			if (dialogo.Contiene(TipoDePalabraGenerica.intensidadAdjetivo) && !flag)
			{
				return true;
			}
			if (dialogo.ContieneEnOrden(TipoDePalabraGenerica.estas, TipoDePalabraGenerica.tu, TipoDePalabraGenerica.accionPresente, true))
			{
				return true;
			}
			if (dialogo.ContieneEnOrden(TipoDePalabraGenerica.tu, TipoDePalabraGenerica.estas, TipoDePalabraGenerica.accionPresente, true))
			{
				return true;
			}
			if (dialogo.Contiene(TipoDePalabraGenerica.peticionPersonal) || dialogo.Contiene(TipoDePalabraGenerica.peticionPresente) || dialogo.Contiene(TipoDePalabraGenerica.peticionSerConjugado))
			{
				return true;
			}
			if (this.EsContextoErradoTuCosaEmocionMiCosa(calculo, dialogo))
			{
				return true;
			}
			if (dialogo.ContieneEnOrden(TipoDePalabraGenerica.hacerPasado, TipoDePalabraGenerica.tu, TipoDePalabraGenerica.just, true))
			{
				return true;
			}
			if (dialogo.ContieneEnOrden(TipoDePalabraGenerica.tomarPerfecto, TipoDePalabraGenerica.tuyo, TipoDePalabraGenerica.cosaOther, true) | dialogo.ContieneEnOrden(TipoDePalabraGenerica.voltearPerfecto, TipoDePalabraGenerica.tuyo, TipoDePalabraGenerica.cosaOther, true))
			{
				return true;
			}
			if (dialogo.ContieneEnOrden(TipoDePalabraGenerica.tu, TipoDePalabraGenerica.estas, TipoDePalabraGenerica.emocionPresente, true))
			{
				return true;
			}
			bool flag2 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.accionPlural, TipoDePalabraGenerica.con, TipoDePalabraGenerica.tuyo, true);
			bool flag3 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.accionPlural, TipoDePalabraGenerica.mi, TipoDePalabraGenerica.cosaPropia, true);
			bool flag4 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.tu, TipoDePalabraGenerica.hacerPlural, TipoDePalabraGenerica.eso, true);
			bool flag5 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.cosaOther, TipoDePalabraGenerica.accion3Persona, TipoDePalabraGenerica.me, true);
			bool flag6 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.cosaOther, TipoDePalabraGenerica.accion3Persona, TipoDePalabraGenerica.mi, true);
			bool flag7 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.cosaOther, TipoDePalabraGenerica.accionPresente, TipoDePalabraGenerica.me, true);
			bool flag8 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.cosaOther, TipoDePalabraGenerica.accionPresente, TipoDePalabraGenerica.mi, true);
			bool flag9 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.cuando, TipoDePalabraGenerica.tu, TipoDePalabraGenerica.accionPlural, true);
			if (flag2 || flag3 || flag4 || flag5 || flag6 || flag7 || flag8 || flag9)
			{
				return true;
			}
			if (dialogo.ContieneEnOrden(TipoDePalabraGenerica.why, TipoDePalabraGenerica.estas, TipoDePalabraGenerica.tu, true))
			{
				return true;
			}
			if (dialogo.ContieneEnOrden(TipoDePalabraGenerica.why, TipoDePalabraGenerica.hacerPasado))
			{
				return true;
			}
			if (dialogo.ContieneEnOrden(TipoDePalabraGenerica.why, TipoDePalabraGenerica.stop))
			{
				return true;
			}
			if (dialogo.ContieneEnOrden(TipoDePalabraGenerica.yo, TipoDePalabraGenerica.sentimientoPerfecto, TipoDePalabraGenerica.eso, true))
			{
				return true;
			}
			bool flag10 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.esoEsta, TipoDePalabraGenerica.emocionPresente, TipoDePalabraGenerica.me, true);
			bool flag11 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.esoEsta, TipoDePalabraGenerica.emocionPresente, TipoDePalabraGenerica.mi, true);
			if (flag10 || flag11)
			{
				return true;
			}
			bool flag12 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.eso, TipoDePalabraGenerica.emocionPersonalPlural, TipoDePalabraGenerica.mi, true);
			bool flag13 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.eso, TipoDePalabraGenerica.emocionPersonalPlural, TipoDePalabraGenerica.mi, true);
			bool flag14 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.eso, TipoDePalabraGenerica.emocionPersonalPlural, TipoDePalabraGenerica.me, true);
			bool flag15 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.eso, TipoDePalabraGenerica.emocionPersonalPlural, TipoDePalabraGenerica.me, true);
			if (flag12 || flag13 || flag14 || flag15)
			{
				return true;
			}
			if (calculo is ICalculoDeEstimuloTactil)
			{
				ICalculoDeEstimuloTactil calculoDeEstimuloTactil = (ICalculoDeEstimuloTactil)calculo;
				if (dialogo.ContieneEnOrdenLast(TipoDePalabraGenerica.yo, TipoDePalabraGenerica.accion, TipoDePalabraGenerica.tu) && (calculoDeEstimuloTactil.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.derramamientoSobre || calculoDeEstimuloTactil.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.derramamientoDentro))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001479 RID: 5241 RVA: 0x000611D8 File Offset: 0x0005F3D8
		private bool EsContextoErrado(ICalculoDeEstimulo calculo, DialogoInfoGenerico dialogo, bool estaHaciendoloEllaMisma)
		{
			if (calculo.EsOrgasmo())
			{
				return false;
			}
			if (estaHaciendoloEllaMisma)
			{
				return this.EsContextoErradoHaciendoloEllaMisma(calculo, dialogo);
			}
			bool flag = dialogo.ContieneEnOrdenLast(TipoDePalabraGenerica.yo, TipoDePalabraGenerica.accion, TipoDePalabraGenerica.tu);
			bool flag2 = dialogo.ContieneEnOrdenLast(TipoDePalabraGenerica.yo, TipoDePalabraGenerica.accion, TipoDePalabraGenerica.tuyo);
			bool flag3 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.yoEstoy, TipoDePalabraGenerica.accionPresente, TipoDePalabraGenerica.tu, true);
			bool flag4 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.yoEstoy, TipoDePalabraGenerica.accionPresente, TipoDePalabraGenerica.tuyo, true);
			bool flag5 = dialogo.ContieneEnOrdenLast(TipoDePalabraGenerica.mi, TipoDePalabraGenerica.accionPresente, TipoDePalabraGenerica.tu);
			bool flag6 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.mi, TipoDePalabraGenerica.accionPresente, TipoDePalabraGenerica.tuyo, true);
			bool flag7 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.yoEstoy, TipoDePalabraGenerica.haciendo, TipoDePalabraGenerica.esto, true);
			if (flag || flag2 || flag3 || flag4 || flag5 || flag6 || flag7)
			{
				return true;
			}
			if (this.EsContextoErradoCoito(calculo, dialogo))
			{
				return true;
			}
			if (calculo is ICalculoDeEstimuloPorCambioDePose)
			{
				return this.EsContextoErradoPose(calculo as ICalculoDeEstimuloPorCambioDePose, dialogo, estaHaciendoloEllaMisma);
			}
			if (calculo is ICalculoDeEstimuloPorDesvestir)
			{
				return this.EsContextoErradoDesvestidura(calculo as ICalculoDeEstimuloPorDesvestir, dialogo, estaHaciendoloEllaMisma);
			}
			if (calculo is ICalculoDeEstimuloPorMovimientoDeBones)
			{
				return this.EsContextoErradoMovimientoDeBone(calculo as ICalculoDeEstimuloPorMovimientoDeBones, dialogo, estaHaciendoloEllaMisma);
			}
			bool flag8 = dialogo.ContieneEnOrden(TipoDePalabraGenerica.yoEstoy, TipoDePalabraGenerica.accionPresente, TipoDePalabraGenerica.mi, true);
			bool flag9 = dialogo.Contiene(TipoDePalabraGenerica.yoMismo);
			if ((flag8 || flag9) && !estaHaciendoloEllaMisma)
			{
				return true;
			}
			bool flag10 = calculo.emocion.reaccion == ReaccionHumana.dolor;
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			InteracionEstimulanteBasica interacionEstimulanteBasica = ((calculoDeInteracionEstimulante != null) ? calculoDeInteracionEstimulante.estimuloBasico : null);
			if (dialogo.Contiene(TipoDePalabraGenerica.intensidadAdjetivo) && interacionEstimulanteBasica != null)
			{
				if (!interacionEstimulanteBasica.tipoDeEstimulo.EsIntercambioFisico())
				{
					return true;
				}
				if (dialogo.ContieneEnOrden(TipoDePalabraGenerica.mi, TipoDePalabraGenerica.cosaPropia, TipoDePalabraGenerica.esta, true) && !interacionEstimulanteBasica.ContineParte(ParteDelCuerpoHumano.vag) && !interacionEstimulanteBasica.ContineParte(ParteDelCuerpoHumano.ano) && !interacionEstimulanteBasica.ContineParte(ParteDelCuerpoHumano.bocaInterno))
				{
					return true;
				}
			}
			bool flag11 = dialogo.Contiene(TipoDePalabraGenerica.intensidadAdverbio);
			if (flag11 && interacionEstimulanteBasica != null && !interacionEstimulanteBasica.tipoDeEstimulo.EsIntercambioFisico())
			{
				return true;
			}
			dialogo.Contiene(TipoDePalabraGenerica.peticionSerConjugado);
			return (flag11 && interacionEstimulanteBasica != null && flag10 && !interacionEstimulanteBasica.tipoDeEstimulo.EsIntercambioFisico()) || this.EsContextoErradoTuCosaEmocionMiCosa(calculo, dialogo);
		}

		// Token: 0x0600147A RID: 5242 RVA: 0x000613AC File Offset: 0x0005F5AC
		private bool EsContextoErradoTuCosaEmocionMiCosa(ICalculoDeEstimulo calculo, DialogoInfoGenerico dialogo)
		{
			bool flag = dialogo.Contiene(TipoDePalabraGenerica.cosaPropia);
			bool flag2 = dialogo.Contiene(TipoDePalabraGenerica.emocionPersonal) || dialogo.Contiene(TipoDePalabraGenerica.emocionPresente) || dialogo.Contiene(TipoDePalabraGenerica.emocionTerceraPersona);
			flag2 |= dialogo.Contiene(TipoDePalabraGenerica.emocionPersonalPlural) || dialogo.Contiene(TipoDePalabraGenerica.emocionTerceraPersonaPlural);
			bool flag3 = calculo.emocion.reaccion == ReaccionHumana.rabia;
			bool flag4 = calculo.emocion.reaccion == ReaccionHumana.miedo;
			bool flag5 = calculo.emocion.reaccion == ReaccionHumana.placer;
			bool flag6 = calculo.emocion.reaccion == ReaccionHumana.decepcion;
			return (flag3 || flag5 || flag6 || flag4) && flag2 && flag;
		}

		// Token: 0x0600147B RID: 5243 RVA: 0x00061450 File Offset: 0x0005F650
		private bool EsContextoErradoCoito(ICalculoDeEstimulo calculo, DialogoInfoGenerico dialogo)
		{
			bool flag = dialogo.Contiene(TipoDePalabraGenerica.yoMismo);
			if (!(calculo is ICalculoDeEstimuloCoitalHole))
			{
				return flag;
			}
			if (this.forcedEnAutoInteraccion || (this.m_IFemaleCharacterIdleable != null && this.m_IFemaleCharacterIdleable.enAutoInteraccionCoital))
			{
				int num = -1;
				bool flag2 = dialogo.ContieneRefIndex(TipoDePalabraGenerica.tu, ref num);
				int num2 = -1;
				bool flag3 = dialogo.ContieneRefIndex(TipoDePalabraGenerica.estas, ref num2);
				int num3 = -1;
				bool flag4 = dialogo.ContieneRefIndex(TipoDePalabraGenerica.hacerPasado, ref num3);
				int num4 = -1;
				bool flag5 = dialogo.ContieneRefIndex(TipoDePalabraGenerica.hacerPlural, ref num4);
				int num5 = -1;
				bool flag6 = dialogo.ContieneRefIndex(TipoDePalabraGenerica.accionPlural, ref num5);
				bool flag7 = flag2 && flag3 && num2 == num + 2;
				bool flag8 = flag2 && flag3 && num == num2 + 2;
				bool flag9 = flag2 && flag4 && num == num3 + 2;
				bool flag10 = flag2 && flag5 && num4 == num + 2;
				bool flag11 = flag2 && flag6 && (num5 == num + 2 || num5 == num + 4);
				bool flag12 = dialogo.Contiene(TipoDePalabraGenerica.peticionPersonal) || dialogo.Contiene(TipoDePalabraGenerica.peticionPresente) || dialogo.Contiene(TipoDePalabraGenerica.peticionSerConjugado);
				bool flag13 = dialogo.Contiene(TipoDePalabraGenerica.tomarPerfecto) || dialogo.Contiene(TipoDePalabraGenerica.voltearPerfecto);
				return flag7 || flag8 || flag9 || flag10 || flag11 || flag12 || flag13;
			}
			int num6;
			int num7;
			bool flag14 = dialogo.Contiene(TipoDePalabraGenerica.yoEstoy, out num6) && dialogo.Contiene(TipoDePalabraGenerica.accionPresente, out num7) && num6 < num7;
			return flag || flag14;
		}

		// Token: 0x0600147C RID: 5244 RVA: 0x000615B0 File Offset: 0x0005F7B0
		private bool EsContextoErradoPose(ICalculoDeEstimuloPorCambioDePose calculo, DialogoInfoGenerico dialogo, bool estaHaciendoloEllaMisma)
		{
			if (calculo == null)
			{
				return false;
			}
			bool flag = dialogo.Contiene(TipoDePalabraGenerica.cosaOther);
			bool flag2 = calculo.estimulanteParte == ParteQuePuedeEstimular.manos;
			return flag && !flag2;
		}

		// Token: 0x0600147D RID: 5245 RVA: 0x000615DC File Offset: 0x0005F7DC
		private bool EsContextoErradoDesvestidura(ICalculoDeEstimuloPorDesvestir calculo, DialogoInfoGenerico dialogo, bool estaHaciendoloEllaMisma)
		{
			return calculo != null && dialogo.Contiene(TipoDePalabraGenerica.cosaOther);
		}

		// Token: 0x0600147E RID: 5246 RVA: 0x000615DC File Offset: 0x0005F7DC
		private bool EsContextoErradoMovimientoDeBone(ICalculoDeEstimuloPorMovimientoDeBones calculo, DialogoInfoGenerico dialogo, bool estaHaciendoloEllaMisma)
		{
			return calculo != null && dialogo.Contiene(TipoDePalabraGenerica.cosaOther);
		}

		// Token: 0x0600147F RID: 5247 RVA: 0x000615F0 File Offset: 0x0005F7F0
		private bool EsRedundante(ICalculoDeEstimulo calculo, DialogoInfoGenerico dialogo, bool estaHaciendoloEllaMisma)
		{
			if (calculo.EsOrgasmo())
			{
				return false;
			}
			if (estaHaciendoloEllaMisma)
			{
				return false;
			}
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			if (calculoDeInteracionEstimulante == null)
			{
				return false;
			}
			bool flag = false;
			ICalculoDeEstimuloDeParteEstimulante calculoDeEstimuloDeParteEstimulante = calculo as ICalculoDeEstimuloDeParteEstimulante;
			if (calculoDeEstimuloDeParteEstimulante != null)
			{
				ParteQuePuedeEstimular estimulanteParte = calculoDeEstimuloDeParteEstimulante.estimulanteParte;
				ParteDelCuerpoHumano parteDelCuerpoHumano = ReactorSegundario.PartePrincipalEstimulada(calculoDeInteracionEstimulante, estaHaciendoloEllaMisma);
				if (estimulanteParte <= ParteQuePuedeEstimular.lengua)
				{
					if (estimulanteParte <= ParteQuePuedeEstimular.propSexToy)
					{
						switch (estimulanteParte)
						{
						case ParteQuePuedeEstimular.None:
						case ParteQuePuedeEstimular.noEspecificada:
						case ParteQuePuedeEstimular.piernas:
							goto IL_00E4;
						case (ParteQuePuedeEstimular)3:
						case (ParteQuePuedeEstimular)5:
						case (ParteQuePuedeEstimular)6:
						case (ParteQuePuedeEstimular)7:
							break;
						case ParteQuePuedeEstimular.manos:
							flag = parteDelCuerpoHumano == ParteDelCuerpoHumano.manos;
							goto IL_00E4;
						case ParteQuePuedeEstimular.pene:
							flag = parteDelCuerpoHumano == ParteDelCuerpoHumano.pene;
							goto IL_00E4;
						default:
							if (estimulanteParte == ParteQuePuedeEstimular.propSexToy)
							{
								goto IL_00E4;
							}
							break;
						}
					}
					else
					{
						if (estimulanteParte == ParteQuePuedeEstimular.torzo)
						{
							goto IL_00E4;
						}
						if (estimulanteParte == ParteQuePuedeEstimular.lengua)
						{
							flag = parteDelCuerpoHumano == ParteDelCuerpoHumano.lengua;
							goto IL_00E4;
						}
					}
				}
				else if (estimulanteParte <= ParteQuePuedeEstimular.ojos)
				{
					if (estimulanteParte == ParteQuePuedeEstimular.boca)
					{
						flag = parteDelCuerpoHumano == ParteDelCuerpoHumano.bocaInterno;
						goto IL_00E4;
					}
					if (estimulanteParte == ParteQuePuedeEstimular.ojos)
					{
						goto IL_00E4;
					}
				}
				else if (estimulanteParte == ParteQuePuedeEstimular.semen || estimulanteParte == ParteQuePuedeEstimular.dedo)
				{
					goto IL_00E4;
				}
				throw new ArgumentOutOfRangeException(estimulanteParte.ToString());
			}
			IL_00E4:
			return flag || this.EsRedundanteVisual(calculo as ICalculoDeEstimuloVisual, dialogo, estaHaciendoloEllaMisma) || this.EsRedundanteTactil(calculo as ICalculoDeEstimuloTactil, dialogo, estaHaciendoloEllaMisma) || this.EsRedundanteCoital(calculo as ICalculoDeEstimuloCoitalHole, dialogo, estaHaciendoloEllaMisma);
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x00061714 File Offset: 0x0005F914
		private bool EsRedundanteTactil(ICalculoDeEstimuloTactil calculo, DialogoInfoGenerico dialogo, bool estaHaciendoloEllaMisma)
		{
			if (calculo == null)
			{
				return false;
			}
			if (estaHaciendoloEllaMisma)
			{
				return false;
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = ReactorSegundario.PartePrincipalEstimulada(calculo, estaHaciendoloEllaMisma);
			bool flag = dialogo.Contiene(TipoDePalabraGenerica.accionPresente);
			bool flag2 = flag || ObtenerDialogosUtil.EsAccion(dialogo);
			bool flag3 = dialogo.Contiene(TipoDePalabraGenerica.cosaOther);
			bool flag4 = dialogo.Contiene(TipoDePalabraGenerica.cosaPropia);
			bool flag5 = dialogo.Contiene(TipoDePalabraGenerica.peticionSerConjugado);
			int num = (flag ? dialogo.LastIndexOf(TipoDePalabraGenerica.accionPresente) : (-1));
			bool flag6 = (flag3 ? dialogo.LastIndexOf(TipoDePalabraGenerica.cosaOther) : (-1)) < num;
			bool flag7 = flag3 && flag4 && parteDelCuerpoHumano == ParteDelCuerpoHumano.manos && calculo.estimulanteParte == ParteQuePuedeEstimular.manos;
			bool flag8 = flag2 && flag3 && !flag4 && !flag6 && calculo.estimulanteParte == ParteQuePuedeEstimular.manos && calculo.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.caricia;
			bool flag9 = flag2 && flag3 && calculo.estimulanteParte == ParteQuePuedeEstimular.semen && (calculo.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.derramamientoDentro || calculo.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.derramamientoSobre);
			bool flag10 = flag2 && flag3 && calculo.estimulanteParte == ParteQuePuedeEstimular.boca && calculo.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.beso;
			bool flag11 = flag2 && flag3 && calculo.estimulanteParte == ParteQuePuedeEstimular.lengua && calculo.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.lambida;
			bool flag12 = flag2 && flag3 && calculo.estimulanteParte == ParteQuePuedeEstimular.manos && calculo.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.slapping;
			bool flag13 = flag2 && flag3 && calculo.estimulanteParte == ParteQuePuedeEstimular.dedo && calculo.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.poking;
			bool flag14 = flag2 && flag3 && calculo.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.humping;
			bool flag15 = flag2 && flag3 && calculo.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.dryHump;
			bool flag16 = flag2 && flag4 && calculo.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.humping && parteDelCuerpoHumano != ParteDelCuerpoHumano.vientreBajo && parteDelCuerpoHumano != ParteDelCuerpoHumano.nalgas;
			bool flag17 = flag2 && flag5 && (calculo.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.poking || calculo.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.slapping || calculo.estimulo.tipoDeEstimuloTactil == TipoDeEstimuloTactil.golpe);
			return flag7 || flag8 || flag9 || flag10 || flag11 || flag12 || flag13 || flag17 || flag14 || flag15 || flag16;
		}

		// Token: 0x06001481 RID: 5249 RVA: 0x0006193C File Offset: 0x0005FB3C
		private bool EsRedundanteCoital(ICalculoDeEstimuloCoitalHole calculo, DialogoInfoGenerico dialogo, bool estaHaciendoloEllaMisma)
		{
			if (calculo == null)
			{
				return false;
			}
			if (estaHaciendoloEllaMisma)
			{
				return false;
			}
			bool flag = (this.forcedEnAutoInteraccion || (this.m_IFemaleCharacterIdleable != null && this.m_IFemaleCharacterIdleable.enAutoInteraccionCoital)) && dialogo.Contiene(TipoDePalabraGenerica.yoMismo);
			int num = -1;
			int num2 = -1;
			bool flag2 = ObtenerDialogosUtil.EsAccion(dialogo, ref num2);
			bool flag3 = dialogo.Contiene(TipoDePalabraGenerica.cosaOther);
			bool flag4 = dialogo.Contiene(TipoDePalabraGenerica.cosaPropia);
			bool flag5 = calculo.estimulanteParte == ParteQuePuedeEstimular.pene && calculo.estimulo.tipoDeEstimuloCoital == TipoDeEstimuloCoital.conPene;
			if (flag)
			{
				flag5 = false;
			}
			bool flag6 = calculo.estimulanteParte == ParteQuePuedeEstimular.dedo && calculo.estimulo.tipoDeEstimuloCoital == TipoDeEstimuloCoital.conDedo;
			int num3 = (flag3 ? dialogo.LastIndexOf(TipoDePalabraGenerica.cosaOther) : (-1));
			bool flag7 = num3 < num || num3 < num2;
			bool flag8 = flag2 && flag3 && !flag4 && !flag7 && flag5;
			bool flag9 = flag2 && flag3 && flag6;
			return flag8 || flag9;
		}

		// Token: 0x06001482 RID: 5250 RVA: 0x00061A1C File Offset: 0x0005FC1C
		private bool EsRedundanteVisual(ICalculoDeEstimuloVisual calculo, DialogoInfoGenerico dialogo, bool estaHaciendoloEllaMisma)
		{
			if (calculo == null)
			{
				return false;
			}
			if (estaHaciendoloEllaMisma)
			{
				return false;
			}
			bool flag = dialogo.Contiene(TipoDePalabraGenerica.peticionPersonal) || dialogo.Contiene(TipoDePalabraGenerica.peticionPresente);
			bool flag2 = dialogo.Contiene(TipoDePalabraGenerica.accionPresente) || ObtenerDialogosUtil.EsAccion(dialogo);
			bool flag3 = dialogo.Contiene(TipoDePalabraGenerica.cosaOther);
			bool flag4 = ((dialogo.Contiene(TipoDePalabraGenerica.emocionPersonal) || dialogo.Contiene(TipoDePalabraGenerica.emocionPresente) || dialogo.Contiene(TipoDePalabraGenerica.emocionTerceraPersona)) | (dialogo.Contiene(TipoDePalabraGenerica.emocionPersonalPlural) || dialogo.Contiene(TipoDePalabraGenerica.emocionTerceraPersonaPlural))) && flag3 && (calculo.estimulanteParte == ParteQuePuedeEstimular.ojos || calculo.estimulanteParte == ParteQuePuedeEstimular.propSexToy);
			return ((flag || flag2) && flag3 && calculo.estimulanteParte == ParteQuePuedeEstimular.ojos) || flag4;
		}

		// Token: 0x06001483 RID: 5251 RVA: 0x00061AD4 File Offset: 0x0005FCD4
		private static bool EsAccion(DialogoInfoGenerico dialogo)
		{
			return dialogo.Contiene(TipoDePalabraGenerica.accionPresente) || dialogo.Contiene(TipoDePalabraGenerica.accion) || dialogo.Contiene(TipoDePalabraGenerica.accionConjugada) || dialogo.Contiene(TipoDePalabraGenerica.accionPlural) || dialogo.Contiene(TipoDePalabraGenerica.accion3Persona) || dialogo.Contiene(TipoDePalabraGenerica.accion3PersonaPlural) || dialogo.Contiene(TipoDePalabraGenerica.accionPasado);
		}

		// Token: 0x06001484 RID: 5252 RVA: 0x00061B24 File Offset: 0x0005FD24
		private static bool EsAccion(DialogoInfoGenerico dialogo, ref int accionIndex)
		{
			return dialogo.ContieneRefIndex(TipoDePalabraGenerica.accionPresente, ref accionIndex) || dialogo.ContieneRefIndex(TipoDePalabraGenerica.accion, ref accionIndex) || dialogo.ContieneRefIndex(TipoDePalabraGenerica.accionConjugada, ref accionIndex) || dialogo.ContieneRefIndex(TipoDePalabraGenerica.accionPlural, ref accionIndex) || dialogo.ContieneRefIndex(TipoDePalabraGenerica.accion3Persona, ref accionIndex) || dialogo.ContieneRefIndex(TipoDePalabraGenerica.accion3PersonaPlural, ref accionIndex) || dialogo.ContieneRefIndex(TipoDePalabraGenerica.accionPasado, ref accionIndex);
		}

		// Token: 0x06001485 RID: 5253 RVA: 0x00061B7C File Offset: 0x0005FD7C
		private DialogoInfoParteDelCuerpo ObtenerDialogosDeParteEstumulada(ICalculoDeEstimulo calculo, bool estaHaciendoloEllaMisma)
		{
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			if (calculoDeInteracionEstimulante == null)
			{
				return null;
			}
			if (!Singleton<NombresLocalizadosDePartes>.IsInScene)
			{
				throw new InvalidOperationException();
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = ReactorSegundario.PartePrincipalEstimulada(calculoDeInteracionEstimulante, false);
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo = Singleton<NombresLocalizadosDePartes>.instance.ObtenerDeCurrentLocalization(parteDelCuerpoHumano);
			if (dialogoInfoParteDelCuerpo == null)
			{
				throw new ArgumentNullException("dialogo", "dialogo de " + parteDelCuerpoHumano.ToString() + " es null");
			}
			if (!dialogoInfoParteDelCuerpo.plural && !dialogoInfoParteDelCuerpo.singular)
			{
				throw new InvalidOperationException();
			}
			return dialogoInfoParteDelCuerpo;
		}

		// Token: 0x06001486 RID: 5254 RVA: 0x00061BF8 File Offset: 0x0005FDF8
		public static string ObtenerPosesivoPrimeraPersona(bool esPlural, DireccionDeEstimulo direccion)
		{
			TipoDePalabraGenerica tipoDePalabraGenerica;
			if (esPlural)
			{
				tipoDePalabraGenerica = TipoDePalabraGenerica.miPlural;
			}
			else
			{
				tipoDePalabraGenerica = TipoDePalabraGenerica.mi;
			}
			PalabrasDeDialogosGenericos.DialogosDeLocal dialogosDeLocal = Singleton<PalabrasDeDialogosGenericos>.instance.DialogosDeCurrentLocal();
			ListaDeDialogos listaDeDialogos = null;
			if (dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras.ContainsKey(tipoDePalabraGenerica))
			{
				DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> diccionaryEnum = dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras[tipoDePalabraGenerica];
				if (diccionaryEnum != null)
				{
					diccionaryEnum.TryGetValue(Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable, out listaDeDialogos);
				}
			}
			if (listaDeDialogos == null || listaDeDialogos.Count == 0)
			{
				return "Not FOund";
			}
			return listaDeDialogos.Obtener(null).NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, direccion.ObtenerDireccionParaDialogos());
		}

		// Token: 0x06001487 RID: 5255 RVA: 0x00061C80 File Offset: 0x0005FE80
		public static string ObtenerPosesivoSegundaPersona(bool esPlural, DireccionDeEstimulo direccion)
		{
			TipoDePalabraGenerica tipoDePalabraGenerica;
			if (esPlural)
			{
				tipoDePalabraGenerica = TipoDePalabraGenerica.tuyoPlural;
			}
			else
			{
				tipoDePalabraGenerica = TipoDePalabraGenerica.tuyo;
			}
			PalabrasDeDialogosGenericos.DialogosDeLocal dialogosDeLocal = Singleton<PalabrasDeDialogosGenericos>.instance.DialogosDeCurrentLocal();
			ListaDeDialogos listaDeDialogos = null;
			if (dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras.ContainsKey(tipoDePalabraGenerica))
			{
				DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> diccionaryEnum = dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras[tipoDePalabraGenerica];
				if (diccionaryEnum != null)
				{
					diccionaryEnum.TryGetValue(Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable, out listaDeDialogos);
				}
			}
			if (listaDeDialogos == null || listaDeDialogos.Count == 0)
			{
				return "Not FOund";
			}
			return listaDeDialogos.Obtener(null).NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, direccion.ObtenerDireccionParaDialogos());
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x00061D08 File Offset: 0x0005FF08
		public static string ObtenerEsoCosa(bool esPlural, DireccionDeEstimulo direccion)
		{
			TipoDePalabraGenerica tipoDePalabraGenerica;
			if (esPlural)
			{
				tipoDePalabraGenerica = TipoDePalabraGenerica.esoCosaPlural;
			}
			else
			{
				tipoDePalabraGenerica = TipoDePalabraGenerica.esoCosa;
			}
			return ObtenerDialogosUtil.ObtenerPalabraGenericaLocalizada(tipoDePalabraGenerica, direccion);
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x00061D28 File Offset: 0x0005FF28
		public static string ObtenerPalabraGenericaLocalizada(TipoDePalabraGenerica palabra, DireccionDeEstimulo direccion)
		{
			PalabrasDeDialogosGenericos.DialogosDeLocal dialogosDeLocal = Singleton<PalabrasDeDialogosGenericos>.instance.DialogosDeCurrentLocal();
			ListaDeDialogos listaDeDialogos = null;
			if (dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras.ContainsKey(palabra))
			{
				DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> diccionaryEnum = dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras[palabra];
				if (diccionaryEnum != null)
				{
					diccionaryEnum.TryGetValue(Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable, out listaDeDialogos);
				}
			}
			if (listaDeDialogos == null || listaDeDialogos.Count == 0)
			{
				return "Not FOund";
			}
			return listaDeDialogos.Obtener(null).NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, direccion.ObtenerDireccionParaDialogos());
		}

		// Token: 0x0600148A RID: 5258 RVA: 0x00061DA4 File Offset: 0x0005FFA4
		public static string ObtenerArticuloDeterminado(bool esPlural, bool esFemenino, DireccionDeEstimulo direccion)
		{
			PalabrasDeDialogosGenericos.DialogosDeLocal dialogosDeLocal = Singleton<PalabrasDeDialogosGenericos>.instance.DialogosDeCurrentLocal();
			TipoDePalabraGenerica tipoDePalabraGenerica;
			if (esPlural)
			{
				if (esFemenino)
				{
					tipoDePalabraGenerica = TipoDePalabraGenerica.las;
				}
				else
				{
					tipoDePalabraGenerica = TipoDePalabraGenerica.los;
				}
			}
			else if (esFemenino)
			{
				tipoDePalabraGenerica = TipoDePalabraGenerica.la;
			}
			else
			{
				tipoDePalabraGenerica = TipoDePalabraGenerica.el;
			}
			ListaDeDialogos listaDeDialogos = null;
			if (dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras.ContainsKey(tipoDePalabraGenerica))
			{
				DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> diccionaryEnum = dialogosDeLocal.tipoDeRespuestaDeTipoDePalabras[tipoDePalabraGenerica];
				if (diccionaryEnum != null)
				{
					diccionaryEnum.TryGetValue(Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable, out listaDeDialogos);
				}
			}
			if (listaDeDialogos == null || listaDeDialogos.Count == 0)
			{
				return "Not FOund";
			}
			return listaDeDialogos.Obtener(null).NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, direccion.ObtenerDireccionParaDialogos());
		}

		// Token: 0x0600148B RID: 5259 RVA: 0x00061E3C File Offset: 0x0006003C
		private void ActualizarPronombre(DialogoInfoGenerico.SeccionGenerica lastPronombre, DialogoInfoParteDelCuerpo dialogoDeNombreDeParte, PalabrasDeDialogosGenericos.DialogosDeLocal dialogosGenericos, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta)
		{
			if (lastPronombre == null || dialogoDeNombreDeParte == null)
			{
				return;
			}
			if (dialogosGenericos == null)
			{
				throw new ArgumentNullException("dialogosGenericos", "dialogosGenericos null reference.");
			}
			ListaDeDialogos listaDeDialogos = null;
			TipoDePalabraGenerica tipoGenerico = lastPronombre.tipoGenerico;
			if (tipoGenerico != TipoDePalabraGenerica.mi)
			{
				switch (tipoGenerico)
				{
				case TipoDePalabraGenerica.tuyo:
					if (dialogoDeNombreDeParte.plural && dialogosGenericos.tipoDeRespuestaDeTipoDePalabras.ContainsKey(TipoDePalabraGenerica.tuyoPlural))
					{
						DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> diccionaryEnum = dialogosGenericos.tipoDeRespuestaDeTipoDePalabras[TipoDePalabraGenerica.tuyoPlural];
						if (diccionaryEnum != null)
						{
							diccionaryEnum.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
						}
					}
					break;
				case TipoDePalabraGenerica.tuyoPlural:
					if (dialogoDeNombreDeParte.singular && dialogosGenericos.tipoDeRespuestaDeTipoDePalabras.ContainsKey(TipoDePalabraGenerica.tuyo))
					{
						DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> diccionaryEnum2 = dialogosGenericos.tipoDeRespuestaDeTipoDePalabras[TipoDePalabraGenerica.tuyo];
						if (diccionaryEnum2 != null)
						{
							diccionaryEnum2.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
						}
					}
					break;
				case TipoDePalabraGenerica.miPlural:
					if (dialogoDeNombreDeParte.singular && dialogosGenericos.tipoDeRespuestaDeTipoDePalabras.ContainsKey(TipoDePalabraGenerica.mi))
					{
						DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> diccionaryEnum3 = dialogosGenericos.tipoDeRespuestaDeTipoDePalabras[TipoDePalabraGenerica.mi];
						if (diccionaryEnum3 != null)
						{
							diccionaryEnum3.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
						}
					}
					break;
				}
			}
			else if (dialogoDeNombreDeParte.plural && dialogosGenericos.tipoDeRespuestaDeTipoDePalabras.ContainsKey(TipoDePalabraGenerica.miPlural))
			{
				DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> diccionaryEnum4 = dialogosGenericos.tipoDeRespuestaDeTipoDePalabras[TipoDePalabraGenerica.miPlural];
				if (diccionaryEnum4 != null)
				{
					diccionaryEnum4.TryGetValue(tipoDeRespuesta, out listaDeDialogos);
				}
			}
			if (listaDeDialogos != null)
			{
				DialogoInfo dialogoInfo = listaDeDialogos.Obtener(null);
				if (dialogoInfo != null)
				{
					lastPronombre.Actualizar(dialogoInfo);
				}
			}
		}

		// Token: 0x0600148C RID: 5260 RVA: 0x00061F94 File Offset: 0x00060194
		private DialogoInfoParteDelCuerpo ObtenerDialogosDeParteEstimulante(ICalculoDeEstimulo calculo, bool estaHaciendoloEllaMisma)
		{
			if (calculo == null)
			{
				throw new ArgumentNullException("calculo", "calculo null reference.");
			}
			ICalculoDeInteracionEstimulanteDeParteEstimulante calculoDeInteracionEstimulanteDeParteEstimulante = calculo as ICalculoDeInteracionEstimulanteDeParteEstimulante;
			if (calculoDeInteracionEstimulanteDeParteEstimulante == null)
			{
				return null;
			}
			ParteQuePuedeEstimular estimulanteParte = calculoDeInteracionEstimulanteDeParteEstimulante.estimulanteParte;
			InteracionEstimulanteBasica estimuloBasico = calculoDeInteracionEstimulanteDeParteEstimulante.estimuloBasico;
			if (estimulanteParte == ParteQuePuedeEstimular.noEspecificada || estimulanteParte == ParteQuePuedeEstimular.None)
			{
				return null;
			}
			if (!Singleton<NombresLocalizadosDePartes>.IsInScene)
			{
				throw new InvalidOperationException();
			}
			NombresLocalizadosDePartes instance = Singleton<NombresLocalizadosDePartes>.instance;
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo;
			if (estimulanteParte == ParteQuePuedeEstimular.semen && estimuloBasico is EstimuloTactilDeSemen)
			{
				SemenParticulaQuePuedeEstimular estimulanteSemenParticle = ((EstimuloTactilDeSemen)estimuloBasico).tipoDeSemen.GetEstimulanteSemenParticle();
				dialogoInfoParteDelCuerpo = instance.ObtenerDeCurrentLocalization(estimulanteSemenParticle, estimuloBasico.tipoDeEstimulo);
			}
			else if (estimulanteParte == ParteQuePuedeEstimular.propSexToy)
			{
				Component getRealEstimulante = estimuloBasico.GetRealEstimulante;
				IDefinedProp definedProp;
				if (getRealEstimulante == null)
				{
					definedProp = null;
				}
				else
				{
					IPertenecibleDeCharacter componentInParent = getRealEstimulante.GetComponentInParent<IPertenecibleDeCharacter>();
					if (componentInParent == null)
					{
						definedProp = null;
					}
					else
					{
						ICharacter inmediateOwner = componentInParent.inmediateOwner;
						definedProp = ((inmediateOwner != null) ? inmediateOwner.GetComponent<IDefinedProp>() : null);
					}
				}
				IDefinedProp definedProp2 = definedProp;
				if (definedProp2 != null)
				{
					dialogoInfoParteDelCuerpo = instance.ObtenerDeCurrentLocalization(definedProp2.tipo, estimuloBasico.tipoDeEstimulo);
				}
				else
				{
					dialogoInfoParteDelCuerpo = instance.ObtenerDeCurrentLocalization(estimulanteParte, estimuloBasico.tipoDeEstimulo);
				}
			}
			else
			{
				dialogoInfoParteDelCuerpo = instance.ObtenerDeCurrentLocalization(estimulanteParte, estimuloBasico.tipoDeEstimulo);
			}
			if (dialogoInfoParteDelCuerpo == null)
			{
				Debug.LogError("error ahead, el dialogo fue nulo, no deberia pasar");
				return null;
			}
			if (!dialogoInfoParteDelCuerpo.plural && !dialogoInfoParteDelCuerpo.singular)
			{
				Debug.LogError("dialogo " + dialogoInfoParteDelCuerpo.seccionado + " no es singular ni plural, debe ser alguno de  los dos");
			}
			return dialogoInfoParteDelCuerpo;
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x000620CC File Offset: 0x000602CC
		public static string ObternerStringDeKey(ValueTuple<int, int, int, int> key, TipoDeStringAccion tipoDeStringAccion, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, bool obtenerPrimero, DireccionDeEstimulo direccion)
		{
			TipoDePalabraGenerica tipoDePalabraGenerica = tipoDeStringAccion.TipoDePalabraDeTipoAccion();
			PalabrasDeDialogosGenericos.DialogosDeLocal dialogosDeLocal = Singleton<PalabrasDeDialogosGenericos>.instance.DialogosDeCurrentLocal();
			Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> dictionary;
			switch (tipoDePalabraGenerica)
			{
			case TipoDePalabraGenerica.accion3Persona:
				dictionary = dialogosDeLocal.acciones3PersonaDeTipoDeRespuesta;
				break;
			case TipoDePalabraGenerica.accion3PersonaPlural:
				dictionary = dialogosDeLocal.acciones3PersonaPluralDeTipoDeRespuesta;
				break;
			case TipoDePalabraGenerica.accionConjugada:
				dictionary = dialogosDeLocal.accionesConjugadasDeTipoDeRespuesta;
				break;
			case TipoDePalabraGenerica.accionPlural:
				dictionary = dialogosDeLocal.accionesPluralesDeTipoDeRespuesta;
				break;
			case TipoDePalabraGenerica.accionPresente:
				dictionary = dialogosDeLocal.accionesPresentesDeTipoDeRespuesta;
				break;
			default:
				if (tipoDePalabraGenerica != TipoDePalabraGenerica.accionPasado)
				{
					if (tipoDePalabraGenerica != TipoDePalabraGenerica.accion)
					{
						throw new ArgumentOutOfRangeException(tipoDePalabraGenerica.ToString());
					}
					dictionary = dialogosDeLocal.accionesDeTipoDeRespuesta;
				}
				else
				{
					dictionary = dialogosDeLocal.accionesPasadoDeTipoDeRespuesta;
				}
				break;
			}
			ListaDeDialogos listaDeDialogos;
			if (!dictionary.ContainsKey(key) || !dictionary[key].TryGetValue(tipoDeRespuesta, out listaDeDialogos))
			{
				return null;
			}
			if (obtenerPrimero)
			{
				return listaDeDialogos.ObtenerPrimero().NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, direccion.ObtenerDireccionParaDialogos());
			}
			return listaDeDialogos.Obtener(null).NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, direccion.ObtenerDireccionParaDialogos());
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x000621C6 File Offset: 0x000603C6
		public static string ObternerStringDeTipoDeEstimuloTactil(TipoDeStringAccion tipoDeStringAccion, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, DireccionDeEstimulo direccion, TipoDeEstimuloTactil tipoDeEstimuloTactil, bool obtenerPrimero)
		{
			return ObtenerDialogosUtil.ObternerStringDeKey(new ValueTuple<int, int, int, int>(1, (int)direccion, (int)tipoDeEstimuloTactil, 1), tipoDeStringAccion, tipoDeRespuesta, obtenerPrimero, direccion);
		}

		// Token: 0x0600148F RID: 5263 RVA: 0x000621DB File Offset: 0x000603DB
		public static string ObternerStringDeTipoDeEstimuloCoital(TipoDeStringAccion tipoDeStringAccion, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, DireccionDeEstimulo direccion, TipoDeEstimuloCoital tipoDeEstimuloCoital, bool obtenerPrimero)
		{
			return ObtenerDialogosUtil.ObternerStringDeKey(new ValueTuple<int, int, int, int>(8, (int)direccion, (int)tipoDeEstimuloCoital, -1), tipoDeStringAccion, tipoDeRespuesta, obtenerPrimero, direccion);
		}

		// Token: 0x06001490 RID: 5264 RVA: 0x000621F0 File Offset: 0x000603F0
		public static string ObternerStringDeTipoDeEstimuloVisual(TipoDeStringAccion tipoDeStringAccion, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, DireccionDeEstimulo direccion, TipoDeEstimuloVisual tipoDeEstimuloVisual, bool obtenerPrimero)
		{
			return ObtenerDialogosUtil.ObternerStringDeKey(new ValueTuple<int, int, int, int>(3, (int)direccion, (int)tipoDeEstimuloVisual, -1), tipoDeStringAccion, tipoDeRespuesta, obtenerPrimero, direccion);
		}

		// Token: 0x04000E9C RID: 3740
		public bool flagClearIgnoreList;

		// Token: 0x04000E9D RID: 3741
		public ListaDeTipoDePalabraGenerica ignorarPalabraGenericas = new ListaDeTipoDePalabraGenerica();

		// Token: 0x04000E9E RID: 3742
		private Dictionary<object, ListaDeTipoDePalabraGenerica> m_ignorarPalabraGenericasDeProductor = new Dictionary<object, ListaDeTipoDePalabraGenerica>();

		// Token: 0x04000E9F RID: 3743
		private IFemaleCharacterIdleable m_IFemaleCharacterIdleable;

		// Token: 0x04000EA0 RID: 3744
		[NonSerialized]
		public bool forcedEnAutoInteraccion;

		// Token: 0x04000EA1 RID: 3745
		[NonSerialized]
		public Object contexto;

		// Token: 0x0200032C RID: 812
		public enum Resultado
		{
			// Token: 0x04000EA3 RID: 3747
			exito,
			// Token: 0x04000EA4 RID: 3748
			redundante,
			// Token: 0x04000EA5 RID: 3749
			contextoErrado = 4,
			// Token: 0x04000EA6 RID: 3750
			noExisteDialogo = 2,
			// Token: 0x04000EA7 RID: 3751
			noExisteDialogoTipoDeRespuesta = 5,
			// Token: 0x04000EA8 RID: 3752
			error = 3
		}
	}
}
