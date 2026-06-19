using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x02000511 RID: 1297
	[Obsolete("hay una version mejor q funciona con deshielo", true)]
	public class FearPorCambioDeEmociones : CalculoDeEstimuloEnFrame<FearPorCambioDeEmociones.Configuracion>
	{
		// Token: 0x1700085B RID: 2139
		// (get) Token: 0x06001F65 RID: 8037 RVA: 0x00004252 File Offset: 0x00002452
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.None;
			}
		}

		// Token: 0x1700085C RID: 2140
		// (get) Token: 0x06001F66 RID: 8038 RVA: 0x00005F51 File Offset: 0x00004151
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700085D RID: 2141
		// (get) Token: 0x06001F67 RID: 8039 RVA: 0x000767C2 File Offset: 0x000749C2
		public bool estimuloExisteEnFrame
		{
			get
			{
				return this.m_masFuerte != null;
			}
		}

		// Token: 0x1700085E RID: 2142
		// (get) Token: 0x06001F68 RID: 8040 RVA: 0x000767CD File Offset: 0x000749CD
		public ICalculoDeEstimulo calculoMasFuerteBase
		{
			get
			{
				return this.m_masFuerte;
			}
		}

		// Token: 0x06001F69 RID: 8041 RVA: 0x000767D8 File Offset: 0x000749D8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_DesHielo = this.GetComponentEnRoot(false);
			this.m_fear = this.GetComponentEnRoot(false);
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_DesHielo == null)
			{
				throw new ArgumentNullException("m_DesHielo", "m_DesHielo null reference.");
			}
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentCorrupted", "m_ConsentCorrupted null reference.");
			}
			if (this.m_fear == null)
			{
				throw new ArgumentNullException("m_fear", "m_fear null reference.");
			}
			FearPorCambioDeEmociones.LoadLista<ICalculadorDeEstimuloCoital>(ref this.m_calculadoresCoitales, this.m_emocionesDeOwner, ref this.m_calculadoresCoitalesDEbug);
			FearPorCambioDeEmociones.LoadLista<ICalculadorDeEstimuloVisual>(ref this.m_calculadoresVisuales, this.m_emocionesDeOwner, ref this.m_calculadoresVisualesDEbug);
			FearPorCambioDeEmociones.LoadLista<ICalculadorDeEstimuloTactil>(ref this.m_calculadoresTactiles, this.m_emocionesDeOwner, ref this.m_calculadoresTactilesDEbug);
			FearPorCambioDeEmociones.LoadLista<ICalculadorDeEstimuloPorDesvestir>(ref this.m_calculadoresDesvestir, this.m_emocionesDeOwner, ref this.m_calculadoresDesvestirDEbug);
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
		}

		// Token: 0x06001F6A RID: 8042 RVA: 0x00076A80 File Offset: 0x00074C80
		public static void LoadLista<T>(ref List<T> target, EmocionesFemeninas emocionesDeOwner, ref List<Object> debug) where T : ICalculadorDeEstimulo
		{
			target = new List<T>();
			emocionesDeOwner.GetComponentsInChildren<T>(false, target);
			target.RemoveAll((T c) => c.tipo != TipoDeCalculadorDeEstimulo.frame || (c.emo.reaccion != ReaccionHumana.dolor && c.emo.reaccion != ReaccionHumana.rabia));
			if (Application.isEditor)
			{
				debug = new List<Object>();
				for (int i = 0; i < target.Count; i++)
				{
					debug.Add(target[i] as Object);
				}
			}
		}

		// Token: 0x06001F6B RID: 8043 RVA: 0x00076AFD File Offset: 0x00074CFD
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Fear;
		}

		// Token: 0x06001F6C RID: 8044 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x06001F6D RID: 8045 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void Updating(float deltaTime)
		{
		}

		// Token: 0x06001F6E RID: 8046 RVA: 0x00076B08 File Offset: 0x00074D08
		protected override void DoUpdate(ref float generadoNoLimitado, ref float generadoLimitado, ref float cambiarValorDeEmocionDespuesDeTiempoMod, float deltaTime)
		{
			for (int i = 0; i < this.m_resultados.Count; i++)
			{
				IClearable clearable = this.m_resultados[i].Item1 as IClearable;
				if (clearable != null)
				{
					clearable.Clear();
				}
			}
			this.m_resultados.Clear();
			this.m_masFuerte = null;
			float num = 0f;
			float num2 = 0f;
			FearPorCambioDeEmociones.ProcesarCalculadores<ICalculadorDeEstimuloCoital, ICalculoDeEstimuloCoitalHole, EstimuloPenetrante>(this.m_calculadoresCoitales, this.m_ConsentForzado, this.m_DesHielo, this.config, this.m_resultadosSegunCalculadores, this.m_fear, this.m_resultados, ref num, ref num2);
			FearPorCambioDeEmociones.ProcesarCalculadores<ICalculadorDeEstimuloVisual, ICalculoDeEstimuloVisual, EstimuloVisual>(this.m_calculadoresVisuales, this.m_ConsentForzado, this.m_DesHielo, this.config, this.m_resultadosSegunCalculadores, this.m_fear, this.m_resultados, ref num, ref num2);
			FearPorCambioDeEmociones.ProcesarCalculadores<ICalculadorDeEstimuloTactil, ICalculoDeEstimuloTactil, EstimuloTactil>(this.m_calculadoresTactiles, this.m_ConsentForzado, this.m_DesHielo, this.config, this.m_resultadosSegunCalculadores, this.m_fear, this.m_resultados, ref num, ref num2);
			FearPorCambioDeEmociones.ProcesarCalculadores<ICalculadorDeEstimuloPorDesvestir, ICalculoDeEstimuloPorDesvestir, EstimuloPorDesvestir>(this.m_calculadoresDesvestir, this.m_ConsentForzado, this.m_DesHielo, this.config, this.m_resultadosSegunCalculadores, this.m_fear, this.m_resultados, ref num, ref num2);
			if (this.m_fear.value.total >= 100f)
			{
				num2 = 0f;
			}
			generadoNoLimitado = num;
			generadoLimitado = num2;
			float num3 = 0f;
			ICalculoDeEstimulo calculoDeEstimulo = null;
			for (int j = 0; j < this.m_resultados.Count; j++)
			{
				ValueTuple<ICalculoDeEstimulo, float> valueTuple = this.m_resultados[j];
				float item = valueTuple.Item2;
				if (item > num3)
				{
					calculoDeEstimulo = valueTuple.Item1;
					num3 = item;
				}
			}
			if (num3 > 0f && calculoDeEstimulo != null)
			{
				this.m_masFuerte = calculoDeEstimulo;
			}
		}

		// Token: 0x06001F6F RID: 8047 RVA: 0x00076CC0 File Offset: 0x00074EC0
		public static void ProcesarCalculadores<T_Calculador, TCalculo, TEstimulo>(IReadOnlyList<T_Calculador> m_calculadores, ConsentCorrupted consentForzado, DesHielo desHielo, FearPorCambioDeEmociones.Configuracion config, Dictionary<ICalculadorDeEstimulo, ICalculoDeEstimulo> resultadosSegunCalculadores, Fear fear, List<ValueTuple<ICalculoDeEstimulo, float>> resultados, ref float generadoNoLimitadoNested, ref float generadoLimitadoNested) where T_Calculador : ICalculadorDeEstimulo<TCalculo> where TCalculo : ICalculoDeEstimulo, IClearable, ICalculoDeEstimuloConEstado, ICalculoDeEstimulo<TEstimulo> where TEstimulo : InteracionEstimulanteBasica
		{
			for (int i = 0; i < m_calculadores.Count; i++)
			{
				T_Calculador t_Calculador = m_calculadores[i];
				if (t_Calculador.estimuloExisteEnFrame)
				{
					TCalculo calculoMasFuerte = t_Calculador.calculoMasFuerte;
					UmbralBasico.Estado estado = calculoMasFuerte.EstadoMasFuerte();
					float valor = FearPorCambioDeEmociones.GetValor(consentForzado, desHielo, config, estado, calculoMasFuerte);
					if (valor > 0f)
					{
						if (calculoMasFuerte.estimulo.tipoDeEstimulo == TipoDeEstimulo.None)
						{
							throw new NotSupportedException();
						}
						ICalculoDeEstimulo calculoDeEstimulo;
						if (resultadosSegunCalculadores.TryGetValue(t_Calculador, out calculoDeEstimulo))
						{
							(calculoMasFuerte as ICopiableA).CopiarA(calculoDeEstimulo);
							UmbralBasico.Estado estado2 = estado;
							estado2.SobreEscribirEstimulacionGeneradaEnFrame(valor, valor, 1f);
							(calculoDeEstimulo as ICalculoDeEstimuloConEstado).SobreEscribirEstadoMasFuerte(estado2);
							calculoDeEstimulo.emocion = fear;
							resultados.Add(new ValueTuple<ICalculoDeEstimulo, float>(calculoDeEstimulo, valor));
						}
						float num = valor;
						generadoLimitadoNested += num;
						generadoNoLimitadoNested += num;
					}
				}
			}
		}

		// Token: 0x06001F70 RID: 8048 RVA: 0x00076DCC File Offset: 0x00074FCC
		public static float GetValor(ConsentCorrupted consentForzado, DesHielo desHielo, FearPorCambioDeEmociones.Configuracion config, UmbralBasico.Estado estado, ICalculoDeInteracionEstimulante calculo)
		{
			if (((calculo != null) ? calculo.emocion : null) == null)
			{
				return 0f;
			}
			float num;
			switch (calculo.estimuloBasico.tipoDeEstimulo.GetTipoBasico())
			{
			case TipoDeEstimuloBasico.visual:
				num = config.modPorVisuales;
				goto IL_0096;
			case TipoDeEstimuloBasico.verbal:
				num = config.modPorVerbales;
				goto IL_0096;
			case TipoDeEstimuloBasico.tactil:
				num = config.modPorTactiles;
				goto IL_0096;
			case TipoDeEstimuloBasico.coital:
				num = config.modPorCoitales;
				goto IL_0096;
			}
			throw new ArgumentOutOfRangeException(calculo.estimuloBasico.tipoDeEstimulo.GetTipoBasico().ToString());
			IL_0096:
			float num2 = (consentForzado.EsCorrupted(calculo) ? 0.1f : 1f);
			float num3 = ((calculo.tag == "golpe") ? config.modPorTagHit : 1f);
			ValueTuple<int, int, int, int> valueTuple;
			float num4 = Mathf.Lerp(1f, config.disminucionPorDesHieloMax, (desHielo.ObtenerValor(calculo, out valueTuple) / 100f).InPow(3f));
			return estado.estimulacionGeneradaEnFrame * config.aumentoPorEstimulacionGenerada * num * num3 * num2 * num4;
		}

		// Token: 0x040014B4 RID: 5300
		private DesHielo m_DesHielo;

		// Token: 0x040014B5 RID: 5301
		private Fear m_fear;

		// Token: 0x040014B6 RID: 5302
		private ConsentCorrupted m_ConsentForzado;

		// Token: 0x040014B7 RID: 5303
		private List<ICalculadorDeEstimuloCoital> m_calculadoresCoitales;

		// Token: 0x040014B8 RID: 5304
		private List<ICalculadorDeEstimuloVisual> m_calculadoresVisuales;

		// Token: 0x040014B9 RID: 5305
		private List<ICalculadorDeEstimuloTactil> m_calculadoresTactiles;

		// Token: 0x040014BA RID: 5306
		private List<ICalculadorDeEstimuloPorDesvestir> m_calculadoresDesvestir;

		// Token: 0x040014BB RID: 5307
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_calculadoresCoitalesDEbug;

		// Token: 0x040014BC RID: 5308
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_calculadoresVisualesDEbug;

		// Token: 0x040014BD RID: 5309
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_calculadoresTactilesDEbug;

		// Token: 0x040014BE RID: 5310
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_calculadoresDesvestirDEbug;

		// Token: 0x040014BF RID: 5311
		private Dictionary<ICalculadorDeEstimulo, ICalculoDeEstimulo> m_resultadosSegunCalculadores = new Dictionary<ICalculadorDeEstimulo, ICalculoDeEstimulo>();

		// Token: 0x040014C0 RID: 5312
		private List<ValueTuple<ICalculoDeEstimulo, float>> m_resultados = new List<ValueTuple<ICalculoDeEstimulo, float>>();

		// Token: 0x040014C1 RID: 5313
		private ICalculoDeEstimulo m_masFuerte;

		// Token: 0x02000512 RID: 1298
		[Serializable]
		public class Configuracion
		{
			// Token: 0x040014C2 RID: 5314
			public float modPorVisuales = 2f;

			// Token: 0x040014C3 RID: 5315
			public float modPorVerbales = 1.5f;

			// Token: 0x040014C4 RID: 5316
			public float modPorTactiles = 1f;

			// Token: 0x040014C5 RID: 5317
			public float modPorCoitales = 0.25f;

			// Token: 0x040014C6 RID: 5318
			public float modPorTagHit = 2f;

			// Token: 0x040014C7 RID: 5319
			public float aumentoPorEstimulacionGenerada = 2f;

			// Token: 0x040014C8 RID: 5320
			public float disminucionPorDesHieloMax = 0.1f;
		}
	}
}
