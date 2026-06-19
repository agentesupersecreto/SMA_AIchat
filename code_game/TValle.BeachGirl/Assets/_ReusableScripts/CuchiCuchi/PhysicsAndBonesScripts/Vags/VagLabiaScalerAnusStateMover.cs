using System;
using Assets._ReusableScripts.Bones.V2;
using Assets._ReusableScripts.Bones.V2.Abstracts;
using Assets._ReusableScripts.Bones.V2.Modificadores;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Vags
{
	// Token: 0x0200010F RID: 271
	[RequireComponent(typeof(VagLabia))]
	public class VagLabiaScalerAnusStateMover : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x06000BF5 RID: 3061 RVA: 0x00028232 File Offset: 0x00026432
		public sealed override int updateEvent1Index
		{
			get
			{
				return (int)this.m_UpdateEvent1;
			}
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x0002823C File Offset: 0x0002643C
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_VagLabia = base.GetComponent<VagLabia>();
			this.m_VagHole = this.GetComponentEnRoot(false);
			this.m_AnusHole = this.GetComponentEnRoot(false);
			Animator componentEnRoot = this.GetComponentEnRoot(false);
			this.hips = componentEnRoot.GetBoneTransform(HumanBodyBones.Hips);
			if (this.m_AnusHole == null)
			{
				throw new ArgumentNullException("m_AnusHole", "m_AnusHole null reference.");
			}
			if (this.hips == null)
			{
				throw new ArgumentNullException("hips", "hips null reference.");
			}
			if (!this.m_VagLabia.isStared)
			{
				this.m_VagLabia.stared += this.M_VagLabia_stared;
			}
			else
			{
				this.M_VagLabia_stared(this.m_VagLabia);
			}
			this.m_initialLocalPosition = base.transform.localPosition;
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x0002830C File Offset: 0x0002650C
		private void M_VagLabia_stared(object obj)
		{
			this.labiaStared = true;
			this.m_backPointOutInitialPositionFromVagRoot = this.m_VagHole.vagRoot.InverseTransformPoint(this.m_VagLabia.backPoint.joint.transform.position);
			ModificableDeScalaLocalDeBone modificableDeScalaLocal = this.GetComponentNotNull<BaseBone, BoneHijo>().modificableDeScalaLocal;
			if (modificableDeScalaLocal == null)
			{
				throw new ArgumentNullException("modificableDeScala", "modificableDeScala null reference.");
			}
			this.m_yScalaMod = modificableDeScalaLocal.y.modificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x0002838C File Offset: 0x0002658C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeFloat yScalaMod = this.m_yScalaMod;
			if (yScalaMod != null)
			{
				yScalaMod.TryRemoverDeOwner(true);
			}
			this.m_yScalaMod = null;
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x000283B0 File Offset: 0x000265B0
		public sealed override void OnUpdateEvent1()
		{
			if (!this.labiaStared)
			{
				return;
			}
			float num;
			float num2;
			this.ResolverScala(out num, out num2);
			Vector3 vector = Vector3.zero;
			try
			{
				if (num2 > 0f)
				{
					vector = base.transform.InverseTransformDirection(-base.transform.up * num2 * 0.5f * this.config.distanciaCalculadaMod);
				}
			}
			finally
			{
				base.transform.localPosition = Vector3.MoveTowards(base.transform.localPosition, this.m_initialLocalPosition + vector, Time.fixedDeltaTime * this.config.velocityPosition);
			}
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x00028468 File Offset: 0x00026668
		private void ResolverScala(out float yScaleResult, out float diferecnciaGlobal)
		{
			yScaleResult = 1f;
			Vector3 vector = this.m_VagHole.vagRoot.TransformPoint(this.m_backPointOutInitialPositionFromVagRoot);
			try
			{
				diferecnciaGlobal = VagHoleJointAnusStateMover.CalcularDiferenciaGlobal(this.configCalcule, this.m_AnusHole, vector, this.hips, this.smooth);
				if (diferecnciaGlobal > 0f)
				{
					float magnitude = (vector - this.m_VagHole.clitBaseTransform.position).magnitude;
					float num = Mathf.Max(0f, magnitude - diferecnciaGlobal) / magnitude;
					if (num < 1f)
					{
						num = Mathf.Clamp(num, 0.333f, 1f);
						yScaleResult = num;
					}
				}
			}
			finally
			{
				this.m_yScalaMod.valor.valor = Mathf.MoveTowards(this.m_yScalaMod.valor.valor, yScaleResult, Time.fixedDeltaTime * this.config.velocityScale);
			}
		}

		// Token: 0x04000674 RID: 1652
		public VagLabiaScalerAnusStateMover.Config config = new VagLabiaScalerAnusStateMover.Config();

		// Token: 0x04000675 RID: 1653
		public VagHoleJointAnusStateMover.Config configCalcule = new VagHoleJointAnusStateMover.Config
		{
			distanciaDeToleranciaLocalAhips = 0.002f,
			distanciaDeReservaLocalAhips = 0f
		};

		// Token: 0x04000676 RID: 1654
		[SerializeField]
		protected GlobalUpdater.UpdateType m_UpdateEvent1 = GlobalUpdater.UpdateType.fixedUpdate2;

		// Token: 0x04000677 RID: 1655
		private VagHole m_VagHole;

		// Token: 0x04000678 RID: 1656
		private VagLabia m_VagLabia;

		// Token: 0x04000679 RID: 1657
		private AnusHole m_AnusHole;

		// Token: 0x0400067A RID: 1658
		private Transform hips;

		// Token: 0x0400067B RID: 1659
		private bool labiaStared;

		// Token: 0x0400067C RID: 1660
		private Vector3 m_backPointOutInitialPositionFromVagRoot;

		// Token: 0x0400067D RID: 1661
		private Vector3 m_initialLocalPosition;

		// Token: 0x0400067E RID: 1662
		private SmoothFloats smooth = new SmoothFloats(15);

		// Token: 0x0400067F RID: 1663
		private ModificadorDeFloat m_yScalaMod;

		// Token: 0x020001EF RID: 495
		[Serializable]
		public class Config
		{
			// Token: 0x04000AB8 RID: 2744
			public float distanciaCalculadaMod = 1.6f;

			// Token: 0x04000AB9 RID: 2745
			public float velocityScale = 1f;

			// Token: 0x04000ABA RID: 2746
			public float velocityPosition = 0.05f;
		}
	}
}
