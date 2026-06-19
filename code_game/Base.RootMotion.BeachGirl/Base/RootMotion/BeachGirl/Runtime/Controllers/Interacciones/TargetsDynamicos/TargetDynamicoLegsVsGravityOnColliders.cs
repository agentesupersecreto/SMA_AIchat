using System;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones.TargetsDynamicos
{
	// Token: 0x02000040 RID: 64
	public class TargetDynamicoLegsVsGravityOnColliders : TargetDynamicoLimbVsGravityOnColliders
	{
		// Token: 0x060002B3 RID: 691 RVA: 0x0000E168 File Offset: 0x0000C368
		protected override float GetExtraCastDistance(ICharacter para, float scala, Vector3 castOrigin, float castDistance, Vector3 castDirection)
		{
			float extraCastDistance = base.GetExtraCastDistance(para, scala, castOrigin, castDistance, castDirection);
			ICharacterHighHeelable componentInChildren = para.GetComponentInChildren<ICharacterHighHeelable>();
			if (componentInChildren == null)
			{
				return extraCastDistance;
			}
			castDirection = castDirection.normalized;
			Side side = this.side;
			Vector3 vector;
			Vector3 vector2;
			if (side != Side.L)
			{
				if (side != Side.R)
				{
					Debug.LogError("Side de target dinamico es incorrecto", this);
					return extraCastDistance;
				}
				vector = componentInChildren.GetDownDirectionFromHeelsR();
				vector2 = componentInChildren.GetDownDirectionFromToesR();
			}
			else
			{
				vector = componentInChildren.GetDownDirectionFromHeelsL();
				vector2 = componentInChildren.GetDownDirectionFromToesL();
			}
			Vector3 vector3 = Vector3.Project(this.toes.position - this.bone3.position, castDirection);
			Vector3 vector4 = Vector3.Project(vector2 * componentInChildren.currentRealToeWorldTotalHeight, castDirection);
			Vector3 vector5 = castDirection * castDistance + (vector3 + vector4);
			float num = vector3.magnitude + vector4.magnitude;
			bool debugDraw = this.debugDraw;
			Vector3 vector6 = Vector3.Project(vector * componentInChildren.currentRealHeelWorldTotalHeight, castDirection);
			Vector3 vector7 = castDirection * castDistance + vector6;
			float magnitude = vector6.magnitude;
			bool debugDraw2 = this.debugDraw;
			float num2;
			if (vector5.sqrMagnitude > vector7.sqrMagnitude)
			{
				num2 = num;
			}
			else
			{
				num2 = magnitude;
			}
			return extraCastDistance + num2;
		}

		// Token: 0x040001DD RID: 477
		public Transform toes;

		// Token: 0x040001DE RID: 478
		public Side side;
	}
}
