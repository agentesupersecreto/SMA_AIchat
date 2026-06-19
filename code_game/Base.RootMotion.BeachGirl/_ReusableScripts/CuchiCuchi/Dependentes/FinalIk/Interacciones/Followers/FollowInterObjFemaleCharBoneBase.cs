using System;
using Assets._ReusableScripts.CuchiCuchi.TransFollowers;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Followers
{
	// Token: 0x020000B1 RID: 177
	public abstract class FollowInterObjFemaleCharBoneBase : InterObjIKPassMatrixFollower
	{
		// Token: 0x060006BD RID: 1725 RVA: 0x00020B29 File Offset: 0x0001ED29
		protected override void StartUnityEvent()
		{
			this.LoadTarget();
			base.StartUnityEvent();
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00020B37 File Offset: 0x0001ED37
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.pass = IKPassMatrixFollower.Pass.ultimo;
			this.postPhysicsIKWeight = 0.75f;
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00020B54 File Offset: 0x0001ED54
		protected override void LoadTarget()
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

		// Token: 0x060006C0 RID: 1728 RVA: 0x00020BFD File Offset: 0x0001EDFD
		protected override bool Following()
		{
			return this.m_boneTarget != null;
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x00020C0B File Offset: 0x0001EE0B
		protected override Matrix4x4 GetLocalToWorldMatrix()
		{
			return this.m_boneTarget.localToWorldMatrix;
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00020C18 File Offset: 0x0001EE18
		protected override void FollowingValidarMatrix(ref Matrix4x4 matrix)
		{
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00020C1A File Offset: 0x0001EE1A
		protected override void Followed()
		{
		}

		// Token: 0x0400048F RID: 1167
		[Header("Female Bones Config")]
		[StringSelector(typeof(MapaSingletonDeFemaleBones), "fieldNamesEditor")]
		public string boneName;

		// Token: 0x04000490 RID: 1168
		[ReadOnlyUI]
		[SerializeField]
		protected Transform m_boneTarget;
	}
}
