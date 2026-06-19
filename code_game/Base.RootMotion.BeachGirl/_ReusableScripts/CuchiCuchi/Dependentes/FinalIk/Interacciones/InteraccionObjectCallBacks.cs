using System;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x020000A4 RID: 164
	[RequireComponent(typeof(InteractionObjectV2Base))]
	public abstract class InteraccionObjectCallBacks : AplicableBehaviour
	{
		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000655 RID: 1621 RVA: 0x0001EFC8 File Offset: 0x0001D1C8
		public float currentDuration
		{
			get
			{
				return this.m_currentDuration;
			}
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0001EFD0 File Offset: 0x0001D1D0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteractionObject = base.GetComponent<InteractionObjectV2Base>();
			if (this.m_InteractionObject == null)
			{
				throw new ArgumentNullException("m_InteractionObject", "m_InteractionObject null reference.");
			}
			this.m_InteractionObject.staring += this.M_InteractionObject_staring;
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x0001F024 File Offset: 0x0001D224
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_InteractionObject.staring -= this.M_InteractionObject_staring;
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x0001F044 File Offset: 0x0001D244
		private void M_InteractionObject_staring(InteractionObjectV2Base arg1, InteractionSystem arg2)
		{
			this.m_currentDuration = this.CurrentInteractionObjectDuracion();
			this.OnStaring(arg2);
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0001F05C File Offset: 0x0001D25C
		protected float CurrentInteractionObjectDuracion()
		{
			InteractionObject component = base.GetComponent<InteractionObject>();
			if (component == null)
			{
				throw new ArgumentNullException("io", "io null reference.");
			}
			float num = 0f;
			for (int i = 0; i < component.weightCurves.Length; i++)
			{
				if (component.weightCurves[i].curve.length > 0)
				{
					float time = component.weightCurves[i].curve.keys[component.weightCurves[i].curve.length - 1].time;
					num = Mathf.Clamp(num, time, num);
				}
			}
			return num;
		}

		// Token: 0x0600065A RID: 1626
		protected abstract void OnStaring(InteractionSystem interactionSystem);

		// Token: 0x0600065B RID: 1627 RVA: 0x0001F0F2 File Offset: 0x0001D2F2
		protected sealed override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Set InteractionObject Eventos",
				playTimeVisible = false
			};
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0001F10B File Offset: 0x0001D30B
		protected sealed override void OnAplicar2()
		{
			base.OnAplicar2();
			this.SetCallBacks();
			TValleEditorTools.SetDirty(base.GetComponent<InteractionObjectV2Base>());
		}

		// Token: 0x0600065D RID: 1629
		protected abstract void SetCallBacks();

		// Token: 0x0600065E RID: 1630 RVA: 0x0001F124 File Offset: 0x0001D324
		protected InteractionObject.InteractionEvent SetCallBack(Action callback, float time)
		{
			InteractionObject.InteractionEvent interactionEvent = null;
			InteractionObject component = base.GetComponent<InteractionObject>();
			if (component == null)
			{
				return interactionEvent;
			}
			if (callback.Target != this)
			{
				throw new InvalidOperationException();
			}
			string name = callback.Method.Name;
			foreach (InteractionObject.InteractionEvent interactionEvent2 in component.events)
			{
				if (interactionEvent != null)
				{
					break;
				}
				foreach (InteractionObject.Message message in interactionEvent2.messages)
				{
					if (message.function == name)
					{
						message.recipient = base.gameObject;
						interactionEvent = interactionEvent2;
						break;
					}
				}
			}
			if (interactionEvent == null)
			{
				interactionEvent = new InteractionObject.InteractionEvent();
				InteractionObject.Message message2 = new InteractionObject.Message();
				message2.function = name;
				message2.recipient = base.gameObject;
				List<InteractionObject.Message> list;
				if (((interactionEvent != null) ? interactionEvent.messages : null) != null)
				{
					list = new List<InteractionObject.Message>(interactionEvent.messages);
				}
				else
				{
					list = new List<InteractionObject.Message>();
				}
				list.Add(message2);
				interactionEvent.messages = list.ToArray();
				List<InteractionObject.InteractionEvent> list2;
				if (component.events != null)
				{
					list2 = new List<InteractionObject.InteractionEvent>(component.events);
				}
				else
				{
					list2 = new List<InteractionObject.InteractionEvent>();
				}
				list2.Add(interactionEvent);
				component.events = list2.ToArray();
			}
			interactionEvent.time = time;
			return interactionEvent;
		}

		// Token: 0x0400045E RID: 1118
		protected InteractionObjectV2Base m_InteractionObject;

		// Token: 0x0400045F RID: 1119
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentDuration;
	}
}
