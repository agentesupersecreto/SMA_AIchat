using System;
using Assets.FinalIk;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000087 RID: 135
	[RequireComponent(typeof(OjosLookAtIK))]
	[RequireComponent(typeof(LookAtIKTargets))]
	public sealed class OjosLookAtManager : CustomUpdatedMonobehaviourBase, ILookAtOjosTargets, ILookAtIKOjos
	{
		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000547 RID: 1351 RVA: 0x0001AC7C File Offset: 0x00018E7C
		public override int updateEvent1Index
		{
			get
			{
				return 77;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000548 RID: 1352 RVA: 0x0001AC80 File Offset: 0x00018E80
		public LookAtIKTargets.Targets primarios
		{
			get
			{
				return this.m_targets.primarios;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000549 RID: 1353 RVA: 0x0001AC8D File Offset: 0x00018E8D
		public LookAtIKTargets.Targets segundarios
		{
			get
			{
				return this.m_targets.segundarios;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600054A RID: 1354 RVA: 0x0001AC9A File Offset: 0x00018E9A
		public LookAtTargetWieghtParCollection primariosCollection
		{
			get
			{
				return this.m_targets.primariosCollection;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600054B RID: 1355 RVA: 0x0001ACA7 File Offset: 0x00018EA7
		public LookAtTargetWieghtParCollection segundariosCollection
		{
			get
			{
				return this.m_targets.segundariosCollection;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x0001ACB4 File Offset: 0x00018EB4
		public ILookAtOjosTargets targets
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600054D RID: 1357 RVA: 0x0001ACB7 File Offset: 0x00018EB7
		// (set) Token: 0x0600054E RID: 1358 RVA: 0x0001ACBF File Offset: 0x00018EBF
		public Vector3 postUpdateCenterPosition { get; set; }

		// Token: 0x14000052 RID: 82
		// (add) Token: 0x0600054F RID: 1359 RVA: 0x0001ACC8 File Offset: 0x00018EC8
		// (remove) Token: 0x06000550 RID: 1360 RVA: 0x0001AD00 File Offset: 0x00018F00
		public event Action<ILookAtIKOjos> updating;

		// Token: 0x06000551 RID: 1361 RVA: 0x0001AD38 File Offset: 0x00018F38
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_targets = base.GetComponent<LookAtIKTargets>();
			this.m_Character = base.GetComponentInParent<ICharacter>();
			this.m_Animator = this.m_Character.GetComponentInChildren<Animator>();
			this.m_OjosLookAtIK = base.GetComponent<OjosLookAtIK>();
			this.head = this.m_Animator.GetBoneTransform(HumanBodyBones.Head);
			this.m_ojosMatrix = this.head.CreateChild("OjosMatrix");
			this.m_ojosMatrix.position = (this.m_Animator.GetBoneTransform(HumanBodyBones.LeftEye).position + this.m_Animator.GetBoneTransform(HumanBodyBones.RightEye).position) / 2f;
			this.m_ojosMatrix.rotation = this.m_Animator.transform.rotation;
			this.evaluadorEnRango = new LookAtTargetWieghtParCollection.EvaluadorDeRango(this.EstaEnAngle);
			if (!this.m_OjosLookAtIK.isAwaken)
			{
				this.m_OjosLookAtIK.ManualAwake();
			}
			this.m_OjosLookAtIK.Init(this.m_Animator);
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0001AE40 File Offset: 0x00019040
		private bool EstaEnAngle(Vector3 ojosPosition, Vector3 bodyForward, Vector3 posicionGlobal)
		{
			Vector3 vector = posicionGlobal - ojosPosition;
			return Vector3.Angle(bodyForward, vector) <= this.config.maxAngleToLookAt;
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0001AE6C File Offset: 0x0001906C
		public override void OnUpdateEvent1()
		{
			Vector3 vector = this.m_OjosLookAtIK.IKPosition;
			float num = 0f;
			float num2 = 1f;
			try
			{
				Vector3 vector2;
				float num3;
				float num4;
				if (LookAtTargetWieghtParCollection.CalcularCurrentTargetConPrioridad(this.primariosCollection, this.segundariosCollection, this.evaluadorEnRango, this.m_ojosMatrix.forward, this.m_ojosMatrix.position, out vector2, out num3, out num4, this.config.minTargetDistance))
				{
					num2 = num4;
					vector = vector2;
					num = Mathf.Clamp01(num3);
				}
			}
			finally
			{
				Vector3 vector3 = FinalIKUtils.RotateTowards(this.m_ojosMatrix.position, this.m_ojosMatrix.forward, this.m_ojosMatrix.up, num, this.m_OjosLookAtIK.IKPosition, vector, this.config.targetGradosVelocidad * num2, this.config.targetSmooth, this.debugDraw, 45f);
				float num5 = FinalIKUtils.ResolverLookAtIKWeight(this.m_OjosLookAtIK.IKPositionWeight, num, this.config.weightCambioVelocidad * num2, this.m_OjosLookAtIK.IKPosition, this.m_ojosMatrix.position, this.m_ojosMatrix.forward, 5f);
				this.m_OjosLookAtIK.IKPositionWeight = num5;
				this.m_OjosLookAtIK.IKPosition = vector3;
				Action<ILookAtIKOjos> action = this.updating;
				if (action != null)
				{
					action(this);
				}
				this.m_OjosLookAtIK.Solve();
				this.postUpdateCenterPosition = (this.m_OjosLookAtIK.ojoL.position + this.m_OjosLookAtIK.ojoR.position) / 2f;
			}
		}

		// Token: 0x040003A3 RID: 931
		public bool debugDraw;

		// Token: 0x040003A4 RID: 932
		public OjosLookAtManager.Config config = new OjosLookAtManager.Config();

		// Token: 0x040003A5 RID: 933
		private LookAtIKTargets m_targets;

		// Token: 0x040003A6 RID: 934
		private Animator m_Animator;

		// Token: 0x040003A7 RID: 935
		private ICharacter m_Character;

		// Token: 0x040003A8 RID: 936
		private OjosLookAtIK m_OjosLookAtIK;

		// Token: 0x040003A9 RID: 937
		private Transform head;

		// Token: 0x040003AA RID: 938
		private Transform m_ojosMatrix;

		// Token: 0x040003AB RID: 939
		private LookAtTargetWieghtParCollection.EvaluadorDeRango evaluadorEnRango;

		// Token: 0x0200017C RID: 380
		[Serializable]
		public class Config
		{
			// Token: 0x0400089C RID: 2204
			public float maxAngleToLookAt = 100f;

			// Token: 0x0400089D RID: 2205
			public float minTargetDistance = 0.1f;

			// Token: 0x0400089E RID: 2206
			public float targetGradosVelocidad = 525f;

			// Token: 0x0400089F RID: 2207
			public bool targetSmooth;

			// Token: 0x040008A0 RID: 2208
			public float weightCambioVelocidad = 5.5f;
		}
	}
}
