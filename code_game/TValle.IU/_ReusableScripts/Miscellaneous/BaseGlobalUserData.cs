using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.UI;
using UnityEngine;

namespace Assets._ReusableScripts.Miscellaneous
{
	// Token: 0x020000C0 RID: 192
	[Serializable]
	public abstract class BaseGlobalUserData
	{
		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600055A RID: 1370 RVA: 0x00014C6A File Offset: 0x00012E6A
		public string stringId
		{
			get
			{
				return this.m_stringId;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x00014C72 File Offset: 0x00012E72
		public string stringDisplayId
		{
			get
			{
				return this.m_stringDisplayId;
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x00014C7A File Offset: 0x00012E7A
		public bool iniciado
		{
			get
			{
				return this.init;
			}
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x00014C84 File Offset: 0x00012E84
		public void Init()
		{
			if (this.init)
			{
				return;
			}
			if (Application.isPlaying)
			{
				this.init = true;
			}
			this.OnInit();
			this.InitID();
			this.OnInitiatedID();
			this.nombreCorto = this.nombreCorto.Trim();
			this.nombreCompleto = this.nombreCompleto.Trim();
			RegexOptions regexOptions = RegexOptions.None;
			Regex regex = new Regex("[ ]{2,}", regexOptions);
			this.nombreCompleto = regex.Replace(this.nombreCompleto, " ");
			this.nombreCorto = regex.Replace(this.nombreCorto, " ");
			if (string.IsNullOrEmpty(this.nombreCorto) && string.IsNullOrEmpty(this.nombreCompleto))
			{
				this.nombreCompleto = (this.nombreCorto = "????");
				return;
			}
			if (string.IsNullOrEmpty(this.nombreCorto))
			{
				this.nombreCorto = ((this.nombreCompleto.IndexOf(" ") > -1) ? this.nombreCompleto.Substring(0, this.nombreCompleto.IndexOf(" ")) : this.nombreCompleto);
				return;
			}
			if (string.IsNullOrEmpty(this.nombreCompleto))
			{
				this.nombreCompleto = this.nombreCorto;
			}
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00014DAC File Offset: 0x00012FAC
		public virtual void InitID()
		{
			string text;
			string text2;
			this.GenerateID(out text, out text2);
			this.m_stringId = text;
			this.m_stringDisplayId = text2;
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00014DD4 File Offset: 0x00012FD4
		public bool TryInitID()
		{
			string text;
			string text2;
			if (this.TryGenerateID(out text, out text2))
			{
				this.m_stringId = text;
				this.m_stringDisplayId = text2;
				return true;
			}
			return false;
		}

		// Token: 0x06000560 RID: 1376
		protected abstract void GenerateID(out string ID, out string displayID);

		// Token: 0x06000561 RID: 1377
		protected abstract bool TryGenerateID(out string ID, out string displayID);

		// Token: 0x06000562 RID: 1378
		protected abstract void OnInitiatedID();

		// Token: 0x06000563 RID: 1379 RVA: 0x00014DFE File Offset: 0x00012FFE
		public bool IsPreInitValid()
		{
			return this.OnIsPreInitValid();
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x00014E06 File Offset: 0x00013006
		public virtual bool IsPostInitValid()
		{
			if (string.IsNullOrWhiteSpace(this.m_stringId) || string.IsNullOrWhiteSpace(this.m_stringDisplayId) || !Application.isPlaying)
			{
				return this.OnIsPostInitValid();
			}
			return this.init;
		}

		// Token: 0x06000565 RID: 1381
		protected abstract bool OnIsPreInitValid();

		// Token: 0x06000566 RID: 1382
		protected abstract bool OnIsPostInitValid();

		// Token: 0x06000567 RID: 1383
		protected abstract void OnInit();

		// Token: 0x06000568 RID: 1384 RVA: 0x00014E38 File Offset: 0x00013038
		public virtual void OnUsed()
		{
			if (this.displayAutorsOnUsed)
			{
				for (int i = 0; i < this.autores.Count; i++)
				{
					BaseGlobalUserData.Autor au = this.autores[i];
					Singleton<MainCanvas>.instance.MostrartMsg(this.nombreCompleto, string.Concat(new string[] { "Version: <B>", this.version, "</B>\nFrom: <B>", au.name, "</B>\n", au.URL }), 2f, true, null, null, delegate(object s)
					{
						Application.OpenURL(au.URL);
					});
				}
			}
		}

		// Token: 0x04000208 RID: 520
		[ReadOnlyUI]
		[SerializeField]
		private string m_stringDisplayId;

		// Token: 0x04000209 RID: 521
		[ReadOnlyUI]
		[SerializeField]
		private string m_stringId;

		// Token: 0x0400020A RID: 522
		public string organizacion;

		// Token: 0x0400020B RID: 523
		public string categoria;

		// Token: 0x0400020C RID: 524
		public string nombreCompleto;

		// Token: 0x0400020D RID: 525
		public string nombreCorto;

		// Token: 0x0400020E RID: 526
		public string version;

		// Token: 0x0400020F RID: 527
		public bool displayAutorsOnUsed;

		// Token: 0x04000210 RID: 528
		public List<BaseGlobalUserData.Autor> autores = new List<BaseGlobalUserData.Autor>();

		// Token: 0x04000211 RID: 529
		[NonSerialized]
		protected bool init;

		// Token: 0x02000194 RID: 404
		[Serializable]
		public class Autor
		{
			// Token: 0x0400052D RID: 1325
			public string name;

			// Token: 0x0400052E RID: 1326
			public string URL;
		}
	}
}
