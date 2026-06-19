using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000277 RID: 631
	[AddComponentMenu("Dialogue System/Save System/Persistent Active Data")]
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/persistent_active_data.html")]
	public class PersistentActiveData : MonoBehaviour
	{
		// Token: 0x06001B5D RID: 7005 RVA: 0x0003023C File Offset: 0x0002E43C
		protected virtual void Start()
		{
			if (this.checkOnStart)
			{
				this.Check();
			}
		}

		// Token: 0x06001B5E RID: 7006 RVA: 0x00030250 File Offset: 0x0002E450
		protected virtual void OnEnable()
		{
			PersistentDataManager.RegisterPersistentData(base.gameObject);
		}

		// Token: 0x06001B5F RID: 7007 RVA: 0x00030260 File Offset: 0x0002E460
		protected virtual void OnDisable()
		{
			PersistentDataManager.UnregisterPersistentData(base.gameObject);
		}

		// Token: 0x06001B60 RID: 7008 RVA: 0x00030270 File Offset: 0x0002E470
		public void OnApplyPersistentData()
		{
			this.Check();
		}

		// Token: 0x06001B61 RID: 7009 RVA: 0x00030278 File Offset: 0x0002E478
		public virtual void Check()
		{
			if (base.enabled)
			{
				this.target.SetActive(this.condition.IsTrue(null));
			}
		}

		// Token: 0x04000F62 RID: 3938
		[Tooltip("The GameObject to set active or inactive based on the Condition below.")]
		public GameObject target;

		// Token: 0x04000F63 RID: 3939
		[Tooltip("If true, Target is activated; otherwise deactivated.")]
		public Condition condition;

		// Token: 0x04000F64 RID: 3940
		[Tooltip("When script starts, check condition & set target GameObject active/inactive.")]
		public bool checkOnStart;
	}
}
