using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones
{
	// Token: 0x02000035 RID: 53
	public abstract class InteraccionMalePrimariaBase : Interaccion, IInteraccionPrimaria
	{
		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000244 RID: 580 RVA: 0x0000CC81 File Offset: 0x0000AE81
		public sealed override int Tipo
		{
			get
			{
				return this.m_Tipo;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000245 RID: 581 RVA: 0x0000CC89 File Offset: 0x0000AE89
		public Transform interactionRootBone
		{
			get
			{
				return this.m_interactionRootBone;
			}
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000CC94 File Offset: 0x0000AE94
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
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

		// Token: 0x06000247 RID: 583 RVA: 0x0000CD29 File Offset: 0x0000AF29
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

		// Token: 0x06000248 RID: 584 RVA: 0x0000CD44 File Offset: 0x0000AF44
		protected override bool OnPuedeEjecutarse()
		{
			IInteraccionesDeCharacter owner = base.owner;
			Object @object;
			if (owner == null)
			{
				@object = null;
			}
			else
			{
				ICharacter character = owner.character;
				@object = ((character != null) ? character.rootBoneTransform : null);
			}
			if (@object != null)
			{
				this.m_lastLossyEscaleOfTarget = (this.m_interactionRootBone.localScale = base.owner.character.rootBoneTransform.lossyScale);
			}
			else
			{
				this.m_lastLossyEscaleOfTarget = (this.m_interactionRootBone.localScale = Vector3.one);
			}
			return base.OnPuedeEjecutarse();
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000CDC4 File Offset: 0x0000AFC4
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
			CoroutineCapsule coroutine = this.m_Coroutine;
			if (coroutine == null)
			{
				return;
			}
			coroutine.Start(this.ScaleChangeChecker(), null, null);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000CF03 File Offset: 0x0000B103
		private void Interaccion_onPause()
		{
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000CF05 File Offset: 0x0000B105
		protected override void DespuesDeDetenerse()
		{
			this.m_flagDontRestorePose = false;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000CF0E File Offset: 0x0000B10E
		public void FlagToDontRestorePoseOnStop()
		{
			this.m_flagDontRestorePose = true;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000CF18 File Offset: 0x0000B118
		protected override void Termina()
		{
			CoroutineCapsule coroutine = this.m_Coroutine;
			if (((coroutine != null) ? new bool?(coroutine.ejecutandose) : null).GetValueOrDefault())
			{
				this.m_Coroutine.Stop();
			}
			if (this.m_interactionRootBone != null)
			{
				this.m_lastLossyEscaleOfTarget = (this.m_interactionRootBone.localScale = Vector3.one);
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000CF80 File Offset: 0x0000B180
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

		// Token: 0x0600024F RID: 591 RVA: 0x0000CF8F File Offset: 0x0000B18F
		private void OnTargetScaleChanged()
		{
		}

		// Token: 0x040001AC RID: 428
		[SerializeField]
		private int m_Tipo;

		// Token: 0x040001AD RID: 429
		[ReadOnlyUI]
		[SerializeField]
		private InteractionObject m_mainInteractionObject;

		// Token: 0x040001AE RID: 430
		[SerializeField]
		private Transform m_interactionRootBone;

		// Token: 0x040001AF RID: 431
		private CoroutineCapsule m_Coroutine;

		// Token: 0x040001B0 RID: 432
		[SerializeField]
		[ReadOnlyUI]
		private bool m_flagDontRestorePose;

		// Token: 0x040001B1 RID: 433
		private Vector3 m_lastLossyEscaleOfTarget;
	}
}
