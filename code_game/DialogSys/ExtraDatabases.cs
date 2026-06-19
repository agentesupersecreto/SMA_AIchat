using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200003C RID: 60
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/extra_databases.html")]
	[AddComponentMenu("Dialogue System/Miscellaneous/Extra Databases")]
	public class ExtraDatabases : MonoBehaviour
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060001B5 RID: 437 RVA: 0x00009454 File Offset: 0x00007654
		// (remove) Token: 0x060001B6 RID: 438 RVA: 0x00009488 File Offset: 0x00007688
		public static event Action addedDatabases;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060001B7 RID: 439 RVA: 0x000094BC File Offset: 0x000076BC
		// (remove) Token: 0x060001B8 RID: 440 RVA: 0x000094F0 File Offset: 0x000076F0
		public static event Action removedDatabases;

		// Token: 0x060001B9 RID: 441 RVA: 0x00009524 File Offset: 0x00007724
		private void TryAddDatabases(Transform interactor, bool immediate)
		{
			if (!this.trying)
			{
				this.trying = true;
				try
				{
					if (this.condition == null || this.condition.IsTrue(interactor))
					{
						this.AddDatabases(immediate);
						if (this.once)
						{
							Object.Destroy(this);
						}
					}
				}
				finally
				{
					this.trying = false;
				}
			}
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00009588 File Offset: 0x00007788
		public void AddDatabases(bool immediate)
		{
			if (immediate)
			{
				this.AddDatabasesImmediate();
				return;
			}
			if (base.gameObject.activeInHierarchy && base.enabled)
			{
				base.StartCoroutine(this.AddDatabasesCoroutine());
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000095B8 File Offset: 0x000077B8
		private void AddDatabasesImmediate()
		{
			foreach (DialogueDatabase dialogueDatabase in this.databases)
			{
				this.AddDatabase(dialogueDatabase);
			}
			ExtraDatabases.addedDatabases();
		}

		// Token: 0x060001BC RID: 444 RVA: 0x000095EF File Offset: 0x000077EF
		private IEnumerator AddDatabasesCoroutine()
		{
			foreach (DialogueDatabase dialogueDatabase in this.databases)
			{
				this.AddDatabase(dialogueDatabase);
				yield return null;
			}
			DialogueDatabase[] array = null;
			ExtraDatabases.addedDatabases();
			yield break;
		}

		// Token: 0x060001BD RID: 445 RVA: 0x000095FE File Offset: 0x000077FE
		private void AddDatabase(DialogueDatabase database)
		{
			if (database != null)
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Adding database {1}", new object[] { "Dialogue System", database.name }), this);
				}
				DialogueManager.AddDatabase(database);
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00009640 File Offset: 0x00007840
		private void TryRemoveDatabases(Transform interactor, bool immediate)
		{
			if (!this.trying)
			{
				this.trying = true;
				try
				{
					if (this.condition == null || this.condition.IsTrue(interactor))
					{
						this.RemoveDatabases(immediate);
						if (this.once)
						{
							Object.Destroy(this);
						}
					}
				}
				finally
				{
					this.trying = false;
				}
			}
		}

		// Token: 0x060001BF RID: 447 RVA: 0x000096A4 File Offset: 0x000078A4
		public void RemoveDatabases(bool immediate)
		{
			if (immediate)
			{
				this.RemoveDatabasesImmediate();
				return;
			}
			if (base.gameObject.activeInHierarchy && base.enabled)
			{
				base.StartCoroutine(this.RemoveDatabasesCoroutine());
			}
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x000096D4 File Offset: 0x000078D4
		private void RemoveDatabasesImmediate()
		{
			foreach (DialogueDatabase dialogueDatabase in this.databases)
			{
				this.RemoveDatabase(dialogueDatabase);
			}
			ExtraDatabases.removedDatabases();
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000970B File Offset: 0x0000790B
		private IEnumerator RemoveDatabasesCoroutine()
		{
			foreach (DialogueDatabase dialogueDatabase in this.databases)
			{
				this.RemoveDatabase(dialogueDatabase);
				yield return null;
			}
			DialogueDatabase[] array = null;
			ExtraDatabases.removedDatabases();
			yield break;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000971A File Offset: 0x0000791A
		private void RemoveDatabase(DialogueDatabase database)
		{
			if (database != null)
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Removing database {1}", new object[] { "Dialogue System", database.name }), this);
				}
				DialogueManager.RemoveDatabase(database);
			}
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00009759 File Offset: 0x00007959
		public IEnumerator Start()
		{
			yield return null;
			if (this.addTrigger == DialogueTriggerEvent.OnStart)
			{
				this.TryAddDatabases(null, this.onePerFrame);
			}
			if (this.removeTrigger == DialogueTriggerEvent.OnStart)
			{
				this.TryRemoveDatabases(null, this.onePerFrame);
			}
			yield break;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00009768 File Offset: 0x00007968
		public void OnEnable()
		{
			if (this.addTrigger == DialogueTriggerEvent.OnEnable)
			{
				this.TryAddDatabases(null, this.onePerFrame);
			}
			if (this.removeTrigger == DialogueTriggerEvent.OnEnable)
			{
				this.TryRemoveDatabases(null, this.onePerFrame);
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00009798 File Offset: 0x00007998
		public void OnDisable()
		{
			if (this.addTrigger == DialogueTriggerEvent.OnDisable)
			{
				this.TryAddDatabases(null, this.onePerFrame);
			}
			if (this.removeTrigger == DialogueTriggerEvent.OnDisable)
			{
				this.TryRemoveDatabases(null, this.onePerFrame);
			}
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x000097CE File Offset: 0x000079CE
		public void OnDestroy()
		{
			if (this.addTrigger == DialogueTriggerEvent.OnDestroy)
			{
				this.TryAddDatabases(null, this.onePerFrame);
			}
			if (this.removeTrigger == DialogueTriggerEvent.OnDestroy)
			{
				this.TryRemoveDatabases(null, this.onePerFrame);
			}
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00009804 File Offset: 0x00007A04
		public void OnUse(Transform actor)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.addTrigger == DialogueTriggerEvent.OnUse)
			{
				this.TryAddDatabases(actor, this.onePerFrame);
			}
			if (this.removeTrigger == DialogueTriggerEvent.OnUse)
			{
				this.TryRemoveDatabases(actor, this.onePerFrame);
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000983D File Offset: 0x00007A3D
		public void OnUse(string message)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.addTrigger == DialogueTriggerEvent.OnUse)
			{
				this.TryAddDatabases(null, this.onePerFrame);
			}
			if (this.removeTrigger == DialogueTriggerEvent.OnUse)
			{
				this.TryRemoveDatabases(null, this.onePerFrame);
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00009876 File Offset: 0x00007A76
		public void OnUse()
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.addTrigger == DialogueTriggerEvent.OnUse)
			{
				this.TryAddDatabases(null, this.onePerFrame);
			}
			if (this.removeTrigger == DialogueTriggerEvent.OnUse)
			{
				this.TryRemoveDatabases(null, this.onePerFrame);
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000098B0 File Offset: 0x00007AB0
		public void OnTriggerEnter(Collider other)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.addTrigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryAddDatabases(other.transform, this.onePerFrame);
			}
			if (this.removeTrigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryRemoveDatabases(other.transform, this.onePerFrame);
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x000098FC File Offset: 0x00007AFC
		public void OnTriggerEnter2D(Collider2D other)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.addTrigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryAddDatabases(other.transform, this.onePerFrame);
			}
			if (this.removeTrigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryRemoveDatabases(other.transform, this.onePerFrame);
			}
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00009948 File Offset: 0x00007B48
		public void OnTriggerExit(Collider other)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.addTrigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryAddDatabases(other.transform, this.onePerFrame);
			}
			if (this.removeTrigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryRemoveDatabases(other.transform, this.onePerFrame);
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000999C File Offset: 0x00007B9C
		public void OnTriggerExit2D(Collider2D other)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.addTrigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryAddDatabases(other.transform, this.onePerFrame);
			}
			if (this.removeTrigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryRemoveDatabases(other.transform, this.onePerFrame);
			}
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00009A22 File Offset: 0x00007C22
		// Note: this type is marked as 'beforefieldinit'.
		static ExtraDatabases()
		{
			ExtraDatabases.addedDatabases = delegate
			{
			};
			ExtraDatabases.removedDatabases = delegate
			{
			};
		}

		// Token: 0x04000144 RID: 324
		public DialogueTriggerEvent addTrigger = DialogueTriggerEvent.OnStart;

		// Token: 0x04000145 RID: 325
		public DialogueTriggerEvent removeTrigger = DialogueTriggerEvent.None;

		// Token: 0x04000146 RID: 326
		public DialogueDatabase[] databases = new DialogueDatabase[0];

		// Token: 0x04000147 RID: 327
		public Condition condition = new Condition();

		// Token: 0x04000148 RID: 328
		[Tooltip("As soon as one event (add or remove) has occurred, destroy this component.")]
		public bool once;

		// Token: 0x04000149 RID: 329
		[Tooltip("Add/remove one database per frame instead of adding them all at the same time. Useful to avoid stutter when adding several databases.")]
		public bool onePerFrame;

		// Token: 0x0400014C RID: 332
		private bool trying;
	}
}
