using System;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x020000A9 RID: 169
	[RequireComponent(typeof(InteractionObjectV2Base))]
	public sealed class InteractionObjectV2EnableScripts : AplicableBehaviour
	{
		// Token: 0x06000675 RID: 1653 RVA: 0x0001F9D8 File Offset: 0x0001DBD8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteractionObjectV2 = base.GetComponent<InteractionObjectV2Base>();
			this.m_InteractionObjectV2.staring += this.M_InteractionObjectV2_staring;
			this.m_InteractionObjectV2.stoped += this.M_InteractionObjectV2_stoped;
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0001FA28 File Offset: 0x0001DC28
		public void Add(Behaviour script)
		{
			CustomUpdatedMonobehaviourBase customUpdatedMonobehaviourBase = script as CustomUpdatedMonobehaviourBase;
			if (customUpdatedMonobehaviourBase != null)
			{
				if (!customUpdatedMonobehaviourBase.isAwaken)
				{
					customUpdatedMonobehaviourBase.ManualAwake();
				}
				if (!customUpdatedMonobehaviourBase.initPendiente && !customUpdatedMonobehaviourBase.isStared)
				{
					customUpdatedMonobehaviourBase.ManualStart();
				}
			}
			this.scripts.Add(script);
			this.UpdateScriptsState();
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x0001FA7B File Offset: 0x0001DC7B
		public void Remove(Behaviour script)
		{
			this.scripts.Remove(script);
			this.UpdateScriptsState();
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x0001FA90 File Offset: 0x0001DC90
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.UpdateScriptsState();
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x0001FA9E File Offset: 0x0001DC9E
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.UpdateScriptsState();
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x0001FAAC File Offset: 0x0001DCAC
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			for (int i = 0; i < this.scripts.Count; i++)
			{
				this.scripts[i].enabled = false;
			}
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x0001FAE8 File Offset: 0x0001DCE8
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_InteractionObjectV2.stared -= this.M_InteractionObjectV2_staring;
			this.m_InteractionObjectV2.stoped -= this.M_InteractionObjectV2_stoped;
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0001FB20 File Offset: 0x0001DD20
		private void UpdateScriptsState()
		{
			for (int i = 0; i < this.scripts.Count; i++)
			{
				this.scripts[i].enabled = this.m_InteractionObjectV2.interacting;
			}
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x0001FB60 File Offset: 0x0001DD60
		private void M_InteractionObjectV2_staring(InteractionObjectV2Base arg1, InteractionSystem arg2)
		{
			for (int i = 0; i < this.scripts.Count; i++)
			{
				this.scripts[i].enabled = true;
			}
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0001FB98 File Offset: 0x0001DD98
		private void M_InteractionObjectV2_stoped(InteractionObjectV2Base arg1, InteractionSystem arg2)
		{
			for (int i = 0; i < this.scripts.Count; i++)
			{
				this.scripts[i].enabled = false;
			}
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x0001FBCD File Offset: 0x0001DDCD
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Forzar Activacion",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x0001FBE6 File Offset: 0x0001DDE6
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Forzar Desactivacion",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x0001FC00 File Offset: 0x0001DE00
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			for (int i = 0; i < this.scripts.Count; i++)
			{
				this.scripts[i].enabled = true;
			}
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x0001FC3C File Offset: 0x0001DE3C
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			for (int i = 0; i < this.scripts.Count; i++)
			{
				this.scripts[i].enabled = false;
			}
		}

		// Token: 0x04000471 RID: 1137
		[SerializeField]
		[CoolArrayItem]
		private List<Behaviour> scripts = new List<Behaviour>();

		// Token: 0x04000472 RID: 1138
		private InteractionObjectV2Base m_InteractionObjectV2;
	}
}
