using System;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones
{
	// Token: 0x02000037 RID: 55
	[RequireComponent(typeof(InteraccionSegundaria))]
	public sealed class FingerPointAtInteraction : AplicableBehaviour
	{
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000256 RID: 598 RVA: 0x0000CF99 File Offset: 0x0000B199
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.lateUpdateAfterCameraController);
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000CFA4 File Offset: 0x0000B1A4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteraccionSegundaria = base.GetComponent<InteraccionSegundaria>();
			this.m_handTarget = this.m_InteraccionSegundaria.GetComponentInChildren<InteractionTarget>();
			if (this.m_handTarget == null)
			{
				throw new ArgumentNullException("m_handTarget", "m_handTarget null reference.");
			}
			this.m_character = this.GetComponentEnRoot(false);
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			if (!this.m_character.isStared)
			{
				this.m_character.stared += this.M_character_stared;
				return;
			}
			this.M_character_stared(this.m_character);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000D048 File Offset: 0x0000B248
		private void M_character_stared(object sender)
		{
			this.m_localUpFromShoulder = this.m_character.bones.armsR.transform.InverseTransformDirection(Vector3.up);
			this.m_localPositionShoulderFromChest = this.m_character.bones.chest.transform.InverseTransformPoint(this.m_character.bones.armsR.transform.position);
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000D0B4 File Offset: 0x0000B2B4
		public bool StartPointAt(Transform target, Vector3 targetLocalOffset, float duracion, float velocidadInMod, float velocidadOutMod)
		{
			if (!base.isStared)
			{
				return false;
			}
			if (target == null)
			{
				throw new ArgumentNullException("target", "target null reference.");
			}
			this.m_currentTarget = target;
			this.m_currentTargetLocalOffset = targetLocalOffset;
			this.SetHandTargetToTarget();
			return this.m_InteraccionSegundaria.Ejecutar(9999999, duracion, ControllerPrioridadConfig.interrumpir, velocidadInMod, velocidadOutMod, false);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000D10F File Offset: 0x0000B30F
		public void StopPointAt()
		{
			this.m_InteraccionSegundaria.Detener(false);
			this.m_currentTarget = null;
			this.m_currentTargetLocalOffset = Vector3.zero;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000D12F File Offset: 0x0000B32F
		public override void OnUpdateEvent1()
		{
			if (!this.m_InteraccionSegundaria.ejecutandose || this.m_currentTarget == null)
			{
				this.m_currentTarget = null;
				this.m_currentTargetLocalOffset = Vector3.zero;
				return;
			}
			this.SetHandTargetToTarget();
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000D168 File Offset: 0x0000B368
		public void SetHandTargetToTarget()
		{
			Vector3 vector = this.m_currentTarget.TransformPoint(this.m_currentTargetLocalOffset);
			Vector3 position = this.m_character.bones.armsR.transform.position;
			Vector3 position2 = this.m_character.bones.foreArmsR.transform.position;
			Vector3 position3 = this.m_character.bones.handR.transform.position;
			float num = Vector3.Distance(position, position2) + Vector3.Distance(position2, position3);
			Vector3 vector2 = this.m_character.bones.chest.transform.TransformPoint(this.m_localPositionShoulderFromChest);
			Vector3 vector3 = vector - vector2;
			float magnitude = vector3.magnitude;
			Vector3 normalized = vector3.normalized;
			Quaternion quaternion = Quaternion.LookRotation(normalized, this.m_character.bones.armsR.transform.TransformDirection(this.m_localUpFromShoulder));
			Vector3 vector4 = vector2 + normalized * Mathf.Min(magnitude, num * this.chainDistanceMod);
			this.m_handTarget.transform.SetPositionAndRotation(vector4, quaternion);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000D27B File Offset: 0x0000B47B
		protected sealed override CustomMonobehaviourBotonConfig Boton4()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				editorTimeVisible = false,
				text = "Ejecutar: interrumpiendo Permanente"
			};
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000D29C File Offset: 0x0000B49C
		protected override void OnAplicar4()
		{
			base.OnAplicar4();
			if (this.StartPointAt(this.m_currentTarget, Vector3.zero, -1f, 1f, 1f))
			{
				Debug.Log("ejecutando: " + base.name);
				return;
			}
			Debug.LogWarning("falla ejecutando: " + base.name);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000D2FC File Offset: 0x0000B4FC
		protected sealed override CustomMonobehaviourBotonConfig Boton5()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				editorTimeVisible = false,
				text = "Detener"
			};
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000D31C File Offset: 0x0000B51C
		protected override void OnAplicar5()
		{
			base.OnAplicar5();
			this.StopPointAt();
		}

		// Token: 0x040001B2 RID: 434
		[SerializeField]
		private Transform m_currentTarget;

		// Token: 0x040001B3 RID: 435
		[SerializeField]
		private Vector3 m_currentTargetLocalOffset = Vector3.zero;

		// Token: 0x040001B4 RID: 436
		private InteraccionSegundaria m_InteraccionSegundaria;

		// Token: 0x040001B5 RID: 437
		private InteractionTarget m_handTarget;

		// Token: 0x040001B6 RID: 438
		private IAnimatorCharacter m_character;

		// Token: 0x040001B7 RID: 439
		[Range(0f, 1f)]
		public float chainDistanceMod = 0.666f;

		// Token: 0x040001B8 RID: 440
		private Vector3 m_localUpFromShoulder;

		// Token: 0x040001B9 RID: 441
		private Vector3 m_localPositionShoulderFromChest;
	}
}
