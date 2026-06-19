using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200021A RID: 538
	public class DatabaseManager
	{
		// Token: 0x0600182C RID: 6188 RVA: 0x000218E8 File Offset: 0x0001FAE8
		public DatabaseManager(DialogueDatabase defaultDatabase = null)
		{
			this.masterDatabase = ScriptableObject.CreateInstance(typeof(DialogueDatabase)) as DialogueDatabase;
			this.DefaultDatabase = defaultDatabase;
		}

		// Token: 0x17000A16 RID: 2582
		// (get) Token: 0x0600182D RID: 6189 RVA: 0x00021928 File Offset: 0x0001FB28
		// (set) Token: 0x0600182E RID: 6190 RVA: 0x00021930 File Offset: 0x0001FB30
		public DialogueDatabase DefaultDatabase { get; set; }

		// Token: 0x17000A17 RID: 2583
		// (get) Token: 0x0600182F RID: 6191 RVA: 0x0002193C File Offset: 0x0001FB3C
		public DialogueDatabase MasterDatabase
		{
			get
			{
				return this.GetMasterDatabase();
			}
		}

		// Token: 0x06001830 RID: 6192 RVA: 0x00021944 File Offset: 0x0001FB44
		private DialogueDatabase GetMasterDatabase()
		{
			if (this.loadedDatabases.Count == 0)
			{
				this.Add(this.DefaultDatabase);
			}
			return this.masterDatabase;
		}

		// Token: 0x06001831 RID: 6193 RVA: 0x00021974 File Offset: 0x0001FB74
		public void Add(DialogueDatabase database)
		{
			if (database != null && !this.loadedDatabases.Contains(database))
			{
				if (this.loadedDatabases.Count == 0)
				{
					DialogueLua.InitializeChatMapperVariables();
				}
				DialogueLua.AddChatMapperVariables(database, this.loadedDatabases);
				this.masterDatabase.Add(database);
				this.loadedDatabases.Add(database);
			}
		}

		// Token: 0x06001832 RID: 6194 RVA: 0x000219D8 File Offset: 0x0001FBD8
		public void Remove(DialogueDatabase database)
		{
			if (database != null)
			{
				this.loadedDatabases.Remove(database);
				this.masterDatabase.Remove(database, this.loadedDatabases);
				DialogueLua.RemoveChatMapperVariables(database, this.loadedDatabases);
			}
		}

		// Token: 0x06001833 RID: 6195 RVA: 0x00021A14 File Offset: 0x0001FC14
		public void Clear()
		{
			DialogueLua.InitializeChatMapperVariables();
			this.masterDatabase.Clear();
			this.loadedDatabases.Clear();
		}

		// Token: 0x06001834 RID: 6196 RVA: 0x00021A34 File Offset: 0x0001FC34
		public void Reset(DatabaseResetOptions databaseResetOptions = DatabaseResetOptions.RevertToDefault)
		{
			if (databaseResetOptions != DatabaseResetOptions.KeepAllLoaded)
			{
				if (databaseResetOptions == DatabaseResetOptions.RevertToDefault)
				{
					this.ResetToDefaultDatabase();
				}
			}
			else
			{
				this.ResetToLoadedDatabases();
			}
		}

		// Token: 0x06001835 RID: 6197 RVA: 0x00021A6C File Offset: 0x0001FC6C
		private void ResetToDefaultDatabase()
		{
			this.Clear();
			this.Add(this.DefaultDatabase);
		}

		// Token: 0x06001836 RID: 6198 RVA: 0x00021A80 File Offset: 0x0001FC80
		private void ResetToLoadedDatabases()
		{
			List<DialogueDatabase> list = new List<DialogueDatabase>(this.loadedDatabases);
			this.Clear();
			this.Add(this.DefaultDatabase);
			foreach (DialogueDatabase dialogueDatabase in list)
			{
				this.Add(dialogueDatabase);
			}
		}

		// Token: 0x04000DA6 RID: 3494
		private DialogueDatabase masterDatabase;

		// Token: 0x04000DA7 RID: 3495
		private List<DialogueDatabase> loadedDatabases = new List<DialogueDatabase>();
	}
}
