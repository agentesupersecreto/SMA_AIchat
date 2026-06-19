using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x0200050B RID: 1291
	public sealed class DesHieloPorCambioDeEmociones : CalculoDeEstimuloEnFrame<DesHieloPorCambioDeEmociones.Configuracion>, ICalculadorDeEstimuloConCalculosDeHielo, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x17000851 RID: 2129
		// (get) Token: 0x06001F39 RID: 7993 RVA: 0x00075A05 File Offset: 0x00073C05
		public int cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil
		{
			get
			{
				return this.m_calculosEnFrameMasFuerteADebil.Count;
			}
		}

		// Token: 0x17000852 RID: 2130
		// (get) Token: 0x06001F3A RID: 7994 RVA: 0x00075A05 File Offset: 0x00073C05
		public int cantidadDeCalculosEnFrame
		{
			get
			{
				return this.m_calculosEnFrameMasFuerteADebil.Count;
			}
		}

		// Token: 0x06001F3B RID: 7995 RVA: 0x00075A12 File Offset: 0x00073C12
		public ICalculoDeEstimulo GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(int index)
		{
			return this.m_calculosEnFrameMasFuerteADebil[index];
		}

		// Token: 0x06001F3C RID: 7996 RVA: 0x00075A12 File Offset: 0x00073C12
		public ICalculoDeEstimulo GetCalculoEnFrameBase(int index)
		{
			return this.m_calculosEnFrameMasFuerteADebil[index];
		}

		// Token: 0x17000853 RID: 2131
		// (get) Token: 0x06001F3D RID: 7997 RVA: 0x00004252 File Offset: 0x00002452
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.None;
			}
		}

		// Token: 0x06001F3E RID: 7998 RVA: 0x00075A20 File Offset: 0x00073C20
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_deshielo = base.GetComponentInParent<DesHielo>();
			if (this.m_deshielo == null)
			{
				throw new ArgumentNullException("m_deshielo", "m_deshielo null reference.");
			}
			DesHieloPorCambioDeEmociones.LoadLista<ICalculadorDeEstimuloCoital>(ref this.m_calculadoresCoitales, this.m_emocionesDeOwner, ref this.m_calculadoresCoitalesDEbug);
			DesHieloPorCambioDeEmociones.LoadLista<ICalculadorDeEstimuloVisual>(ref this.m_calculadoresVisuales, this.m_emocionesDeOwner, ref this.m_calculadoresVisualesDEbug);
			DesHieloPorCambioDeEmociones.LoadLista<ICalculadorDeEstimuloTactil>(ref this.m_calculadoresTactiles, this.m_emocionesDeOwner, ref this.m_calculadoresTactilesDEbug);
			DesHieloPorCambioDeEmociones.LoadLista<ICalculadorDeEstimuloPorDesvestir>(ref this.m_calculadoresDesvestir, this.m_emocionesDeOwner, ref this.m_calculadoresDesvestirDEbug);
			foreach (ICalculadorDeEstimuloCoital calculadorDeEstimuloCoital in this.m_calculadoresCoitales)
			{
				ICalculoDeEstimuloCoitalHole calculoDeEstimuloCoitalHole;
				if (calculadorDeEstimuloCoital.TryInstantiateCalculo(out calculoDeEstimuloCoitalHole) && calculoDeEstimuloCoitalHole is ICopiableA && calculoDeEstimuloCoitalHole != null && calculoDeEstimuloCoitalHole != null)
				{
					this.m_resultadosSegunCalculadores.Add(calculadorDeEstimuloCoital, calculoDeEstimuloCoitalHole);
					calculoDeEstimuloCoitalHole.Clear();
				}
			}
			foreach (ICalculadorDeEstimuloVisual calculadorDeEstimuloVisual in this.m_calculadoresVisuales)
			{
				ICalculoDeEstimuloVisual calculoDeEstimuloVisual;
				if (calculadorDeEstimuloVisual.TryInstantiateCalculo(out calculoDeEstimuloVisual) && calculoDeEstimuloVisual is ICopiableA && calculoDeEstimuloVisual != null && calculoDeEstimuloVisual != null)
				{
					this.m_resultadosSegunCalculadores.Add(calculadorDeEstimuloVisual, calculoDeEstimuloVisual);
					calculoDeEstimuloVisual.Clear();
				}
			}
			foreach (ICalculadorDeEstimuloTactil calculadorDeEstimuloTactil in this.m_calculadoresTactiles)
			{
				ICalculoDeEstimuloTactil calculoDeEstimuloTactil;
				if (calculadorDeEstimuloTactil.TryInstantiateCalculo(out calculoDeEstimuloTactil) && calculoDeEstimuloTactil is ICopiableA && calculoDeEstimuloTactil != null && calculoDeEstimuloTactil != null)
				{
					this.m_resultadosSegunCalculadores.Add(calculadorDeEstimuloTactil, calculoDeEstimuloTactil);
					calculoDeEstimuloTactil.Clear();
				}
			}
			foreach (ICalculadorDeEstimuloPorDesvestir calculadorDeEstimuloPorDesvestir in this.m_calculadoresDesvestir)
			{
				ICalculoDeEstimuloPorDesvestir calculoDeEstimuloPorDesvestir;
				if (calculadorDeEstimuloPorDesvestir.TryInstantiateCalculo(out calculoDeEstimuloPorDesvestir) && calculoDeEstimuloPorDesvestir is ICopiableA && calculoDeEstimuloPorDesvestir != null && calculoDeEstimuloPorDesvestir != null)
				{
					this.m_resultadosSegunCalculadores.Add(calculadorDeEstimuloPorDesvestir, calculoDeEstimuloPorDesvestir);
					calculoDeEstimuloPorDesvestir.Clear();
				}
			}
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x06001F3F RID: 7999 RVA: 0x00075C80 File Offset: 0x00073E80
		public static void LoadLista<T>(ref List<T> target, EmocionesFemeninas emocionesDeOwner, ref List<Object> debug) where T : ICalculadorDeEstimulo
		{
			target = new List<T>();
			emocionesDeOwner.GetComponentsInChildren<T>(false, target);
			target.RemoveAll((T c) => c.tipo != TipoDeCalculadorDeEstimulo.frame || (c.emo.reaccion != ReaccionHumana.dolor && c.emo.reaccion != ReaccionHumana.rabia && c.emo.reaccion != ReaccionHumana.placer && c.emo.reaccion != ReaccionHumana.decepcion));
			if (Application.isEditor)
			{
				debug = new List<Object>();
				for (int i = 0; i < target.Count; i++)
				{
					debug.Add(target[i] as Object);
				}
			}
		}

		// Token: 0x17000854 RID: 2132
		// (get) Token: 0x06001F40 RID: 8000 RVA: 0x00075CFD File Offset: 0x00073EFD
		[Obsolete("", true)]
		public ICalculoDeEstimulo calculoMasFuerteBase
		{
			get
			{
				return this.m_masFuerte;
			}
		}

		// Token: 0x17000855 RID: 2133
		// (get) Token: 0x06001F41 RID: 8001 RVA: 0x00075D05 File Offset: 0x00073F05
		[Obsolete("", true)]
		public bool estimuloExisteEnFrame
		{
			get
			{
				return this.m_masFuerte != null;
			}
		}

		// Token: 0x17000856 RID: 2134
		// (get) Token: 0x06001F42 RID: 8002 RVA: 0x00005F51 File Offset: 0x00004151
		[Obsolete("", true)]
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001F43 RID: 8003 RVA: 0x00075D10 File Offset: 0x00073F10
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is DesHielo;
		}

		// Token: 0x06001F44 RID: 8004 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void Updating(float deltaTime)
		{
		}

		// Token: 0x06001F45 RID: 8005 RVA: 0x00075D1C File Offset: 0x00073F1C
		public float GetLastValue(ICalculoDeInteracionEstimulanteConEstado calculo, [TupleElementNames(new string[] { "estimulado", "tipoDeEstimulo", "direccion", "subTipoDeEstimulo" })] out ValueTuple<int, int, int, int> key)
		{
			ValueTuple<float, ValueTuple<int, int, int, int>> valueTuple = this.m_hieloValorBeforeUpdating[calculo];
			key = valueTuple.Item2;
			return valueTuple.Item1;
		}

		// Token: 0x06001F46 RID: 8006 RVA: 0x00075D48 File Offset: 0x00073F48
		public static void ProcesarCalculadores<T_Calculadores, T_Calculo, T_Estimulo>(ICalculadorDeEstimulo calculadorDesHielo, DesHielo desHielo, List<T_Calculadores> calculadores, DesHieloPorCambioDeEmociones.Configuracion config, ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio, Dictionary<ICalculadorDeEstimulo, ICalculoDeInteracionEstimulanteConEstado> resultadosSegunCalculadores, [TupleElementNames(new string[] { null, null, "estimulado", "tipoDeEstimulo", "direccion", "subTipoDeEstimulo" })] Dictionary<ICalculoDeInteracionEstimulanteConEstado, ValueTuple<float, ValueTuple<int, int, int, int>>> m_hieloValorBeforeUpdating, HashSet<ValueTuple<int, int, int, int>> m_estimuloRepetidoEnFrame, List<ICalculoDeInteracionEstimulanteConEstado> calculosEnFrameMasFuerteADebilResultado, ref float generadoNoLimitadoNested, ref float generadoLimitadoNested) where T_Calculadores : ICalculadorDeEstimulo<T_Calculo> where T_Calculo : ICalculoDeEstimuloConEstado, ICalculoDeEstimulo<T_Estimulo>, ICalculoDeEstimuloDeParteEstimulante, IClearable where T_Estimulo : InteracionEstimulanteBasica
		{
			for (int i = 0; i < calculadores.Count; i++)
			{
				T_Calculadores t_Calculadores = calculadores[i];
				if (t_Calculadores.cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil != 0)
				{
					T_Calculo calculoConEstimulosEnFrameMasFuerteAMasDebil = t_Calculadores.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(0);
					if (!calculoConEstimulosEnFrameMasFuerteAMasDebil.esSingleEstado)
					{
						Debug.LogError("Procesador generico solo es compatible con calculos de un solo estado", calculoConEstimulosEnFrameMasFuerteAMasDebil as Object);
					}
					else
					{
						UmbralBasico.Estado estado;
						calculoConEstimulosEnFrameMasFuerteAMasDebil.GetSingleEstado(out estado);
						if (calculoConEstimulosEnFrameMasFuerteAMasDebil.estimulo.tipoDeEstimulo == TipoDeEstimulo.None)
						{
							throw new NotSupportedException();
						}
						ValueTuple<int, int, int, int> valueTuple;
						float num = desHielo.ObtenerValor(calculoConEstimulosEnFrameMasFuerteAMasDebil, out valueTuple);
						ValueTuple<ParteDelCuerpoHumano, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular> valueTuple2 = new ValueTuple<ParteDelCuerpoHumano, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular>((ParteDelCuerpoHumano)valueTuple.Item1, (TipoDeEstimulo)valueTuple.Item2, (DireccionDeEstimulo)valueTuple.Item3, calculoConEstimulosEnFrameMasFuerteAMasDebil.estimulanteParte);
						if (m_estimuloRepetidoEnFrame.Add(valueTuple))
						{
							float num2 = DesHieloPorCambioDeEmociones.GetValor(config, ref estado, calculoConEstimulosEnFrameMasFuerteAMasDebil, m_modificablesDeInteraccio, ref valueTuple2);
							num2 = desHielo.SimularAumento(num2);
							if (num2 > 0f)
							{
								ICalculoDeInteracionEstimulanteConEstado calculoDeInteracionEstimulanteConEstado;
								if (resultadosSegunCalculadores.TryGetValue(t_Calculadores, out calculoDeInteracionEstimulanteConEstado))
								{
									(calculoConEstimulosEnFrameMasFuerteAMasDebil as ICopiableA).CopiarA(calculoDeInteracionEstimulanteConEstado);
									UmbralBasico.Estado estado2 = estado;
									estado2.SobreEscribirEstimulacionGeneradaEnFrame(num2, num2, 1f);
									calculoDeInteracionEstimulanteConEstado.SobreEscribirSingleEstado(ref estado2);
									calculoDeInteracionEstimulanteConEstado.emocion = desHielo;
									calculoDeInteracionEstimulanteConEstado.producidoPorSegundario = calculoDeInteracionEstimulanteConEstado.producidoPor;
									calculoDeInteracionEstimulanteConEstado.producidoPor = calculadorDesHielo;
									calculosEnFrameMasFuerteADebilResultado.Add(calculoDeInteracionEstimulanteConEstado);
									m_hieloValorBeforeUpdating[calculoDeInteracionEstimulanteConEstado] = new ValueTuple<float, ValueTuple<int, int, int, int>>(num, valueTuple);
								}
								desHielo.RegistrarEstimuloGenerico(calculoConEstimulosEnFrameMasFuerteAMasDebil.estimulo, num2, 0.01f, ref generadoNoLimitadoNested, ref generadoLimitadoNested);
							}
						}
					}
				}
			}
		}

		// Token: 0x06001F47 RID: 8007 RVA: 0x00075EF8 File Offset: 0x000740F8
		protected sealed override void DoUpdate(ref float generadoNoLimitado, ref float generadoLimitado, ref float cambiarValorDeEmocionDespuesDeTiempoMod, float deltaTime)
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
			this.m_hieloValorBeforeUpdating.Clear();
			this.m_estimuloRepetidoEnFrame.Clear();
			float num = 0f;
			float num2 = 0f;
			if (this.generarCoitales)
			{
				for (int j = 0; j < this.m_calculadoresCoitales.Count; j++)
				{
					ICalculadorDeEstimuloCoital calculadorDeEstimuloCoital = this.m_calculadoresCoitales[j];
					if (calculadorDeEstimuloCoital.cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil != 0)
					{
						ICalculoDeEstimuloCoitalHole calculoConEstimulosEnFrameMasFuerteAMasDebil = calculadorDeEstimuloCoital.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(0);
						UmbralBasico.Estado estado;
						calculoConEstimulosEnFrameMasFuerteAMasDebil.GetPenetracionEstado(out estado);
						if (calculoConEstimulosEnFrameMasFuerteAMasDebil.estimulo.tipoDeEstimulo == TipoDeEstimulo.None)
						{
							throw new NotSupportedException();
						}
						ValueTuple<int, int, int, int> valueTuple;
						float num3 = this.m_deshielo.ObtenerValor(calculoConEstimulosEnFrameMasFuerteAMasDebil, out valueTuple);
						ValueTuple<ParteDelCuerpoHumano, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular> valueTuple2 = new ValueTuple<ParteDelCuerpoHumano, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular>((ParteDelCuerpoHumano)valueTuple.Item1, (TipoDeEstimulo)valueTuple.Item2, (DireccionDeEstimulo)valueTuple.Item3, calculoConEstimulosEnFrameMasFuerteAMasDebil.estimulanteParte);
						if (this.m_estimuloRepetidoEnFrame.Add(valueTuple))
						{
							float valor = DesHieloPorCambioDeEmociones.GetValor(this.config, ref estado, calculoConEstimulosEnFrameMasFuerteAMasDebil, this.m_modificablesDeInteraccio, ref valueTuple2);
							if (valor > 0f)
							{
								ICalculoDeInteracionEstimulanteConEstado calculoDeInteracionEstimulanteConEstado;
								if (this.m_resultadosSegunCalculadores.TryGetValue(calculadorDeEstimuloCoital, out calculoDeInteracionEstimulanteConEstado))
								{
									ICalculoDeEstimuloCoitalHole calculoDeEstimuloCoitalHole = (ICalculoDeEstimuloCoitalHole)calculoDeInteracionEstimulanteConEstado;
									(calculoConEstimulosEnFrameMasFuerteAMasDebil as ICopiableA).CopiarA(calculoDeEstimuloCoitalHole);
									UmbralBasico.Estado estado2 = estado;
									estado2.SobreEscribirEstimulacionGeneradaEnFrame(valor, valor, 1f);
									calculoDeEstimuloCoitalHole.SetEstadoAny(ref estado2);
									calculoDeInteracionEstimulanteConEstado.emocion = this.m_deshielo;
									calculoDeInteracionEstimulanteConEstado.producidoPorSegundario = calculoDeInteracionEstimulanteConEstado.producidoPor;
									calculoDeInteracionEstimulanteConEstado.producidoPor = this;
									this.m_calculosEnFrameMasFuerteADebil.Add(calculoDeInteracionEstimulanteConEstado);
									this.m_hieloValorBeforeUpdating[calculoDeInteracionEstimulanteConEstado] = new ValueTuple<float, ValueTuple<int, int, int, int>>(num3, valueTuple);
								}
								this.m_deshielo.RegistrarEstimulo(calculoConEstimulosEnFrameMasFuerteAMasDebil.estimulo, valor, 0.01f, ref num, ref num2);
							}
						}
					}
				}
			}
			if (this.generarVisuales)
			{
				DesHieloPorCambioDeEmociones.ProcesarCalculadores<ICalculadorDeEstimuloVisual, ICalculoDeEstimuloVisual, EstimuloVisual>(this, this.m_deshielo, this.m_calculadoresVisuales, this.config, this.m_modificablesDeInteraccio, this.m_resultadosSegunCalculadores, this.m_hieloValorBeforeUpdating, this.m_estimuloRepetidoEnFrame, this.m_calculosEnFrameMasFuerteADebil, ref num, ref num2);
			}
			if (this.generarTactil)
			{
				DesHieloPorCambioDeEmociones.ProcesarCalculadores<ICalculadorDeEstimuloTactil, ICalculoDeEstimuloTactil, EstimuloTactil>(this, this.m_deshielo, this.m_calculadoresTactiles, this.config, this.m_modificablesDeInteraccio, this.m_resultadosSegunCalculadores, this.m_hieloValorBeforeUpdating, this.m_estimuloRepetidoEnFrame, this.m_calculosEnFrameMasFuerteADebil, ref num, ref num2);
			}
			if (this.generarDesvestidura)
			{
				DesHieloPorCambioDeEmociones.ProcesarCalculadores<ICalculadorDeEstimuloPorDesvestir, ICalculoDeEstimuloPorDesvestir, EstimuloPorDesvestir>(this, this.m_deshielo, this.m_calculadoresDesvestir, this.config, this.m_modificablesDeInteraccio, this.m_resultadosSegunCalculadores, this.m_hieloValorBeforeUpdating, this.m_estimuloRepetidoEnFrame, this.m_calculosEnFrameMasFuerteADebil, ref num, ref num2);
			}
			if (this.m_deshielo.value.total >= 100f)
			{
				num2 = 0f;
			}
			generadoNoLimitado = num;
			generadoLimitado = num2;
			this.m_calculosEnFrameMasFuerteADebil.SortMasFuerteAlMasDebil();
		}

		// Token: 0x06001F48 RID: 8008 RVA: 0x000761D8 File Offset: 0x000743D8
		public static float GetValor(DesHieloPorCambioDeEmociones.Configuracion config, ref UmbralBasico.Estado estado, ICalculoDeInteracionEstimulante calculo, ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio, [TupleElementNames(new string[] { "estimulado", "tipoDeEstimulo", "direccion", "estimulanteParte" })] ref ValueTuple<ParteDelCuerpoHumano, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular> key)
		{
			if (((calculo != null) ? calculo.emocion : null) == null)
			{
				return 0f;
			}
			float num = config.aumentoPorSegundo;
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
			float num2;
			switch (calculo.estimuloBasico.tipoDeEstimulo.GetTipoBasico())
			{
			case TipoDeEstimuloBasico.visual:
				num2 = config.modPorVisuales;
				goto IL_00FA;
			case TipoDeEstimuloBasico.verbal:
				num2 = config.modPorVerbales;
				goto IL_00FA;
			case TipoDeEstimuloBasico.tactil:
				num2 = config.modPorTactiles;
				goto IL_00FA;
			case TipoDeEstimuloBasico.coital:
				num2 = config.modPorCoitales;
				goto IL_00FA;
			}
			throw new ArgumentOutOfRangeException(calculo.estimuloBasico.tipoDeEstimulo.GetTipoBasico().ToString());
			IL_00FA:
			DireccionDeEstimulo tipo = calculo.estimuloBasico.tipo;
			float num3;
			float num4;
			if (tipo != DireccionDeEstimulo.recibida)
			{
				if (tipo != DireccionDeEstimulo.dada)
				{
					throw new ArgumentOutOfRangeException(calculo.estimuloBasico.tipo.ToString());
				}
				num3 = config.modPorDadas;
				num4 = ((calculo.tag == "golpe") ? config.modPorDadasTagHit : 1f);
			}
			else
			{
				num3 = config.modPorRecibidas;
				num4 = ((calculo.tag == "golpe") ? config.modPorRecibidasTagHit : 1f);
			}
			float num5 = num * (calculo.estimuloBasico.esUnaVez ? 2.5f : Time.deltaTime);
			float num6 = estado.estimulacionGeneradaEnFrame * config.aumentoPorEstimulacionGenerada;
			return (num5 + num6) * num2 * num3 * num4;
		}

		// Token: 0x06001F49 RID: 8009 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x06001F4A RID: 8010 RVA: 0x0007639F File Offset: 0x0007459F
		public bool TryInstantiateCalculoBase(out ICalculoDeEstimulo calculo)
		{
			calculo = null;
			return false;
		}

		// Token: 0x06001F4C RID: 8012 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001F4D RID: 8013 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001F4E RID: 8014 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001F4F RID: 8015 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001F50 RID: 8016 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001F51 RID: 8017 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x04001484 RID: 5252
		public bool generarVisuales = true;

		// Token: 0x04001485 RID: 5253
		public bool generarTactil = true;

		// Token: 0x04001486 RID: 5254
		public bool generarCoitales = true;

		// Token: 0x04001487 RID: 5255
		public bool generarDesvestidura = true;

		// Token: 0x04001488 RID: 5256
		private List<ICalculadorDeEstimuloCoital> m_calculadoresCoitales;

		// Token: 0x04001489 RID: 5257
		private List<ICalculadorDeEstimuloVisual> m_calculadoresVisuales;

		// Token: 0x0400148A RID: 5258
		private List<ICalculadorDeEstimuloTactil> m_calculadoresTactiles;

		// Token: 0x0400148B RID: 5259
		private List<ICalculadorDeEstimuloPorDesvestir> m_calculadoresDesvestir;

		// Token: 0x0400148C RID: 5260
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_calculadoresCoitalesDEbug;

		// Token: 0x0400148D RID: 5261
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_calculadoresVisualesDEbug;

		// Token: 0x0400148E RID: 5262
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_calculadoresTactilesDEbug;

		// Token: 0x0400148F RID: 5263
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_calculadoresDesvestirDEbug;

		// Token: 0x04001490 RID: 5264
		private DesHielo m_deshielo;

		// Token: 0x04001491 RID: 5265
		private Dictionary<ICalculadorDeEstimulo, ICalculoDeInteracionEstimulanteConEstado> m_resultadosSegunCalculadores = new Dictionary<ICalculadorDeEstimulo, ICalculoDeInteracionEstimulanteConEstado>();

		// Token: 0x04001492 RID: 5266
		[SerializeReference]
		private List<ICalculoDeInteracionEstimulanteConEstado> m_calculosEnFrameMasFuerteADebil = new List<ICalculoDeInteracionEstimulanteConEstado>();

		// Token: 0x04001493 RID: 5267
		[TupleElementNames(new string[] { null, null, "estimulado", "tipoDeEstimulo", "direccion", "subTipoDeEstimulo" })]
		private Dictionary<ICalculoDeInteracionEstimulanteConEstado, ValueTuple<float, ValueTuple<int, int, int, int>>> m_hieloValorBeforeUpdating = new Dictionary<ICalculoDeInteracionEstimulanteConEstado, ValueTuple<float, ValueTuple<int, int, int, int>>>();

		// Token: 0x04001494 RID: 5268
		private HashSet<ValueTuple<int, int, int, int>> m_estimuloRepetidoEnFrame = new HashSet<ValueTuple<int, int, int, int>>();

		// Token: 0x04001495 RID: 5269
		[Obsolete("", true)]
		private List<ValueTuple<ICalculoDeEstimulo, float>> m_resultados = new List<ValueTuple<ICalculoDeEstimulo, float>>();

		// Token: 0x04001496 RID: 5270
		[Obsolete("", true)]
		private ICalculoDeEstimulo m_masFuerte;

		// Token: 0x04001497 RID: 5271
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;

		// Token: 0x0200050C RID: 1292
		[Serializable]
		public class Configuracion
		{
			// Token: 0x04001498 RID: 5272
			[HideInInspector]
			[Obsolete("", true)]
			public float modVisual = 150f;

			// Token: 0x04001499 RID: 5273
			[HideInInspector]
			[Obsolete("", true)]
			public float modTactil = 8f;

			// Token: 0x0400149A RID: 5274
			[HideInInspector]
			[Obsolete("", true)]
			public float modCoital = 6f;

			// Token: 0x0400149B RID: 5275
			public float modPorVisuales = 1f;

			// Token: 0x0400149C RID: 5276
			public float modPorVerbales = 0.8333333f;

			// Token: 0x0400149D RID: 5277
			public float modPorTactiles = 0.6666666f;

			// Token: 0x0400149E RID: 5278
			public float modPorCoitales = 0.5f;

			// Token: 0x0400149F RID: 5279
			public float modPorRecibidas = 1f;

			// Token: 0x040014A0 RID: 5280
			public float modPorDadas = 4f;

			// Token: 0x040014A1 RID: 5281
			public float modPorRecibidasTagHit = 0.125f;

			// Token: 0x040014A2 RID: 5282
			public float modPorDadasTagHit = 8f;

			// Token: 0x040014A3 RID: 5283
			public float aumentoPorEstimulacionGenerada = 0.01f;

			// Token: 0x040014A4 RID: 5284
			public float aumentoPorSegundo = 5f;

			// Token: 0x040014A5 RID: 5285
			[HideInInspector]
			[Obsolete("", true)]
			public float aumentoPorDecepcion = 0.1f;

			// Token: 0x040014A6 RID: 5286
			[HideInInspector]
			[Obsolete("", true)]
			public float aumentoPorDolor = 0.1f;

			// Token: 0x040014A7 RID: 5287
			[HideInInspector]
			[Obsolete("", true)]
			public float aumentoPorRage = 0.2f;

			// Token: 0x040014A8 RID: 5288
			[HideInInspector]
			[Obsolete("", true)]
			public float aumentoPorArousal = 2f;

			// Token: 0x040014A9 RID: 5289
			[HideInInspector]
			[Obsolete("", true)]
			public float aumentoPorAlegria = 3f;

			// Token: 0x040014AA RID: 5290
			[HideInInspector]
			[Obsolete("", true)]
			public float aumentoPorPlacer = 6f;

			// Token: 0x040014AB RID: 5291
			[HideInInspector]
			[Obsolete("", true)]
			public float aumentoPorConcent = 8f;
		}
	}
}
