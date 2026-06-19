using System;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts
{
	// Token: 0x02000072 RID: 114
	[Obsolete("bugueado en esta version")]
	public class ModificadorDeImpulsoDeContactos : ModificadorDeContactosBase<ModificadorDeImpulsoDeContactos, ModificadorDeImpulsoDeContactosUser, ModificadorDeImpulsoDeContactos.Data>
	{
		// Token: 0x06000283 RID: 643 RVA: 0x00007920 File Offset: 0x00005B20
		protected override void Physics_ContactModifyEvent(PhysicsScene arg1, NativeArray<ModifiableContactPair> arg2)
		{
			for (int i = 0; i < arg2.Length; i++)
			{
				ModifiableContactPair modifiableContactPair = arg2[i];
				bool flag = this.m_collidersIds.Contains(modifiableContactPair.colliderInstanceID);
				bool flag2 = this.m_collidersIds.Contains(modifiableContactPair.otherColliderInstanceID);
				if (flag || flag2)
				{
					for (int j = 0; j < modifiableContactPair.contactCount; j++)
					{
						float num = modifiableContactPair.GetMaxImpulse(i);
						float separation = modifiableContactPair.GetSeparation(i);
						if (flag)
						{
							float num2 = this.Procesar(modifiableContactPair.colliderInstanceID, flag2 ? new int?(modifiableContactPair.otherColliderInstanceID) : null, separation);
							num = ((num2 < num) ? num2 : num);
						}
						if (flag2)
						{
							float num3 = this.Procesar(modifiableContactPair.otherColliderInstanceID, flag ? new int?(modifiableContactPair.colliderInstanceID) : null, separation);
							num = ((num3 < num) ? num3 : num);
						}
						modifiableContactPair.SetMaxImpulse(i, num);
						modifiableContactPair.IgnoreContact(i);
					}
				}
			}
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00007A3C File Offset: 0x00005C3C
		private float Procesar(int colliderInstanceID, int? otherColliderInstanceID, float separacion)
		{
			int num = this.m_colliderToUserID[colliderInstanceID];
			ModificadorDeImpulsoDeContactos.Data data = this.m_dataDeUserID[num];
			float num2 = Mathf.InverseLerp(data.separationRange.y, data.separationRange.x, separacion);
			float num3 = Mathf.Lerp(data.impulseCap, 0f, num2);
			if (otherColliderInstanceID != null)
			{
				int num4 = this.m_colliderToUserID[otherColliderInstanceID.Value];
				int layer = this.m_dataDeUserID[num4].layer;
				float2 @float = data.separationRangePerLayer[layer];
				float num5 = data.impulseCapPerLayer[layer];
				float num6 = Mathf.InverseLerp(@float.y, @float.x, separacion);
				float num7 = Mathf.Lerp(num5, 0f, num6);
				num3 = ((num7 < num3) ? num7 : num3);
			}
			return num3;
		}

		// Token: 0x02000163 RID: 355
		[Serializable]
		public struct Data
		{
			// Token: 0x0400084A RID: 2122
			public int layer;

			// Token: 0x0400084B RID: 2123
			public float2 separationRange;

			// Token: 0x0400084C RID: 2124
			public float2[] separationRangePerLayer;

			// Token: 0x0400084D RID: 2125
			public float impulseCap;

			// Token: 0x0400084E RID: 2126
			public float[] impulseCapPerLayer;
		}
	}
}
