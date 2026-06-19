using System;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.TransFollowers
{
	// Token: 0x0200004B RID: 75
	public class FollowFemaleCharIKBone : IKPassMatrixFollower
	{
		// Token: 0x06000341 RID: 833 RVA: 0x000107CB File Offset: 0x0000E9CB
		protected override void InitTransformTarget()
		{
			this.LoadTarget();
			base.InitTransformTarget();
		}

		// Token: 0x06000342 RID: 834 RVA: 0x000107DC File Offset: 0x0000E9DC
		private void LoadTarget()
		{
			if (string.IsNullOrEmpty(this.boneName))
			{
				throw new NullReferenceException();
			}
			Animator componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			string text = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerNombreDeHueso(this.boneName);
			this.m_boneTarget = componentEnRoot.transform.FindDeepChild(text, true);
			if (this.m_boneTarget == null)
			{
				this.m_boneTarget = componentEnRoot.transform.FindDeepChild(this.boneName, true);
			}
			if (this.m_boneTarget == null)
			{
				throw new ArgumentNullException("m_boneTarget", "m_boneTarget null reference.");
			}
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00010885 File Offset: 0x0000EA85
		protected sealed override bool Following()
		{
			return this.m_boneTarget;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00010892 File Offset: 0x0000EA92
		protected sealed override Matrix4x4 GetLocalToWorldMatrix()
		{
			return this.m_boneTarget.localToWorldMatrix;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0001089F File Offset: 0x0000EA9F
		protected sealed override void FollowingValidarMatrix(ref Matrix4x4 matrix)
		{
		}

		// Token: 0x06000346 RID: 838 RVA: 0x000108A1 File Offset: 0x0000EAA1
		protected sealed override void Followed()
		{
		}

		// Token: 0x04000246 RID: 582
		[StringSelector(typeof(MapaSingletonDeFemaleBones), "fieldNamesEditor")]
		public string boneName;

		// Token: 0x04000247 RID: 583
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_boneTarget;
	}
}
