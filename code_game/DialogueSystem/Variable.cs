using System;
using PixelCrushers.DialogueSystem.ChatMapper;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000027 RID: 39
	[Serializable]
	public class Variable : Asset
	{
		// Token: 0x060001FA RID: 506 RVA: 0x00009008 File Offset: 0x00007208
		public Variable()
		{
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00009010 File Offset: 0x00007210
		public Variable(Variable sourceVariable)
			: base(sourceVariable)
		{
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000901C File Offset: 0x0000721C
		public Variable(UserVariable chatMapperUserVariable)
		{
			this.Assign(chatMapperUserVariable);
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001FD RID: 509 RVA: 0x0000902C File Offset: 0x0000722C
		// (set) Token: 0x060001FE RID: 510 RVA: 0x0000903C File Offset: 0x0000723C
		public string InitialValue
		{
			get
			{
				return base.LookupValue("Initial Value");
			}
			set
			{
				Field.SetValue(this.fields, "Initial Value", value);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001FF RID: 511 RVA: 0x00009050 File Offset: 0x00007250
		// (set) Token: 0x06000200 RID: 512 RVA: 0x00009060 File Offset: 0x00007260
		public float InitialFloatValue
		{
			get
			{
				return base.LookupFloat("Initial Value");
			}
			set
			{
				Field.SetValue(this.fields, "Initial Value", value);
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000201 RID: 513 RVA: 0x00009074 File Offset: 0x00007274
		// (set) Token: 0x06000202 RID: 514 RVA: 0x00009084 File Offset: 0x00007284
		public bool InitialBoolValue
		{
			get
			{
				return base.LookupBool("Initial Value");
			}
			set
			{
				Field.SetValue(this.fields, "Initial Value", value);
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00009098 File Offset: 0x00007298
		// (set) Token: 0x06000204 RID: 516 RVA: 0x000090A0 File Offset: 0x000072A0
		public FieldType Type
		{
			get
			{
				return this.LookupInitialValueType();
			}
			set
			{
				this.SetInitialValueType(value);
			}
		}

		// Token: 0x06000205 RID: 517 RVA: 0x000090AC File Offset: 0x000072AC
		public void Assign(UserVariable chatMapperUserVariable)
		{
			if (chatMapperUserVariable != null)
			{
				base.Assign(0, chatMapperUserVariable.Fields);
				Field field = Field.Lookup(this.fields, "Initial Value");
				if (field != null && field.type == FieldType.Number && (string.Equals(field.value, "True") || string.Equals(field.value, "False")))
				{
					field.type = FieldType.Boolean;
				}
			}
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00009120 File Offset: 0x00007320
		private FieldType LookupInitialValueType()
		{
			Field field = Field.Lookup(this.fields, "Initial Value");
			return (field != null) ? field.type : FieldType.Text;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00009150 File Offset: 0x00007350
		private void SetInitialValueType(FieldType type)
		{
			Field field = Field.Lookup(this.fields, "Initial Value");
			if (field != null)
			{
				field.type = type;
			}
		}
	}
}
