using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000497 RID: 1175
	public class RecopiladorDeCalculosParaReactores : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06001BFC RID: 7164 RVA: 0x0006FD0C File Offset: 0x0006DF0C
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.comparison2 = new Comparison<ICalculoDeEstimulo>(RecopiladorDeCalculosParaReactores.Comparacion2);
			this.m_emos = this.GetComponentEnRoot(false);
			if (this.m_emos == null)
			{
				throw new ArgumentNullException("m_emos", "m_emos null reference.");
			}
		}

		// Token: 0x06001BFD RID: 7165 RVA: 0x0006FD5C File Offset: 0x0006DF5C
		public static int Comparacion2(ICalculoDeEstimulo x, ICalculoDeEstimulo y)
		{
			double prioridad = y.prioridad;
			double prioridad2 = y.producidoPor.prioridad;
			double num = prioridad * prioridad2;
			double num2 = num;
			if (x != y)
			{
				double prioridad3 = x.prioridad;
				double prioridad4 = x.producidoPor.prioridad;
				num2 = prioridad3 * prioridad4;
			}
			return num.CompareTo(num2);
		}

		// Token: 0x06001BFE RID: 7166 RVA: 0x0006FDA5 File Offset: 0x0006DFA5
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.ActualizarCalculadores();
			this.ActualizarReactores();
			this.m_emos.updatedEmociones += this.RecopiladorDeCalculosParaReactores_updatedEmociones;
		}

		// Token: 0x06001BFF RID: 7167 RVA: 0x0006FDD0 File Offset: 0x0006DFD0
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_emos.updatedEmociones -= this.RecopiladorDeCalculosParaReactores_updatedEmociones;
		}

		// Token: 0x06001C00 RID: 7168 RVA: 0x0006FDF0 File Offset: 0x0006DFF0
		public void Ignorar(RecopiladorDeCalculosParaReactores.Ignoraciones ignoracion)
		{
			this.m_ignoradores.Add(ignoracion);
		}

		// Token: 0x06001C01 RID: 7169 RVA: 0x0006FE00 File Offset: 0x0006E000
		public void ActualizarCalculadores()
		{
			this.m_calculadores.Clear();
			this.m_calculadoresPorEmocion.Clear();
			this.m_EmocionesDeCalculadores.Clear();
			base.GetComponentsInChildren<ICalculadorDeEstimuloConCalculos>(this.m_calculadores);
			for (int i = 0; i < this.m_calculadores.Count; i++)
			{
				ICalculadorDeEstimuloConCalculos calculadorDeEstimuloConCalculos = this.m_calculadores[i];
				if (!calculadorDeEstimuloConCalculos.isAwaken)
				{
					calculadorDeEstimuloConCalculos.ManualAwake();
				}
				List<ICalculadorDeEstimuloConCalculos> list;
				if (!this.m_calculadoresPorEmocion.TryGetValue(calculadorDeEstimuloConCalculos.emo, out list))
				{
					list = new List<ICalculadorDeEstimuloConCalculos>();
					this.m_calculadoresPorEmocion.Add(calculadorDeEstimuloConCalculos.emo, list);
					this.m_EmocionesDeCalculadores.Add(calculadorDeEstimuloConCalculos.emo);
				}
				list.Add(calculadorDeEstimuloConCalculos);
			}
			if (Application.isEditor)
			{
				this.m_calculadoresDebug = this.m_calculadores.Cast<Object>().ToList<Object>();
				this.m_calculadoresFrameDebug = this.m_calculadores.Where((ICalculadorDeEstimuloConCalculos cal) => cal.tipo == TipoDeCalculadorDeEstimulo.frame).Cast<Object>().ToList<Object>();
			}
		}

		// Token: 0x06001C02 RID: 7170 RVA: 0x0006FF08 File Offset: 0x0006E108
		public void ActualizarReactores()
		{
			this.m_reactores.Clear();
			this.m_registradores.Clear();
			this.m_paraReactores.Clear();
			Character componentInParent = base.GetComponentInParent<Character>();
			if (componentInParent == null)
			{
				throw new ArgumentNullException("Character", "Character null reference.");
			}
			componentInParent.GetComponentsInChildren<IReactor>(this.m_reactores);
			componentInParent.GetComponentsInChildren<IReactorRegistrador>(this.m_registradores);
			componentInParent.GetComponentsInChildren<IParaReactor>(this.m_paraReactores);
		}

		// Token: 0x06001C03 RID: 7171 RVA: 0x0006FF78 File Offset: 0x0006E178
		private void RecopiladorDeCalculosParaReactores_updatedEmociones(EmocionesFemeninas obj)
		{
			try
			{
				for (int i = 0; i < this.m_EmocionesDeCalculadores.Count; i++)
				{
					Emocion emocion = this.m_EmocionesDeCalculadores[i];
					List<ICalculadorDeEstimuloConCalculos> list = this.m_calculadoresPorEmocion[emocion];
					try
					{
						for (int j = 0; j < list.Count; j++)
						{
							ICalculadorDeEstimuloConCalculos calculadorDeEstimuloConCalculos = list[j];
							if (calculadorDeEstimuloConCalculos.isActiveAndEnabled)
							{
								for (int k = 0; k < calculadorDeEstimuloConCalculos.cantidadDeCalculosEnFrame; k++)
								{
									ICalculoDeEstimulo calculoEnFrameBase = calculadorDeEstimuloConCalculos.GetCalculoEnFrameBase(k);
									if (calculoEnFrameBase != null && calculoEnFrameBase.producidoPor != null && calculoEnFrameBase.prioridad > 0.0)
									{
										this.m_TEMP_TODOS.Add(calculoEnFrameBase);
									}
								}
								for (int l = 0; l < calculadorDeEstimuloConCalculos.cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil; l++)
								{
									ICalculoDeEstimulo calculoConEstimulosEnFrameMasFuerteAMasDebilBase = calculadorDeEstimuloConCalculos.GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(l);
									if (calculoConEstimulosEnFrameMasFuerteAMasDebilBase != null && calculoConEstimulosEnFrameMasFuerteAMasDebilBase.producidoPor != null && calculoConEstimulosEnFrameMasFuerteAMasDebilBase.prioridad > 0.0)
									{
										this.m_TEMP_SOLO_GENERADO.Add(calculoConEstimulosEnFrameMasFuerteAMasDebilBase);
										if (emocion.currentFrameIsValueAtMax)
										{
											this.m_tempEmo.Add(calculoConEstimulosEnFrameMasFuerteAMasDebilBase);
										}
									}
								}
							}
						}
						if (emocion.currentFrameIsValueAtMax && this.m_tempEmo.Count > 0)
						{
							this.m_tempEmo.Sort(this.comparison2);
							for (int m = 0; m < this.m_tempEmo.Count; m++)
							{
								ICalculoDeEstimulo calculoDeEstimulo = this.m_tempEmo[m];
								if (calculoDeEstimulo.tipo != TipoDeCalculoDeEstimulo.None && this.m_tempAddedTipoDeEstimulo.Add((int)calculoDeEstimulo.tipo))
								{
									calculoDeEstimulo.causoMaxValue = true;
								}
							}
						}
					}
					finally
					{
						this.m_tempEmo.Clear();
						this.m_tempAddedTipoDeEstimulo.Clear();
					}
				}
				if (this.puedeIgnorarCalculosParaRegistradores)
				{
					for (int n = this.m_TEMP_TODOS.Count - 1; n >= 0; n--)
					{
						ICalculoDeEstimulo calculoDeEstimulo2 = this.m_TEMP_TODOS[n];
						for (int num = 0; num < this.m_ignoradores.Count; num++)
						{
							if (this.m_ignoradores[num].EstaIgnorando(calculoDeEstimulo2))
							{
								this.m_TEMP_TODOS.RemoveAt(n);
								break;
							}
						}
					}
				}
				if (this.puedeIgnorarCalculosParaReactores)
				{
					for (int num2 = this.m_TEMP_SOLO_GENERADO.Count - 1; num2 >= 0; num2--)
					{
						ICalculoDeEstimulo calculoDeEstimulo3 = this.m_TEMP_SOLO_GENERADO[num2];
						for (int num3 = 0; num3 < this.m_ignoradores.Count; num3++)
						{
							if (this.m_ignoradores[num3].EstaIgnorando(calculoDeEstimulo3))
							{
								this.m_TEMP_SOLO_GENERADO.RemoveAt(num2);
								break;
							}
						}
					}
				}
				this.m_TEMP_SOLO_GENERADO.Sort(this.comparison2);
				this.m_TEMP_TODOS.Sort(this.comparison2);
				for (int num4 = 0; num4 < this.m_registradores.Count; num4++)
				{
					this.m_registradores[num4].Registrar(this.m_TEMP_TODOS);
				}
				if (this.reaccionarParaReactiores)
				{
					for (int num5 = 0; num5 < this.m_paraReactores.Count; num5++)
					{
						this.m_paraReactores[num5].BeforeReacciones();
					}
				}
				bool flag = false;
				for (int num6 = 0; num6 < this.m_reactores.Count; num6++)
				{
					flag = this.m_reactores[num6].Reaccionar(this.m_TEMP_SOLO_GENERADO, this.comparison2) || flag;
				}
				if (this.reaccionarParaReactiores)
				{
					for (int num7 = 0; num7 < this.m_paraReactores.Count; num7++)
					{
						this.m_paraReactores[num7].Reaccionar(this.m_TEMP_SOLO_GENERADO);
					}
				}
			}
			finally
			{
				this.m_TEMP_SOLO_GENERADO.Clear();
				this.m_TEMP_TODOS.Clear();
			}
		}

		// Token: 0x040013BB RID: 5051
		public bool reaccionarParaReactiores = true;

		// Token: 0x040013BC RID: 5052
		public bool puedeIgnorarCalculosParaRegistradores;

		// Token: 0x040013BD RID: 5053
		public bool puedeIgnorarCalculosParaReactores;

		// Token: 0x040013BE RID: 5054
		[SerializeField]
		private List<Object> m_calculadoresDebug = new List<Object>();

		// Token: 0x040013BF RID: 5055
		[SerializeField]
		private List<Object> m_calculadoresFrameDebug = new List<Object>();

		// Token: 0x040013C0 RID: 5056
		[SerializeReference]
		private List<RecopiladorDeCalculosParaReactores.Ignoraciones> m_ignoradores = new List<RecopiladorDeCalculosParaReactores.Ignoraciones>();

		// Token: 0x040013C1 RID: 5057
		private List<ICalculadorDeEstimuloConCalculos> m_calculadores = new List<ICalculadorDeEstimuloConCalculos>();

		// Token: 0x040013C2 RID: 5058
		private List<Emocion> m_EmocionesDeCalculadores = new List<Emocion>();

		// Token: 0x040013C3 RID: 5059
		private Dictionary<Emocion, List<ICalculadorDeEstimuloConCalculos>> m_calculadoresPorEmocion = new Dictionary<Emocion, List<ICalculadorDeEstimuloConCalculos>>();

		// Token: 0x040013C4 RID: 5060
		private List<IReactor> m_reactores = new List<IReactor>();

		// Token: 0x040013C5 RID: 5061
		private List<IReactorRegistrador> m_registradores = new List<IReactorRegistrador>();

		// Token: 0x040013C6 RID: 5062
		private List<IParaReactor> m_paraReactores = new List<IParaReactor>();

		// Token: 0x040013C7 RID: 5063
		private List<ICalculoDeEstimulo> m_TEMP_TODOS = new List<ICalculoDeEstimulo>();

		// Token: 0x040013C8 RID: 5064
		private List<ICalculoDeEstimulo> m_TEMP_SOLO_GENERADO = new List<ICalculoDeEstimulo>();

		// Token: 0x040013C9 RID: 5065
		private List<ICalculoDeEstimulo> m_tempEmo = new List<ICalculoDeEstimulo>();

		// Token: 0x040013CA RID: 5066
		private HashSet<int> m_tempAddedTipoDeEstimulo = new HashSet<int>();

		// Token: 0x040013CB RID: 5067
		private Comparison<ICalculoDeEstimulo> comparison2;

		// Token: 0x040013CC RID: 5068
		private EmocionesFemeninas m_emos;

		// Token: 0x02000498 RID: 1176
		[Serializable]
		public class IgnoracionesDeEmocion : RecopiladorDeCalculosParaReactores.Ignoraciones
		{
			// Token: 0x06001C05 RID: 7173 RVA: 0x00070405 File Offset: 0x0006E605
			public override bool EstaIgnorando(ICalculoDeEstimulo calculo)
			{
				return calculo.emocion.reaccion == this.emocion && calculo.causoMaxValue == this.maxValue;
			}

			// Token: 0x040013CD RID: 5069
			public ReaccionHumana emocion;

			// Token: 0x040013CE RID: 5070
			public bool maxValue;
		}

		// Token: 0x02000499 RID: 1177
		[Serializable]
		public abstract class Ignoraciones
		{
			// Token: 0x06001C07 RID: 7175
			public abstract bool EstaIgnorando(ICalculoDeEstimulo calculo);

			// Token: 0x040013CF RID: 5071
			public bool enabled;
		}
	}
}
