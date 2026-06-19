using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts
{
	// Token: 0x0200007E RID: 126
	public abstract class RangosDeGeneracionPara : AplicableCustomMonobehaviour
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000243 RID: 579
		protected abstract RangosDeGeneracionPara.UnidadDeRango display { get; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000244 RID: 580
		protected abstract IEnumerable<ParteQuePuedeEstimular> estimulamtes { get; }

		// Token: 0x06000245 RID: 581
		protected abstract bool Ignorando(ParteDelCuerpoHumano estimulada);

		// Token: 0x06000246 RID: 582
		protected abstract void Simular(ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada, out float rangoMinimo, out float rangoMaximo, out float generacionMinima, out float generacionMaxima);

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000247 RID: 583 RVA: 0x0000E3DE File Offset: 0x0000C5DE
		public Character character
		{
			get
			{
				return this.m_character;
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000E3E6 File Offset: 0x0000C5E6
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_character = this.GetComponentEnRoot(false);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000E3FB File Offset: 0x0000C5FB
		public virtual void Clear()
		{
			this.m_Rangos.Clear();
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000E408 File Offset: 0x0000C608
		public virtual void Actualizar()
		{
			this.m_Rangos.Clear();
			using (IEnumerator<int> enumerator = typeof(ParteDelCuerpoHumano).GetEnumValoresInt().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)enumerator.Current;
					if (!this.Ignorando(parteDelCuerpoHumano))
					{
						foreach (ParteQuePuedeEstimular parteQuePuedeEstimular in this.estimulamtes)
						{
							try
							{
								float num;
								float num2;
								float num3;
								float num4;
								this.Simular(parteQuePuedeEstimular, parteDelCuerpoHumano, out num, out num2, out num3, out num4);
								RangosDeGeneracionPara.Ranges ranges = default(RangosDeGeneracionPara.Ranges);
								ranges.display = this.display;
								ranges.estimulante = parteQuePuedeEstimular;
								ranges.estimulando = parteDelCuerpoHumano;
								ranges.rangoMinimo = num;
								ranges.rangoMaximo = num2;
								ranges.generacionMinima = num3;
								ranges.generacionMaxima = num4;
								this.m_Rangos.Add(ranges);
							}
							catch (Exception ex)
							{
								Debug.LogWarning("Error calculando Rangos De Generacion Para: " + base.name + ". " + ex.Message, this);
								Debug.LogException(ex, this);
							}
						}
					}
				}
			}
			if (this.reordenarSegunMaxGenerada)
			{
				this.m_Rangos.Sort((RangosDeGeneracionPara.Ranges x, RangosDeGeneracionPara.Ranges y) => y.generacionMaxima.CompareTo(x.generacionMaxima));
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000E584 File Offset: 0x0000C784
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Actualizar",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000E59D File Offset: 0x0000C79D
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.Actualizar();
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000E5AB File Offset: 0x0000C7AB
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			if (this.m_Rangos.Count == 0)
			{
				return base.Boton2();
			}
			return new CustomMonobehaviourBotonConfig
			{
				text = "Limpiar",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000E5D8 File Offset: 0x0000C7D8
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.Clear();
		}

		// Token: 0x040000F5 RID: 245
		public bool reordenarSegunMaxGenerada = true;

		// Token: 0x040000F6 RID: 246
		[SerializeField]
		private List<RangosDeGeneracionPara.Ranges> m_Rangos = new List<RangosDeGeneracionPara.Ranges>();

		// Token: 0x040000F7 RID: 247
		private Character m_character;

		// Token: 0x020000F1 RID: 241
		public enum UnidadDeRango
		{
			// Token: 0x0400033B RID: 827
			None,
			// Token: 0x0400033C RID: 828
			metroPorSegundo,
			// Token: 0x0400033D RID: 829
			centimetroPorSegundo,
			// Token: 0x0400033E RID: 830
			metro,
			// Token: 0x0400033F RID: 831
			centimetro
		}

		// Token: 0x020000F2 RID: 242
		[Serializable]
		public struct Ranges
		{
			// Token: 0x04000340 RID: 832
			public RangosDeGeneracionPara.UnidadDeRango display;

			// Token: 0x04000341 RID: 833
			public ParteQuePuedeEstimular estimulante;

			// Token: 0x04000342 RID: 834
			public ParteDelCuerpoHumano estimulando;

			// Token: 0x04000343 RID: 835
			public float rangoMinimo;

			// Token: 0x04000344 RID: 836
			public float rangoMaximo;

			// Token: 0x04000345 RID: 837
			public float generacionMinima;

			// Token: 0x04000346 RID: 838
			public float generacionMaxima;
		}
	}
}
