using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000022 RID: 34
	public abstract class EmulatedMaleHitSkin : MaleHitSkinBasica
	{
		// Token: 0x060000DC RID: 220 RVA: 0x00004252 File Offset: 0x00002452
		public override bool PointIsInside(Vector3 worldPoint)
		{
			return false;
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00004E33 File Offset: 0x00003033
		public sealed override ParteQuePuedeEstimular parteQuePuedeEstimular
		{
			get
			{
				return this.m_parte;
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004E3C File Offset: 0x0000303C
		protected void InitEmulated(ParteQuePuedeEstimular Parte, Transform boneTarget, Skin VisualSkin)
		{
			this.m_parte = Parte;
			this.m_myCharacter = base.GetComponentInParent<Character>();
			base.InitBasica(boneTarget, VisualSkin);
			foreach (Collider collider in this.skinCollidersSet)
			{
				collider.gameObject.AddComponent<ColliderDeEmulatedMaleHitSkin>().Init(this);
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00004EB4 File Offset: 0x000030B4
		public bool ContieneCollider(Collider collider)
		{
			return this.skinCollidersSet.Contains(collider);
		}

		// Token: 0x04000092 RID: 146
		[SerializeField]
		[ReadOnlyUI]
		private ParteQuePuedeEstimular m_parte;

		// Token: 0x04000093 RID: 147
		private Character m_myCharacter;
	}
}
