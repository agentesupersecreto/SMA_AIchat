using System;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Followers
{
	// Token: 0x020000B2 RID: 178
	public abstract class FollowInterObjFemaleCharBoneScalerBase : FollowInterObjFemaleCharBoneBase
	{
		// Token: 0x060006C5 RID: 1733 RVA: 0x00020C24 File Offset: 0x0001EE24
		protected override void StartUnityEvent()
		{
			this.LoadScalerTarget();
			base.StartUnityEvent();
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x00020C34 File Offset: 0x0001EE34
		private void LoadScalerTarget()
		{
			if (string.IsNullOrEmpty(this.scalerBoneName))
			{
				throw new NullReferenceException();
			}
			Animator componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			string text = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerNombreDeHueso(this.scalerBoneName);
			this.m_scalerBoneTarget = componentEnRoot.transform.FindDeepChild(text, this.scalerBoneName, true);
			if (this.m_scalerBoneTarget == null)
			{
				throw new ArgumentNullException("m_scalerBoneTarget", "m_scalerBoneTarget null reference.");
			}
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x00020CBD File Offset: 0x0001EEBD
		protected override bool Following()
		{
			return base.Following() && this.m_scalerBoneTarget != null;
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x00020CD8 File Offset: 0x0001EED8
		protected override Matrix4x4 GetLocalToWorldMatrix()
		{
			Matrix4x4 identity = Matrix4x4.identity;
			Vector3 lossyScale = this.m_scalerBoneTarget.lossyScale;
			Vector3 vector = lossyScale;
			switch (this.xScaleEs)
			{
			case Axis.x:
				vector.x = lossyScale.x;
				goto IL_007B;
			case Axis.y:
				vector.x = lossyScale.y;
				goto IL_007B;
			case Axis.z:
				vector.x = lossyScale.z;
				goto IL_007B;
			}
			throw new ArgumentOutOfRangeException(this.xScaleEs.ToString());
			IL_007B:
			switch (this.yScaleEs)
			{
			case Axis.x:
				vector.y = lossyScale.x;
				goto IL_00E2;
			case Axis.y:
				vector.y = lossyScale.y;
				goto IL_00E2;
			case Axis.z:
				vector.y = lossyScale.z;
				goto IL_00E2;
			}
			throw new ArgumentOutOfRangeException(this.xScaleEs.ToString());
			IL_00E2:
			switch (this.zScaleEs)
			{
			case Axis.x:
				vector.z = lossyScale.x;
				goto IL_0149;
			case Axis.y:
				vector.z = lossyScale.y;
				goto IL_0149;
			case Axis.z:
				vector.z = lossyScale.z;
				goto IL_0149;
			}
			throw new ArgumentOutOfRangeException(this.xScaleEs.ToString());
			IL_0149:
			if (this.transferenciaDeEscala == 1f)
			{
				identity.SetTRS(this.m_boneTarget.position, this.m_boneTarget.rotation, vector);
			}
			else if (this.transferenciaDeEscala > 1f)
			{
				identity.SetTRS(this.m_boneTarget.position, this.m_boneTarget.rotation, vector * this.transferenciaDeEscala);
			}
			else
			{
				identity.SetTRS(this.m_boneTarget.position, this.m_boneTarget.rotation, Vector3.Lerp(this.m_boneTarget.lossyScale, vector, this.transferenciaDeEscala));
			}
			return identity;
		}

		// Token: 0x04000491 RID: 1169
		[Header("Scaler Config")]
		[StringSelector(typeof(MapaSingletonDeFemaleBones), "fieldNamesEditor")]
		public string scalerBoneName;

		// Token: 0x04000492 RID: 1170
		[ReadOnlyUI]
		[SerializeField]
		protected Transform m_scalerBoneTarget;

		// Token: 0x04000493 RID: 1171
		[Range(0f, 1f)]
		public float transferenciaDeEscala = 1f;

		// Token: 0x04000494 RID: 1172
		public Axis xScaleEs = Axis.x;

		// Token: 0x04000495 RID: 1173
		public Axis yScaleEs = Axis.y;

		// Token: 0x04000496 RID: 1174
		public Axis zScaleEs = Axis.z;
	}
}
