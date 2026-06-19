using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Utilidades
{
	// Token: 0x020000F2 RID: 242
	[RequireComponent(typeof(Interaccion))]
	public sealed class TransferirAnimatorBoneScalaToPivot : TransferirScalaToPivot
	{
		// Token: 0x0600091E RID: 2334 RVA: 0x0002979C File Offset: 0x0002799C
		protected override Transform ObtenerTarget(Interaccion obj)
		{
			ICharacter componentInParent = obj.GetComponentInParent<ICharacter>();
			if (componentInParent == null)
			{
				throw new ArgumentNullException("character", "character null reference.");
			}
			return componentInParent.bodyAnimator.GetBoneTransform(this.bone);
		}

		// Token: 0x040005B3 RID: 1459
		public HumanBodyBones bone;
	}
}
