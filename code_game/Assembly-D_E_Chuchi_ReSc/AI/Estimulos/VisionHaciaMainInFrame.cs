using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003F6 RID: 1014
	public class VisionHaciaMainInFrame : EstimuloInFrame
	{
		// Token: 0x17000573 RID: 1395
		// (get) Token: 0x0600162B RID: 5675 RVA: 0x0005C87A File Offset: 0x0005AA7A
		public DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual> frameVistas
		{
			get
			{
				return this.m_result;
			}
		}

		// Token: 0x0600162C RID: 5676 RVA: 0x0005C884 File Offset: 0x0005AA84
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_visionInformer = this.m_character.GetComponentInChildren<ICharVisionInformer>();
			if (this.m_visionInformer == null)
			{
				throw new ArgumentNullException("m_visionInformer", "m_visionInformer null reference.");
			}
			this.m_result = new DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual>((ParteQuePuedeEstimular e) => (int)e);
			this.instanciasGetter = new Func<EstimuloVisual>(this.m_pool.GetItem);
		}

		// Token: 0x0600162D RID: 5677 RVA: 0x0005C904 File Offset: 0x0005AB04
		protected override void OnUpdateEstimulo(EmocionesFemeninas emos)
		{
			if (this.m_result.Count > 0)
			{
				foreach (KeyValuePair<int, EstimuloVisual> keyValuePair in this.m_result)
				{
					this.m_pool.ReturnItem(keyValuePair.Value);
				}
				this.m_result.Clear();
			}
			Character current = MainChar.current;
			if (current == null)
			{
				return;
			}
			this.m_visionInformer.EstimulosDadoA(current, this.instanciasGetter, this.m_result);
			IReadOnlyList<ICharacter> slavesDe = Singleton<CharacteresActivos>.instance.GetSlavesDe(current);
			if (slavesDe != null)
			{
				for (int i = 0; i < slavesDe.Count; i++)
				{
					this.m_visionInformer.EstimulosDadoA(slavesDe[i], this.instanciasGetter, this.m_result);
				}
			}
			if (this.debugLog)
			{
				foreach (KeyValuePair<int, EstimuloVisual> keyValuePair2 in this.m_result)
				{
					Debug.Log("Estimulante: " + ((ParteQuePuedeEstimular)keyValuePair2.Key).ToString() + " Estimulada: " + string.Join(", ", keyValuePair2.Value.partesDelCuerpoHumanoEstimuladas.Select((ParteDelCuerpoHumano p) => p.ToString())));
				}
			}
		}

		// Token: 0x0400119E RID: 4510
		public bool debugLog;

		// Token: 0x0400119F RID: 4511
		private ICharVisionInformer m_visionInformer;

		// Token: 0x040011A0 RID: 4512
		private DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual> m_result;

		// Token: 0x040011A1 RID: 4513
		private Func<EstimuloVisual> instanciasGetter;

		// Token: 0x040011A2 RID: 4514
		private PoolDeInteraccionEstimulante<EstimuloVisual> m_pool = new PoolDeInteraccionEstimulante<EstimuloVisual>();
	}
}
