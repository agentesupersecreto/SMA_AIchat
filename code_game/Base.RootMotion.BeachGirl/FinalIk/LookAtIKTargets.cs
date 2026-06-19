using System;
using UnityEngine;

namespace Assets.FinalIk
{
	// Token: 0x0200000C RID: 12
	public class LookAtIKTargets : CustomMonobehaviour
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00003240 File Offset: 0x00001440
		public LookAtTargetWieghtParCollection primariosCollection
		{
			get
			{
				return this.m_primariosColleccion;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00003248 File Offset: 0x00001448
		public LookAtTargetWieghtParCollection segundariosCollection
		{
			get
			{
				return this.m_segundariosColleccion;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00003250 File Offset: 0x00001450
		public LookAtIKTargets.Targets primarios
		{
			get
			{
				return this.m_primarios;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00003258 File Offset: 0x00001458
		public LookAtIKTargets.Targets segundarios
		{
			get
			{
				return this.m_segundarios;
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003260 File Offset: 0x00001460
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_primariosColleccion.master = this.m_primarios.master;
			this.m_primariosColleccion.Add(this.m_primarios.slot1);
			this.m_primariosColleccion.Add(this.m_primarios.slot2);
			this.m_primariosColleccion.Add(this.m_primarios.slot3);
			this.m_primariosColleccion.Add(this.m_primarios.slot4);
			this.m_segundariosColleccion.master = this.m_segundarios.master;
			this.m_segundariosColleccion.Add(this.m_segundarios.slot1);
			this.m_segundariosColleccion.Add(this.m_segundarios.slot2);
			this.m_segundariosColleccion.Add(this.m_segundarios.slot3);
			this.m_segundariosColleccion.Add(this.m_segundarios.slot4);
		}

		// Token: 0x0400000B RID: 11
		[SerializeField]
		private LookAtIKTargets.Targets m_primarios = new LookAtIKTargets.Targets();

		// Token: 0x0400000C RID: 12
		[SerializeField]
		private LookAtIKTargets.Targets m_segundarios = new LookAtIKTargets.Targets();

		// Token: 0x0400000D RID: 13
		private LookAtTargetWieghtParCollection m_primariosColleccion = new LookAtTargetWieghtParCollection();

		// Token: 0x0400000E RID: 14
		private LookAtTargetWieghtParCollection m_segundariosColleccion = new LookAtTargetWieghtParCollection();

		// Token: 0x02000113 RID: 275
		[Serializable]
		public class Targets
		{
			// Token: 0x17000218 RID: 536
			// (get) Token: 0x06000A8E RID: 2702 RVA: 0x0002F196 File Offset: 0x0002D396
			public LookAtTargetWieghtPar master
			{
				get
				{
					return this.m_master;
				}
			}

			// Token: 0x17000219 RID: 537
			// (get) Token: 0x06000A8F RID: 2703 RVA: 0x0002F19E File Offset: 0x0002D39E
			public LookAtTargetWieghtPar slot1
			{
				get
				{
					return this.m_slot1;
				}
			}

			// Token: 0x1700021A RID: 538
			// (get) Token: 0x06000A90 RID: 2704 RVA: 0x0002F1A6 File Offset: 0x0002D3A6
			public LookAtTargetWieghtPar slot2
			{
				get
				{
					return this.m_slot2;
				}
			}

			// Token: 0x1700021B RID: 539
			// (get) Token: 0x06000A91 RID: 2705 RVA: 0x0002F1AE File Offset: 0x0002D3AE
			public LookAtTargetWieghtPar slot3
			{
				get
				{
					return this.m_slot3;
				}
			}

			// Token: 0x1700021C RID: 540
			// (get) Token: 0x06000A92 RID: 2706 RVA: 0x0002F1B6 File Offset: 0x0002D3B6
			public LookAtTargetWieghtPar slot4
			{
				get
				{
					return this.m_slot4;
				}
			}

			// Token: 0x06000A93 RID: 2707 RVA: 0x0002F1C0 File Offset: 0x0002D3C0
			public LookAtTargetWieghtPar ObtenerSlot(int index)
			{
				if (index < 0)
				{
					return null;
				}
				if (index > 4)
				{
					return null;
				}
				switch (index)
				{
				case 0:
					return this.m_master;
				case 1:
					return this.m_slot1;
				case 2:
					return this.m_slot2;
				case 3:
					return this.m_slot3;
				case 4:
					return this.m_slot4;
				default:
					throw new ArgumentOutOfRangeException(index.ToString());
				}
			}

			// Token: 0x04000679 RID: 1657
			[SerializeField]
			private LookAtTargetWieghtPar m_master = new LookAtTargetWieghtPar();

			// Token: 0x0400067A RID: 1658
			[SerializeField]
			private LookAtTargetWieghtPar m_slot1 = new LookAtTargetWieghtPar();

			// Token: 0x0400067B RID: 1659
			[SerializeField]
			private LookAtTargetWieghtPar m_slot2 = new LookAtTargetWieghtPar();

			// Token: 0x0400067C RID: 1660
			[SerializeField]
			private LookAtTargetWieghtPar m_slot3 = new LookAtTargetWieghtPar();

			// Token: 0x0400067D RID: 1661
			[SerializeField]
			private LookAtTargetWieghtPar m_slot4 = new LookAtTargetWieghtPar();
		}
	}
}
