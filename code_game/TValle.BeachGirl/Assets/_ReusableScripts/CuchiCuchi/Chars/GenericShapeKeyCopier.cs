using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars
{
	// Token: 0x02000135 RID: 309
	[RequireComponent(typeof(SkinnedMeshRenderer))]
	public class GenericShapeKeyCopier : BlendShapeCopier
	{
		// Token: 0x06000D61 RID: 3425 RVA: 0x0002E890 File Offset: 0x0002CA90
		public static GenericShapeKeyCopier Add(SkinnedMeshRenderer target, SkinnedMeshRenderer source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source", "source null reference.");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target", "target null reference.");
			}
			GenericShapeKeyCopier genericShapeKeyCopier = target.gameObject.AddComponent<GenericShapeKeyCopier>();
			genericShapeKeyCopier.SetSource(source);
			return genericShapeKeyCopier;
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06000D62 RID: 3426 RVA: 0x0002E8E1 File Offset: 0x0002CAE1
		public sealed override int updateEvent1Index
		{
			get
			{
				return 42;
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06000D63 RID: 3427 RVA: 0x0002E8E5 File Offset: 0x0002CAE5
		protected override SkinnedMeshRenderer skinnedMeshRendererSource
		{
			get
			{
				return this.m_source;
			}
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06000D64 RID: 3428 RVA: 0x0002E8ED File Offset: 0x0002CAED
		protected override List<SkinnedMeshRenderer> skinnedMeshRendererSourceTargets
		{
			get
			{
				return this.m_targets;
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06000D65 RID: 3429 RVA: 0x0002E8F5 File Offset: 0x0002CAF5
		public bool init
		{
			get
			{
				return this.m_source != null;
			}
		}

		// Token: 0x06000D66 RID: 3430 RVA: 0x0002E904 File Offset: 0x0002CB04
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			SkinnedMeshRenderer component = base.GetComponent<SkinnedMeshRenderer>();
			if (component == null)
			{
				throw new ArgumentNullException("target", "target null reference.");
			}
			this.m_targets = new List<SkinnedMeshRenderer> { component };
			if (!this.init)
			{
				base.SetInicializable();
				base.SetManualStart();
			}
		}

		// Token: 0x06000D67 RID: 3431 RVA: 0x0002E95D File Offset: 0x0002CB5D
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			base.UpdateData();
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x0002E96C File Offset: 0x0002CB6C
		public void Init(SkinnedMeshRenderer source)
		{
			if (this.init)
			{
				throw new InvalidOperationException("ya esta init");
			}
			if (source == null)
			{
				throw new ArgumentNullException("source", "source null reference.");
			}
			this.m_source = source;
			if (Application.isPlaying)
			{
				base.Initialize();
				base.ManualStart();
			}
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x0002E9BF File Offset: 0x0002CBBF
		public void SetSource(SkinnedMeshRenderer source)
		{
			this.Init(source);
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x0002E9C8 File Offset: 0x0002CBC8
		public sealed override void OnUpdateEvent1()
		{
			base.CopyShapes();
		}

		// Token: 0x04000780 RID: 1920
		[NonSerialized]
		private List<SkinnedMeshRenderer> m_targets;

		// Token: 0x04000781 RID: 1921
		[SerializeField]
		private SkinnedMeshRenderer m_source;
	}
}
