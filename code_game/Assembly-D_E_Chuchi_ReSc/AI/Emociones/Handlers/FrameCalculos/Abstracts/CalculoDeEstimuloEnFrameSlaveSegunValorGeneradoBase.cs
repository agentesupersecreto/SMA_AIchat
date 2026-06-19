using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Abstracts
{
	// Token: 0x0200052D RID: 1325
	public abstract class CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoBase<TMaster, T_ICalculoDeEstimuloResultado, T_ICalculoDeEstimuloEntrante> : CalculoDeEstimuloEnFrame, ICalculadorDeEstimulo<T_ICalculoDeEstimuloResultado>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TMaster : ICalculadorDeEstimulo where T_ICalculoDeEstimuloResultado : class, IClearable, ICalculoDeEstimulo, new() where T_ICalculoDeEstimuloEntrante : ICalculoDeEstimulo
	{
		// Token: 0x06002053 RID: 8275 RVA: 0x0007A538 File Offset: 0x00078738
		public T_ICalculoDeEstimuloResultado GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			if (!this.m_estimuloExisteEnFrame)
			{
				return default(T_ICalculoDeEstimuloResultado);
			}
			if (index == 0)
			{
				return this.m_elegidoCopiaPropia;
			}
			return default(T_ICalculoDeEstimuloResultado);
		}

		// Token: 0x06002054 RID: 8276 RVA: 0x0007A56A File Offset: 0x0007876A
		public T_ICalculoDeEstimuloResultado GetCalculoEnFrame(int index)
		{
			return this.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(index);
		}

		// Token: 0x06002055 RID: 8277 RVA: 0x0007A573 File Offset: 0x00078773
		public bool TryInstantiateCalculo(out T_ICalculoDeEstimuloResultado calculo)
		{
			calculo = new T_ICalculoDeEstimuloResultado();
			return true;
		}

		// Token: 0x06002056 RID: 8278 RVA: 0x0007A584 File Offset: 0x00078784
		public bool TryInstantiateCalculoBase(out ICalculoDeEstimulo calculo)
		{
			T_ICalculoDeEstimuloResultado t_ICalculoDeEstimuloResultado;
			bool flag = this.TryInstantiateCalculo(out t_ICalculoDeEstimuloResultado);
			calculo = t_ICalculoDeEstimuloResultado;
			return flag;
		}

		// Token: 0x170008B0 RID: 2224
		// (get) Token: 0x06002057 RID: 8279
		protected abstract PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana { get; }

		// Token: 0x170008B1 RID: 2225
		// (get) Token: 0x06002058 RID: 8280 RVA: 0x0007A5A1 File Offset: 0x000787A1
		[Obsolete("", true)]
		public T_ICalculoDeEstimuloResultado calculoMasFuerte
		{
			get
			{
				return this.m_elegidoCopiaPropia;
			}
		}

		// Token: 0x06002059 RID: 8281 RVA: 0x0007A5A9 File Offset: 0x000787A9
		[Obsolete("", true)]
		public void GetCalculosDelMasFuerteAlMasDebil(IList<T_ICalculoDeEstimuloResultado> resultado)
		{
			resultado.Add(this.m_elegidoCopiaPropia);
		}

		// Token: 0x170008B2 RID: 2226
		// (get) Token: 0x0600205A RID: 8282 RVA: 0x0007A5B7 File Offset: 0x000787B7
		public TMaster master
		{
			get
			{
				return this.m_masterCalculador;
			}
		}

		// Token: 0x170008B3 RID: 2227
		// (get) Token: 0x0600205B RID: 8283 RVA: 0x0007A5BF File Offset: 0x000787BF
		public int cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil
		{
			get
			{
				if (!this.m_estimuloExisteEnFrame)
				{
					return 0;
				}
				return 1;
			}
		}

		// Token: 0x170008B4 RID: 2228
		// (get) Token: 0x0600205C RID: 8284 RVA: 0x0007A5CC File Offset: 0x000787CC
		public int cantidadDeCalculosEnFrame
		{
			get
			{
				return this.cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil;
			}
		}

		// Token: 0x0600205D RID: 8285 RVA: 0x0007A5D4 File Offset: 0x000787D4
		public ICalculoDeEstimulo GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(int index)
		{
			if (!this.m_estimuloExisteEnFrame)
			{
				return null;
			}
			if (index == 0)
			{
				return this.m_elegidoCopiaPropia;
			}
			return null;
		}

		// Token: 0x0600205E RID: 8286 RVA: 0x0007A5F0 File Offset: 0x000787F0
		public ICalculoDeEstimulo GetCalculoEnFrameBase(int index)
		{
			return this.GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(index);
		}

		// Token: 0x0600205F RID: 8287 RVA: 0x0007A5F9 File Offset: 0x000787F9
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_masterCalculador = this.LoadMaster();
			if (this.m_masterCalculador == null)
			{
				throw new ArgumentNullException("m_masterCalculador", "m_masterCalculador null reference.");
			}
		}

		// Token: 0x06002060 RID: 8288 RVA: 0x0007A62A File Offset: 0x0007882A
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.ClearOldData();
		}

		// Token: 0x06002061 RID: 8289
		protected abstract TMaster LoadMaster();

		// Token: 0x06002062 RID: 8290
		protected abstract bool CalculoEsValido(T_ICalculoDeEstimuloEntrante calculo, float generado);

		// Token: 0x06002063 RID: 8291
		protected abstract void Convertir(T_ICalculoDeEstimuloEntrante entrante, T_ICalculoDeEstimuloResultado resultado);

		// Token: 0x06002064 RID: 8292
		protected abstract T_ICalculoDeEstimuloResultado Comparar(T_ICalculoDeEstimuloResultado a, T_ICalculoDeEstimuloResultado b);

		// Token: 0x06002065 RID: 8293
		protected abstract void CopiarCalculo(T_ICalculoDeEstimuloResultado original, T_ICalculoDeEstimuloResultado copiaResultado);

		// Token: 0x06002066 RID: 8294
		protected abstract bool FrameEsValido(T_ICalculoDeEstimuloResultado calculoElegidoOriginal, float generadoTotal);

		// Token: 0x06002067 RID: 8295
		protected abstract void PoblarConData(T_ICalculoDeEstimuloResultado calculoElegidoCopia, float deltaTime);

		// Token: 0x06002068 RID: 8296
		protected abstract void ObtenerCambioGenerado(T_ICalculoDeEstimuloResultado calculoElegidoCopia, out float generadoNoLimitado, out float generadoLimitado);

		// Token: 0x06002069 RID: 8297 RVA: 0x0007A63C File Offset: 0x0007883C
		protected void Comparar(T_ICalculoDeEstimuloEntrante calculo, float generado)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (calculo == null)
			{
				return;
			}
			if (!this.CalculoEsValido(calculo, generado))
			{
				return;
			}
			this.Convertir(calculo, this.m_convertidoTemp);
			if (this.m_elegido == null)
			{
				this.m_elegido = this.m_convertidoTemp;
				return;
			}
			this.m_elegido = this.Comparar(this.m_elegido, this.m_convertidoTemp);
		}

		// Token: 0x0600206A RID: 8298 RVA: 0x0007A6A8 File Offset: 0x000788A8
		protected void Verificar(float generado)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (this.m_elegido == null)
			{
				return;
			}
			if (!this.FrameEsValido(this.m_elegido, generado))
			{
				return;
			}
			this.CopiarCalculo(this.m_elegido, this.m_elegidoCopiaPropia);
			this.m_elegido = default(T_ICalculoDeEstimuloResultado);
			this.m_existenEstimulosMaestros = true;
			this.m_convertidoTemp.Clear();
		}

		// Token: 0x0600206B RID: 8299 RVA: 0x0007A711 File Offset: 0x00078911
		protected override void Updating(float deltaTime)
		{
			if (!this.m_existenEstimulosMaestros)
			{
				this.ClearOldData();
			}
		}

		// Token: 0x0600206C RID: 8300 RVA: 0x0007A724 File Offset: 0x00078924
		protected sealed override void DoUpdate(ref float generadoNoLimitado, ref float generadoLimitado, ref float cambiarValorDeEmocionDespuesDeTiempoMod, float deltaTime)
		{
			try
			{
				this.m_estimuloExisteEnFrame = this.m_existenEstimulosMaestros;
				if (this.m_estimuloExisteEnFrame)
				{
					this.PoblarConData(this.m_elegidoCopiaPropia, deltaTime);
					this.ObtenerCambioGenerado(this.m_elegidoCopiaPropia, out generadoNoLimitado, out generadoLimitado);
				}
			}
			finally
			{
				this.m_elegido = default(T_ICalculoDeEstimuloResultado);
				this.m_existenEstimulosMaestros = false;
			}
		}

		// Token: 0x0600206D RID: 8301 RVA: 0x0007A788 File Offset: 0x00078988
		protected void ClearOldData()
		{
			this.m_convertidoTemp.Clear();
			this.m_elegidoCopiaPropia.Clear();
			this.m_existenEstimulosMaestros = false;
		}

		// Token: 0x170008B5 RID: 2229
		// (get) Token: 0x0600206E RID: 8302 RVA: 0x0007A7B1 File Offset: 0x000789B1
		[Obsolete("", true)]
		public bool estimuloExisteEnFrame
		{
			get
			{
				return this.m_estimuloExisteEnFrame;
			}
		}

		// Token: 0x170008B6 RID: 2230
		// (get) Token: 0x0600206F RID: 8303 RVA: 0x0007A7B9 File Offset: 0x000789B9
		[Obsolete("", true)]
		public ICalculoDeEstimulo calculoMasFuerteBase
		{
			get
			{
				return this.m_elegidoCopiaPropia;
			}
		}

		// Token: 0x06002071 RID: 8305 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06002072 RID: 8306 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06002073 RID: 8307 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06002074 RID: 8308 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06002075 RID: 8309 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06002076 RID: 8310 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x0400154F RID: 5455
		[SerializeField]
		[ReadOnlyUI]
		private TMaster m_masterCalculador;

		// Token: 0x04001550 RID: 5456
		[SerializeField]
		[ReadOnlyUI]
		private T_ICalculoDeEstimuloResultado m_elegidoCopiaPropia = new T_ICalculoDeEstimuloResultado();

		// Token: 0x04001551 RID: 5457
		[SerializeField]
		[ReadOnlyUI]
		private bool m_estimuloExisteEnFrame;

		// Token: 0x04001552 RID: 5458
		[NonSerialized]
		private bool m_existenEstimulosMaestros;

		// Token: 0x04001553 RID: 5459
		[NonSerialized]
		private T_ICalculoDeEstimuloResultado m_elegido;

		// Token: 0x04001554 RID: 5460
		private T_ICalculoDeEstimuloResultado m_convertidoTemp = new T_ICalculoDeEstimuloResultado();
	}
}
