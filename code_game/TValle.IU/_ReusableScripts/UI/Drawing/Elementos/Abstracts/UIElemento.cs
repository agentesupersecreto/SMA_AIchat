using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000BB RID: 187
	public class UIElemento : AplicableCustomMonobehaviour, IUIElemento, IUIElementoSecondaryBindable
	{
		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x0600053B RID: 1339 RVA: 0x0001490F File Offset: 0x00012B0F
		public string modelName
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x00014917 File Offset: 0x00012B17
		public Type modelType
		{
			get
			{
				return this.m_ModelSerializableType.type;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x0600053D RID: 1341 RVA: 0x00014924 File Offset: 0x00012B24
		public bool isBinded
		{
			get
			{
				return !string.IsNullOrWhiteSpace(this.m_model) && this.m_ModelSerializableType.type != null;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x0600053E RID: 1342 RVA: 0x00014946 File Offset: 0x00012B46
		public int modelItemIndex
		{
			get
			{
				return this.m_modelItemIndex;
			}
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0001494E File Offset: 0x00012B4E
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x00014958 File Offset: 0x00012B58
		public virtual void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			if (modeloType == null)
			{
				throw new ArgumentNullException("modeloType", "modeloType null reference.");
			}
			if (string.IsNullOrWhiteSpace(modeloName))
			{
				throw new ArgumentNullException("modeloName", "modeloName null reference.");
			}
			this.m_ModelSerializableType.type = modeloType;
			if (isListItem)
			{
				ModeloConIndex modeloConIndex = null;
				try
				{
					modeloConIndex = JsonUtility.FromJson<ModeloConIndex>(modeloName);
				}
				catch (Exception ex)
				{
					base.name = modeloName;
					this.m_model = modeloName;
					Debug.LogException(ex, this);
				}
				if (modeloConIndex != null)
				{
					base.name = modeloConIndex.modeloName + "->" + modeloConIndex.index.ToString();
					this.m_model = modeloConIndex.modeloName;
					this.m_modelItemIndex = modeloConIndex.index;
					return;
				}
			}
			else
			{
				base.name = modeloName;
				this.m_model = modeloName;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000541 RID: 1345 RVA: 0x00014A24 File Offset: 0x00012C24
		public bool isSecondaryBinded
		{
			get
			{
				return !string.IsNullOrWhiteSpace(this.m_secondaryModelName) && this.m_secondaryModelType.type != null;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x00014A46 File Offset: 0x00012C46
		public Type secondaryModelType
		{
			get
			{
				return this.m_secondaryModelType.type;
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000543 RID: 1347 RVA: 0x00014A53 File Offset: 0x00012C53
		public string secondaryModelName
		{
			get
			{
				return this.m_secondaryModelName;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000544 RID: 1348 RVA: 0x00014A5B File Offset: 0x00012C5B
		public int secondaryModelIndex
		{
			get
			{
				return this.m_secondaryModelIndex;
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000545 RID: 1349 RVA: 0x00014A63 File Offset: 0x00012C63
		public Func<object> secondaryModeloValueGetter
		{
			get
			{
				return this.m_secondaryModeloValueGetter;
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x00014A6B File Offset: 0x00012C6B
		public Transform panelTransform
		{
			get
			{
				return this.m_panelTransform;
			}
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x00014A73 File Offset: 0x00012C73
		public void SecondaryBind(string ModeloName, Type ModeloType, int ModeloIndex, Func<object> ModeloValueGetter)
		{
			this.m_secondaryModelType.type = ModeloType;
			this.m_secondaryModelName = ModeloName;
			this.m_secondaryModelIndex = ModeloIndex;
			this.m_secondaryModeloValueGetter = ModeloValueGetter;
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00014A97 File Offset: 0x00012C97
		public void AddedTo(Transform PanelTransform)
		{
			this.m_panelTransform = PanelTransform;
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x00014AAF File Offset: 0x00012CAF
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x00014AB7 File Offset: 0x00012CB7
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040001FD RID: 509
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_panelTransform;

		// Token: 0x040001FE RID: 510
		[ReadOnlyUI]
		[SerializeField]
		private SerializableType m_ModelSerializableType;

		// Token: 0x040001FF RID: 511
		[ReadOnlyUI]
		[SerializeField]
		private string m_model;

		// Token: 0x04000200 RID: 512
		[ReadOnlyUI]
		[SerializeField]
		private int m_modelItemIndex = -1;

		// Token: 0x04000201 RID: 513
		[Obsolete]
		[NonSerialized]
		public Graphic elmentoBase;

		// Token: 0x04000202 RID: 514
		[ReadOnlyUI]
		[SerializeField]
		private SerializableType m_secondaryModelType;

		// Token: 0x04000203 RID: 515
		[ReadOnlyUI]
		[SerializeField]
		private string m_secondaryModelName;

		// Token: 0x04000204 RID: 516
		[ReadOnlyUI]
		[SerializeField]
		private int m_secondaryModelIndex;

		// Token: 0x04000205 RID: 517
		private Func<object> m_secondaryModeloValueGetter;
	}
}
