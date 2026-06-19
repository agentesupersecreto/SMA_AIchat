using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x020001FE RID: 510
	[RequireComponent(typeof(DesHieloPorCambioDeEmociones))]
	public sealed class DesHieloPorCambioDeEmocionesDependientes : CalculoDeEstimuloEnFrame<DesHieloPorCambioDeEmociones.Configuracion>, ICalculadorDeEstimuloConCalculosDeHielo, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000C81 RID: 3201 RVA: 0x00023F85 File Offset: 0x00022185
		[Obsolete("", true)]
		public bool estimuloExisteEnFrame
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000C82 RID: 3202 RVA: 0x00023F85 File Offset: 0x00022185
		[Obsolete("", true)]
		public ICalculoDeEstimulo calculoMasFuerteBase
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06000C83 RID: 3203 RVA: 0x0003A51E File Offset: 0x0003871E
		public int cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil
		{
			get
			{
				return this.m_calculosEnFrameMasFuerteADebil.Count;
			}
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06000C84 RID: 3204 RVA: 0x0003A51E File Offset: 0x0003871E
		public int cantidadDeCalculosEnFrame
		{
			get
			{
				return this.m_calculosEnFrameMasFuerteADebil.Count;
			}
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x0003A52B File Offset: 0x0003872B
		public ICalculoDeEstimulo GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(int index)
		{
			return this.m_calculosEnFrameMasFuerteADebil[index];
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x0003A52B File Offset: 0x0003872B
		public ICalculoDeEstimulo GetCalculoEnFrameBase(int index)
		{
			return this.m_calculosEnFrameMasFuerteADebil[index];
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x0003A539 File Offset: 0x00038739
		public bool TryInstantiateCalculoBase(out ICalculoDeEstimulo calculo)
		{
			calculo = null;
			return false;
		}

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06000C88 RID: 3208 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.None;
			}
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x0003A540 File Offset: 0x00038740
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_DesHieloPorCambioDeEmociones = base.GetComponent<DesHieloPorCambioDeEmociones>();
			DesHieloPorCambioDeEmociones.LoadLista<ICalculadorDeEstimuloDeCambioDePose>(ref this.m_calculadoresCambioDePose, this.m_emocionesDeOwner, ref this.m_calculadoresCambioDePoseDEbug);
			DesHieloPorCambioDeEmociones.LoadLista<ICalculadorDeEstimuloDeMovimientoDeBones>(ref this.m_calculadoresMovimientoDeBone, this.m_emocionesDeOwner, ref this.m_calculadoresMovimientoDeBoneDEbug);
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
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			this.config = this.m_DesHieloPorCambioDeEmociones.config;
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x0003A688 File Offset: 0x00038888
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_deshielo = base.GetComponentInParent<DesHielo>();
			this.m_Personalidad = this.GetComponentEnRoot(false);
		}

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000C8B RID: 3211 RVA: 0x000066D6 File Offset: 0x000048D6
		[Obsolete("", true)]
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x0003A6A9 File Offset: 0x000388A9
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is DesHielo;
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected sealed override void Updating(float deltaTime)
		{
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x0003A6B4 File Offset: 0x000388B4
		public float GetLastValue(ICalculoDeInteracionEstimulanteConEstado calculo, [TupleElementNames(new string[] { "estimulado", "tipoDeEstimulo", "direccion", "subTipoDeEstimulo" })] out ValueTuple<int, int, int, int> key)
		{
			ValueTuple<float, ValueTuple<int, int, int, int>> valueTuple = this.m_hieloValorBeforeUpdating[calculo];
			key = valueTuple.Item2;
			return valueTuple.Item1;
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x0003A6E0 File Offset: 0x000388E0
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
			if (this.generarPoses)
			{
				DesHieloPorCambioDeEmociones.ProcesarCalculadores<ICalculadorDeEstimuloDeCambioDePose, ICalculoDeEstimuloPorCambioDePose, EstimuloPorCambiarPose>(this, this.m_deshielo, this.m_calculadoresCambioDePose, this.config, this.m_modificablesDeInteraccio, this.m_resultadosSegunCalculadores, this.m_hieloValorBeforeUpdating, this.m_estimuloRepetidoEnFrame, this.m_calculosEnFrameMasFuerteADebil, ref num, ref num2);
			}
			if (this.generarManipulacion)
			{
				DesHieloPorCambioDeEmociones.ProcesarCalculadores<ICalculadorDeEstimuloDeMovimientoDeBones, ICalculoDeEstimuloPorMovimientoDeBones, EstimuloPorManipulacionDeBone>(this, this.m_deshielo, this.m_calculadoresMovimientoDeBone, this.config, this.m_modificablesDeInteraccio, this.m_resultadosSegunCalculadores, this.m_hieloValorBeforeUpdating, this.m_estimuloRepetidoEnFrame, this.m_calculosEnFrameMasFuerteADebil, ref num, ref num2);
			}
			if (this.m_deshielo.value.total >= 100f)
			{
				num2 = 0f;
			}
			generadoNoLimitado = num;
			generadoLimitado = num2;
			this.m_calculosEnFrameMasFuerteADebil.SortMasFuerteAlMasDebil();
		}

		// Token: 0x06000C90 RID: 3216 RVA: 0x000380AB File Offset: 0x000362AB
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x040008CE RID: 2254
		public bool generarPoses = true;

		// Token: 0x040008CF RID: 2255
		public bool generarManipulacion = true;

		// Token: 0x040008D0 RID: 2256
		private List<ICalculadorDeEstimuloDeCambioDePose> m_calculadoresCambioDePose;

		// Token: 0x040008D1 RID: 2257
		private List<ICalculadorDeEstimuloDeMovimientoDeBones> m_calculadoresMovimientoDeBone;

		// Token: 0x040008D2 RID: 2258
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_calculadoresCambioDePoseDEbug;

		// Token: 0x040008D3 RID: 2259
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_calculadoresMovimientoDeBoneDEbug;

		// Token: 0x040008D4 RID: 2260
		private DesHieloPorCambioDeEmociones m_DesHieloPorCambioDeEmociones;

		// Token: 0x040008D5 RID: 2261
		private DesHielo m_deshielo;

		// Token: 0x040008D6 RID: 2262
		private Personalidad m_Personalidad;

		// Token: 0x040008D7 RID: 2263
		private Dictionary<ICalculadorDeEstimulo, ICalculoDeInteracionEstimulanteConEstado> m_resultadosSegunCalculadores = new Dictionary<ICalculadorDeEstimulo, ICalculoDeInteracionEstimulanteConEstado>();

		// Token: 0x040008D8 RID: 2264
		[SerializeReference]
		private List<ICalculoDeInteracionEstimulanteConEstado> m_calculosEnFrameMasFuerteADebil = new List<ICalculoDeInteracionEstimulanteConEstado>();

		// Token: 0x040008D9 RID: 2265
		[TupleElementNames(new string[] { null, null, "estimulado", "tipoDeEstimulo", "direccion", "subTipoDeEstimulo" })]
		private Dictionary<ICalculoDeInteracionEstimulanteConEstado, ValueTuple<float, ValueTuple<int, int, int, int>>> m_hieloValorBeforeUpdating = new Dictionary<ICalculoDeInteracionEstimulanteConEstado, ValueTuple<float, ValueTuple<int, int, int, int>>>();

		// Token: 0x040008DA RID: 2266
		private HashSet<ValueTuple<int, int, int, int>> m_estimuloRepetidoEnFrame = new HashSet<ValueTuple<int, int, int, int>>();

		// Token: 0x040008DB RID: 2267
		[Obsolete("", true)]
		private List<ValueTuple<ICalculoDeEstimulo, float>> m_resultados = new List<ValueTuple<ICalculoDeEstimulo, float>>();

		// Token: 0x040008DC RID: 2268
		[Obsolete("", true)]
		private ICalculoDeEstimulo m_masFuerte;

		// Token: 0x040008DD RID: 2269
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
