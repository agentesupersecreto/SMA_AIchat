using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Miscellaneous.Checkers;
using Assets._ReusableScripts.PhysicsScripts;
using RootMotion.Dynamics;
using TValleCustomClases;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones
{
	// Token: 0x02000034 RID: 52
	[RequireComponent(typeof(EmulatedSphereTrigger))]
	public abstract class InteraccionAdderOnRangeBase<T_Interactable> : CustomUpdatedMonobehaviourBase where T_Interactable : class
	{
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000233 RID: 563 RVA: 0x0000C823 File Offset: 0x0000AA23
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.fixedUpdate1);
			}
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000C82C File Offset: 0x0000AA2C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_EmulatedSphereTrigger = base.GetComponent<EmulatedSphereTrigger>();
			if (this.m_EmulatedSphereTrigger == null)
			{
				throw new ArgumentNullException("m_EmulatedSphereTrigger", "m_EmulatedSphereTrigger null reference.");
			}
			if (this.m_TriggerRanges == null || this.m_TriggerRanges.Length == 0 || this.m_TriggerRanges[0] == null)
			{
				throw new ArgumentNullException("m_TriggerRanges", "m_TriggerRanges null reference.");
			}
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000C89C File Offset: 0x0000AA9C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_EmulatedSphereTrigger.onEnter += this.M_EmulatedSphereTrigger_onEnter;
			this.m_EmulatedSphereTrigger.onStay += this.M_EmulatedSphereTrigger_onStay;
			this.m_EmulatedSphereTrigger.onExit += this.M_EmulatedSphereTrigger_onExit;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000C8F4 File Offset: 0x0000AAF4
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_EmulatedSphereTrigger.onEnter -= this.M_EmulatedSphereTrigger_onEnter;
			this.m_EmulatedSphereTrigger.onStay -= this.M_EmulatedSphereTrigger_onStay;
			this.m_EmulatedSphereTrigger.onExit -= this.M_EmulatedSphereTrigger_onExit;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000C94D File Offset: 0x0000AB4D
		public override void OnUpdateEvent1()
		{
			if (this.m_CoolDown.isOn)
			{
				return;
			}
			this.m_CoolDown.ApplyNextRandomMod(this.coolDown, 0.1f);
			this.DoUpdate();
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public virtual void DoUpdate()
		{
			ConfiguracionGlobal.Layers layers = Singleton<ConfiguracionGeneral>.instance.layers;
			int num;
			switch (this.againts)
			{
			case InteraccionAdderOnRangeBase<T_Interactable>.TriggerAgaints.characterController:
				num = layers.characterController.ToLayerMask();
				break;
			case InteraccionAdderOnRangeBase<T_Interactable>.TriggerAgaints.ragdoll:
				num = layers.ragdoll.ToLayerMask();
				break;
			case InteraccionAdderOnRangeBase<T_Interactable>.TriggerAgaints.touchingHand:
				num = layers.touchingHand.ToLayerMask();
				break;
			default:
				throw new ArgumentOutOfRangeException(this.againts.ToString());
			}
			this.m_EmulatedSphereTrigger.layerMask = num;
			try
			{
				this.m_EmulatedSphereTrigger.DoUpdate();
			}
			finally
			{
				this.m_Temp.Clear();
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000CA2C File Offset: 0x0000AC2C
		private void M_EmulatedSphereTrigger_onEnter(Collider obj)
		{
			this.OnTigger(obj);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000CA35 File Offset: 0x0000AC35
		private void M_EmulatedSphereTrigger_onStay(Collider obj)
		{
			this.OnTigger(obj);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000CA40 File Offset: 0x0000AC40
		private void M_EmulatedSphereTrigger_onExit(Collider obj)
		{
			T_Interactable t_Interactable = this.ObtenerInteractable(obj);
			ICharacter character = this.GetCharacter(t_Interactable);
			if (t_Interactable == null || character == null || character.sexo != this.para)
			{
				return;
			}
			this.Remove(t_Interactable);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0000CA80 File Offset: 0x0000AC80
		protected virtual void OnTigger(Collider obj)
		{
			T_Interactable t_Interactable = this.ObtenerInteractable(obj);
			ICharacter character = this.GetCharacter(t_Interactable);
			if (t_Interactable == null || character == null || character.sexo != this.para)
			{
				return;
			}
			Vector3 vector;
			Transform transformToCheck = this.GetTransformToCheck(obj, character, out vector);
			if (transformToCheck == null)
			{
				return;
			}
			if (this.InRange(transformToCheck, vector))
			{
				this.Add(t_Interactable);
				return;
			}
			this.Remove(t_Interactable);
		}

		// Token: 0x0600023D RID: 573
		protected abstract ICharacter GetCharacter(T_Interactable interactable);

		// Token: 0x0600023E RID: 574 RVA: 0x0000CAE8 File Offset: 0x0000ACE8
		protected virtual T_Interactable ObtenerInteractable(Collider col)
		{
			if (col == null)
			{
				return default(T_Interactable);
			}
			ICharacterRoot root = col.GetRoot();
			if (root == null)
			{
				return default(T_Interactable);
			}
			if (this.m_Temp.Contains(root))
			{
				return default(T_Interactable);
			}
			this.m_Temp.Add(root);
			return root.GetComponentInChildren<T_Interactable>(false);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0000CB48 File Offset: 0x0000AD48
		protected Transform GetTransformToCheck(Collider obj, ICharacter character, out Vector3 localOffset)
		{
			localOffset = Vector3.zero;
			Transform animatorRootMotionTransform = character.animatorRootMotionTransform;
			if (!this.usarMusculo)
			{
				return animatorRootMotionTransform;
			}
			PuppetMaster componentInChildren = character.GetComponentInChildren<PuppetMaster>();
			if (componentInChildren == null)
			{
				return animatorRootMotionTransform;
			}
			Muscle muscle = componentInChildren.GetMuscle(this.paraMusculoSide, Muscle.GroupCompleto.Hand);
			if (muscle == null)
			{
				return animatorRootMotionTransform;
			}
			localOffset = this.localMuscleOffset;
			return muscle.rigidbody.transform;
		}

		// Token: 0x06000240 RID: 576
		protected abstract void Add(T_Interactable interactable);

		// Token: 0x06000241 RID: 577
		protected abstract void Remove(T_Interactable interactable);

		// Token: 0x06000242 RID: 578 RVA: 0x0000CBB0 File Offset: 0x0000ADB0
		private bool InRange(Transform target, Vector3 targetLocalOffset)
		{
			bool flag;
			if (this.mode == TriggerRanges.Mode.and)
			{
				flag = true;
			}
			else
			{
				if (this.mode != TriggerRanges.Mode.or)
				{
					throw new ArgumentOutOfRangeException();
				}
				flag = false;
			}
			for (int i = 0; i < this.m_TriggerRanges.Length; i++)
			{
				TriggerRanges triggerRanges = this.m_TriggerRanges[i];
				if (!(triggerRanges == null) && triggerRanges.isActiveAndEnabled)
				{
					bool flag2 = triggerRanges.IsCharacterInRange(target, targetLocalOffset, true);
					if (!flag2 && this.mode == TriggerRanges.Mode.and)
					{
						return false;
					}
					if (flag2 && this.mode == TriggerRanges.Mode.or)
					{
						return true;
					}
					if (this.mode == TriggerRanges.Mode.and)
					{
						flag = flag && flag2;
					}
					else if (this.mode == TriggerRanges.Mode.or)
					{
						flag = flag || flag2;
					}
				}
			}
			return flag;
		}

		// Token: 0x040001A0 RID: 416
		[Header("EmulatedSphereTrigger Layer Es Automatico")]
		[Header("Para")]
		public InteraccionAdderOnRangeBase<T_Interactable>.TriggerAgaints againts;

		// Token: 0x040001A1 RID: 417
		public TriggerRanges.Mode mode = TriggerRanges.Mode.or;

		// Token: 0x040001A2 RID: 418
		public Sexo para = Sexo.femenino;

		// Token: 0x040001A3 RID: 419
		[Header("Para Muscle (optional)")]
		public bool usarMusculo;

		// Token: 0x040001A4 RID: 420
		public Muscle.GroupCompleto paraMusculoGrupo;

		// Token: 0x040001A5 RID: 421
		public Side paraMusculoSide;

		// Token: 0x040001A6 RID: 422
		public Vector3 localMuscleOffset;

		// Token: 0x040001A7 RID: 423
		[Header("Config")]
		public float coolDown = 0.2f;

		// Token: 0x040001A8 RID: 424
		[SerializeField]
		protected TriggerRanges[] m_TriggerRanges;

		// Token: 0x040001A9 RID: 425
		private EmulatedSphereTrigger m_EmulatedSphereTrigger;

		// Token: 0x040001AA RID: 426
		private CoolDown m_CoolDown = new CoolDown();

		// Token: 0x040001AB RID: 427
		private HashSet<ICharacterRoot> m_Temp = new HashSet<ICharacterRoot>();

		// Token: 0x0200012D RID: 301
		public enum TriggerAgaints
		{
			// Token: 0x040006FB RID: 1787
			characterController,
			// Token: 0x040006FC RID: 1788
			ragdoll,
			// Token: 0x040006FD RID: 1789
			touchingHand
		}
	}
}
