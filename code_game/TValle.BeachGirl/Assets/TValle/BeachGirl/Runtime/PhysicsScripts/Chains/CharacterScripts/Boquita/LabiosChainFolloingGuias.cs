using System;
using Assets.TValle.BeachGirl.Runtime.Guias;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x0200008E RID: 142
	[RequireComponent(typeof(LabiosChain))]
	public class LabiosChainFolloingGuias : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x0000CCEF File Offset: 0x0000AEEF
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeFixedUpdates3);
			}
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x0000CCF8 File Offset: 0x0000AEF8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_LabiosChain = base.GetComponent<LabiosChain>();
			this.m_BocaHole = base.GetComponentInChildren<BocaHole>();
			if (this.m_BocaHole == null)
			{
				throw new ArgumentNullException("m_BocaHole", "m_BocaHole null reference.");
			}
			if (!this.m_LabiosChain.isStared)
			{
				base.SetManualStart();
				this.m_LabiosChain.stared += this.M_LabiosChain_stared;
			}
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0000CD6B File Offset: 0x0000AF6B
		private void M_LabiosChain_stared(object sender)
		{
			base.ManualStart();
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0000CD74 File Offset: 0x0000AF74
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_LabiosChain.jointsFixed += this.M_LabiosChain_jointsFixed;
			Animator bodyAnimator = this.GetRoot().bodyAnimator;
			Renderer renderer = MapaSingleton<MapaSingletonDeMainSkins>.instance.ObtenerRenderer(bodyAnimator, MapaSingleton<MapaSingletonDeMainSkins>.instance.body);
			this.m_guias = renderer.GetComponentInChildren<CollecionDeGuiasSlaveChildOf>();
			if (this.m_guias == null)
			{
				throw new ArgumentNullException("m_guias", "m_guias null reference.");
			}
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x0000CDEA File Offset: 0x0000AFEA
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_LabiosChain)
			{
				this.m_LabiosChain.jointsFixed -= this.M_LabiosChain_jointsFixed;
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x0000CE18 File Offset: 0x0000B018
		public void UpdatePointsTarget()
		{
			bool flag = this.alwaysUpdate || !ExtendedMonoBehaviour.AlmostEqual(this.m_lastLocalRotationOffset, this.localRotationOffset, 0.01f) || !ExtendedMonoBehaviour.AlmostEqual(this.m_LocalFromBocaPositionOffset, this.localFromBocaPositionOffset, 0.001f);
			this.m_lastLocalRotationOffset = this.localRotationOffset;
			this.m_LocalFromBocaPositionOffset = this.localFromBocaPositionOffset;
			this.m_worldPositionOffset = this.m_BocaHole.entradaTransform.TransformPoint(this.m_LocalFromBocaPositionOffset) - this.m_BocaHole.entradaTransform.position;
			if (this.updateLabioPoints)
			{
				MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
				this.UpdatePointsTarget(instance.LabioOutUp, instance.LabioInUp, flag);
				this.UpdatePointsTarget(instance.LabioOutUp_L, instance.LabioInUp_L, flag);
				this.UpdatePointsTarget(instance.LabioOutSide_L, instance.LabioInSide_L, flag);
				this.UpdatePointsTarget(instance.LabioOutDown_L, instance.LabioInDown_L, flag);
				this.UpdatePointsTarget(instance.LabioOutDown, instance.LabioInDown, flag);
				this.UpdatePointsTarget(instance.LabioOutDown_R, instance.LabioInDown_R, flag);
				this.UpdatePointsTarget(instance.LabioOutSide_R, instance.LabioInSide_R, flag);
				this.UpdatePointsTarget(instance.LabioOutUp_R, instance.LabioInUp_R, flag);
			}
			if (this.updateLabioToLabioPoints && this.m_LabiosChain.usandoLabioToLabio)
			{
				for (int i = 0; i < this.m_LabiosChain.labioToLabios.Count; i++)
				{
					this.UpdateLabioToLabioTarget(this.m_LabiosChain.labioToLabios[i], flag);
				}
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x0000CF9C File Offset: 0x0000B19C
		private void UpdatePointsTarget(string puntoName, string guiaName, bool force)
		{
			Object @object;
			if (!this.m_guias.guiasPorNombreDeSlave.TryGetValue(guiaName, out @object))
			{
				throw new InvalidOperationException();
			}
			Transform transform = (Transform)@object;
			int num;
			if (!this.m_LabiosChain.indexDePuntoNombre.TryGetValue(puntoName, out num))
			{
				throw new InvalidOperationException();
			}
			this.m_LabiosChain.puntos[num].SetTarget(transform.position + this.m_worldPositionOffset, transform.rotation, new Vector3?(this.localRotationOffset));
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0000D020 File Offset: 0x0000B220
		private void UpdateLabioToLabioTarget(LabioToLabioJoint labioToLabio, bool force)
		{
			string name = labioToLabio.target.scalerBone.name;
			Object @object;
			if (!this.m_guias.guiasPorNombreDeSlave.TryGetValue(name, out @object))
			{
				throw new InvalidOperationException();
			}
			Transform transform = (Transform)@object;
			if (!this.updateLabioToLabioPointsRelative)
			{
				labioToLabio.SetTarget(transform.position + this.m_worldPositionOffset);
				return;
			}
			string name2 = labioToLabio.self.scalerBone.name;
			Object object2;
			if (!this.m_guias.guiasPorNombreDeSlave.TryGetValue(name2, out object2))
			{
				throw new InvalidOperationException();
			}
			Transform transform2 = (Transform)object2;
			if (Application.isEditor && transform2 == transform)
			{
				throw new InvalidOperationException();
			}
			Vector3 vector = transform2.InverseTransformPoint(transform.position);
			Vector3 vector2 = labioToLabio.jointTransform.TransformPoint(vector);
			labioToLabio.SetTarget(vector2 + this.m_worldPositionOffset);
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0000D0FD File Offset: 0x0000B2FD
		private void M_LabiosChain_jointsFixed(LinearBoneChain<LabioPoint, LabioPoint.Configuracion> obj)
		{
			this.UpdatePointsTarget();
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0000D105 File Offset: 0x0000B305
		public override void OnUpdateEvent1()
		{
			this.UpdatePointsTarget();
		}

		// Token: 0x04000258 RID: 600
		public bool updateLabioPoints = true;

		// Token: 0x04000259 RID: 601
		public bool updateLabioToLabioPoints = true;

		// Token: 0x0400025A RID: 602
		[NonSerialized]
		private bool alwaysUpdate = true;

		// Token: 0x0400025B RID: 603
		public Vector3 localRotationOffset;

		// Token: 0x0400025C RID: 604
		public Vector3 localFromBocaPositionOffset;

		// Token: 0x0400025D RID: 605
		private Vector3 m_lastLocalRotationOffset;

		// Token: 0x0400025E RID: 606
		private Vector3 m_LocalFromBocaPositionOffset;

		// Token: 0x0400025F RID: 607
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_worldPositionOffset;

		// Token: 0x04000260 RID: 608
		public bool updateLabioToLabioPointsRelative = true;

		// Token: 0x04000261 RID: 609
		private BocaHole m_BocaHole;

		// Token: 0x04000262 RID: 610
		private LabiosChain m_LabiosChain;

		// Token: 0x04000263 RID: 611
		private CollecionDeGuiasSlaveChildOf m_guias;
	}
}
