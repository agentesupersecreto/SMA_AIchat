using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts
{
	// Token: 0x02000073 RID: 115
	[Obsolete("bugueado en esta version")]
	public class ModificadorDeImpulsoDeContactosUser : ModificadorDeContactosUserBase<ModificadorDeImpulsoDeContactos.Data>
	{
		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000286 RID: 646 RVA: 0x00007B13 File Offset: 0x00005D13
		public override ModificadorDeImpulsoDeContactos.Data data
		{
			get
			{
				return this.m_data;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000287 RID: 647 RVA: 0x00007B1B File Offset: 0x00005D1B
		public ModificadorDeImpulsoDeContactosUser.Modificables modificables
		{
			get
			{
				return this.m_modificables;
			}
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00007B24 File Offset: 0x00005D24
		public ModificadorDeImpulsoDeContactosUser.Modificables GetAgaintsLayerModificable(int layer)
		{
			ModificadorDeImpulsoDeContactosUser.Modificables modificables = this.m_perLayerModificables[layer];
			if (modificables == null)
			{
				modificables = new ModificadorDeImpulsoDeContactosUser.Modificables();
				this.m_perLayerModificables[layer] = modificables;
			}
			return modificables;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00007B4D File Offset: 0x00005D4D
		protected override void AwakeUnityEvent()
		{
			this.m_data = default(ModificadorDeImpulsoDeContactos.Data);
			this.m_data.separationRangePerLayer = new float2[32];
			this.m_data.impulseCapPerLayer = new float[32];
			base.AwakeUnityEvent();
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00007B88 File Offset: 0x00005D88
		public override void UpdateData()
		{
			float num = Physics.defaultContactOffset;
			this.m_data.layer = base.gameObject.layer;
			this.m_data.separationRange = new float2((this.m_modificables.startSeparacionPromediable.Count == 0) ? num : this.m_modificables.startSeparacionPromediable.PromediarSinValor(), (this.m_modificables.endSeparacionPromediable.Count == 0) ? num : this.m_modificables.endSeparacionPromediable.PromediarSinValor());
			this.m_data.impulseCap = this.m_modificables.impulseCapLimitable.MinimoValorIncluyendo(float.MaxValue);
			for (int i = 0; i < 32; i++)
			{
				ModificadorDeImpulsoDeContactosUser.Modificables modificables = this.m_perLayerModificables[i];
				if (modificables == null)
				{
					this.m_data.separationRangePerLayer[i] = new float2(num, num);
					this.m_data.impulseCapPerLayer[i] = float.MaxValue;
				}
				else
				{
					this.m_data.separationRangePerLayer[i] = new float2((modificables.startSeparacionPromediable.Count == 0) ? num : modificables.startSeparacionPromediable.PromediarSinValor(), (modificables.endSeparacionPromediable.Count == 0) ? num : modificables.endSeparacionPromediable.PromediarSinValor());
					this.m_data.impulseCapPerLayer[i] = modificables.impulseCapLimitable.MinimoValorIncluyendo(float.MaxValue);
				}
			}
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00007CDF File Offset: 0x00005EDF
		protected override void Subcribe()
		{
			Singleton<ModificadorDeImpulsoDeContactos>.instance.Add(this);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00007CEC File Offset: 0x00005EEC
		protected override void UnSubcribe()
		{
			if (Singleton<ModificadorDeImpulsoDeContactos>.IsInScene)
			{
				Singleton<ModificadorDeImpulsoDeContactos>.instance.Remove(this);
			}
		}

		// Token: 0x0400019D RID: 413
		private const float defaultContactOffset = 0.0075f;

		// Token: 0x0400019E RID: 414
		[SerializeField]
		private ModificadorDeImpulsoDeContactos.Data m_data;

		// Token: 0x0400019F RID: 415
		[SerializeField]
		private ModificadorDeImpulsoDeContactosUser.Modificables m_modificables = new ModificadorDeImpulsoDeContactosUser.Modificables();

		// Token: 0x040001A0 RID: 416
		[SerializeField]
		private ModificadorDeImpulsoDeContactosUser.Modificables[] m_perLayerModificables = new ModificadorDeImpulsoDeContactosUser.Modificables[32];

		// Token: 0x02000164 RID: 356
		[Serializable]
		public class Modificables
		{
			// Token: 0x170004E7 RID: 1255
			// (get) Token: 0x06000E22 RID: 3618 RVA: 0x00030E55 File Offset: 0x0002F055
			public ModificableDeFloat startSeparacionPromediable
			{
				get
				{
					return this.m_startSeparacionPromediable;
				}
			}

			// Token: 0x170004E8 RID: 1256
			// (get) Token: 0x06000E23 RID: 3619 RVA: 0x00030E5D File Offset: 0x0002F05D
			public ModificableDeFloat endSeparacionPromediable
			{
				get
				{
					return this.m_endSeparacionPromediable;
				}
			}

			// Token: 0x170004E9 RID: 1257
			// (get) Token: 0x06000E24 RID: 3620 RVA: 0x00030E65 File Offset: 0x0002F065
			public ModificableDeFloat impulseCapLimitable
			{
				get
				{
					return this.m_impulseCapLimitable;
				}
			}

			// Token: 0x0400084F RID: 2127
			[SerializeField]
			private ModificableDeFloat m_startSeparacionPromediable = new ModificableDeFloat(0.0075f);

			// Token: 0x04000850 RID: 2128
			[SerializeField]
			private ModificableDeFloat m_endSeparacionPromediable = new ModificableDeFloat(0.0075f);

			// Token: 0x04000851 RID: 2129
			[SerializeField]
			private ModificableDeFloat m_impulseCapLimitable = new ModificableDeFloat(float.MaxValue);
		}
	}
}
