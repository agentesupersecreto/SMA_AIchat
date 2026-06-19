using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x02000514 RID: 1300
	public class FearPorDesHielo : CalculoDeEstimuloEnFrame<FearPorDesHielo.Configuracion>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x1700085F RID: 2143
		// (get) Token: 0x06001F76 RID: 8054 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("ahora todos los resultado y estados de resultados deben ser registrados", true)]
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000860 RID: 2144
		// (get) Token: 0x06001F77 RID: 8055 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("", true)]
		public bool estimuloExisteEnFrame
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000861 RID: 2145
		// (get) Token: 0x06001F78 RID: 8056 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("", true)]
		public ICalculoDeEstimulo calculoMasFuerteBase
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000862 RID: 2146
		// (get) Token: 0x06001F79 RID: 8057 RVA: 0x00004252 File Offset: 0x00002452
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.None;
			}
		}

		// Token: 0x17000863 RID: 2147
		// (get) Token: 0x06001F7A RID: 8058 RVA: 0x00076FC2 File Offset: 0x000751C2
		public int cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil
		{
			get
			{
				return this.m_calculosEnFrameMasFuerteADebil.Count;
			}
		}

		// Token: 0x17000864 RID: 2148
		// (get) Token: 0x06001F7B RID: 8059 RVA: 0x00076FC2 File Offset: 0x000751C2
		public int cantidadDeCalculosEnFrame
		{
			get
			{
				return this.m_calculosEnFrameMasFuerteADebil.Count;
			}
		}

		// Token: 0x06001F7C RID: 8060 RVA: 0x00076FD0 File Offset: 0x000751D0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_deshielo = this.GetComponentEnRoot(false);
			if (this.m_deshielo == null)
			{
				throw new ArgumentNullException("m_deshielo", "m_deshielo null reference.");
			}
			this.m_DesHieloPorCambioDeEmociones = this.m_deshielo.GetComponentInChildren<DesHieloPorCambioDeEmociones>();
			if (this.m_DesHieloPorCambioDeEmociones == null)
			{
				throw new ArgumentNullException("m_DesHieloPorCambioDeEmociones", "m_DesHieloPorCambioDeEmociones null reference.");
			}
			this.m_Fear = base.GetComponentInParent<Fear>();
			if (this.m_Fear == null)
			{
				throw new ArgumentNullException("m_Fear", "m_Fear null reference.");
			}
			this.m_ConsentNecesario = this.GetComponentEnRoot(false);
			if (this.m_ConsentNecesario == null)
			{
				throw new ArgumentNullException("m_ConsentNecesario", "m_ConsentNecesario null reference.");
			}
			this.m_ConsentCorrupted = this.GetComponentEnRoot(false);
			if (this.m_ConsentCorrupted == null)
			{
				throw new ArgumentNullException("m_ConsentCorrupted", "m_ConsentCorrupted null reference.");
			}
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x06001F7D RID: 8061 RVA: 0x000770CE File Offset: 0x000752CE
		public ICalculoDeEstimulo GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(int index)
		{
			return this.m_calculosEnFrameMasFuerteADebil[index];
		}

		// Token: 0x06001F7E RID: 8062 RVA: 0x000770CE File Offset: 0x000752CE
		public ICalculoDeEstimulo GetCalculoEnFrameBase(int index)
		{
			return this.m_calculosEnFrameMasFuerteADebil[index];
		}

		// Token: 0x06001F7F RID: 8063 RVA: 0x00076AFD File Offset: 0x00074CFD
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Fear;
		}

		// Token: 0x06001F80 RID: 8064 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x06001F81 RID: 8065 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void Updating(float deltaTime)
		{
		}

		// Token: 0x06001F82 RID: 8066 RVA: 0x000770DC File Offset: 0x000752DC
		protected override void DoUpdate(ref float generadoNoLimitado, ref float generadoLimitado, ref float cambiarValorDeEmocionDespuesDeTiempoMod, float deltaTime)
		{
			for (int i = 0; i < this.m_calculosEnFrameMasFuerteADebil.Count; i++)
			{
				IClearable clearable = this.m_calculosEnFrameMasFuerteADebil[i] as IClearable;
				if (clearable != null)
				{
					clearable.Clear();
				}
			}
			this.m_calculosEnFrameMasFuerteADebil.Clear();
			float num = 0f;
			float num2 = 0f;
			this.ProcesarCalculosDeDeshielo(ref num, ref num2);
			if (this.m_deshielo.value.total >= 100f)
			{
				num2 = 0f;
			}
			generadoNoLimitado = num;
			generadoLimitado = num2;
			this.m_calculosEnFrameMasFuerteADebil.SortMasFuerteAlMasDebil();
		}

		// Token: 0x06001F83 RID: 8067 RVA: 0x00077170 File Offset: 0x00075370
		protected virtual void ProcesarCalculosDeDeshielo(ref float generadoNoLimitadoNested, ref float generadoLimitadoNested)
		{
			FearPorDesHielo.CalculateFear(this, this.m_DesHieloPorCambioDeEmociones, this.m_Fear, this.m_modificablesDeInteraccio, this.m_resultadosSegunCalculadores, this.m_calculosEnFrameMasFuerteADebil, this.m_deshielo, this.m_ConsentNecesario, this.m_ConsentCorrupted, this.config, ref generadoNoLimitadoNested, ref generadoLimitadoNested);
		}

		// Token: 0x06001F84 RID: 8068 RVA: 0x000771BC File Offset: 0x000753BC
		protected static void CalculateFear(ICalculadorDeEstimuloConCalculos calculador, ICalculadorDeEstimuloConCalculosDeHielo m_DesHieloPorCambioDeEmociones, Fear m_Fear, ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio, Dictionary<ICalculadorDeEstimulo, ICalculoDeInteracionEstimulanteConEstado> m_resultadosSegunCalculadores, List<ICalculoDeInteracionEstimulanteConEstado> m_calculosEnFrameMasFuerteADebil, DesHielo m_deshielo, ConsentNecesario m_ConsentNecesario, ConsentCorrupted m_ConsentCorrupted, FearPorDesHielo.Configuracion config, ref float generadoNoLimitadoNested, ref float generadoLimitadoNested)
		{
			for (int i = 0; i < m_DesHieloPorCambioDeEmociones.cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil; i++)
			{
				ICalculoDeEstimuloCompleto calculoDeEstimuloCompleto = m_DesHieloPorCambioDeEmociones.GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(i) as ICalculoDeEstimuloCompleto;
				if (calculoDeEstimuloCompleto != null)
				{
					bool flag = calculoDeEstimuloCompleto.tag == "golpe";
					if (calculoDeEstimuloCompleto.estimuloBasico.tipo != DireccionDeEstimulo.dada)
					{
						ValueTuple<int, int, int, int> valueTuple;
						float lastValue = m_DesHieloPorCambioDeEmociones.GetLastValue(calculoDeEstimuloCompleto, out valueTuple);
						if (lastValue < 100f)
						{
							bool flag2 = !flag && m_ConsentNecesario.EsConsentidoConJerarquia(calculoDeEstimuloCompleto, null, null);
							bool flag3 = m_ConsentCorrupted.EsCorrupted(calculoDeEstimuloCompleto);
							DireccionDeEstimulo tipo = calculoDeEstimuloCompleto.estimuloBasico.tipo;
							if (!flag2 && !flag3)
							{
								TipoDeEstimulo tipoDeEstimulo = calculoDeEstimuloCompleto.estimuloBasico.tipoDeEstimulo;
								ParteQuePuedeEstimular estimulanteParte = calculoDeEstimuloCompleto.estimulanteParte;
								ParteDelCuerpoHumano parteDelCuerpoHumano = calculoDeEstimuloCompleto.estimuloBasico.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed);
								float num = ((flag3 || flag2) ? 6f : 2f);
								float num2 = 1f - (lastValue / 100f).OutPow(num);
								IReadOnlyList<ConsensualTree.Data> gerarquia = FearPorDesHielo.GetGerarquia(tipoDeEstimulo, tipo, parteDelCuerpoHumano, estimulanteParte);
								int num3 = Mathf.Min(15, gerarquia.Count);
								float num4 = 1f;
								float num5;
								if (estimulanteParte == ParteQuePuedeEstimular.semen)
								{
									if (calculoDeEstimuloCompleto.estimuloBasico is EstimuloTactilDeSemen)
									{
										EstimuloTactilDeSemen estimuloTactilDeSemen = (EstimuloTactilDeSemen)calculoDeEstimuloCompleto.estimuloBasico;
										switch (estimuloTactilDeSemen.tipoDeSemen)
										{
										case TipoDeSemen.semen:
											num5 = 0.2f;
											break;
										case TipoDeSemen.water:
											num5 = 0.05f;
											break;
										case TipoDeSemen.lubricante:
											num5 = 0.1f;
											break;
										case TipoDeSemen.orine:
											num5 = 0.5f;
											break;
										default:
											throw new ArgumentOutOfRangeException(estimuloTactilDeSemen.tipoDeSemen.ToString());
										}
									}
									else
									{
										num5 = 0.2f;
									}
								}
								else
								{
									num5 = 1f;
								}
								float num7;
								if (num3 > 0)
								{
									for (int j = 1; j < num3; j++)
									{
										ConsensualTree.Data data = gerarquia[j];
										float num6 = m_deshielo.ObtenerValor(calculoDeEstimuloCompleto, new ParteQuePuedeEstimular?(data.parteEstimulante), new ParteDelCuerpoHumano?(data.parteEstimulada), new TipoDeEstimulo?(data.tipoDeEstimulo), new DireccionDeEstimulo?(data.direccion), null);
										num4 += 1f - num6 / 100f;
									}
									num4 /= (float)num3;
									num7 = Mathf.Lerp(0.2f, 1f, num4.InPow(num));
								}
								else
								{
									num7 = 0.2f;
								}
								ValueTuple<ParteDelCuerpoHumano, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular> valueTuple2 = new ValueTuple<ParteDelCuerpoHumano, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular>((ParteDelCuerpoHumano)valueTuple.Item1, (TipoDeEstimulo)valueTuple.Item2, (DireccionDeEstimulo)valueTuple.Item3, calculoDeEstimuloCompleto.estimulanteParte);
								float num8 = FearPorDesHielo.GetGeneracion(calculoDeEstimuloCompleto, config, m_modificablesDeInteraccio, ref valueTuple2) * num2 * num7 * num5;
								if (num8 > 0f)
								{
									generadoNoLimitadoNested += num8;
									generadoLimitadoNested += num8;
									ICalculoDeInteracionEstimulanteConEstado calculoDeInteracionEstimulanteConEstado;
									if (FearPorDesHielo.TryGetCalculoResultSegunCalculador(m_resultadosSegunCalculadores, calculoDeEstimuloCompleto, out calculoDeInteracionEstimulanteConEstado))
									{
										(calculoDeEstimuloCompleto as ICopiableA).CopiarA(calculoDeInteracionEstimulanteConEstado);
										for (int k = 0; k < calculoDeEstimuloCompleto.cantidadDeEstados; k++)
										{
											UmbralBasico.Estado estado;
											calculoDeEstimuloCompleto.GetEstadoCopia(k, out estado);
											estado.SobreEscribirEstimulacionGeneradaEnFrame(num8, num8, 1f);
											calculoDeInteracionEstimulanteConEstado.SobreEscribirEstado(k, ref estado);
										}
										calculoDeInteracionEstimulanteConEstado.emocion = m_Fear;
										calculoDeInteracionEstimulanteConEstado.producidoPor = calculador;
										m_calculosEnFrameMasFuerteADebil.Add(calculoDeInteracionEstimulanteConEstado);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06001F85 RID: 8069 RVA: 0x000774D8 File Offset: 0x000756D8
		private static float GetGeneracion(ICalculoDeEstimuloCompleto calculo, FearPorDesHielo.Configuracion config, ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio, [TupleElementNames(new string[] { "estimulado", "tipoDeEstimulo", "direccion", "estimulanteParte" })] ref ValueTuple<ParteDelCuerpoHumano, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular> key)
		{
			float num = FearPorDesHielo.GetGeneracion(calculo, key.Item1, config);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix modificador = m_modificablesDeInteraccio.GetModificador(calculo.estimuloBasico, key.Item1, key.Item4, false, null);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced advanced = modificador.advanced;
			if (advanced != null)
			{
				num *= advanced.gainModificable.ModificarValor(1f);
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional tradicional = modificador.tradicional;
			if (tradicional != null)
			{
				num *= tradicional.gainModificable.ModificarValor(1f);
			}
			return num;
		}

		// Token: 0x06001F86 RID: 8070 RVA: 0x00077550 File Offset: 0x00075750
		private static float GetGeneracion(ICalculoDeEstimuloCompleto calculo, ParteDelCuerpoHumano estimulada, FearPorDesHielo.Configuracion config)
		{
			switch (calculo.estimuloBasico.tipoDeEstimulo)
			{
			case TipoDeEstimulo.tactil:
			{
				float num = (calculo.estimuloBasico.esUnaVez ? config.aumentoPorTactilUnaVez : (config.aumentoPorSegundoTactil * Time.deltaTime));
				bool flag = estimulada.EsPrivadaSocialmenteTactil();
				bool flag2 = estimulada.EsSemiPrivadaSocialmenteTactil();
				if (flag)
				{
					return num;
				}
				if (flag2)
				{
					return num * 0.75f;
				}
				return num * 0.5625f;
			}
			case TipoDeEstimulo.visual:
			{
				float num2 = ((calculo.estimuloBasico.tipo == DireccionDeEstimulo.dada) ? config.aumentoPorSegundoVisualDada : config.aumentoPorSegundoVisualRecibida);
				float num3 = (calculo.estimuloBasico.esUnaVez ? config.aumentoPorVisualUnaVez : (num2 * Time.deltaTime));
				bool flag3 = estimulada.EsMuyPrivadaSocialmenteVisual();
				bool flag4 = estimulada.EsPrivadaSocialmenteVisual();
				bool flag5 = estimulada.EsSemiPrivadaSocialmenteVisual();
				if (flag3)
				{
					return num3;
				}
				if (flag4)
				{
					return num3 * 0.75f;
				}
				if (flag5)
				{
					return num3 * 0.5625f;
				}
				return num3 * 0.421875f;
			}
			case TipoDeEstimulo.coital:
			{
				float num4 = (calculo.estimuloBasico.esUnaVez ? config.aumentoPorCoitalUnaVez : (config.aumentoPorSegundoCoital * Time.deltaTime));
				bool flag6 = estimulada.EsPrivadaSocialmenteCoital();
				bool flag7 = estimulada.EsSemiPrivadaSocialmenteCoital();
				if (flag6)
				{
					return num4;
				}
				if (flag7)
				{
					return num4 * 0.75f;
				}
				return num4 * 0.5625f;
			}
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.manipulandoBone:
			{
				float num5 = (calculo.estimuloBasico.esUnaVez ? config.aumentoPorForzamientoUnaVez : (config.aumentoPorSegundoForzamiento * Time.deltaTime));
				bool flag8 = estimulada.EsPrivadaSocialmenteTactil();
				bool flag9 = estimulada.EsSemiPrivadaSocialmenteTactil();
				if (flag8)
				{
					return num5;
				}
				if (flag9)
				{
					return num5 * 0.75f;
				}
				return num5 * 0.5625f;
			}
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
			{
				float num6 = (calculo.estimuloBasico.esUnaVez ? config.aumentoPorPeticionUnaVez : (config.aumentoPorSegundoPeticion * Time.deltaTime));
				bool flag10 = estimulada.EsMuyPrivadaSocialmenteVisual();
				bool flag11 = estimulada.EsPrivadaSocialmenteVisual();
				bool flag12 = estimulada.EsSemiPrivadaSocialmenteVisual();
				if (flag10)
				{
					return num6;
				}
				if (flag11)
				{
					return num6 * 0.75f;
				}
				if (flag12)
				{
					return num6 * 0.5625f;
				}
				return num6 * 0.421875f;
			}
			}
			throw new ArgumentOutOfRangeException(calculo.estimuloBasico.tipoDeEstimulo.ToString());
		}

		// Token: 0x06001F87 RID: 8071 RVA: 0x0007778C File Offset: 0x0007598C
		private static IReadOnlyList<ConsensualTree.Data> GetGerarquia(TipoDeEstimulo tipoDeEstimulo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante)
		{
			string text = null;
			ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string> valueTuple = new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string>(tipoDeEstimulo, direccion, parteEstimulada, parteEstimulante, text);
			List<ConsensualTree.Data> list;
			if (!FearPorDesHielo.m_overridesInvertedMemFiltered.TryGetValue(valueTuple, out list))
			{
				HashSet<TipoDeEstimulo> filtroValid1 = new HashSet<TipoDeEstimulo>();
				HashSet<ParteQuePuedeEstimular> filtroInvalid2 = new HashSet<ParteQuePuedeEstimular>();
				switch (tipoDeEstimulo)
				{
				case TipoDeEstimulo.tactil:
					filtroValid1.Add(TipoDeEstimulo.visual);
					filtroValid1.Add(TipoDeEstimulo.tactil);
					goto IL_0262;
				case TipoDeEstimulo.visual:
					filtroValid1.Add(TipoDeEstimulo.visual);
					goto IL_0262;
				case TipoDeEstimulo.coital:
					filtroValid1.Add(TipoDeEstimulo.visual);
					filtroValid1.Add(TipoDeEstimulo.tactil);
					filtroValid1.Add(TipoDeEstimulo.coital);
					filtroInvalid2.Add(ParteQuePuedeEstimular.semen);
					filtroInvalid2.UnionWith(ParteQuePuedeEstimularHelper.puedenPenetrar);
					filtroInvalid2.UnionWith(ParteQuePuedeEstimularHelper.puedenQueHacenHumping);
					goto IL_0262;
				case TipoDeEstimulo.desvestidura:
					filtroValid1.Add(TipoDeEstimulo.visual);
					filtroValid1.Add(TipoDeEstimulo.tactil);
					filtroValid1.Add(TipoDeEstimulo.peticionDesvestidura);
					goto IL_0262;
				case TipoDeEstimulo.peticionDesvestidura:
					filtroValid1.Add(TipoDeEstimulo.visual);
					filtroValid1.Add(TipoDeEstimulo.peticionDesvestidura);
					goto IL_0262;
				case TipoDeEstimulo.ejecucionDePose:
					filtroValid1.Add(TipoDeEstimulo.visual);
					filtroValid1.Add(TipoDeEstimulo.tactil);
					filtroValid1.Add(TipoDeEstimulo.peticionEjecucionDePose);
					goto IL_0262;
				case TipoDeEstimulo.peticionEjecucionDePose:
					filtroValid1.Add(TipoDeEstimulo.visual);
					filtroValid1.Add(TipoDeEstimulo.peticionEjecucionDePose);
					goto IL_0262;
				case TipoDeEstimulo.guiandoBone:
					filtroValid1.Add(TipoDeEstimulo.visual);
					filtroValid1.Add(TipoDeEstimulo.guiandoBone);
					goto IL_0262;
				case TipoDeEstimulo.manipulandoBone:
					filtroValid1.Add(TipoDeEstimulo.visual);
					filtroValid1.Add(TipoDeEstimulo.tactil);
					filtroValid1.Add(TipoDeEstimulo.guiandoBone);
					goto IL_0262;
				}
				throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
				IL_0262:
				list = (from o in ConsensualTree.OverridesInverted(tipoDeEstimulo, direccion, parteEstimulada, parteEstimulante, null)
					where o.tipoDeEstimulo != tipoDeEstimulo || o.direccion != direccion || o.parteEstimulada != parteEstimulada || o.parteEstimulante != parteEstimulante
					where !o.tipoDeEstimulo.EsIntercambioVerbal() || ParteQuePuedeEstimularHelper.puedenComunicarSet.Contains((int)o.parteEstimulante)
					where filtroValid1.Contains(o.tipoDeEstimulo)
					where !filtroInvalid2.Contains(o.parteEstimulante)
					orderby o.Getpriorida() descending
					select o).ToList<ConsensualTree.Data>();
				FearPorDesHielo.m_overridesInvertedMemFiltered.Add(valueTuple, list);
			}
			return list;
		}

		// Token: 0x06001F88 RID: 8072 RVA: 0x00077AAC File Offset: 0x00075CAC
		private static bool TryGetCalculoResultSegunCalculador(Dictionary<ICalculadorDeEstimulo, ICalculoDeInteracionEstimulanteConEstado> m_resultadosSegunCalculadores, ICalculoDeEstimulo calculoDeDesHielo, out ICalculoDeInteracionEstimulanteConEstado resultado)
		{
			ICalculadorDeEstimuloConCalculos calculadorDeEstimuloConCalculos = calculoDeDesHielo.producidoPorSegundario as ICalculadorDeEstimuloConCalculos;
			resultado = null;
			if (calculadorDeEstimuloConCalculos == null)
			{
				return false;
			}
			if (!m_resultadosSegunCalculadores.TryGetValue(calculadorDeEstimuloConCalculos, out resultado))
			{
				ICalculoDeEstimulo calculoDeEstimulo;
				if (calculadorDeEstimuloConCalculos.TryInstantiateCalculoBase(out calculoDeEstimulo) && calculoDeEstimulo is ICopiableA && calculoDeEstimulo is ICalculoDeInteracionEstimulanteConEstado && calculoDeEstimulo is IClearable)
				{
					resultado = (ICalculoDeInteracionEstimulanteConEstado)calculoDeEstimulo;
					m_resultadosSegunCalculadores.Add(calculadorDeEstimuloConCalculos, resultado);
					((IClearable)resultado).Clear();
				}
				else
				{
					Debug.LogError("Todos los calculos deberian ser compatibles");
				}
			}
			return resultado != null;
		}

		// Token: 0x06001F89 RID: 8073 RVA: 0x0007639F File Offset: 0x0007459F
		public bool TryInstantiateCalculoBase(out ICalculoDeEstimulo calculo)
		{
			calculo = null;
			return false;
		}

		// Token: 0x06001F8A RID: 8074 RVA: 0x00077B27 File Offset: 0x00075D27
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Test Gerarquia"
			};
		}

		// Token: 0x06001F8B RID: 8075 RVA: 0x00077B40 File Offset: 0x00075D40
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			Debug.Log(FearPorDesHielo.GetGerarquia(this.m_debugCorruptedData.tipoDeEstimulo, this.m_debugCorruptedData.direccion, this.m_debugCorruptedData.parteEstimulada, this.m_debugCorruptedData.parteEstimulante));
		}

		// Token: 0x06001F8E RID: 8078 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001F8F RID: 8079 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001F90 RID: 8080 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001F91 RID: 8081 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001F92 RID: 8082 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001F93 RID: 8083 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x040014CB RID: 5323
		protected Dictionary<ICalculadorDeEstimulo, ICalculoDeInteracionEstimulanteConEstado> m_resultadosSegunCalculadores = new Dictionary<ICalculadorDeEstimulo, ICalculoDeInteracionEstimulanteConEstado>();

		// Token: 0x040014CC RID: 5324
		[SerializeReference]
		protected List<ICalculoDeInteracionEstimulanteConEstado> m_calculosEnFrameMasFuerteADebil = new List<ICalculoDeInteracionEstimulanteConEstado>();

		// Token: 0x040014CD RID: 5325
		private DesHieloPorCambioDeEmociones m_DesHieloPorCambioDeEmociones;

		// Token: 0x040014CE RID: 5326
		protected DesHielo m_deshielo;

		// Token: 0x040014CF RID: 5327
		protected Fear m_Fear;

		// Token: 0x040014D0 RID: 5328
		protected ConsentNecesario m_ConsentNecesario;

		// Token: 0x040014D1 RID: 5329
		protected ConsentCorrupted m_ConsentCorrupted;

		// Token: 0x040014D2 RID: 5330
		protected ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;

		// Token: 0x040014D3 RID: 5331
		private static readonly Dictionary<ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string>, List<ConsensualTree.Data>> m_overridesInvertedMemFiltered = new Dictionary<ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string>, List<ConsensualTree.Data>>();

		// Token: 0x040014D4 RID: 5332
		[Header("DEBUG")]
		[SerializeField]
		private FearPorDesHielo.DebugCorrupted m_debugCorruptedData = new FearPorDesHielo.DebugCorrupted();

		// Token: 0x02000515 RID: 1301
		[Serializable]
		public class Configuracion
		{
			// Token: 0x040014D5 RID: 5333
			public float aumentoPorSegundoVisualDada = 3f;

			// Token: 0x040014D6 RID: 5334
			public float aumentoPorSegundoVisualRecibida = 10f;

			// Token: 0x040014D7 RID: 5335
			public float aumentoPorSegundoTactil = 40f;

			// Token: 0x040014D8 RID: 5336
			public float aumentoPorSegundoCoital = 80f;

			// Token: 0x040014D9 RID: 5337
			public float aumentoPorSegundoPeticion = 20f;

			// Token: 0x040014DA RID: 5338
			public float aumentoPorSegundoForzamiento = 60f;

			// Token: 0x040014DB RID: 5339
			public float aumentoPorVisualUnaVez = 15f;

			// Token: 0x040014DC RID: 5340
			public float aumentoPorTactilUnaVez = 50f;

			// Token: 0x040014DD RID: 5341
			public float aumentoPorCoitalUnaVez = 90f;

			// Token: 0x040014DE RID: 5342
			public float aumentoPorPeticionUnaVez = 30f;

			// Token: 0x040014DF RID: 5343
			public float aumentoPorForzamientoUnaVez = 70f;
		}

		// Token: 0x02000516 RID: 1302
		[Serializable]
		public class DebugCorrupted
		{
			// Token: 0x040014E0 RID: 5344
			public TipoDeEstimulo tipoDeEstimulo;

			// Token: 0x040014E1 RID: 5345
			public DireccionDeEstimulo direccion;

			// Token: 0x040014E2 RID: 5346
			public ParteDelCuerpoHumano parteEstimulada;

			// Token: 0x040014E3 RID: 5347
			public ParteQuePuedeEstimular parteEstimulante;
		}
	}
}
