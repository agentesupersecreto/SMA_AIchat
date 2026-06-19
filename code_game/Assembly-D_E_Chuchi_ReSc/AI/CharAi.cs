using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000321 RID: 801
	public abstract class CharAi : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x0600113B RID: 4411
		public abstract Vector3 ConvertirParteEnumEnWorldPosition(PartesHumanasParaAi parte);

		// Token: 0x0600113C RID: 4412 RVA: 0x0004A599 File Offset: 0x00048799
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_updateCorutina = new CoroutineCapsule(this.UpdateRutina(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x0600113D RID: 4413 RVA: 0x0004A5C6 File Offset: 0x000487C6
		private IEnumerator UpdateRutina()
		{
			WaitForSeconds w = new WaitForSeconds(5f.Random(0.2f));
			for (;;)
			{
				yield return w;
				for (int i = 0; i < this.m_registrosTemporalesSingle.Count; i++)
				{
					ValueTuple<ParteDelCuerpoHumano, TipoDeSemen, Side, int> valueTuple = this.m_registrosTemporalesSingle[i];
					this.UnRegistrarSemenSobre(valueTuple.Item1, valueTuple.Item2, valueTuple.Item3, valueTuple.Item4);
				}
				this.m_registrosTemporalesSingle.Clear();
			}
			yield break;
		}

		// Token: 0x0600113E RID: 4414 RVA: 0x0004A5D5 File Offset: 0x000487D5
		public void RegistrarSemenSobreTemporal(ParteDelCuerpoHumano parte, TipoDeSemen tipo, Side side, int cantidadARegistrar = 1)
		{
			this.RegistrarSemenSobre(parte, tipo, side, cantidadARegistrar);
			this.m_registrosTemporalesSingle.Add(new ValueTuple<ParteDelCuerpoHumano, TipoDeSemen, Side, int>(parte, tipo, side, cantidadARegistrar));
		}

		// Token: 0x0600113F RID: 4415 RVA: 0x0004A5F8 File Offset: 0x000487F8
		public void RegistrarSemenSobre(ParteDelCuerpoHumano parte, TipoDeSemen tipo, Side side, int cantidadARegistrar = 1)
		{
			if (cantidadARegistrar <= 0)
			{
				return;
			}
			ValueTuple<ParteDelCuerpoHumano, TipoDeSemen, Side> valueTuple = new ValueTuple<ParteDelCuerpoHumano, TipoDeSemen, Side>(parte, tipo, side);
			int num;
			if (!this.m_currentPartesCubiertasDeSemen.TryGetValue(valueTuple, out num))
			{
				num = 0;
				this.m_currentPartesCubiertasDeSemen.Add(valueTuple, num);
			}
			this.m_currentPartesCubiertasDeSemen[valueTuple] = Mathf.Clamp(num + cantidadARegistrar, 0, int.MaxValue);
		}

		// Token: 0x06001140 RID: 4416 RVA: 0x0004A650 File Offset: 0x00048850
		public void UnRegistrarSemenSobre(ParteDelCuerpoHumano parte, TipoDeSemen tipo, Side side, int cantidadAUnRegistrar = 1)
		{
			if (cantidadAUnRegistrar <= 0)
			{
				return;
			}
			ValueTuple<ParteDelCuerpoHumano, TipoDeSemen, Side> valueTuple = new ValueTuple<ParteDelCuerpoHumano, TipoDeSemen, Side>(parte, tipo, side);
			int num;
			if (!this.m_currentPartesCubiertasDeSemen.TryGetValue(valueTuple, out num))
			{
				return;
			}
			if (num < 0)
			{
				this.m_currentPartesCubiertasDeSemen[valueTuple] = 0;
				return;
			}
			if (num == 0)
			{
				return;
			}
			this.m_currentPartesCubiertasDeSemen[valueTuple] = Mathf.Clamp(num - cantidadAUnRegistrar, 0, int.MaxValue);
		}

		// Token: 0x06001141 RID: 4417 RVA: 0x0004A6B0 File Offset: 0x000488B0
		public bool SemenSobre(ParteDelCuerpoHumano parte, TipoDeSemen tipo, Side side)
		{
			ValueTuple<ParteDelCuerpoHumano, TipoDeSemen, Side> valueTuple = new ValueTuple<ParteDelCuerpoHumano, TipoDeSemen, Side>(parte, tipo, side);
			int num;
			return this.m_currentPartesCubiertasDeSemen.TryGetValue(valueTuple, out num) && num > 0;
		}

		// Token: 0x06001142 RID: 4418 RVA: 0x0004A6E0 File Offset: 0x000488E0
		public int SemenSobreCantidad(ParteDelCuerpoHumano parte, TipoDeSemen tipo, Side side)
		{
			ValueTuple<ParteDelCuerpoHumano, TipoDeSemen, Side> valueTuple = new ValueTuple<ParteDelCuerpoHumano, TipoDeSemen, Side>(parte, tipo, side);
			int num;
			if (!this.m_currentPartesCubiertasDeSemen.TryGetValue(valueTuple, out num))
			{
				return 0;
			}
			if (num < 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x06001143 RID: 4419 RVA: 0x0004A710 File Offset: 0x00048910
		public bool SemenSobreAny(ParteDelCuerpoHumano parte, Side side)
		{
			IReadOnlyList<int> enumValoresInt = typeof(TipoDeSemen).GetEnumValoresInt();
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				if (this.SemenSobre(parte, (TipoDeSemen)enumValoresInt[i], side))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001144 RID: 4420 RVA: 0x0004A754 File Offset: 0x00048954
		public int SemenSobreCantidadAny(ParteDelCuerpoHumano parte, Side side)
		{
			IReadOnlyList<int> enumValoresInt = typeof(TipoDeSemen).GetEnumValoresInt();
			int num = 0;
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				num += this.SemenSobreCantidad(parte, (TipoDeSemen)enumValoresInt[i], side);
			}
			if (num < 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x04000DC3 RID: 3523
		private Dictionary<ValueTuple<ParteDelCuerpoHumano, TipoDeSemen, Side>, int> m_currentPartesCubiertasDeSemen = new Dictionary<ValueTuple<ParteDelCuerpoHumano, TipoDeSemen, Side>, int>();

		// Token: 0x04000DC4 RID: 3524
		private List<ValueTuple<ParteDelCuerpoHumano, TipoDeSemen, Side, int>> m_registrosTemporalesSingle = new List<ValueTuple<ParteDelCuerpoHumano, TipoDeSemen, Side, int>>();

		// Token: 0x04000DC5 RID: 3525
		private CoroutineCapsule m_updateCorutina;
	}
}
