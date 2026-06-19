using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x0200017A RID: 378
	public class TValleOffsetPose : MonoBehaviour
	{
		// Token: 0x06000829 RID: 2089 RVA: 0x0002B049 File Offset: 0x00029249
		private void Start()
		{
			this.m_character = this.GetComponentEnRoot(false);
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x0002B070 File Offset: 0x00029270
		public void Apply(IKSolverFullBodyBiped solver, float weight)
		{
			for (int i = 0; i < this.effectorLinks.Length; i++)
			{
				this.effectorLinks[i].Apply(solver, weight, solver.GetRoot().rotation, this.m_character);
			}
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x0002B0B0 File Offset: 0x000292B0
		public void Apply(IKSolverFullBodyBiped solver, float weight, Quaternion rotation)
		{
			for (int i = 0; i < this.effectorLinks.Length; i++)
			{
				this.effectorLinks[i].Apply(solver, weight, rotation, this.m_character);
			}
		}

		// Token: 0x0400068C RID: 1676
		private ICharacter m_character;

		// Token: 0x0400068D RID: 1677
		public TValleOffsetPose.EffectorLink[] effectorLinks = new TValleOffsetPose.EffectorLink[0];

		// Token: 0x0200017B RID: 379
		[Serializable]
		public class EffectorLink
		{
			// Token: 0x0600082D RID: 2093 RVA: 0x0002B0FC File Offset: 0x000292FC
			public void Apply(IKSolverFullBodyBiped solver, float weight, Quaternion rotation, ICharacter character)
			{
				solver.GetEffector(this.effector).positionOffset += rotation * (this.offset * character.escala) * weight;
				Vector3 vector = solver.GetRoot().position + rotation * (this.pin * character.escala) - solver.GetEffector(this.effector).bone.position;
				Vector3 vector2 = this.pinWeight * Mathf.Abs(weight);
				solver.GetEffector(this.effector).positionOffset = new Vector3(Mathf.Lerp(solver.GetEffector(this.effector).positionOffset.x, vector.x, vector2.x), Mathf.Lerp(solver.GetEffector(this.effector).positionOffset.y, vector.y, vector2.y), Mathf.Lerp(solver.GetEffector(this.effector).positionOffset.z, vector.z, vector2.z));
			}

			// Token: 0x0600082E RID: 2094 RVA: 0x0002B224 File Offset: 0x00029424
			public void Visualize(IKSolverFullBodyBiped solver, Quaternion rotation, ICharacter character)
			{
				Vector3 position = solver.GetEffector(this.effector).position;
				Vector3 vector = rotation * (this.offset * character.escala);
				Vector3 vector2 = solver.GetRoot().position + rotation * (this.pin * character.escala) - solver.GetEffector(this.effector).bone.position;
				Vector3 vector3 = this.pinWeight;
				vector = new Vector3(Mathf.Lerp(vector.x, vector2.x, vector3.x), Mathf.Lerp(vector.y, vector2.y, vector3.y), Mathf.Lerp(vector.z, vector2.z, vector3.z));
				Color color;
				switch (this.effector)
				{
				case FullBodyBipedEffector.Body:
					color = Color.yellow;
					break;
				case FullBodyBipedEffector.LeftShoulder:
					color = Color.black;
					break;
				case FullBodyBipedEffector.RightShoulder:
					color = Color.green;
					break;
				case FullBodyBipedEffector.LeftThigh:
					color = Color.magenta;
					break;
				case FullBodyBipedEffector.RightThigh:
					color = Color.cyan;
					break;
				case FullBodyBipedEffector.LeftHand:
					color = Color.red;
					break;
				case FullBodyBipedEffector.RightHand:
					color = Color.blue;
					break;
				case FullBodyBipedEffector.LeftFoot:
					color = Color.green;
					break;
				case FullBodyBipedEffector.RightFoot:
					color = Color.black;
					break;
				default:
					throw new ArgumentOutOfRangeException(this.effector.ToString());
				}
				Gizmos.color = color;
				Gizmos.DrawSphere(position, 0.01f);
				Gizmos.DrawSphere(position + vector, 0.01f);
				Gizmos.DrawLine(position, position + vector);
			}

			// Token: 0x0400068E RID: 1678
			public FullBodyBipedEffector effector;

			// Token: 0x0400068F RID: 1679
			public Vector3 offset;

			// Token: 0x04000690 RID: 1680
			public Vector3 pin;

			// Token: 0x04000691 RID: 1681
			public Vector3 pinWeight;
		}
	}
}
