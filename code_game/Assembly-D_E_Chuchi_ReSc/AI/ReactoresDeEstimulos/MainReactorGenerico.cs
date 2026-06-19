using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x020003A4 RID: 932
	public class MainReactorGenerico : ReactorPadreSinLogicaACalculoDeEstimulo<ICalculoDeEstimulo>, IReactorInyectable, IReactor
	{
		// Token: 0x06001482 RID: 5250 RVA: 0x00058530 File Offset: 0x00056730
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.reaccionarUnoALaVez)
			{
				Debug.LogWarning("Los reactores estan diseñados para funcionar mejor reaccionando todos a la vez");
			}
		}

		// Token: 0x1400005E RID: 94
		// (add) Token: 0x06001483 RID: 5251 RVA: 0x0005854C File Offset: 0x0005674C
		// (remove) Token: 0x06001484 RID: 5252 RVA: 0x00058584 File Offset: 0x00056784
		public event IReactorReaccionandoHandler reaccionando;

		// Token: 0x1400005F RID: 95
		// (add) Token: 0x06001485 RID: 5253 RVA: 0x000585BC File Offset: 0x000567BC
		// (remove) Token: 0x06001486 RID: 5254 RVA: 0x000585F4 File Offset: 0x000567F4
		public event IReactorReaccionadoHandler reaccionado;

		// Token: 0x06001487 RID: 5255 RVA: 0x0005862C File Offset: 0x0005682C
		public bool Reaccionar(IReadOnlyList<ICalculoDeEstimulo> resultadosEnFrame, Comparison<ICalculoDeEstimulo> comparacion)
		{
			this.m_calculos.AddRange(resultadosEnFrame);
			IReactorReaccionandoHandler reactorReaccionandoHandler = this.reaccionando;
			if (reactorReaccionandoHandler != null)
			{
				reactorReaccionandoHandler(this.m_calculos, this);
			}
			this.m_calculos.Sort(comparacion);
			bool flag4;
			try
			{
				bool flag = false;
				if (this.debugLog)
				{
					MonoBehaviour.print("MAIN REACTOR REACCIOANDO....");
					MonoBehaviour.print("DATA....");
					foreach (ICalculoDeEstimulo calculoDeEstimulo in this.m_calculos)
					{
						MonoBehaviour.print(JsonUtility.ToJson(calculoDeEstimulo, true));
					}
				}
				if (this.reaccionarUnoALaVez)
				{
					Debug.LogWarning("Muchos reacctores ya no son compatibles con este procedimiento.");
					for (int i = 0; i < this.m_calculos.Count; i++)
					{
						bool flag2 = this.ReaccionarACalculo(this.m_calculos[i]);
						flag = flag || flag2;
						if (this.debugLog)
						{
							if (!flag2)
							{
								MonoBehaviour.print("reaccion FALLIDA en data");
								MonoBehaviour.print(JsonUtility.ToJson(this.m_calculos[i], true));
							}
							else
							{
								MonoBehaviour.print("reaccion CON EXITO en data");
								MonoBehaviour.print(JsonUtility.ToJson(this.m_calculos[i], true));
							}
						}
					}
				}
				else
				{
					bool flag3 = this.ReaccionarACalculos(this.m_calculos);
					flag = flag || flag3;
					if (this.debugLog)
					{
						if (!flag3)
						{
							MonoBehaviour.print("reaccion FALLIDA en data");
							MonoBehaviour.print(JsonUtility.ToJson(this.m_calculos, true));
						}
						else
						{
							MonoBehaviour.print("reaccion CON EXITO en data");
							MonoBehaviour.print(JsonUtility.ToJson(this.m_calculos, true));
						}
					}
				}
				if (this.debugLog)
				{
					MonoBehaviour.print("MAIN REACTOR TERMINA CON: " + flag.ToString() + "....");
				}
				flag4 = flag;
			}
			finally
			{
				this.m_calculos.Clear();
				IReactorReaccionadoHandler reactorReaccionadoHandler = this.reaccionado;
				if (reactorReaccionadoHandler != null)
				{
					reactorReaccionadoHandler(this);
				}
			}
			return flag4;
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool CalculoEsValido(ICalculoDeEstimulo calculo)
		{
			return true;
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x00030684 File Offset: 0x0002E884
		protected sealed override float CoolDownModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f;
		}

		// Token: 0x040010C9 RID: 4297
		[Header("uno a la vez es OBSOLETO")]
		[Tooltip("uno a la vez es OBSOLETO")]
		public bool reaccionarUnoALaVez;

		// Token: 0x040010CA RID: 4298
		private List<ICalculoDeEstimulo> m_calculos = new List<ICalculoDeEstimulo>();
	}
}
