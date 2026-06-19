using System;
using Unity.Collections;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts
{
	// Token: 0x02000074 RID: 116
	public class ModificadorDeMasaDeContactos : ModificadorDeContactosBase<ModificadorDeMasaDeContactos, ModificadorDeMasaDeContactosUser, ModificadorDeMasaDeContactos.Data>
	{
		// Token: 0x0600028E RID: 654 RVA: 0x00007D20 File Offset: 0x00005F20
		protected override void Physics_ContactModifyEvent(PhysicsScene arg1, NativeArray<ModifiableContactPair> arg2)
		{
			for (int i = 0; i < arg2.Length; i++)
			{
				ModifiableContactPair modifiableContactPair = arg2[i];
				bool flag = this.m_collidersIds.Contains(modifiableContactPair.colliderInstanceID);
				bool flag2 = this.m_collidersIds.Contains(modifiableContactPair.otherColliderInstanceID);
				if (flag || flag2)
				{
					ModifiableMassProperties massProperties = modifiableContactPair.massProperties;
					if (flag)
					{
						this.Procesar(modifiableContactPair.colliderInstanceID, flag2 ? new int?(modifiableContactPair.otherColliderInstanceID) : null, ref massProperties.inverseInertiaScale, ref massProperties.inverseMassScale);
					}
					if (flag2)
					{
						this.Procesar(modifiableContactPair.otherColliderInstanceID, flag ? new int?(modifiableContactPair.colliderInstanceID) : null, ref massProperties.otherInverseInertiaScale, ref massProperties.otherInverseMassScale);
					}
					modifiableContactPair.massProperties = massProperties;
				}
			}
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00007E04 File Offset: 0x00006004
		private void Procesar(int colliderInstanceID, int? otherColliderInstanceID, ref float inverseInertiaScale, ref float inverseMassScale)
		{
			int num = this.m_colliderToUserID[colliderInstanceID];
			ModificadorDeMasaDeContactos.Data data = this.m_dataDeUserID[num];
			inverseInertiaScale *= data.inverseMassScaleMod;
			inverseMassScale *= data.inverseMassScaleMod;
			if (otherColliderInstanceID != null)
			{
				int num2 = this.m_colliderToUserID[otherColliderInstanceID.Value];
				ModificadorDeMasaDeContactos.Data data2 = this.m_dataDeUserID[num2];
				float num3 = data.inverseMassScalePerLayer[data2.layer];
				inverseInertiaScale *= num3 * data2.otherInverseMassScaleMod;
				inverseMassScale *= num3 * data2.otherInverseMassScaleMod;
			}
		}

		// Token: 0x02000165 RID: 357
		[Serializable]
		public struct Data
		{
			// Token: 0x04000852 RID: 2130
			public int layer;

			// Token: 0x04000853 RID: 2131
			public float otherInverseMassScaleMod;

			// Token: 0x04000854 RID: 2132
			public float inverseMassScaleMod;

			// Token: 0x04000855 RID: 2133
			public float[] inverseMassScalePerLayer;
		}
	}
}
