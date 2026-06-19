using System;
using UnityEngine;

// Token: 0x0200002C RID: 44
[Serializable]
public class SerializableType
{
	// Token: 0x06000185 RID: 389 RVA: 0x0000926E File Offset: 0x0000746E
	public static string GetClassRef(Type type)
	{
		if (type != null)
		{
			return type.AssemblyQualifiedName;
		}
		return null;
	}

	// Token: 0x06000186 RID: 390 RVA: 0x00009281 File Offset: 0x00007481
	public SerializableType()
	{
	}

	// Token: 0x06000187 RID: 391 RVA: 0x00009289 File Offset: 0x00007489
	public SerializableType(string assemblyQualifiedClassName)
	{
		this.type = ((!string.IsNullOrEmpty(assemblyQualifiedClassName)) ? Type.GetType(assemblyQualifiedClassName) : null);
		if (this.type == null)
		{
			throw new ArgumentNullException("type", "type null reference.");
		}
	}

	// Token: 0x06000188 RID: 392 RVA: 0x000092C6 File Offset: 0x000074C6
	public SerializableType(Type Type)
	{
		this.type = Type;
	}

	// Token: 0x17000024 RID: 36
	// (get) Token: 0x06000189 RID: 393 RVA: 0x000092D5 File Offset: 0x000074D5
	public string assemblyQualifiedName
	{
		get
		{
			return this.m_assemblyQualifiedName;
		}
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x0600018A RID: 394 RVA: 0x000092E0 File Offset: 0x000074E0
	// (set) Token: 0x0600018B RID: 395 RVA: 0x0000933F File Offset: 0x0000753F
	public Type type
	{
		get
		{
			bool flag = string.IsNullOrEmpty(this.m_assemblyQualifiedName);
			if (flag || this.m_assemblyQualifiedName == "(None)")
			{
				this.m_type = null;
			}
			else if (this.m_type == null && !flag)
			{
				this.m_type = Type.GetType(this.m_assemblyQualifiedName);
			}
			return this.m_type;
		}
		set
		{
			this.m_type = value;
			this.m_assemblyQualifiedName = SerializableType.GetClassRef(value);
		}
	}

	// Token: 0x0600018C RID: 396 RVA: 0x00009354 File Offset: 0x00007554
	public static implicit operator Type(SerializableType typeReference)
	{
		return typeReference.type;
	}

	// Token: 0x0600018D RID: 397 RVA: 0x0000935C File Offset: 0x0000755C
	public static implicit operator SerializableType(Type type)
	{
		return new SerializableType(type);
	}

	// Token: 0x0600018E RID: 398 RVA: 0x00009364 File Offset: 0x00007564
	public override string ToString()
	{
		if (!(this.type != null))
		{
			return "(None)";
		}
		return this.type.FullName;
	}

	// Token: 0x04000065 RID: 101
	[SerializeField]
	private string m_assemblyQualifiedName;

	// Token: 0x04000066 RID: 102
	[NonSerialized]
	private Type m_type;
}
