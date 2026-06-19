using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003DE RID: 990
	public abstract class EstimuloInFrame : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06001588 RID: 5512 RVA: 0x0005AF36 File Offset: 0x00059136
		public Character character
		{
			get
			{
				return this.m_character;
			}
		}

		// Token: 0x06001589 RID: 5513 RVA: 0x0005AF40 File Offset: 0x00059140
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_character = base.GetComponentInParent<Character>();
			this.m_emos = this.m_character.GetComponentInChildren<EmocionesFemeninas>();
			if (this.m_emos == null)
			{
				throw new ArgumentNullException("emos", "emos null reference.");
			}
			this.m_emos.updatingEmociones += this.UpdateEstimulo;
		}

		// Token: 0x0600158A RID: 5514 RVA: 0x0005AFA5 File Offset: 0x000591A5
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_emos != null)
			{
				this.m_emos.updatingEmociones -= this.UpdateEstimulo;
			}
		}

		// Token: 0x0600158B RID: 5515 RVA: 0x0005AFD3 File Offset: 0x000591D3
		private void UpdateEstimulo(EmocionesFemeninas emos)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			this.OnUpdateEstimulo(emos);
		}

		// Token: 0x0600158C RID: 5516
		protected abstract void OnUpdateEstimulo(EmocionesFemeninas emos);

		// Token: 0x0400114C RID: 4428
		protected Character m_character;

		// Token: 0x0400114D RID: 4429
		protected EmocionesFemeninas m_emos;
	}
}
