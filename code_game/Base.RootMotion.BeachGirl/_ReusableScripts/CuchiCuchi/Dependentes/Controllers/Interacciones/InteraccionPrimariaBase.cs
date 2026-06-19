using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones.TargetsDynamicos;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000D8 RID: 216
	public abstract class InteraccionPrimariaBase : Interaccion, IInteraccionPrimaria
	{
		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x00025FA6 File Offset: 0x000241A6
		public sealed override int Tipo
		{
			get
			{
				return this.m_Tipo;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x0600080A RID: 2058
		protected abstract AnimController animController { get; }

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x0600080B RID: 2059 RVA: 0x00025FAE File Offset: 0x000241AE
		public Transform interactionRootBone
		{
			get
			{
				return this.m_interactionRootBone;
			}
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00025FB8 File Offset: 0x000241B8
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			base.GetComponentsInChildren<ChainBendGoalDeInteraccion>(false, this.m_bendGoalDynamic);
			base.GetComponentsInChildren<TargetDynamicoDeInteracionBase>(false, this.m_targetsDynamicos);
			if (this.m_interactionRootBone == null)
			{
				throw new ArgumentNullException("m_interactionRootBone", "m_interactionRootBone null reference.");
			}
			InteractionObject[] componentsInChildren = base.GetComponentsInChildren<InteractionObject>();
			this.m_mainInteractionObject = componentsInChildren.FirstOrDefault((InteractionObject i) => i.name.IndexOf("main", StringComparison.InvariantCultureIgnoreCase) >= 0);
			if (this.m_mainInteractionObject == null)
			{
				this.m_mainInteractionObject = componentsInChildren.First<InteractionObject>();
			}
			this.m_Coroutine = new CoroutineCapsule(this, new CoroutineCapsuleConfig
			{
				autoRestart = false
			});
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x00026067 File Offset: 0x00024267
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			CoroutineCapsule coroutine = this.m_Coroutine;
			if (coroutine == null)
			{
				return;
			}
			coroutine.Destroy();
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x00026080 File Offset: 0x00024280
		protected override bool OnPuedeEjecutarse()
		{
			this.m_lastLossyEscaleOfTarget = (this.m_interactionRootBone.localScale = base.owner.character.rootBoneTransform.lossyScale);
			return base.OnPuedeEjecutarse();
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x000260BC File Offset: 0x000242BC
		protected override void Comienza()
		{
			InteractionObject.InteractionEvent interactionEvent = null;
			InteractionObject.Message message = null;
			foreach (InteractionObject.InteractionEvent interactionEvent2 in this.m_mainInteractionObject.events)
			{
				if (interactionEvent2.pause)
				{
					interactionEvent = interactionEvent2;
					foreach (InteractionObject.Message message2 in interactionEvent2.messages)
					{
						if (message2.function == "Interaccion_onPause")
						{
							message = message2;
							break;
						}
					}
					break;
				}
			}
			if (interactionEvent == null)
			{
				Debug.LogWarning("Interaccion: " + base.name + " no posee evento de pause.", this);
			}
			else if (message == null)
			{
				message = new InteractionObject.Message();
				message.function = "Interaccion_onPause";
				message.recipient = base.gameObject;
				List<InteractionObject.Message> list;
				if (((interactionEvent != null) ? interactionEvent.messages : null) != null)
				{
					list = new List<InteractionObject.Message>(interactionEvent.messages);
				}
				else
				{
					list = new List<InteractionObject.Message>();
				}
				list.Add(message);
				interactionEvent.messages = list.ToArray();
			}
			this.m_lastLossyEscaleOfTarget = (this.m_interactionRootBone.localScale = base.owner.character.rootBoneTransform.lossyScale);
			this.UpdateDynamicTargets();
			for (int k = 0; k < this.m_bendGoalDynamic.Count; k++)
			{
				this.m_bendGoalDynamic[k].OnComienza(base.owner.character);
			}
			this.animController.currentPose = this.pose;
			CoroutineCapsule coroutine = this.m_Coroutine;
			if (coroutine == null)
			{
				return;
			}
			coroutine.Start(this.ScaleChangeChecker(), null, null);
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x0002624C File Offset: 0x0002444C
		private void Interaccion_onPause()
		{
			for (int i = 0; i < this.m_bendGoalDynamic.Count; i++)
			{
				this.m_bendGoalDynamic[i].OnPaused();
			}
			this.animController.OnPose();
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x0002628C File Offset: 0x0002448C
		protected override void DespuesDeDetenerse()
		{
			for (int i = 0; i < this.m_bendGoalDynamic.Count; i++)
			{
				this.m_bendGoalDynamic[i].OnResume();
			}
			if (!this.m_flagDontRestorePose)
			{
				this.animController.SetDefaultPose();
			}
			this.m_flagDontRestorePose = false;
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x000262DA File Offset: 0x000244DA
		public void FlagToDontRestorePoseOnStop()
		{
			this.m_flagDontRestorePose = true;
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x000262E4 File Offset: 0x000244E4
		protected override void Termina()
		{
			CoroutineCapsule coroutine = this.m_Coroutine;
			if (((coroutine != null) ? new bool?(coroutine.ejecutandose) : null).GetValueOrDefault())
			{
				this.m_Coroutine.Stop();
			}
			this.ResetDynamicTargets();
			for (int i = 0; i < this.m_bendGoalDynamic.Count; i++)
			{
				this.m_bendGoalDynamic[i].OnTermina();
			}
			if (this.m_interactionRootBone != null)
			{
				this.m_lastLossyEscaleOfTarget = (this.m_interactionRootBone.localScale = Vector3.one);
			}
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x00026379 File Offset: 0x00024579
		private IEnumerator ScaleChangeChecker()
		{
			WaitForSeconds wait = new WaitForSeconds(0.333f);
			for (;;)
			{
				if (base.owner != null && base.owner.character != null)
				{
					Vector3 lossyScale = base.owner.character.rootBoneTransform.lossyScale;
					if (!ExtendedMonoBehaviour.AlmostEqual(this.m_lastLossyEscaleOfTarget, lossyScale, 0.001f))
					{
						this.m_lastLossyEscaleOfTarget = (this.m_interactionRootBone.localScale = lossyScale);
						this.OnTargetScaleChanged();
					}
				}
				yield return wait;
			}
			yield break;
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x00026388 File Offset: 0x00024588
		private void OnTargetScaleChanged()
		{
			this.UpdateDynamicTargets();
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x00026390 File Offset: 0x00024590
		public void UpdateDynamicTargets()
		{
			for (int i = 0; i < this.m_targetsDynamicos.Count; i++)
			{
				TargetDynamicoDeInteracionBase targetDynamicoDeInteracionBase = this.m_targetsDynamicos[i];
				IInteraccionesDeCharacter owner = base.owner;
				targetDynamicoDeInteracionBase.Actualizar((owner != null) ? owner.character : null);
			}
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x000263D8 File Offset: 0x000245D8
		public void ResetDynamicTargets()
		{
			for (int i = 0; i < this.m_targetsDynamicos.Count; i++)
			{
				this.m_targetsDynamicos[i].ResetTarget();
			}
		}

		// Token: 0x04000548 RID: 1352
		[SerializeField]
		private int m_Tipo;

		// Token: 0x04000549 RID: 1353
		public TipoDePose pose;

		// Token: 0x0400054A RID: 1354
		[ReadOnlyUI]
		[SerializeField]
		private InteractionObject m_mainInteractionObject;

		// Token: 0x0400054B RID: 1355
		[SerializeField]
		private Transform m_interactionRootBone;

		// Token: 0x0400054C RID: 1356
		private List<ChainBendGoalDeInteraccion> m_bendGoalDynamic = new List<ChainBendGoalDeInteraccion>();

		// Token: 0x0400054D RID: 1357
		private List<TargetDynamicoDeInteracionBase> m_targetsDynamicos = new List<TargetDynamicoDeInteracionBase>();

		// Token: 0x0400054E RID: 1358
		private CoroutineCapsule m_Coroutine;

		// Token: 0x0400054F RID: 1359
		[SerializeField]
		[ReadOnlyUI]
		private bool m_flagDontRestorePose;

		// Token: 0x04000550 RID: 1360
		private Vector3 m_lastLossyEscaleOfTarget;
	}
}
