using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x020003A9 RID: 937
	public class ReactorGenericoParaCalculosDeInteraccionDeMasPrioridad : ReactorGenerico
	{
		// Token: 0x06001499 RID: 5273 RVA: 0x000588E0 File Offset: 0x00056AE0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.comparison = new Comparison<ICalculoDeEstimulo>(RecopiladorDeCalculosParaReactores.Comparacion2);
		}

		// Token: 0x0600149A RID: 5274 RVA: 0x000588FC File Offset: 0x00056AFC
		protected override void FiltrarArgumentos(List<object> args)
		{
			this.m_selectedframeDeMasPrioridad = 0.0;
			this.m_selectedsessionDeMasPrioridad = 0.0;
			base.FiltrarArgumentos(args);
			try
			{
				for (int i = 0; i < args.Count; i++)
				{
					ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = args[i] as ICalculoDeInteracionEstimulante;
					if (calculoDeInteracionEstimulante != null && calculoDeInteracionEstimulante.estimuloBasico != null && calculoDeInteracionEstimulante.estimuloBasico.tipoDeEstimulo != TipoDeEstimulo.None)
					{
						double num = calculoDeInteracionEstimulante.prioridad * Emocion.APrioridad(calculoDeInteracionEstimulante.emocion);
						switch (calculoDeInteracionEstimulante.tipo)
						{
						case TipoDeCalculoDeEstimulo.None:
							goto IL_00FD;
						case TipoDeCalculoDeEstimulo.frame:
							if (this.m_frameDeMasPrioridad == null || this.m_selectedframeDeMasPrioridad < num)
							{
								this.m_frameDeMasPrioridad = calculoDeInteracionEstimulante;
								this.m_selectedframeDeMasPrioridad = num;
								goto IL_00FD;
							}
							goto IL_00FD;
						case TipoDeCalculoDeEstimulo.sesionComienza:
						case TipoDeCalculoDeEstimulo.sesionEnCurso:
						case TipoDeCalculoDeEstimulo.sesionTermina:
							if (this.m_sessionDeMasPrioridad == null || this.m_selectedsessionDeMasPrioridad < num)
							{
								this.m_sessionDeMasPrioridad = calculoDeInteracionEstimulante;
								this.m_selectedsessionDeMasPrioridad = num;
								goto IL_00FD;
							}
							goto IL_00FD;
						}
						throw new ArgumentOutOfRangeException(calculoDeInteracionEstimulante.tipo.ToString());
					}
					IL_00FD:;
				}
				if (this.fixDiscrepanciaEntreEstimulosDeMasPrioridad && this.m_sessionDeMasPrioridad != null && this.m_frameDeMasPrioridad != null)
				{
					bool flag = this.m_sessionDeMasPrioridad.emocion.reaccion.EsPositiva();
					bool flag2 = this.m_frameDeMasPrioridad.emocion.reaccion.EsPositiva();
					if (flag != flag2 && this.m_sessionDeMasPrioridad.estimuloBasico.ContineAlgunaDeEstasPartes(this.m_frameDeMasPrioridad.estimuloBasico.partesDelCuerpoHumanoEstimuladas))
					{
						this.m_sessionDeMasPrioridad = null;
					}
				}
				if (this.m_sessionDeMasPrioridad != null)
				{
					this.m_temp.Add(this.m_sessionDeMasPrioridad);
				}
				if (this.m_frameDeMasPrioridad != null)
				{
					this.m_temp.Add(this.m_frameDeMasPrioridad);
				}
				this.m_temp.Sort(this.comparison);
				args.Clear();
				for (int j = 0; j < this.m_temp.Count; j++)
				{
					args.Add(this.m_temp[j]);
				}
			}
			finally
			{
				this.m_temp.Clear();
				this.m_sessionDeMasPrioridad = null;
				this.m_frameDeMasPrioridad = null;
			}
		}

		// Token: 0x040010CD RID: 4301
		private ICalculoDeInteracionEstimulante m_frameDeMasPrioridad;

		// Token: 0x040010CE RID: 4302
		private ICalculoDeInteracionEstimulante m_sessionDeMasPrioridad;

		// Token: 0x040010CF RID: 4303
		private double m_selectedframeDeMasPrioridad;

		// Token: 0x040010D0 RID: 4304
		private double m_selectedsessionDeMasPrioridad;

		// Token: 0x040010D1 RID: 4305
		private Comparison<ICalculoDeEstimulo> comparison;

		// Token: 0x040010D2 RID: 4306
		[Header("De mas prioridad config")]
		public bool fixDiscrepanciaEntreEstimulosDeMasPrioridad = true;

		// Token: 0x040010D3 RID: 4307
		private List<ICalculoDeInteracionEstimulante> m_temp = new List<ICalculoDeInteracionEstimulante>();

		// Token: 0x040010D4 RID: 4308
		[SerializeField]
		private bool m_debugShowInfo;

		// Token: 0x040010D5 RID: 4309
		[SerializeField]
		private ReactorGenericoParaCalculosDeInteraccionDeMasPrioridad.DebugInfo m_frameInfo;

		// Token: 0x040010D6 RID: 4310
		[SerializeField]
		private ReactorGenericoParaCalculosDeInteraccionDeMasPrioridad.DebugInfo m_sessionInfo;

		// Token: 0x020003AA RID: 938
		[Serializable]
		private struct DebugInfo
		{
			// Token: 0x0600149C RID: 5276 RVA: 0x00058B54 File Offset: 0x00056D54
			public static ReactorGenericoParaCalculosDeInteraccionDeMasPrioridad.DebugInfo Get(ICalculoDeInteracionEstimulante calculo)
			{
				ReactorGenericoParaCalculosDeInteraccionDeMasPrioridad.DebugInfo debugInfo = default(ReactorGenericoParaCalculosDeInteraccionDeMasPrioridad.DebugInfo);
				debugInfo.ReaccionHumana = calculo.emocion.reaccion;
				debugInfo.ParteDelCuerpoHumano = calculo.estimuloBasico.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed);
				ICalculoDeEstimuloDeParteEstimulante calculoDeEstimuloDeParteEstimulante = calculo as ICalculoDeEstimuloDeParteEstimulante;
				debugInfo.ParteQuePuedeEstimular = ((calculoDeEstimuloDeParteEstimulante != null) ? new ParteQuePuedeEstimular?(calculoDeEstimuloDeParteEstimulante.estimulanteParte) : null).GetValueOrDefault();
				debugInfo.DireccionDeEstimulo = calculo.estimuloBasico.tipo;
				debugInfo.Side = calculo.estimuloBasico.side;
				debugInfo.TipoDeEstimulo = calculo.estimuloBasico.tipoDeEstimulo;
				debugInfo.Prioridad = calculo.prioridad;
				return debugInfo;
			}

			// Token: 0x040010D7 RID: 4311
			public ReaccionHumana ReaccionHumana;

			// Token: 0x040010D8 RID: 4312
			public ParteDelCuerpoHumano ParteDelCuerpoHumano;

			// Token: 0x040010D9 RID: 4313
			public ParteQuePuedeEstimular ParteQuePuedeEstimular;

			// Token: 0x040010DA RID: 4314
			public DireccionDeEstimulo DireccionDeEstimulo;

			// Token: 0x040010DB RID: 4315
			public Side Side;

			// Token: 0x040010DC RID: 4316
			public TipoDeEstimulo TipoDeEstimulo;

			// Token: 0x040010DD RID: 4317
			public double Prioridad;
		}
	}
}
