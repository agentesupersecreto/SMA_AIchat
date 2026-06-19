using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using RootMotion.FinalIK;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Abstracts
{
	// Token: 0x020002A9 RID: 681
	[RequireComponent(typeof(Character))]
	public abstract class CharacterRotationMode : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x060011A5 RID: 4517 RVA: 0x00053E7A File Offset: 0x0005207A
		public Character character
		{
			get
			{
				return this.m_Character;
			}
		}

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x060011A6 RID: 4518 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public sealed override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x060011A7 RID: 4519 RVA: 0x00053DA8 File Offset: 0x00051FA8
		public sealed override int updateEvent2Index
		{
			get
			{
				return 75;
			}
		}

		// Token: 0x060011A8 RID: 4520 RVA: 0x00053E84 File Offset: 0x00052084
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_LookAtIk = base.transform.CreateChild("RotationModeLookAtIK").gameObject.AddComponent<LookAtIK>();
			this.m_Character = base.GetComponent<Character>();
			Animator bodyAnimator = this.m_Character.bodyAnimator;
			Transform boneTransform = bodyAnimator.GetBoneTransform(HumanBodyBones.Head);
			Transform boneTransform2 = bodyAnimator.GetBoneTransform(HumanBodyBones.Neck);
			this.m_LookAtIk.solver.SetChain(new Transform[] { boneTransform2 }, boneTransform, null, bodyAnimator.transform);
			this.m_LookAtIk.enabled = false;
		}

		// Token: 0x060011A9 RID: 4521 RVA: 0x00053F10 File Offset: 0x00052110
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_Character.teleported += this.M_Character_positionChanged;
		}

		// Token: 0x060011AA RID: 4522 RVA: 0x00053F2F File Offset: 0x0005212F
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_Character)
			{
				this.m_Character.teleported -= this.M_Character_positionChanged;
			}
		}

		// Token: 0x060011AB RID: 4523 RVA: 0x00053F5C File Offset: 0x0005215C
		private void M_Character_positionChanged(Vector3 position, Quaternion rotation)
		{
			this.OnCharacterPositionChanged(position, rotation);
		}

		// Token: 0x060011AC RID: 4524
		protected abstract void OnCharacterPositionChanged(Vector3 position, Quaternion rotation);

		// Token: 0x060011AD RID: 4525 RVA: 0x00053F66 File Offset: 0x00052166
		public void ForzarBodyRotationPor(float time)
		{
			this.m_forzarBodyRotCoolDown.ApplyNext(time);
		}

		// Token: 0x060011AE RID: 4526 RVA: 0x00053F74 File Offset: 0x00052174
		public sealed override void OnUpdateEvent1()
		{
			if (this.m_forzarBodyRotCoolDown.isOn)
			{
				this.modo = CharacterRotationMode.Modo.bodyRotation;
			}
			this.m_LookAtIk.enabled = false;
			this.m_LookAtIk.solver.FixTransforms();
			this.CheckingMode();
			CharacterRotationMode.Modo? lastModo = this.m_lastModo;
			CharacterRotationMode.Modo modo = this.modo;
			if (!((lastModo.GetValueOrDefault() == modo) & (lastModo != null)) || this.flagUpdateModo)
			{
				this.flagUpdateModo = false;
				this.OnModoChanged();
				this.m_lastModo = new CharacterRotationMode.Modo?(this.modo);
			}
		}

		// Token: 0x060011AF RID: 4527 RVA: 0x00054000 File Offset: 0x00052200
		public sealed override void OnUpdateEvent2()
		{
			CurrentMainChar.ICamera camara = Singleton<CurrentMainChar>.instance.camara;
			float num = ((camara != null) ? 1f : 0f);
			this.m_LookAtIk.solver.IKPositionWeight = Mathf.MoveTowards(this.m_LookAtIk.solver.IKPositionWeight, num, Time.deltaTime * 3f);
			if (camara != null)
			{
				try
				{
					this.m_LookAtIk.solver.IKPosition = camara.cameraTransform.position + camara.cameraTransform.forward;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			this.m_LookAtIk.solver.Update();
		}

		// Token: 0x060011B0 RID: 4528
		protected abstract void CheckingMode();

		// Token: 0x060011B1 RID: 4529
		protected abstract void OnModoChanged();

		// Token: 0x04000CFD RID: 3325
		public bool flagUpdateModo;

		// Token: 0x04000CFE RID: 3326
		public CharacterRotationMode.Modo modo;

		// Token: 0x04000CFF RID: 3327
		private CharacterRotationMode.Modo? m_lastModo;

		// Token: 0x04000D00 RID: 3328
		private LookAtIK m_LookAtIk;

		// Token: 0x04000D01 RID: 3329
		protected Character m_Character;

		// Token: 0x04000D02 RID: 3330
		private CoolDown m_forzarBodyRotCoolDown = new CoolDown();

		// Token: 0x020002AA RID: 682
		public enum Modo
		{
			// Token: 0x04000D04 RID: 3332
			bodyRotation,
			// Token: 0x04000D05 RID: 3333
			headRotation
		}
	}
}
