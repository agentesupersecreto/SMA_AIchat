using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.Abstracts
{
	// Token: 0x020004E0 RID: 1248
	[Obsolete("NO RECUERDO PARA Q SON", true)]
	public abstract class RecopiladorDeCalculadoresDeSesionesGenerales<T_TipoDeEstimuloEnumerable> : CustomUpdatedMonobehaviourBase where T_TipoDeEstimuloEnumerable : struct
	{
		// Token: 0x06001D4B RID: 7499 RVA: 0x00071DE4 File Offset: 0x0006FFE4
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			foreach (ICalculadorDeSessionDeTipo<T_TipoDeEstimuloEnumerable> calculadorDeSessionDeTipo in base.GetComponentsInChildren<ICalculadorDeSessionDeTipo<T_TipoDeEstimuloEnumerable>>(false))
			{
				if (calculadorDeSessionDeTipo.tipo == TipoDeCalculadorDeEstimulo.sesionGeneral)
				{
					int num = this.Parce(calculadorDeSessionDeTipo.tipoDeEstimuloEnumerable);
					if (this.dicc.ContainsKey(num))
					{
						string text = "no se puede agregar session: ";
						string name = calculadorDeSessionDeTipo.name;
						string text2 = " a recompilador. ya esxiste session general de: ";
						T_TipoDeEstimuloEnumerable tipoDeEstimuloEnumerable = calculadorDeSessionDeTipo.tipoDeEstimuloEnumerable;
						Debug.LogError(text + name + text2 + tipoDeEstimuloEnumerable.ToString(), this);
					}
					else
					{
						this.dicc.Add(num, calculadorDeSessionDeTipo);
						if (Application.isEditor)
						{
							this.m_debug.Add(calculadorDeSessionDeTipo as Object);
						}
					}
				}
			}
		}

		// Token: 0x06001D4C RID: 7500 RVA: 0x00071E94 File Offset: 0x00070094
		public bool Contiene(T_TipoDeEstimuloEnumerable enumerable)
		{
			int num = this.Parce(enumerable);
			return this.dicc.ContainsKey(num);
		}

		// Token: 0x06001D4D RID: 7501 RVA: 0x00071EB8 File Offset: 0x000700B8
		public bool EstaSession(T_TipoDeEstimuloEnumerable enumerable)
		{
			int num = this.Parce(enumerable);
			ICalculadorDeSessionDeTipo<T_TipoDeEstimuloEnumerable> calculadorDeSessionDeTipo;
			return this.dicc.TryGetValue(num, out calculadorDeSessionDeTipo) && calculadorDeSessionDeTipo.enSession;
		}

		// Token: 0x06001D4E RID: 7502
		protected abstract int Parce(T_TipoDeEstimuloEnumerable enumerable);

		// Token: 0x06001D4F RID: 7503
		protected abstract T_TipoDeEstimuloEnumerable Parce(int valor);

		// Token: 0x0400140C RID: 5132
		private Dictionary<int, ICalculadorDeSessionDeTipo<T_TipoDeEstimuloEnumerable>> dicc = new Dictionary<int, ICalculadorDeSessionDeTipo<T_TipoDeEstimuloEnumerable>>();

		// Token: 0x0400140D RID: 5133
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_debug = new List<Object>();
	}
}
