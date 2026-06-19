using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000EA RID: 234
	[RequireComponent(typeof(VagHoleJoint))]
	public class VagHoleJointAnusStateMover : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x060009CC RID: 2508 RVA: 0x0001F604 File Offset: 0x0001D804
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_VagHoleJoint = base.GetComponent<VagHoleJoint>();
			this.m_AnusHole = this.GetComponentEnRoot(false);
			Animator componentEnRoot = this.GetComponentEnRoot(false);
			if (!(componentEnRoot != null))
			{
				this.m_esValid = false;
				return;
			}
			this.hips = componentEnRoot.GetBoneTransform(HumanBodyBones.Hips);
			if (this.m_AnusHole == null)
			{
				throw new ArgumentNullException("m_AnusHole", "m_AnusHole null reference.");
			}
			if (this.hips == null)
			{
				throw new ArgumentNullException("hips", "hips null reference.");
			}
			this.m_esValid = true;
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x0001F699 File Offset: 0x0001D899
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (this.m_esValid)
			{
				this.m_VagHoleJoint.updating += this.M_VagHoleJoint_updating;
			}
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x0001F6C0 File Offset: 0x0001D8C0
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_VagHoleJoint != null)
			{
				this.m_VagHoleJoint.updating -= this.M_VagHoleJoint_updating;
			}
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x0001F6EE File Offset: 0x0001D8EE
		private void M_VagHoleJoint_updating(VagHoleJoint sender, VagHoleJoint.UpdatingArg args)
		{
			if (!this.m_esValid)
			{
				return;
			}
			args.distanciaGlobalAgregada += VagHoleJointAnusStateMover.CalcularDiferenciaGlobal(this.config, this.m_AnusHole, sender.posicionGlobalInicial, this.hips, this.smooth);
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x0001F72C File Offset: 0x0001D92C
		public static float CalcularDiferenciaGlobal(VagHoleJointAnusStateMover.Config config, AnusHole m_AnusHole, Vector3 posicionGlobalA, Transform hips, SmoothFloats smooth = null)
		{
			if (m_AnusHole.estadoDePuntos.actualLocal.maxLimpiaLocalHole <= 0.0001f)
			{
				return 0f;
			}
			float num = m_AnusHole.estadoDePuntos.globalActual.maxValue;
			if (smooth != null)
			{
				smooth.Add(num);
				num = smooth.suavizado;
			}
			Vector3 position = m_AnusHole.transform.position;
			float num2 = (posicionGlobalA - position).magnitude * config.distanciaEntreVagYAnusMod;
			float num3 = num * config.distanciaDeAperturaDeAnusMod * 0.5f;
			float z = hips.lossyScale.z;
			float num4 = z * config.distanciaDeReservaLocalAhips;
			float num5 = z * config.distanciaDeToleranciaLocalAhips;
			if (num2 + num5 >= num3 + num4)
			{
				return 0f;
			}
			return (num3 + num4 - (num2 + num5)) * config.distanciaResultadoMod;
		}

		// Token: 0x04000533 RID: 1331
		private bool m_esValid;

		// Token: 0x04000534 RID: 1332
		public VagHoleJointAnusStateMover.Config config = new VagHoleJointAnusStateMover.Config();

		// Token: 0x04000535 RID: 1333
		private VagHoleJoint m_VagHoleJoint;

		// Token: 0x04000536 RID: 1334
		private AnusHole m_AnusHole;

		// Token: 0x04000537 RID: 1335
		private Transform hips;

		// Token: 0x04000538 RID: 1336
		private SmoothFloats smooth = new SmoothFloats(10);

		// Token: 0x020001C0 RID: 448
		[Serializable]
		public class Config
		{
			// Token: 0x04000A00 RID: 2560
			public float distanciaEntreVagYAnusMod = 1f;

			// Token: 0x04000A01 RID: 2561
			public float distanciaDeAperturaDeAnusMod = 1f;

			// Token: 0x04000A02 RID: 2562
			public float distanciaResultadoMod = 1f;

			// Token: 0x04000A03 RID: 2563
			public float distanciaDeReservaLocalAhips = 0.017f;

			// Token: 0x04000A04 RID: 2564
			public float distanciaDeToleranciaLocalAhips;
		}
	}
}
