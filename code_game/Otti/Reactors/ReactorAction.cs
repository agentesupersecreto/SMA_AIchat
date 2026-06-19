using System;
using com.ootii.Data.Serializers;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Reactors
{
	// Token: 0x0200005B RID: 91
	[Serializable]
	public abstract class ReactorAction
	{
		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x00019DB9 File Offset: 0x00017FB9
		// (set) Token: 0x06000453 RID: 1107 RVA: 0x00019DC1 File Offset: 0x00017FC1
		public virtual GameObject Owner
		{
			get
			{
				return this.mOwner;
			}
			set
			{
				this.mOwner = value;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000454 RID: 1108 RVA: 0x00019DCA File Offset: 0x00017FCA
		// (set) Token: 0x06000455 RID: 1109 RVA: 0x00019DD2 File Offset: 0x00017FD2
		public int ActivationType
		{
			get
			{
				return this._ActivationType;
			}
			set
			{
				this._ActivationType = value;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x00019DDB File Offset: 0x00017FDB
		// (set) Token: 0x06000457 RID: 1111 RVA: 0x00019DE3 File Offset: 0x00017FE3
		public string ActivationStateName
		{
			get
			{
				return this._ActivationStateName;
			}
			set
			{
				this._ActivationStateName = value;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000458 RID: 1112 RVA: 0x00019DEC File Offset: 0x00017FEC
		// (set) Token: 0x06000459 RID: 1113 RVA: 0x00019DF4 File Offset: 0x00017FF4
		public int ActivationValue
		{
			get
			{
				return this._ActivationValue;
			}
			set
			{
				this._ActivationValue = value;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x00019DFD File Offset: 0x00017FFD
		// (set) Token: 0x0600045B RID: 1115 RVA: 0x00019E05 File Offset: 0x00018005
		public bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				this._IsEnabled = value;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600045C RID: 1116 RVA: 0x00019E0E File Offset: 0x0001800E
		// (set) Token: 0x0600045D RID: 1117 RVA: 0x00019E16 File Offset: 0x00018016
		public bool IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				this._IsActive = value;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600045E RID: 1118 RVA: 0x00019E1F File Offset: 0x0001801F
		// (set) Token: 0x0600045F RID: 1119 RVA: 0x00019E27 File Offset: 0x00018027
		public float Priority
		{
			get
			{
				return this._Priority;
			}
			set
			{
				this._Priority = value;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000460 RID: 1120 RVA: 0x00019E30 File Offset: 0x00018030
		// (set) Token: 0x06000461 RID: 1121 RVA: 0x00019E38 File Offset: 0x00018038
		public virtual string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000462 RID: 1122 RVA: 0x00019E41 File Offset: 0x00018041
		// (set) Token: 0x06000463 RID: 1123 RVA: 0x00019E49 File Offset: 0x00018049
		public IMessage Message
		{
			get
			{
				return this.mMessage;
			}
			set
			{
				this.mMessage = value;
			}
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00019E52 File Offset: 0x00018052
		public ReactorAction()
		{
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00019E7E File Offset: 0x0001807E
		public ReactorAction(GameObject rOwner)
		{
			this.mOwner = rOwner;
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x00019EB1 File Offset: 0x000180B1
		public virtual void Awake()
		{
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00019EB3 File Offset: 0x000180B3
		public virtual void Clear()
		{
			this.mOwner = null;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00019EBC File Offset: 0x000180BC
		public virtual bool TestActivate(int rOldState, int rNewState)
		{
			if (this.mOwner == null)
			{
				return false;
			}
			if (rOldState == rNewState)
			{
				return false;
			}
			if (this._ActivationType == 1)
			{
				if (this._ActivationValue == 0 || rNewState == this._ActivationValue)
				{
					return true;
				}
			}
			else if (this._ActivationType == 2 && (this._ActivationValue == 0 || rOldState == this._ActivationValue))
			{
				return true;
			}
			return false;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00019F18 File Offset: 0x00018118
		public virtual bool TestActivate(IMessage rMessage)
		{
			if (rMessage == null)
			{
				return false;
			}
			if (this.mOwner == null)
			{
				return false;
			}
			if (this._ActivationType != 0)
			{
				return false;
			}
			if (this._ActivationValue > 0 && this._ActivationValue != rMessage.ID)
			{
				return false;
			}
			this.mMessage = rMessage;
			return true;
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00019F65 File Offset: 0x00018165
		public virtual bool Activate()
		{
			this._IsActive = true;
			return true;
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00019F6F File Offset: 0x0001816F
		public virtual void Deactivate()
		{
			this._IsActive = false;
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00019F78 File Offset: 0x00018178
		public virtual void Update()
		{
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00019F7A File Offset: 0x0001817A
		public virtual string Serialize()
		{
			return JSONSerializer.Serialize(this, false);
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00019F84 File Offset: 0x00018184
		public virtual void Deserialize(string rDefinition)
		{
			object obj = this;
			JSONSerializer.DeserializeInto(rDefinition, ref obj);
		}

		// Token: 0x04000236 RID: 566
		public static string[] ACTIVATION_STYLES = new string[] { "Message Received", "State Set", "State Changed" };

		// Token: 0x04000237 RID: 567
		[NonSerialized]
		protected GameObject mOwner;

		// Token: 0x04000238 RID: 568
		public int _ActivationType;

		// Token: 0x04000239 RID: 569
		public string _ActivationStateName = "";

		// Token: 0x0400023A RID: 570
		public int _ActivationValue;

		// Token: 0x0400023B RID: 571
		public bool _IsEnabled = true;

		// Token: 0x0400023C RID: 572
		public bool _IsActive = true;

		// Token: 0x0400023D RID: 573
		public float _Priority;

		// Token: 0x0400023E RID: 574
		public string _Name = "";

		// Token: 0x0400023F RID: 575
		[NonSerialized]
		protected IMessage mMessage;
	}
}
