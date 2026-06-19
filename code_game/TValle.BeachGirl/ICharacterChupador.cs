using System;

// Token: 0x02000002 RID: 2
public interface ICharacterChupador
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000001 RID: 1
	bool presionEstaAislada { get; }

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000002 RID: 2
	bool estaChupandoPene { get; }

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000003 RID: 3
	float aislamientoWeight { get; }
}
