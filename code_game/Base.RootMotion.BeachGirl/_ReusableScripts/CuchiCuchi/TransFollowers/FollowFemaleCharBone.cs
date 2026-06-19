using System;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.TransFollowers
{
	// Token: 0x0200004A RID: 74
	public class FollowFemaleCharBone : IKMatrixFollower
	{
		// Token: 0x06000339 RID: 825 RVA: 0x000106DF File Offset: 0x0000E8DF
		protected sealed override void StartUnityEvent()
		{
			this.LoadTarget();
			base.StartUnityEvent();
		}

		// Token: 0x0600033A RID: 826 RVA: 0x000106ED File Offset: 0x0000E8ED
		public sealed override void ActualizarEventos()
		{
			this.LoadTarget();
			base.ActualizarEventos();
		}

		// Token: 0x0600033B RID: 827 RVA: 0x000106FC File Offset: 0x0000E8FC
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

		// Token: 0x0600033C RID: 828 RVA: 0x000107A5 File Offset: 0x0000E9A5
		protected sealed override bool Following()
		{
			return this.m_boneTarget;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x000107B2 File Offset: 0x0000E9B2
		protected sealed override Matrix4x4 GetLocalToWorldMatrix()
		{
			return this.m_boneTarget.localToWorldMatrix;
		}

		// Token: 0x0600033E RID: 830 RVA: 0x000107BF File Offset: 0x0000E9BF
		protected sealed override void FollowingValidarMatrix(ref Matrix4x4 matrix)
		{
		}

		// Token: 0x0600033F RID: 831 RVA: 0x000107C1 File Offset: 0x0000E9C1
		protected sealed override void Followed()
		{
		}

		// Token: 0x04000244 RID: 580
		[StringSelector(typeof(MapaSingletonDeFemaleBones), "fieldNamesEditor")]
		public string boneName;

		// Token: 0x04000245 RID: 581
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_boneTarget;
	}
}
