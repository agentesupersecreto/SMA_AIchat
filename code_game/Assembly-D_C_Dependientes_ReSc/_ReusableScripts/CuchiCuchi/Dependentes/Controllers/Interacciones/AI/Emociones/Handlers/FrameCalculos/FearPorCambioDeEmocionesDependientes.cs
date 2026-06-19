using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x020001FF RID: 511
	[Obsolete("fear es igual q rage", true)]
	[RequireComponent(typeof(FearPorCambioDeEmociones))]
	public class FearPorCambioDeEmocionesDependientes : CalculoDeEstimuloEnFrame<FearPorCambioDeEmociones.Configuracion>
	{
		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000C92 RID: 3218 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.None;
			}
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000C93 RID: 3219 RVA: 0x000066D6 File Offset: 0x000048D6
		[Obsolete("", true)]
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x0003A85C File Offset: 0x00038A5C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_FearPorCambioDeEmociones = base.GetComponent<FearPorCambioDeEmociones>();
			this.m_DesHielo = this.GetComponentEnRoot(false);
			this.m_fear = this.GetComponentEnRoot(false);
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_DesHielo == null)
			{
				throw new ArgumentNullException("m_DesHielo", "m_DesHielo null reference.");
			}
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
			if (this.m_fear == null)
			{
				throw new ArgumentNullException("m_fear", "m_fear null reference.");
			}
			FearPorCambioDeEmociones.LoadLista<ICalculadorDeEstimuloDeCambioDePose>(ref this.m_calculadoresCambioDePose, this.m_emocionesDeOwner, ref this.m_calculadoresCambioDePoseDEbug);
			FearPorCambioDeEmociones.LoadLista<ICalculadorDeEstimuloDeMovimientoDeBones>(ref this.m_calculadoresMovimientoDeBone, this.m_emocionesDeOwner, ref this.m_calculadoresMovimientoDeBoneDEbug);
			foreach (ICalculadorDeEstimuloDeCambioDePose calculadorDeEstimuloDeCambioDePose in this.m_calculadoresCambioDePose)
			{
				ICalculoDeEstimuloPorCambioDePose calculoDeEstimuloPorCambioDePose;
				if (calculadorDeEstimuloDeCambioDePose.TryInstantiateCalculo(out calculoDeEstimuloPorCambioDePose) && calculoDeEstimuloPorCambioDePose is ICopiableA && calculoDeEstimuloPorCambioDePose != null && calculoDeEstimuloPorCambioDePose != null)
				{
					this.m_resultadosSegunCalculadores.Add(calculadorDeEstimuloDeCambioDePose, calculoDeEstimuloPorCambioDePose);
					calculoDeEstimuloPorCambioDePose.Clear();
				}
			}
			foreach (ICalculadorDeEstimuloDeMovimientoDeBones calculadorDeEstimuloDeMovimientoDeBones in this.m_calculadoresMovimientoDeBone)
			{
				ICalculoDeEstimuloPorMovimientoDeBones calculoDeEstimuloPorMovimientoDeBones;
				if (calculadorDeEstimuloDeMovimientoDeBones.TryInstantiateCalculo(out calculoDeEstimuloPorMovimientoDeBones) && calculoDeEstimuloPorMovimientoDeBones is ICopiableA && calculoDeEstimuloPorMovimientoDeBones != null && calculoDeEstimuloPorMovimientoDeBones != null)
				{
					this.m_resultadosSegunCalculadores.Add(calculadorDeEstimuloDeMovimientoDeBones, calculoDeEstimuloPorMovimientoDeBones);
					calculoDeEstimuloPorMovimientoDeBones.Clear();
				}
			}
			this.config = this.m_FearPorCambioDeEmociones.config;
		}

		// Token: 0x06000C95 RID: 3221 RVA: 0x0003AA14 File Offset: 0x00038C14
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Fear;
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x000380AB File Offset: 0x000362AB
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void Updating(float deltaTime)
		{
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x0003AA20 File Offset: 0x00038C20
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
			FearPorCambioDeEmociones.ProcesarCalculadores<ICalculadorDeEstimuloDeCambioDePose, ICalculoDeEstimuloPorCambioDePose, EstimuloPorCambiarPose>(this.m_calculadoresCambioDePose, this.m_ConsentForzado, this.m_DesHielo, this.m_FearPorCambioDeEmociones.config, this.m_resultadosSegunCalculadores, this.m_fear, this.m_resultados, ref num, ref num2);
			FearPorCambioDeEmociones.ProcesarCalculadores<ICalculadorDeEstimuloDeMovimientoDeBones, ICalculoDeEstimuloPorMovimientoDeBones, EstimuloPorManipulacionDeBone>(this.m_calculadoresMovimientoDeBone, this.m_ConsentForzado, this.m_DesHielo, this.m_FearPorCambioDeEmociones.config, this.m_resultadosSegunCalculadores, this.m_fear, this.m_resultados, ref num, ref num2);
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

		// Token: 0x040008DE RID: 2270
		private DesHielo m_DesHielo;

		// Token: 0x040008DF RID: 2271
		private Fear m_fear;

		// Token: 0x040008E0 RID: 2272
		private ConsentCorrupted m_ConsentForzado;

		// Token: 0x040008E1 RID: 2273
		private FearPorCambioDeEmociones m_FearPorCambioDeEmociones;

		// Token: 0x040008E2 RID: 2274
		private List<ICalculadorDeEstimuloDeCambioDePose> m_calculadoresCambioDePose;

		// Token: 0x040008E3 RID: 2275
		private List<ICalculadorDeEstimuloDeMovimientoDeBones> m_calculadoresMovimientoDeBone;

		// Token: 0x040008E4 RID: 2276
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_calculadoresCambioDePoseDEbug;

		// Token: 0x040008E5 RID: 2277
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_calculadoresMovimientoDeBoneDEbug;

		// Token: 0x040008E6 RID: 2278
		private Dictionary<ICalculadorDeEstimulo, ICalculoDeEstimulo> m_resultadosSegunCalculadores = new Dictionary<ICalculadorDeEstimulo, ICalculoDeEstimulo>();

		// Token: 0x040008E7 RID: 2279
		private List<ValueTuple<ICalculoDeEstimulo, float>> m_resultados = new List<ValueTuple<ICalculoDeEstimulo, float>>();

		// Token: 0x040008E8 RID: 2280
		private ICalculoDeEstimulo m_masFuerte;
	}
}
