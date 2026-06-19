using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts
{
	// Token: 0x0200007A RID: 122
	public abstract class ConcentMinimoPara : AplicableCustomMonobehaviour
	{
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600022C RID: 556
		protected abstract TipoDeEstimulo tipo { get; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600022D RID: 557
		protected abstract DireccionDeEstimulo direccion { get; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600022E RID: 558
		protected abstract string estimuloTag { get; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600022F RID: 559
		protected abstract IEnumerable<ParteQuePuedeEstimular> estimulamtes { get; }

		// Token: 0x06000230 RID: 560
		protected abstract bool Ignorando(ParteDelCuerpoHumano estimulada);

		// Token: 0x06000231 RID: 561 RVA: 0x0000E188 File Offset: 0x0000C388
		public void Clear()
		{
			this.m_Minimos.Clear();
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000E198 File Offset: 0x0000C398
		public void Actualizar()
		{
			this.m_Minimos.Clear();
			ConsentNecesario componentEnRoot = this.GetComponentEnRoot(false);
			using (IEnumerator<int> enumerator = typeof(ParteDelCuerpoHumano).GetEnumValoresInt().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)enumerator.Current;
					if (!this.Ignorando(parteDelCuerpoHumano))
					{
						foreach (ParteQuePuedeEstimular parteQuePuedeEstimular in this.estimulamtes)
						{
							if (parteDelCuerpoHumano == ParteDelCuerpoHumano.vag && parteQuePuedeEstimular == ParteQuePuedeEstimular.ojos)
							{
								Debug.Break();
							}
							try
							{
								float num = componentEnRoot.ParaConJerarquia(this.tipo, this.direccion, parteDelCuerpoHumano, parteQuePuedeEstimular, null, null, this.estimuloTag);
								ConcentMinimoPara.Trio trio = default(ConcentMinimoPara.Trio);
								trio.consentMinimo = num;
								trio.estimulando = parteDelCuerpoHumano;
								trio.estimulante = parteQuePuedeEstimular;
								this.m_Minimos.Add(trio);
							}
							catch (Exception ex)
							{
								Debug.LogWarning("Error calculando ConsentNecesario: " + ex.Message, this);
								Debug.LogException(ex, this);
							}
						}
					}
				}
			}
			this.m_Minimos.Sort((ConcentMinimoPara.Trio x, ConcentMinimoPara.Trio y) => x.consentMinimo.CompareTo(y.consentMinimo));
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000E310 File Offset: 0x0000C510
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Actualizar",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000E329 File Offset: 0x0000C529
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.Actualizar();
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000E337 File Offset: 0x0000C537
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			if (this.m_Minimos.Count == 0)
			{
				return base.Boton2();
			}
			return new CustomMonobehaviourBotonConfig
			{
				text = "Limpiar",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000E364 File Offset: 0x0000C564
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.Clear();
		}

		// Token: 0x040000F4 RID: 244
		[SerializeField]
		private List<ConcentMinimoPara.Trio> m_Minimos = new List<ConcentMinimoPara.Trio>();

		// Token: 0x020000EF RID: 239
		[Serializable]
		public struct Trio
		{
			// Token: 0x04000335 RID: 821
			public ParteDelCuerpoHumano estimulando;

			// Token: 0x04000336 RID: 822
			public ParteQuePuedeEstimular estimulante;

			// Token: 0x04000337 RID: 823
			public float consentMinimo;
		}
	}
}
