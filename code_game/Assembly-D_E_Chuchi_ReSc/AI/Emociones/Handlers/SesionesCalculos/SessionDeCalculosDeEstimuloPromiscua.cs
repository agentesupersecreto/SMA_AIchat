using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004AF RID: 1199
	public abstract class SessionDeCalculosDeEstimuloPromiscua<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario> : SessionDeEstimulo, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TCalculador : ICalculadorDeEstimuloConCalculos, IActivable where TSelf : SessionDeCalculosDeEstimuloPromiscua<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario> where TResultWrapper : SessionDeCalculosDeEstimuloPromiscua<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario>.ResultadoDeSession, IClearable, new() where T_TipoDeEstimuloSegundario : struct
	{
		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x06001C6C RID: 7276 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("", true)]
		public bool estimuloExisteEnFrame
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x06001C6D RID: 7277 RVA: 0x00006060 File Offset: 0x00004260
		[Obsolete("", true)]
		ICalculoDeEstimulo ICalculadorDeEstimuloConCalculos.calculoMasFuerteBase
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000798 RID: 1944
		// (get) Token: 0x06001C6E RID: 7278 RVA: 0x00070F94 File Offset: 0x0006F194
		public int cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil
		{
			get
			{
				return this.current.calculosAcumulados.Count;
			}
		}

		// Token: 0x17000799 RID: 1945
		// (get) Token: 0x06001C6F RID: 7279 RVA: 0x00070F94 File Offset: 0x0006F194
		public int cantidadDeCalculosEnFrame
		{
			get
			{
				return this.current.calculosAcumulados.Count;
			}
		}

		// Token: 0x06001C70 RID: 7280 RVA: 0x00070FAB File Offset: 0x0006F1AB
		public ICalculoDeEstimulo GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(int index)
		{
			return this.current.calculosAcumulados[index];
		}

		// Token: 0x06001C71 RID: 7281 RVA: 0x00070FC3 File Offset: 0x0006F1C3
		public ICalculoDeEstimulo GetCalculoEnFrameBase(int index)
		{
			return this.GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(index);
		}

		// Token: 0x1700079A RID: 1946
		// (get) Token: 0x06001C72 RID: 7282 RVA: 0x00070FCC File Offset: 0x0006F1CC
		public bool enSession
		{
			get
			{
				return this.m_enSession;
			}
		}

		// Token: 0x1700079B RID: 1947
		// (get) Token: 0x06001C73 RID: 7283 RVA: 0x00070FD4 File Offset: 0x0006F1D4
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

		// Token: 0x1700079C RID: 1948
		// (get) Token: 0x06001C74 RID: 7284
		public abstract TipoDeCalculadorDeEstimulo tipo { get; }

		// Token: 0x1700079D RID: 1949
		// (get) Token: 0x06001C75 RID: 7285
		public abstract T_TipoDeEstimuloSegundario tipoDeEstimuloSegundario { get; }

		// Token: 0x1700079E RID: 1950
		// (get) Token: 0x06001C76 RID: 7286 RVA: 0x00070FFA File Offset: 0x0006F1FA
		public TResultWrapper current
		{
			get
			{
				return this.m_result;
			}
		}

		// Token: 0x1700079F RID: 1951
		// (get) Token: 0x06001C77 RID: 7287 RVA: 0x00070580 File Offset: 0x0006E780
		public Emocion emo
		{
			get
			{
				return this.emocion;
			}
		}

		// Token: 0x170007A0 RID: 1952
		// (get) Token: 0x06001C78 RID: 7288 RVA: 0x00071002 File Offset: 0x0006F202
		double ICalculadorDeEstimulo.prioridad
		{
			get
			{
				return this.m_prioridad * this.ObtenerPrioridad() * Emocion.APrioridad(this.emocion);
			}
		}

		// Token: 0x06001C79 RID: 7289 RVA: 0x0007101D File Offset: 0x0006F21D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.calculador = this.LoadCalculador();
			if (this.calculador == null)
			{
				throw new ArgumentNullException("calculador", "calculador null reference.");
			}
		}

		// Token: 0x06001C7A RID: 7290 RVA: 0x0007104E File Offset: 0x0006F24E
		protected virtual TCalculador LoadCalculador()
		{
			return base.transform.parent.GetComponentInParent<TCalculador>();
		}

		// Token: 0x06001C7B RID: 7291 RVA: 0x00071060 File Offset: 0x0006F260
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_result.Init((TSelf)((object)this));
		}

		// Token: 0x06001C7C RID: 7292 RVA: 0x00071080 File Offset: 0x0006F280
		protected override void OnEmocionesUpdating()
		{
			if (Application.isEditor)
			{
				this.m_duracionDebug = 0f;
			}
			SessionDeCalculosDeEstimuloPromiscua<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario>.IResultado resultado = this.m_result;
			if (!this.m_enSession)
			{
				this.m_result.Clear();
				ICalculoDeEstimulo calculoDeEstimulo;
				if (this.SessionPuedeComenzar(out calculoDeEstimulo))
				{
					this.m_enSession = true;
					this.m_tiempoDeInicioDeSession = new float?(Time.time);
					resultado.Acumular(calculoDeEstimulo, this);
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
			ICalculoDeEstimulo calculoDeEstimulo2 = null;
			if (this.calculador.activado && this.calculador.cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil > 0 && this.AlgunCalculoAcumulable(out calculoDeEstimulo2))
			{
				resultado.Acumular(calculoDeEstimulo2, this);
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
			this.onSesionStay(calculoDeEstimulo2);
			if (Application.isEditor)
			{
				this.m_duracionDebug = this.duracion;
			}
		}

		// Token: 0x06001C7D RID: 7293 RVA: 0x000711CC File Offset: 0x0006F3CC
		private bool SessionPuedeComenzar(out ICalculoDeEstimulo calculo)
		{
			calculo = null;
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

		// Token: 0x06001C7E RID: 7294 RVA: 0x00071294 File Offset: 0x0006F494
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
			ICalculoDeEstimulo calculoDeEstimulo;
			if (this.calculador.activado && this.calculador.cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil != 0 && this.AlgunCalculoAcumulable(out calculoDeEstimulo))
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

		// Token: 0x06001C7F RID: 7295 RVA: 0x0007137C File Offset: 0x0006F57C
		private bool AlgunCalculoAcumulable(out ICalculoDeEstimulo calculo)
		{
			bool flag;
			try
			{
				for (int i = 0; i < this.calculador.cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil; i++)
				{
					this.m_calculosTemp.Add(this.calculador.GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(i));
				}
				flag = this.AlgunCalculoAcumulable(this.m_calculosTemp, out calculo);
			}
			finally
			{
				this.m_calculosTemp.Clear();
			}
			return flag;
		}

		// Token: 0x06001C80 RID: 7296 RVA: 0x000713F0 File Offset: 0x0006F5F0
		protected virtual bool AlgunCalculoAcumulable(List<ICalculoDeEstimulo> calculos, out ICalculoDeEstimulo calculo)
		{
			for (int i = 0; i < this.m_calculosTemp.Count; i++)
			{
				ICalculoDeEstimulo calculoDeEstimulo = this.m_calculosTemp[i];
				if (this.CalculoEsAcumulable(calculoDeEstimulo))
				{
					calculo = calculoDeEstimulo;
					return true;
				}
			}
			calculo = null;
			return false;
		}

		// Token: 0x06001C81 RID: 7297 RVA: 0x00071432 File Offset: 0x0006F632
		protected bool CalculoEsAcumulable(ICalculoDeEstimulo calculo)
		{
			return calculo != null && this.EsAcumulable(calculo) && this.CalculoEsDeTipoEnumerable(this.tipoDeEstimuloSegundario, calculo);
		}

		// Token: 0x06001C82 RID: 7298
		protected abstract double ObtenerPrioridad();

		// Token: 0x06001C83 RID: 7299
		protected abstract bool CalculoEsDeTipoEnumerable(T_TipoDeEstimuloSegundario tipoDeEstimuloSegundario, ICalculoDeEstimulo calculo);

		// Token: 0x06001C84 RID: 7300
		protected abstract bool EsAcumulable(ICalculoDeEstimulo calculo);

		// Token: 0x06001C85 RID: 7301
		protected abstract void Acumuladondo(TResultWrapper resultado, ICalculoDeEstimulo resultadoAcumulado, ICalculoDeEstimulo acumulando);

		// Token: 0x06001C86 RID: 7302
		protected abstract void Acumulado(TResultWrapper resultado, ICalculoDeEstimulo resultadoAcumulado, ICalculoDeEstimulo acumulando);

		// Token: 0x06001C87 RID: 7303 RVA: 0x00071458 File Offset: 0x0006F658
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

		// Token: 0x06001C88 RID: 7304 RVA: 0x000714D0 File Offset: 0x0006F6D0
		private void onSesionStay(ICalculoDeEstimulo acumulable)
		{
			if (this.debugPrint)
			{
				string[] array = new string[6];
				array[0] = " sesion: ";
				array[1] = base.name;
				array[2] = " de cal: ";
				array[3] = this.calculador.name;
				array[4] = " stay. Acu: ";
				int num = 5;
				ICalculoDeEstimuloGenerando calculoDeEstimuloGenerando = acumulable as ICalculoDeEstimuloGenerando;
				array[num] = ((calculoDeEstimuloGenerando != null) ? new float?(calculoDeEstimuloGenerando.estimuloGeneradoEnFrame) : null).ToString();
				MonoBehaviour.print(string.Concat(array));
			}
			this.OnSesionStayed();
			Action<TSelf> action = this.sessionStayed;
			if (action == null)
			{
				return;
			}
			action((TSelf)((object)this));
		}

		// Token: 0x06001C89 RID: 7305 RVA: 0x00071578 File Offset: 0x0006F778
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

		// Token: 0x06001C8A RID: 7306
		protected abstract void OnSesionStarted();

		// Token: 0x06001C8B RID: 7307
		protected abstract void OnSesionStayed();

		// Token: 0x06001C8C RID: 7308
		protected abstract void OnSesionEnded();

		// Token: 0x06001C8D RID: 7309 RVA: 0x000715EE File Offset: 0x0006F7EE
		public bool TryInstantiateCalculoBase(out ICalculoDeEstimulo calculo)
		{
			return this.calculador.TryInstantiateCalculoBase(out calculo);
		}

		// Token: 0x06001C8F RID: 7311 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001C90 RID: 7312 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001C91 RID: 7313 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001C92 RID: 7314 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001C93 RID: 7315 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001C94 RID: 7316 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x040013E7 RID: 5095
		[SerializeField]
		[ReadOnlyUI]
		private bool m_enSession;

		// Token: 0x040013E8 RID: 5096
		[SerializeField]
		[ReadOnlyUI]
		private float m_duracionDebug;

		// Token: 0x040013E9 RID: 5097
		[SerializeField]
		private bool debugPrint;

		// Token: 0x040013EA RID: 5098
		private float? m_tiempoDeInicioDeSession;

		// Token: 0x040013EB RID: 5099
		private float? m_tiempoDelPrimerEstimulo;

		// Token: 0x040013EC RID: 5100
		private float? m_tiempoDelUltimoEstimulo;

		// Token: 0x040013ED RID: 5101
		public Action<TSelf> sessionStared;

		// Token: 0x040013EE RID: 5102
		public Action<TSelf> sessionStayed;

		// Token: 0x040013EF RID: 5103
		public Action<TSelf> sessionEnded;

		// Token: 0x040013F0 RID: 5104
		[SerializeField]
		[ReadOnlyUI]
		private TCalculador calculador;

		// Token: 0x040013F1 RID: 5105
		[SerializeField]
		private TResultWrapper m_result = new TResultWrapper();

		// Token: 0x040013F2 RID: 5106
		private List<ICalculoDeEstimulo> m_calculosTemp = new List<ICalculoDeEstimulo>();

		// Token: 0x020004B0 RID: 1200
		private interface IResultado : IClearable
		{
			// Token: 0x06001C95 RID: 7317
			void Acumular(ICalculoDeEstimulo calculo, SessionDeCalculosDeEstimuloPromiscua<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario> productor);

			// Token: 0x06001C96 RID: 7318
			void SetEstado(ResultadoDeSessionBase.Estado stado);
		}

		// Token: 0x020004B1 RID: 1201
		[Serializable]
		public abstract class ResultadoDeSession : ResultadoDeSessionBase, SessionDeCalculosDeEstimuloPromiscua<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario>.IResultado, IClearable
		{
			// Token: 0x06001C97 RID: 7319 RVA: 0x00071620 File Offset: 0x0006F820
			public virtual void Init(TSelf parent)
			{
				this.m_parent = parent;
			}

			// Token: 0x170007A1 RID: 1953
			// (get) Token: 0x06001C98 RID: 7320 RVA: 0x00071629 File Offset: 0x0006F829
			public IReadOnlyList<ICalculoDeInteracionEstimulanteConEstado> calculosAcumulados
			{
				get
				{
					return this.m_calculosAcumulados;
				}
			}

			// Token: 0x06001C99 RID: 7321 RVA: 0x00003B39 File Offset: 0x00001D39
			protected virtual void OnPropiaInstanciaCreada(ICalculoDeEstimulo creada)
			{
			}

			// Token: 0x06001C9A RID: 7322 RVA: 0x00071634 File Offset: 0x0006F834
			protected void Acumular(ICalculoDeEstimulo calculo, SessionDeCalculosDeEstimuloPromiscua<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario> productor)
			{
				if (calculo == null)
				{
					throw new ArgumentNullException("calculo", "calculo null reference.");
				}
				if (productor.emocion == null)
				{
					throw new ArgumentNullException("productor.emocion", "productor.emocion null reference.");
				}
				ICalculoDeInteracionEstimulanteConEstado calculoDeInteracionEstimulanteConEstado;
				if (!this.TryGetCalculoResultSegunCalculador(calculo, out calculoDeInteracionEstimulanteConEstado))
				{
					Debug.LogError("Todos los calculos deberian ser compatibles");
					return;
				}
				this.m_parent.Acumuladondo((TResultWrapper)((object)this), calculoDeInteracionEstimulanteConEstado, calculo);
				if (calculoDeInteracionEstimulanteConEstado.emocion == null)
				{
					(calculo as ICopiableA).CopiarA(calculoDeInteracionEstimulanteConEstado);
				}
				else
				{
					calculoDeInteracionEstimulanteConEstado.emocion = productor.emocion;
					if (calculo is ICalculoDeEstimuloDeParteEstimulante)
					{
						(calculoDeInteracionEstimulanteConEstado as ICalculoDeEstimuloDeParteEstimulante).estimulanteParte = (calculo as ICalculoDeEstimuloDeParteEstimulante).estimulanteParte;
					}
					IConvinable convinable = (IConvinable)calculoDeInteracionEstimulanteConEstado;
					if (!convinable.Convinable(calculo))
					{
						throw new NotSupportedException("calculos no son convinables");
					}
					convinable.Convinar(calculo);
					ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculoDeInteracionEstimulanteConEstado;
					ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante2 = (ICalculoDeInteracionEstimulante)calculo;
					calculoDeInteracionEstimulante.estimuloBasico.ClearIgnorandoPartesEstimuladas();
					calculoDeInteracionEstimulante2.estimuloBasico.CopiarA(calculoDeInteracionEstimulante.estimuloBasico, true);
					if (calculoDeInteracionEstimulante2.estimuloBasico.tieneCopiaInvertida)
					{
						calculoDeInteracionEstimulante.estimuloInvertidoBasico.ClearIgnorandoPartesEstimuladas();
						calculoDeInteracionEstimulante2.estimuloInvertidoBasico.CopiarA(calculoDeInteracionEstimulante.estimuloInvertidoBasico, true);
					}
				}
				calculoDeInteracionEstimulanteConEstado.producidoPorSegundario = calculo.producidoPor;
				calculoDeInteracionEstimulanteConEstado.producidoPor = productor;
				if (!this.m_calculosAcumulados.Contains(calculoDeInteracionEstimulanteConEstado))
				{
					this.m_calculosAcumulados.Add(calculoDeInteracionEstimulanteConEstado);
				}
				this.m_parent.Acumulado((TResultWrapper)((object)this), calculoDeInteracionEstimulanteConEstado, calculo);
				this.OnAcumulado(calculo, calculoDeInteracionEstimulanteConEstado, productor);
			}

			// Token: 0x06001C9B RID: 7323 RVA: 0x000717A8 File Offset: 0x0006F9A8
			private bool TryGetCalculoResultSegunCalculador(ICalculoDeEstimulo calculo, out ICalculoDeInteracionEstimulanteConEstado resultado)
			{
				resultado = null;
				ICalculadorDeEstimuloConCalculos calculadorDeEstimuloConCalculos = (calculo.producidoPorSegundario as ICalculadorDeEstimuloConCalculos) ?? (calculo.producidoPor as ICalculadorDeEstimuloConCalculos);
				if (calculadorDeEstimuloConCalculos == null)
				{
					Debug.LogError("Todos los calculos deberian ser compatibles");
					return false;
				}
				if (!this.m_calculoAcumuladosDeCalculador.TryGetValue(calculadorDeEstimuloConCalculos, out resultado))
				{
					ICalculoDeEstimulo calculoDeEstimulo;
					if (calculadorDeEstimuloConCalculos.TryInstantiateCalculoBase(out calculoDeEstimulo) && calculoDeEstimulo is ICopiableA && calculoDeEstimulo is ICalculoDeInteracionEstimulanteConEstado && calculoDeEstimulo is IClearable)
					{
						resultado = (ICalculoDeInteracionEstimulanteConEstado)calculoDeEstimulo;
						this.m_calculoAcumuladosDeCalculador.Add(calculadorDeEstimuloConCalculos, resultado);
						((IClearable)resultado).Clear();
						this.OnPropiaInstanciaCreada(resultado);
					}
					else
					{
						Debug.LogError("Todos los calculos deberian ser compatibles");
					}
				}
				return resultado != null;
			}

			// Token: 0x06001C9C RID: 7324 RVA: 0x00003B39 File Offset: 0x00001D39
			protected virtual void OnCleared()
			{
			}

			// Token: 0x06001C9D RID: 7325 RVA: 0x00003B39 File Offset: 0x00001D39
			protected virtual void OnAcumulado(ICalculoDeEstimulo calculo, ICalculoDeEstimulo acumulado, SessionDeCalculosDeEstimuloPromiscua<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario> productor)
			{
			}

			// Token: 0x06001C9E RID: 7326 RVA: 0x00071850 File Offset: 0x0006FA50
			protected override void Clear()
			{
				base.Clear();
				for (int i = 0; i < this.m_calculosAcumulados.Count; i++)
				{
					ICalculoDeInteracionEstimulanteConEstado calculoDeInteracionEstimulanteConEstado = this.m_calculosAcumulados[i];
					if (calculoDeInteracionEstimulanteConEstado != null)
					{
						InteracionEstimulanteBasica estimuloBasico = calculoDeInteracionEstimulanteConEstado.estimuloBasico;
						if (estimuloBasico != null)
						{
							estimuloBasico.Clear();
						}
					}
					if (calculoDeInteracionEstimulanteConEstado != null)
					{
						InteracionEstimulanteBasica estimuloInvertidoBasico = calculoDeInteracionEstimulanteConEstado.estimuloInvertidoBasico;
						if (estimuloInvertidoBasico != null)
						{
							estimuloInvertidoBasico.Clear();
						}
					}
					((IClearable)calculoDeInteracionEstimulanteConEstado).Clear();
				}
				this.m_calculosAcumulados.Clear();
				this.OnCleared();
			}

			// Token: 0x06001C9F RID: 7327 RVA: 0x000718CE File Offset: 0x0006FACE
			void SessionDeCalculosDeEstimuloPromiscua<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario>.IResultado.Acumular(ICalculoDeEstimulo calculo, SessionDeCalculosDeEstimuloPromiscua<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario> productor)
			{
				this.Acumular(calculo, productor);
			}

			// Token: 0x06001CA0 RID: 7328 RVA: 0x00070EF3 File Offset: 0x0006F0F3
			void IClearable.Clear()
			{
				this.Clear();
			}

			// Token: 0x06001CA1 RID: 7329 RVA: 0x000718D8 File Offset: 0x0006FAD8
			void SessionDeCalculosDeEstimuloPromiscua<TCalculador, TSelf, TResultWrapper, T_TipoDeEstimuloSegundario>.IResultado.SetEstado(ResultadoDeSessionBase.Estado stado)
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
				for (int i = 0; i < this.m_calculosAcumulados.Count; i++)
				{
					ICalculoDeInteracionEstimulanteConEstado calculoDeInteracionEstimulanteConEstado = this.m_calculosAcumulados[i];
					calculoDeInteracionEstimulanteConEstado.tipo = tipoDeCalculoDeEstimulo;
					(calculoDeInteracionEstimulanteConEstado as ICalculoDeEstimuloPrioridadModificable).prioridadMod = (double)num;
				}
			}

			// Token: 0x040013F3 RID: 5107
			protected TSelf m_parent;

			// Token: 0x040013F4 RID: 5108
			private Dictionary<ICalculadorDeEstimulo, ICalculoDeInteracionEstimulanteConEstado> m_calculoAcumuladosDeCalculador = new Dictionary<ICalculadorDeEstimulo, ICalculoDeInteracionEstimulanteConEstado>();

			// Token: 0x040013F5 RID: 5109
			[SerializeReference]
			private List<ICalculoDeInteracionEstimulanteConEstado> m_calculosAcumulados = new List<ICalculoDeInteracionEstimulanteConEstado>();
		}
	}
}
