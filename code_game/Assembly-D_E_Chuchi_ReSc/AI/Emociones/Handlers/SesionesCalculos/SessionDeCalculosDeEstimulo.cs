using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004AA RID: 1194
	public abstract class SessionDeCalculosDeEstimulo<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable> : SessionDeEstimulo, ICalculadorDeEstimulo<TCalculoResult>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeSessionDeTipoConResultado<TCalculoResult, TEstimulo, T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable>, ICalculadorDeSessionDeTipo<T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable>, ICalculadorDeSession, ICalculadorDeSessionConResultadoDeCalculosDeEstimulo<TCalculoResult, TEstimulo>, ICalculadorDeSessionConResultado<TCalculoResult, TEstimulo>, ICalculadorDeSessionDeCalculosDeEstimulo<TEstimulo> where TCalculador : ICalculadorDeEstimulo<TCalculoResult>, IActivable where TCalculoResult : ICalculoDeEstimulo<TEstimulo>, ICalculoDeEstimuloGenerando, IConvinable, IClearable, ICopiableA, ICalculoDeEstimuloDeParteEstimulante, ICalculoDeEstimuloPrioridadModificable, new() where TSelf : SessionDeCalculosDeEstimulo<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable> where TResultWrapper : SessionDeCalculosDeEstimulo<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable>.ResultadoDeSession, IClearable, new() where TEstimulo : InteracionEstimulanteBasica where T_TipoDeEstimuloEnumerable : struct where T_DireccionDeEstimuloEnumerable : struct
	{
		// Token: 0x17000784 RID: 1924
		// (get) Token: 0x06001C2A RID: 7210 RVA: 0x000704B4 File Offset: 0x0006E6B4
		public int cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil
		{
			get
			{
				if (!this.estimuloExisteEnFrame)
				{
					return 0;
				}
				return 1;
			}
		}

		// Token: 0x17000785 RID: 1925
		// (get) Token: 0x06001C2B RID: 7211 RVA: 0x000704B4 File Offset: 0x0006E6B4
		public int cantidadDeCalculosEnFrame
		{
			get
			{
				if (!this.estimuloExisteEnFrame)
				{
					return 0;
				}
				return 1;
			}
		}

		// Token: 0x06001C2C RID: 7212 RVA: 0x000704C1 File Offset: 0x0006E6C1
		public TCalculoResult GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			return (TCalculoResult)((object)this.GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(index));
		}

		// Token: 0x06001C2D RID: 7213 RVA: 0x000704C1 File Offset: 0x0006E6C1
		public TCalculoResult GetCalculoEnFrame(int index)
		{
			return (TCalculoResult)((object)this.GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(index));
		}

		// Token: 0x06001C2E RID: 7214 RVA: 0x000704D0 File Offset: 0x0006E6D0
		public ICalculoDeEstimulo GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(int index)
		{
			if (!this.estimuloExisteEnFrame)
			{
				return default(TCalculoResult);
			}
			if (index == 0)
			{
				return this.m_result.calculoAcumulado;
			}
			return default(TCalculoResult);
		}

		// Token: 0x06001C2F RID: 7215 RVA: 0x0007051B File Offset: 0x0006E71B
		public ICalculoDeEstimulo GetCalculoEnFrameBase(int index)
		{
			return this.GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(index);
		}

		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x06001C30 RID: 7216 RVA: 0x00070524 File Offset: 0x0006E724
		public TCalculoResult resultado
		{
			get
			{
				return this.m_result.calculoAcumulado;
			}
		}

		// Token: 0x17000787 RID: 1927
		// (get) Token: 0x06001C31 RID: 7217 RVA: 0x00070536 File Offset: 0x0006E736
		public ICalculoDeEstimulo<TEstimulo> calculoDeEstimulo
		{
			get
			{
				return this.m_result.calculoAcumulado;
			}
		}

		// Token: 0x17000788 RID: 1928
		// (get) Token: 0x06001C32 RID: 7218 RVA: 0x0007054D File Offset: 0x0006E74D
		double ICalculadorDeEstimulo.prioridad
		{
			get
			{
				return this.m_prioridad * this.ObtenerPrioridad() * Emocion.APrioridad(this.emocion);
			}
		}

		// Token: 0x17000789 RID: 1929
		// (get) Token: 0x06001C33 RID: 7219 RVA: 0x00070524 File Offset: 0x0006E724
		[Obsolete("", true)]
		TCalculoResult ICalculadorDeEstimulo<TCalculoResult>.calculoMasFuerte
		{
			get
			{
				return this.m_result.calculoAcumulado;
			}
		}

		// Token: 0x06001C34 RID: 7220 RVA: 0x00070568 File Offset: 0x0006E768
		void ICalculadorDeEstimulo<TCalculoResult>.GetCalculosDelMasFuerteAlMasDebil(IList<TCalculoResult> resultado)
		{
			resultado.Add(this.m_result.calculoAcumulado);
		}

		// Token: 0x1700078A RID: 1930
		// (get) Token: 0x06001C35 RID: 7221 RVA: 0x00070536 File Offset: 0x0006E736
		[Obsolete("", true)]
		ICalculoDeEstimulo ICalculadorDeEstimuloConCalculos.calculoMasFuerteBase
		{
			get
			{
				return this.m_result.calculoAcumulado;
			}
		}

		// Token: 0x1700078B RID: 1931
		// (get) Token: 0x06001C36 RID: 7222 RVA: 0x00070580 File Offset: 0x0006E780
		Emocion ICalculadorDeEstimulo.emo
		{
			get
			{
				return this.emocion;
			}
		}

		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x06001C37 RID: 7223 RVA: 0x00070588 File Offset: 0x0006E788
		[Obsolete("", true)]
		bool ICalculadorDeEstimuloConCalculos.estimuloExisteEnFrame
		{
			get
			{
				return this.estimuloExisteEnFrame;
			}
		}

		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x06001C38 RID: 7224 RVA: 0x00070590 File Offset: 0x0006E790
		protected bool estimuloExisteEnFrame
		{
			get
			{
				return this.m_result.estado > ResultadoDeSessionBase.Estado.fuera;
			}
		}

		// Token: 0x1700078E RID: 1934
		// (get) Token: 0x06001C39 RID: 7225 RVA: 0x000705A5 File Offset: 0x0006E7A5
		public bool enSession
		{
			get
			{
				return this.m_enSession;
			}
		}

		// Token: 0x1700078F RID: 1935
		// (get) Token: 0x06001C3A RID: 7226 RVA: 0x000705AD File Offset: 0x0006E7AD
		public float duracion
		{
			get
			{
				if (this.m_tiempoDeInicioDeSession == null)
				{
					return 0f;
				}
				return Time.time - this.m_tiempoDeInicioDeSession.Value;
			}
		}

		// Token: 0x17000790 RID: 1936
		// (get) Token: 0x06001C3B RID: 7227
		public abstract TipoDeCalculadorDeEstimulo tipo { get; }

		// Token: 0x17000791 RID: 1937
		// (get) Token: 0x06001C3C RID: 7228
		public abstract T_TipoDeEstimuloEnumerable tipoDeEstimuloEnumerableV2 { get; }

		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x06001C3D RID: 7229
		public abstract T_DireccionDeEstimuloEnumerable direccionDeEstimuloEnumerableV2 { get; }

		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x06001C3E RID: 7230 RVA: 0x000705D3 File Offset: 0x0006E7D3
		public TResultWrapper current
		{
			get
			{
				return this.m_result;
			}
		}

		// Token: 0x06001C3F RID: 7231 RVA: 0x000705DB File Offset: 0x0006E7DB
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.calculador = this.LoadCalculador();
			if (this.calculador == null)
			{
				throw new ArgumentNullException("calculador", "calculador null reference.");
			}
		}

		// Token: 0x06001C40 RID: 7232 RVA: 0x0007060C File Offset: 0x0006E80C
		protected virtual TCalculador LoadCalculador()
		{
			return base.GetComponentInParent<TCalculador>();
		}

		// Token: 0x06001C41 RID: 7233 RVA: 0x00070614 File Offset: 0x0006E814
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_result.Init((TSelf)((object)this));
		}

		// Token: 0x06001C42 RID: 7234 RVA: 0x00070634 File Offset: 0x0006E834
		protected override void OnEmocionesUpdating()
		{
			if (Application.isEditor)
			{
				this.m_duracionDebug = 0f;
			}
			SessionDeCalculosDeEstimulo<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable>.IResultado resultado = this.m_result;
			if (!this.m_enSession)
			{
				this.m_result.Clear();
				TCalculoResult tcalculoResult;
				if (this.SessionPuedeComenzar(out tcalculoResult))
				{
					this.m_enSession = true;
					this.m_tiempoDeInicioDeSession = new float?(Time.time);
					resultado.Acumular(tcalculoResult, this);
					resultado.SetEstado(ResultadoDeSessionBase.Estado.comenzando);
					this.onSesionStart();
				}
				return;
			}
			if (this.SessionFinaliza())
			{
				this.m_enSession = false;
				this.m_tiempoDeInicioDeSession = null;
				resultado.SetEstado(ResultadoDeSessionBase.Estado.terminando);
				this.onSesionEnd();
				return;
			}
			TCalculoResult tcalculoResult2 = default(TCalculoResult);
			if (this.calculador.activado && this.calculador.cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil > 0 && this.AlgunCalculoAcumulable(out tcalculoResult2))
			{
				resultado.Acumular(tcalculoResult2, this);
				if (this.debugPrint)
				{
					MonoBehaviour.print(string.Concat(new string[]
					{
						" sesion ",
						base.name,
						" de calculador ",
						this.calculador.name,
						" ha acumulado"
					}));
				}
			}
			resultado.SetEstado(ResultadoDeSessionBase.Estado.activa);
			this.onSesionStay(tcalculoResult2);
			if (Application.isEditor)
			{
				this.m_duracionDebug = this.duracion;
			}
		}

		// Token: 0x06001C43 RID: 7235 RVA: 0x00070788 File Offset: 0x0006E988
		private bool SessionPuedeComenzar(out TCalculoResult calculo)
		{
			calculo = default(TCalculoResult);
			if (this.m_enSession)
			{
				throw new InvalidOperationException();
			}
			if (!this.calculador.activado || this.calculador.cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil == 0)
			{
				this.m_tiempoDelPrimerEstimulo = null;
				return false;
			}
			if (!this.AlgunCalculoAcumulable(out calculo))
			{
				this.m_tiempoDelPrimerEstimulo = null;
				return false;
			}
			if (this.m_tiempoDelPrimerEstimulo == null)
			{
				this.m_tiempoDelPrimerEstimulo = new float?(Time.time);
				if (base.baseConfig.tiempoNecesarioParaComenzarSession > 0f)
				{
					return false;
				}
			}
			if (Time.time - this.m_tiempoDelPrimerEstimulo.Value >= base.baseConfig.tiempoNecesarioParaComenzarSession)
			{
				this.m_tiempoDelPrimerEstimulo = null;
				return true;
			}
			return false;
		}

		// Token: 0x06001C44 RID: 7236 RVA: 0x00070854 File Offset: 0x0006EA54
		private bool SessionFinaliza()
		{
			if (!this.m_enSession)
			{
				throw new InvalidOperationException();
			}
			if (this.m_tiempoDeInicioDeSession == null)
			{
				throw new InvalidOperationException();
			}
			if (Time.time - this.m_tiempoDeInicioDeSession.Value >= base.baseConfig.maximoTiempoDeDuracion)
			{
				this.m_tiempoDelUltimoEstimulo = null;
				return true;
			}
			TCalculoResult tcalculoResult;
			if (this.calculador.activado && this.calculador.cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil != 0 && this.AlgunCalculoAcumulable(out tcalculoResult))
			{
				this.m_tiempoDelUltimoEstimulo = new float?(Time.time);
				return false;
			}
			if (this.m_tiempoDelUltimoEstimulo == null)
			{
				this.m_tiempoDelUltimoEstimulo = new float?(Time.time);
				return false;
			}
			if (Time.time - this.m_tiempoDelUltimoEstimulo.Value >= base.baseConfig.maximoTiempoDeInactividadParaTerminarSesion)
			{
				this.m_tiempoDelUltimoEstimulo = null;
				return true;
			}
			return false;
		}

		// Token: 0x06001C45 RID: 7237 RVA: 0x0007093C File Offset: 0x0006EB3C
		private bool AlgunCalculoAcumulable(out TCalculoResult calculo)
		{
			bool flag;
			try
			{
				for (int i = 0; i < this.calculador.cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil; i++)
				{
					this.m_calculosTemp.Add(this.calculador.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(i));
				}
				flag = this.AlgunCalculoAcumulable(this.m_calculosTemp, out calculo);
			}
			finally
			{
				this.m_calculosTemp.Clear();
			}
			return flag;
		}

		// Token: 0x06001C46 RID: 7238 RVA: 0x000709B0 File Offset: 0x0006EBB0
		protected virtual bool AlgunCalculoAcumulable(List<TCalculoResult> calculos, out TCalculoResult calculo)
		{
			for (int i = 0; i < this.m_calculosTemp.Count; i++)
			{
				TCalculoResult tcalculoResult = this.m_calculosTemp[i];
				if (this.CalculoEsAcumulable(tcalculoResult))
				{
					calculo = tcalculoResult;
					return true;
				}
			}
			calculo = default(TCalculoResult);
			return false;
		}

		// Token: 0x06001C47 RID: 7239 RVA: 0x000709FA File Offset: 0x0006EBFA
		protected bool CalculoEsAcumulable(TCalculoResult calculo)
		{
			return calculo != null && this.CalculoEsDeTipoEnumerable(this.tipoDeEstimuloEnumerableV2, this.direccionDeEstimuloEnumerableV2, calculo) && this.EsAcumulable(calculo);
		}

		// Token: 0x06001C48 RID: 7240
		protected abstract double ObtenerPrioridad();

		// Token: 0x06001C49 RID: 7241
		protected abstract bool CalculoEsDeTipoEnumerable(T_TipoDeEstimuloEnumerable tipo, T_DireccionDeEstimuloEnumerable direccion, TCalculoResult calculo);

		// Token: 0x06001C4A RID: 7242
		protected abstract bool EsAcumulable(TCalculoResult calculo);

		// Token: 0x06001C4B RID: 7243
		protected abstract void Acumuladondo(TResultWrapper resultado, TCalculoResult resultadoAcumulado, TCalculoResult acumulando);

		// Token: 0x06001C4C RID: 7244
		protected abstract void Acumulado(TResultWrapper resultado, TCalculoResult resultadoAcumulado, TCalculoResult acumulando);

		// Token: 0x06001C4D RID: 7245 RVA: 0x00070A24 File Offset: 0x0006EC24
		private void onSesionStart()
		{
			if (this.debugPrint)
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					" sesion ",
					base.name,
					" de calculador ",
					this.calculador.name,
					" ha comenzado"
				}));
			}
			this.OnSesionStarted();
			Action<TSelf> action = this.sessionStared;
			if (action == null)
			{
				return;
			}
			action((TSelf)((object)this));
		}

		// Token: 0x06001C4E RID: 7246 RVA: 0x00070A9C File Offset: 0x0006EC9C
		private void onSesionStay(TCalculoResult acumulable)
		{
			if (this.debugPrint)
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					" sesion: ",
					base.name,
					" de cal: ",
					this.calculador.name,
					" stay. Acu: ",
					((acumulable != null) ? new float?(acumulable.estimuloGeneradoEnFrame) : null).ToString()
				}));
			}
			this.OnSesionStayed();
			Action<TSelf> action = this.sessionStayed;
			if (action == null)
			{
				return;
			}
			action((TSelf)((object)this));
		}

		// Token: 0x06001C4F RID: 7247 RVA: 0x00070B48 File Offset: 0x0006ED48
		private void onSesionEnd()
		{
			if (this.debugPrint)
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					" sesion ",
					base.name,
					" de calculador ",
					this.calculador.name,
					" ha terminado"
				}));
			}
			this.OnSesionEnded();
			Action<TSelf> action = this.sessionEnded;
			if (action == null)
			{
				return;
			}
			action((TSelf)((object)this));
		}

		// Token: 0x06001C50 RID: 7248
		protected abstract void OnSesionStarted();

		// Token: 0x06001C51 RID: 7249
		protected abstract void OnSesionStayed();

		// Token: 0x06001C52 RID: 7250
		protected abstract void OnSesionEnded();

		// Token: 0x06001C53 RID: 7251 RVA: 0x00070BBE File Offset: 0x0006EDBE
		public bool TryInstantiateCalculo(out TCalculoResult calculo)
		{
			return this.calculador.TryInstantiateCalculo(out calculo);
		}

		// Token: 0x06001C54 RID: 7252 RVA: 0x00070BD2 File Offset: 0x0006EDD2
		public bool TryInstantiateCalculoBase(out ICalculoDeEstimulo calculo)
		{
			return this.calculador.TryInstantiateCalculoBase(out calculo);
		}

		// Token: 0x06001C56 RID: 7254 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001C57 RID: 7255 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001C58 RID: 7256 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001C59 RID: 7257 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001C5A RID: 7258 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001C5B RID: 7259 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x040013D2 RID: 5074
		[SerializeField]
		[ReadOnlyUI]
		private TCalculador calculador;

		// Token: 0x040013D3 RID: 5075
		[SerializeField]
		[ReadOnlyUI]
		private bool m_enSession;

		// Token: 0x040013D4 RID: 5076
		[SerializeField]
		[ReadOnlyUI]
		private float m_duracionDebug;

		// Token: 0x040013D5 RID: 5077
		[SerializeField]
		private bool debugPrint;

		// Token: 0x040013D6 RID: 5078
		private float? m_tiempoDeInicioDeSession;

		// Token: 0x040013D7 RID: 5079
		private float? m_tiempoDelPrimerEstimulo;

		// Token: 0x040013D8 RID: 5080
		private float? m_tiempoDelUltimoEstimulo;

		// Token: 0x040013D9 RID: 5081
		public Action<TSelf> sessionStared;

		// Token: 0x040013DA RID: 5082
		public Action<TSelf> sessionStayed;

		// Token: 0x040013DB RID: 5083
		public Action<TSelf> sessionEnded;

		// Token: 0x040013DC RID: 5084
		[SerializeField]
		private TResultWrapper m_result = new TResultWrapper();

		// Token: 0x040013DD RID: 5085
		[Obsolete("Cooldown para acumulacion daña la cantidad total de estimulacion de la session", true)]
		private CoolDown m_coolDownAcumular;

		// Token: 0x040013DE RID: 5086
		private List<TCalculoResult> m_calculosTemp = new List<TCalculoResult>();

		// Token: 0x020004AB RID: 1195
		private interface IResultado : IClearable
		{
			// Token: 0x06001C5C RID: 7260
			void Acumular(TCalculoResult calculo, SessionDeCalculosDeEstimulo<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable> productor);

			// Token: 0x06001C5D RID: 7261
			void SetEstado(ResultadoDeSessionBase.Estado stado);
		}

		// Token: 0x020004AC RID: 1196
		public abstract class ResultadoDeSession : ResultadoDeSessionBase, SessionDeCalculosDeEstimulo<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable>.IResultado, IClearable
		{
			// Token: 0x06001C5E RID: 7262 RVA: 0x00070C04 File Offset: 0x0006EE04
			public virtual void Init(TSelf parent)
			{
				this.m_parent = parent;
				this.m_calculoAcumulado = new TCalculoResult();
				this.OnPropiaInstanciaCreada(this.m_calculoAcumulado);
			}

			// Token: 0x17000794 RID: 1940
			// (get) Token: 0x06001C5F RID: 7263 RVA: 0x00070C24 File Offset: 0x0006EE24
			public TCalculoResult calculoAcumulado
			{
				get
				{
					return this.m_calculoAcumulado;
				}
			}

			// Token: 0x06001C60 RID: 7264 RVA: 0x00003B39 File Offset: 0x00001D39
			protected virtual void OnPropiaInstanciaCreada(TCalculoResult creada)
			{
			}

			// Token: 0x06001C61 RID: 7265 RVA: 0x00070C2C File Offset: 0x0006EE2C
			protected void Acumular(TCalculoResult calculo, SessionDeCalculosDeEstimulo<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable> productor)
			{
				if (calculo == null)
				{
					throw new ArgumentNullException("calculo", "calculo null reference.");
				}
				if (productor.emocion == null)
				{
					throw new ArgumentNullException("productor.emocion", "productor.emocion null reference.");
				}
				this.m_parent.Acumuladondo((TResultWrapper)((object)this), this.m_calculoAcumulado, calculo);
				if (this.m_calculoAcumulado.emocion == null)
				{
					calculo.CopiarA(this.m_calculoAcumulado);
				}
				else
				{
					this.m_calculoAcumulado.emocion = productor.emocion;
					if (!this.m_calculoAcumulado.Convinable(calculo))
					{
						throw new NotSupportedException("calculos no son convinables");
					}
					this.m_calculoAcumulado.Convinar(calculo);
					this.m_calculoAcumulado.estimulo.ClearIgnorandoPartesEstimuladas();
					calculo.estimulo.CopiarA(this.m_calculoAcumulado.estimulo, true);
					if (calculo.estimulo.tieneCopiaInvertida)
					{
						this.m_calculoAcumulado.estimuloInvertido.ClearIgnorandoPartesEstimuladas();
						calculo.estimuloInvertido.CopiarA(this.m_calculoAcumulado.estimuloInvertido, true);
					}
				}
				this.m_calculoAcumulado.producidoPorSegundario = calculo.producidoPor;
				this.m_calculoAcumulado.producidoPor = productor;
				this.m_parent.Acumulado((TResultWrapper)((object)this), this.m_calculoAcumulado, calculo);
				this.OnAcumulado(calculo, productor);
			}

			// Token: 0x06001C62 RID: 7266 RVA: 0x00003B39 File Offset: 0x00001D39
			protected virtual void OnCleared()
			{
			}

			// Token: 0x06001C63 RID: 7267 RVA: 0x00003B39 File Offset: 0x00001D39
			protected virtual void OnAcumulado(TCalculoResult calculo, SessionDeCalculosDeEstimulo<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable> productor)
			{
			}

			// Token: 0x06001C64 RID: 7268 RVA: 0x00070E14 File Offset: 0x0006F014
			protected override void Clear()
			{
				base.Clear();
				ref TCalculoResult ptr = ref this.m_calculoAcumulado;
				TCalculoResult tcalculoResult = default(TCalculoResult);
				if (tcalculoResult == null)
				{
					tcalculoResult = this.m_calculoAcumulado;
					ptr = ref tcalculoResult;
					if (tcalculoResult == null)
					{
						goto IL_004A;
					}
				}
				TEstimulo testimulo = ptr.estimulo;
				if (testimulo != null)
				{
					testimulo.Clear();
				}
				IL_004A:
				ref TCalculoResult ptr2 = ref this.m_calculoAcumulado;
				tcalculoResult = default(TCalculoResult);
				if (tcalculoResult == null)
				{
					tcalculoResult = this.m_calculoAcumulado;
					ptr2 = ref tcalculoResult;
					if (tcalculoResult == null)
					{
						goto IL_008E;
					}
				}
				TEstimulo testimulo2 = ptr2.estimuloInvertido;
				if (testimulo2 != null)
				{
					testimulo2.Clear();
				}
				IL_008E:
				ref TCalculoResult ptr3 = ref this.m_calculoAcumulado;
				tcalculoResult = default(TCalculoResult);
				if (tcalculoResult == null)
				{
					tcalculoResult = this.m_calculoAcumulado;
					ptr3 = ref tcalculoResult;
					if (tcalculoResult == null)
					{
						goto IL_00C2;
					}
				}
				ptr3.Clear();
				IL_00C2:
				this.OnCleared();
			}

			// Token: 0x06001C65 RID: 7269 RVA: 0x00070EE9 File Offset: 0x0006F0E9
			void SessionDeCalculosDeEstimulo<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable>.IResultado.Acumular(TCalculoResult calculo, SessionDeCalculosDeEstimulo<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable> productor)
			{
				this.Acumular(calculo, productor);
			}

			// Token: 0x06001C66 RID: 7270 RVA: 0x00070EF3 File Offset: 0x0006F0F3
			void IClearable.Clear()
			{
				this.Clear();
			}

			// Token: 0x06001C67 RID: 7271 RVA: 0x00070EFC File Offset: 0x0006F0FC
			void SessionDeCalculosDeEstimulo<TCalculador, TCalculoResult, TSelf, TResultWrapper, TEstimulo, T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable>.IResultado.SetEstado(ResultadoDeSessionBase.Estado stado)
			{
				TipoDeCalculoDeEstimulo tipoDeCalculoDeEstimulo = TipoDeCalculoDeEstimulo.None;
				float num = 1f;
				switch (stado)
				{
				case ResultadoDeSessionBase.Estado.fuera:
					tipoDeCalculoDeEstimulo = TipoDeCalculoDeEstimulo.None;
					num = 0f;
					break;
				case ResultadoDeSessionBase.Estado.comenzando:
					tipoDeCalculoDeEstimulo = TipoDeCalculoDeEstimulo.sesionComienza;
					num = 10f;
					break;
				case ResultadoDeSessionBase.Estado.activa:
					tipoDeCalculoDeEstimulo = TipoDeCalculoDeEstimulo.sesionEnCurso;
					num = 5f;
					break;
				case ResultadoDeSessionBase.Estado.terminando:
					tipoDeCalculoDeEstimulo = TipoDeCalculoDeEstimulo.sesionTermina;
					num = 15f;
					break;
				}
				this.m_estado = stado;
				this.m_calculoAcumulado.tipo = tipoDeCalculoDeEstimulo;
				this.m_calculoAcumulado.prioridadMod = (double)num;
			}

			// Token: 0x040013DF RID: 5087
			protected TSelf m_parent;

			// Token: 0x040013E0 RID: 5088
			[SerializeField]
			private TCalculoResult m_calculoAcumulado;
		}
	}
}
