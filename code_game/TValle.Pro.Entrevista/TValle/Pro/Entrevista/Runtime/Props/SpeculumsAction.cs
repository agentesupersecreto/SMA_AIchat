using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Penes;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Props
{
	// Token: 0x02000085 RID: 133
	public sealed class SpeculumsAction : GrabbableToyFireActionWithPoser
	{
		// Token: 0x06000556 RID: 1366 RVA: 0x0001E83C File Offset: 0x0001CA3C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_supJaws == null)
			{
				throw new ArgumentNullException("m_supJaws", "m_supJaws null reference.");
			}
			if (this.m_infJaws == null)
			{
				throw new ArgumentNullException("m_infJaws", "m_infJaws null reference.");
			}
			this.m_supJawsInitialLocalRot = this.m_supJaws.localRotation;
			this.m_infJawsInitialLocalRot = this.m_infJaws.localRotation;
			this.m_supJawsEndLocalRot = this.m_supJawsInitialLocalRot * Quaternion.AngleAxis(this.m_maxAngle / -2f, this.m_jawAxis);
			this.m_infJawsEndLocalRot = this.m_infJawsInitialLocalRot * Quaternion.AngleAxis(this.m_maxAngle / 2f, this.m_jawAxis);
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0001E900 File Offset: 0x0001CB00
		protected override void OnToyStared()
		{
			this.m_data000.Init(this.m_GrabbableToy.toy, 0, this);
			this.m_data001.Init(this.m_GrabbableToy.toy, 1, this);
			this.m_data002.Init(this.m_GrabbableToy.toy, 2, this);
			this.m_data003.Init(this.m_GrabbableToy.toy, 3, this);
			this.m_data004.Init(this.m_GrabbableToy.toy, 4, this);
			this.m_data005.Init(this.m_GrabbableToy.toy, 5, this);
			this.OnPenisStart_FollowLogic();
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0001E9A4 File Offset: 0x0001CBA4
		private void OnPenisStart_FollowLogic()
		{
			string text = this.m_boneName + this.m_upperNameChange;
			string text2 = this.m_boneName + this.m_lowerNameChange;
			List<SpeculumsAction.JawBoneFollowingData> list = new List<SpeculumsAction.JawBoneFollowingData>();
			for (int i = 0; i < this.m_GrabbableToy.toy.partesEnOrden.Count; i++)
			{
				Transform charBone = this.m_GrabbableToy.toy.partesEnOrden[i].charBone;
				string text3 = charBone.name.Replace(this.m_boneName, text);
				string text4 = charBone.name.Replace(this.m_boneName, text2);
				Transform transform = this.m_supJaws.FindDeepChild(text3, true);
				if (transform == null)
				{
					throw new ArgumentNullException("selfUpper", "selfUpper null reference.");
				}
				Transform transform2 = this.m_infJaws.FindDeepChild(text4, true);
				if (transform2 == null)
				{
					throw new ArgumentNullException("selfLower", "selfLower null reference.");
				}
				SpeculumsAction.JawBoneFollowingData jawBoneFollowingData = new SpeculumsAction.JawBoneFollowingData();
				jawBoneFollowingData.Init(transform, this.m_supJaws, this.m_GrabbableToy.toy, i);
				list.Add(jawBoneFollowingData);
				SpeculumsAction.JawBoneFollowingData jawBoneFollowingData2 = new SpeculumsAction.JawBoneFollowingData();
				jawBoneFollowingData2.Init(transform2, this.m_infJaws, this.m_GrabbableToy.toy, i);
				list.Add(jawBoneFollowingData2);
			}
			this.m_JawBoneFollowingData = list.ToArray();
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0001EAF8 File Offset: 0x0001CCF8
		protected override void OnFireActionWeightUpdated(bool changed, bool increasing)
		{
			base.OnFireActionWeightUpdated(changed, increasing);
			this.m_supJaws.localRotation = Quaternion.Slerp(this.m_supJawsInitialLocalRot, this.m_supJawsEndLocalRot, this.m_currentFireActionValue);
			this.m_infJaws.localRotation = Quaternion.Slerp(this.m_infJawsInitialLocalRot, this.m_infJawsEndLocalRot, this.m_currentFireActionValue);
			this.m_data000.Update(this.m_config000, this.m_currentFireActionValue, 1f);
			this.m_data001.Update(this.m_config001, this.m_currentFireActionValue, 1f);
			this.m_data002.Update(this.m_config002, this.m_currentFireActionValue, 1f);
			this.m_data003.Update(this.m_config003, this.m_currentFireActionValue, 1f);
			this.m_data004.Update(this.m_config004, this.m_currentFireActionValue, 1f);
			this.m_data005.Update(this.m_config005, this.m_currentFireActionValue, 1f);
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600055A RID: 1370 RVA: 0x0001EBF9 File Offset: 0x0001CDF9
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterPhyscisConstraints);
			}
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0001EC04 File Offset: 0x0001CE04
		public override void OnUpdateEvent2()
		{
			if (!this.doFollow || this.m_GrabbableToy.estado == GrabbablePropEstado.NotGrabbed)
			{
				return;
			}
			for (int i = this.m_JawBoneFollowingData.Length - 1; i >= 0; i--)
			{
				this.m_JawBoneFollowingData[i].Follow();
			}
		}

		// Token: 0x0400032C RID: 812
		[Header("Speculums General")]
		[SerializeField]
		private Transform m_supJaws;

		// Token: 0x0400032D RID: 813
		[SerializeField]
		private Transform m_infJaws;

		// Token: 0x0400032E RID: 814
		[SerializeField]
		private Vector3 m_jawAxis = Vector3.right;

		// Token: 0x0400032F RID: 815
		[SerializeField]
		private float m_maxAngle = 8.8f;

		// Token: 0x04000330 RID: 816
		[SerializeField]
		private SpeculumsAction.PointConfig m_config000 = new SpeculumsAction.PointConfig();

		// Token: 0x04000331 RID: 817
		[SerializeField]
		private SpeculumsAction.PointConfig m_config001 = new SpeculumsAction.PointConfig();

		// Token: 0x04000332 RID: 818
		[SerializeField]
		private SpeculumsAction.PointConfig m_config002 = new SpeculumsAction.PointConfig();

		// Token: 0x04000333 RID: 819
		[SerializeField]
		private SpeculumsAction.PointConfig m_config003 = new SpeculumsAction.PointConfig();

		// Token: 0x04000334 RID: 820
		[SerializeField]
		private SpeculumsAction.PointConfig m_config004 = new SpeculumsAction.PointConfig();

		// Token: 0x04000335 RID: 821
		[SerializeField]
		private SpeculumsAction.PointConfig m_config005 = new SpeculumsAction.PointConfig();

		// Token: 0x04000336 RID: 822
		[SerializeField]
		private SpeculumsAction.PointData m_data000 = new SpeculumsAction.PointData();

		// Token: 0x04000337 RID: 823
		[SerializeField]
		private SpeculumsAction.PointData m_data001 = new SpeculumsAction.PointData();

		// Token: 0x04000338 RID: 824
		[SerializeField]
		private SpeculumsAction.PointData m_data002 = new SpeculumsAction.PointData();

		// Token: 0x04000339 RID: 825
		[SerializeField]
		private SpeculumsAction.PointData m_data003 = new SpeculumsAction.PointData();

		// Token: 0x0400033A RID: 826
		[SerializeField]
		private SpeculumsAction.PointData m_data004 = new SpeculumsAction.PointData();

		// Token: 0x0400033B RID: 827
		[SerializeField]
		private SpeculumsAction.PointData m_data005 = new SpeculumsAction.PointData();

		// Token: 0x0400033C RID: 828
		private Quaternion m_supJawsInitialLocalRot;

		// Token: 0x0400033D RID: 829
		private Quaternion m_infJawsInitialLocalRot;

		// Token: 0x0400033E RID: 830
		private Quaternion m_supJawsEndLocalRot;

		// Token: 0x0400033F RID: 831
		private Quaternion m_infJawsEndLocalRot;

		// Token: 0x04000340 RID: 832
		[Header("Speculums Follow Logic")]
		[SerializeField]
		private bool doFollow = true;

		// Token: 0x04000341 RID: 833
		[SerializeField]
		private string m_boneName = "Bone";

		// Token: 0x04000342 RID: 834
		[SerializeField]
		private string m_upperNameChange = "Upper";

		// Token: 0x04000343 RID: 835
		[SerializeField]
		private string m_lowerNameChange = "Lower";

		// Token: 0x04000344 RID: 836
		[ReadOnlyUI]
		[SerializeField]
		private SpeculumsAction.JawBoneFollowingData[] m_JawBoneFollowingData;

		// Token: 0x0200020E RID: 526
		[Serializable]
		public class PointConfig
		{
			// Token: 0x040009F5 RID: 2549
			public float initialColliderAnchoMod = 1f;
		}

		// Token: 0x0200020F RID: 527
		[Serializable]
		public class PointData
		{
			// Token: 0x06000FBD RID: 4029 RVA: 0x0004D248 File Offset: 0x0004B448
			public void Init(PenisPart part, SpeculumsAction owner)
			{
				this.main = part.mainCollider;
				this.complemento = part.complementoCollider;
				this.mainAnchoMod = this.main.modificableDeAncho.ObtenerModificadorNotNull(owner);
				this.complementoAnchoMod = this.complemento.modificableDeAncho.ObtenerModificadorNotNull(owner);
			}

			// Token: 0x06000FBE RID: 4030 RVA: 0x0004D29B File Offset: 0x0004B49B
			public void Init(Penetrador penetrador, int index, SpeculumsAction owner)
			{
				this.Init(penetrador.partesEnOrden[index], owner);
			}

			// Token: 0x06000FBF RID: 4031 RVA: 0x0004D2B0 File Offset: 0x0004B4B0
			public void Update(SpeculumsAction.PointConfig config, float w, float power)
			{
				this.mainAnchoMod.valor.valor = (this.complementoAnchoMod.valor.valor = Mathf.Lerp(config.initialColliderAnchoMod, 1f, w.OutPow(power)));
			}

			// Token: 0x040009F6 RID: 2550
			public PenisPointCollider main;

			// Token: 0x040009F7 RID: 2551
			public PenisPointCollider complemento;

			// Token: 0x040009F8 RID: 2552
			public ModificadorDeFloat mainAnchoMod;

			// Token: 0x040009F9 RID: 2553
			public ModificadorDeFloat complementoAnchoMod;
		}

		// Token: 0x02000210 RID: 528
		[Serializable]
		public class JawBoneFollowingData
		{
			// Token: 0x06000FC1 RID: 4033 RVA: 0x0004D2FF File Offset: 0x0004B4FF
			public void Init(Transform Self, Transform Jaw, Penetrador penetrador, int index)
			{
				this.Init(Self, Jaw, penetrador, penetrador.partesEnOrden[index]);
			}

			// Token: 0x06000FC2 RID: 4034 RVA: 0x0004D317 File Offset: 0x0004B517
			public void Init(Transform Self, Transform Jaw, Penetrador penetrador, PenisPart parte)
			{
				this.peneBase = penetrador.penisLinearChain.puntoBaseTransform;
				this.self = Self;
				this.jaw = Jaw;
				this.target = parte.charBone;
			}

			// Token: 0x06000FC3 RID: 4035 RVA: 0x0004D348 File Offset: 0x0004B548
			public void Follow()
			{
				Vector3 vector = this.peneBase.InverseTransformPoint(this.target.position);
				Quaternion quaternion = Quaternion.Inverse(this.peneBase.rotation) * this.target.rotation;
				this.self.SetLocalPositionAndRotation(vector, quaternion);
			}

			// Token: 0x040009FA RID: 2554
			public Transform jaw;

			// Token: 0x040009FB RID: 2555
			public Transform self;

			// Token: 0x040009FC RID: 2556
			public Transform peneBase;

			// Token: 0x040009FD RID: 2557
			public Transform target;
		}
	}
}
