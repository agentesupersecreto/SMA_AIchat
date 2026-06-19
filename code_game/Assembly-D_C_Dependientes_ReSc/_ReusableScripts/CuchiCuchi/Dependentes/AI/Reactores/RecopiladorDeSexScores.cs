using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl.Sexual;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores
{
	// Token: 0x020002F1 RID: 753
	public class RecopiladorDeSexScores : CustomMonobehaviour
	{
		// Token: 0x060012F8 RID: 4856 RVA: 0x0005A5AC File Offset: 0x000587AC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			IBocaHole boca = this.GetComponentEnRoot(false);
			IVagHole vag = this.GetComponentEnRoot(false);
			IAnusHole anus = this.GetComponentEnRoot(false);
			if (boca == null)
			{
				throw new ArgumentNullException("boca", "boca null reference.");
			}
			if (vag == null)
			{
				throw new ArgumentNullException("vag", "vag null reference.");
			}
			if (anus == null)
			{
				throw new ArgumentNullException("anus", "anus null reference.");
			}
			AutoSexPosibilidadScore[] componentsInChildren = base.GetComponentsInChildren<AutoSexPosibilidadScore>();
			AutoSexScore[] componentsInChildren2 = base.GetComponentsInChildren<AutoSexScore>();
			this.m_posibilidadesScores = new Dictionary<ValueTuple<IHole, ParteQuePuedeEstimular>, AutoSexPosibilidadScore[]>
			{
				{
					new ValueTuple<IHole, ParteQuePuedeEstimular>(boca, ParteQuePuedeEstimular.dedo),
					componentsInChildren.Where((AutoSexPosibilidadScore p) => p.paraHole == boca && p.paraParte == ParteQuePuedeEstimular.dedo).ToArray<AutoSexPosibilidadScore>()
				},
				{
					new ValueTuple<IHole, ParteQuePuedeEstimular>(vag, ParteQuePuedeEstimular.dedo),
					componentsInChildren.Where((AutoSexPosibilidadScore p) => p.paraHole == vag && p.paraParte == ParteQuePuedeEstimular.dedo).ToArray<AutoSexPosibilidadScore>()
				},
				{
					new ValueTuple<IHole, ParteQuePuedeEstimular>(anus, ParteQuePuedeEstimular.dedo),
					componentsInChildren.Where((AutoSexPosibilidadScore p) => p.paraHole == anus && p.paraParte == ParteQuePuedeEstimular.dedo).ToArray<AutoSexPosibilidadScore>()
				},
				{
					new ValueTuple<IHole, ParteQuePuedeEstimular>(boca, ParteQuePuedeEstimular.pene),
					componentsInChildren.Where((AutoSexPosibilidadScore p) => p.paraHole == boca && p.paraParte == ParteQuePuedeEstimular.pene).ToArray<AutoSexPosibilidadScore>()
				},
				{
					new ValueTuple<IHole, ParteQuePuedeEstimular>(vag, ParteQuePuedeEstimular.pene),
					componentsInChildren.Where((AutoSexPosibilidadScore p) => p.paraHole == vag && p.paraParte == ParteQuePuedeEstimular.pene).ToArray<AutoSexPosibilidadScore>()
				},
				{
					new ValueTuple<IHole, ParteQuePuedeEstimular>(anus, ParteQuePuedeEstimular.pene),
					componentsInChildren.Where((AutoSexPosibilidadScore p) => p.paraHole == anus && p.paraParte == ParteQuePuedeEstimular.pene).ToArray<AutoSexPosibilidadScore>()
				}
			};
			this.m_sexScores = new Dictionary<ValueTuple<IHole, ParteQuePuedeEstimular>, AutoSexScore[]>
			{
				{
					new ValueTuple<IHole, ParteQuePuedeEstimular>(boca, ParteQuePuedeEstimular.dedo),
					componentsInChildren2.Where((AutoSexScore p) => p.paraHole == boca && p.paraParte == ParteQuePuedeEstimular.dedo).ToArray<AutoSexScore>()
				},
				{
					new ValueTuple<IHole, ParteQuePuedeEstimular>(vag, ParteQuePuedeEstimular.dedo),
					componentsInChildren2.Where((AutoSexScore p) => p.paraHole == vag && p.paraParte == ParteQuePuedeEstimular.dedo).ToArray<AutoSexScore>()
				},
				{
					new ValueTuple<IHole, ParteQuePuedeEstimular>(anus, ParteQuePuedeEstimular.dedo),
					componentsInChildren2.Where((AutoSexScore p) => p.paraHole == anus && p.paraParte == ParteQuePuedeEstimular.dedo).ToArray<AutoSexScore>()
				},
				{
					new ValueTuple<IHole, ParteQuePuedeEstimular>(boca, ParteQuePuedeEstimular.pene),
					componentsInChildren2.Where((AutoSexScore p) => p.paraHole == boca && p.paraParte == ParteQuePuedeEstimular.pene).ToArray<AutoSexScore>()
				},
				{
					new ValueTuple<IHole, ParteQuePuedeEstimular>(vag, ParteQuePuedeEstimular.pene),
					componentsInChildren2.Where((AutoSexScore p) => p.paraHole == vag && p.paraParte == ParteQuePuedeEstimular.pene).ToArray<AutoSexScore>()
				},
				{
					new ValueTuple<IHole, ParteQuePuedeEstimular>(anus, ParteQuePuedeEstimular.pene),
					componentsInChildren2.Where((AutoSexScore p) => p.paraHole == anus && p.paraParte == ParteQuePuedeEstimular.pene).ToArray<AutoSexScore>()
				}
			};
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x0005A85C File Offset: 0x00058A5C
		public float GetLastMaxPosibilidadScoreParaDedo(IHole hole)
		{
			float num = -1f;
			AutoSexPosibilidadScore[] array;
			if (!this.m_posibilidadesScores.TryGetValue(new ValueTuple<IHole, ParteQuePuedeEstimular>(hole, ParteQuePuedeEstimular.dedo), out array))
			{
				return num;
			}
			foreach (AutoSexPosibilidadScore autoSexPosibilidadScore in array)
			{
				num = Mathf.Max(num, Mathf.Max(autoSexPosibilidadScore.resultados.scoreV2, autoSexPosibilidadScore.resultados.scoreByDesires));
			}
			return num;
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x0005A8C0 File Offset: 0x00058AC0
		public float GetLastMaxPosibilidadScoreParaPene(IHole hole)
		{
			float num = -1f;
			AutoSexPosibilidadScore[] array;
			if (!this.m_posibilidadesScores.TryGetValue(new ValueTuple<IHole, ParteQuePuedeEstimular>(hole, ParteQuePuedeEstimular.pene), out array))
			{
				return num;
			}
			foreach (AutoSexPosibilidadScore autoSexPosibilidadScore in array)
			{
				num = Mathf.Max(num, Mathf.Max(autoSexPosibilidadScore.resultados.scoreV2, autoSexPosibilidadScore.resultados.scoreByDesires));
			}
			return num;
		}

		// Token: 0x060012FB RID: 4859 RVA: 0x0005A920 File Offset: 0x00058B20
		public float GetLastMaxScoreParaDedo(IHole hole)
		{
			float num = -1f;
			AutoSexScore[] array;
			if (!this.m_sexScores.TryGetValue(new ValueTuple<IHole, ParteQuePuedeEstimular>(hole, ParteQuePuedeEstimular.dedo), out array))
			{
				return num;
			}
			foreach (AutoSexScore autoSexScore in array)
			{
				num = Mathf.Max(num, Mathf.Max(autoSexScore.resultados.scoreV2, autoSexScore.resultados.scoreByDesires));
			}
			return num;
		}

		// Token: 0x060012FC RID: 4860 RVA: 0x0005A984 File Offset: 0x00058B84
		public float GetLastMaxScoreParaPene(IHole hole)
		{
			float num = -1f;
			AutoSexScore[] array;
			if (!this.m_sexScores.TryGetValue(new ValueTuple<IHole, ParteQuePuedeEstimular>(hole, ParteQuePuedeEstimular.pene), out array))
			{
				return num;
			}
			foreach (AutoSexScore autoSexScore in array)
			{
				num = Mathf.Max(num, Mathf.Max(autoSexScore.resultados.scoreV2, autoSexScore.resultados.scoreByDesires));
			}
			return num;
		}

		// Token: 0x04000DE6 RID: 3558
		private Dictionary<ValueTuple<IHole, ParteQuePuedeEstimular>, AutoSexPosibilidadScore[]> m_posibilidadesScores;

		// Token: 0x04000DE7 RID: 3559
		private Dictionary<ValueTuple<IHole, ParteQuePuedeEstimular>, AutoSexScore[]> m_sexScores;
	}
}
